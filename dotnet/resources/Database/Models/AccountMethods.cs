﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Database.Models.AccountEvents;
using Database.Models.Bans;
using GTANetworkAPI;
using Logger;
using Logger.EventModels;

namespace Database.Models
{
    public partial class Account
    {
        private string ip = null!, hwid = null!;

        [NotMapped]
        public TimeSpan InGameTime => Characters
            .Select(c => c.InGameTime)
            .Aggregate((t1, t2) => t1 + t2);

        [NotMapped]
        public DateTime LastConnectionTime => Connections.OrderByDescending(c => c.CreatedDate).First().CreatedDate;

        #region Characters

        public bool CanCreateCharacter() => Characters.Count > 3;

        public void AddCharacter(Character character)
        {
            PullFromContext();
            Characters.Add(character);
            PushToContext();
        }

        #endregion
        
        public static implicit operator Player (Account account) => 
            NAPI.Pools.GetAllPlayers().FirstOrDefault(p => p.SocialClubId == account.SocialClubId);
        
        public static implicit operator Account (Player player) => AltContext.GetAccount(player);

        public override string ToString() => $"{Username}_[{SocialClubId}]";

        #region Simple user data

        public static bool IsSocialClubIdTaken(ulong socialClubId)
        {
            using var context = new AltContext();
            return context.Accounts.Select(a => a.SocialClubId).Any(u => u == socialClubId);
        }

        public void UpdateUsername(string newUsername)
        {
            if (IsUsernameTaken(newUsername))
                throw new InvalidOperationException("This username already taken");
            Username = newUsername != Username ?
                newUsername : throw new InvalidOperationException("Usernames are same!");
            PushToContext();
            AltLogger.Instance.LogInfo(new AltAccountEvent(this, "UsernameUpdate", "Username changed"));
        }

        public static bool IsUsernameTaken(string username)
        {
            using var context = new AltContext();
            return context.Accounts.Select(a => a.Username).Any(u => u == username);
        }

        public void UpdateEmail(string newEmail)
        {
            if (IsEmailTaken(newEmail))
                throw new InvalidOperationException("This email already taken");
            Email = newEmail != Email ? newEmail : throw new InvalidOperationException("Emails are same!");
            PushToContext();
            AltLogger.Instance.LogInfo(new AltAccountEvent(this, "EmailUpdate", "Email changed"));
        }


        public static bool IsEmailTaken(string email)
        {
            using var context = new AltContext();
            return context.Accounts.Select(a => a.Email).Any(e => e == email);
        }

        public void UpdateHwid(string newHwid)
        {
            LastHwid = newHwid;
            PushToContext();
        }

        public bool IsSameLastHwid(string hwid) => LastHwid == hwid;

        #endregion

        #region Passwords

        public bool IsPasswordsMatch(string incomingPassword) =>
            GetPasswordHash(incomingPassword) == PasswordHash;

        public void UpdatePassword(string newPassword)
        {
            if (IsPasswordsMatch(newPassword))
                throw new InvalidOperationException("Usernames are same!");

            SetNewPasswordData(newPassword);
            PushToContext();
            AltLogger.Instance.LogInfo(new AltAccountEvent(this, "PasswordUpdate", "Password changed"));
        }

        private string GetPasswordHash(string password) =>
            GetSha256(password + PasswordSalt);

        private static string GetSha256(string data)
        {
            using var sha256Hash = SHA256.Create();
            byte[] sourceBytes = Encoding.UTF8.GetBytes(data);
            byte[] hashBytes = sha256Hash.ComputeHash(sourceBytes);
            return BitConverter.ToString(hashBytes).Replace("-", string.Empty);
        }

        private void SetNewPasswordData(string newPassword)
        {
            PasswordSalt = GetSha256(GetRandomString());
            PasswordHash = GetPasswordHash(newPassword);
        }

        private static string GetRandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string response = string.Empty;
            for (int i = 0; i < 128; i++)
                response += chars[RandomNumberGenerator.GetInt32(chars.Length)];
            return response;
        }

        #endregion

        #region Bans

        public bool IsTemporaryBanned()
        {
            var b = GetLongestBan();
            if (b != null) return b.EndDate - DateTime.Now > TimeSpan.Zero;
            return false;
        }

        public TemporaryBan GetLongestBan() => TemporaryBans
            .FirstOrDefault(b => b.EndDate == TemporaryBans.Max(ban => ban.EndDate));

        public void Ban(AbstractBan ban)
        {
            switch (ban)
            {
                case PermanentBan permanentBan:
                {
                    PermanentBan = permanentBan;
                    break;
                }
                case TemporaryBan temporaryBan:
                {
                    TemporaryBans.Add(temporaryBan);
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException(nameof(ban));
            }

            PushToContext();
        }

        #endregion

        #region On Events

        public void OnConnect(string ip, string hwid)
        {
            this.ip = ip;
            this.hwid = hwid;

            var ce = new ConnectionEvent(ConnectionEventType.Connected, ip, hwid, "Account connected.");
            ce.PushToContext();
            Connections.Add(ce);
            PushToContext();
            AltLogger.Instance.LogInfo(new AltAccountEvent(this, "Connect", $"Account connected. HWID: {hwid}, IP: {ip}"));
        }

        public void SaveDisconnect()
        {
            PullFromContext();
            Connections.Add(new ConnectionEvent(ConnectionEventType.Disconnected, ip, hwid, "Account disconnected"));
            PushToContext();
            AltLogger.Instance.LogInfo(new AltAccountEvent(this, "Disconnect", "Account disconnected."));
        }

        #endregion
    }
}