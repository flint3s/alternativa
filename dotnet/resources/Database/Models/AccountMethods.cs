﻿using System;
using System.Security.Cryptography;
using System.Text;
using Database.Models.AccountEvents;
using Logger;
using Logger.EventModels;

namespace Database.Models
{
    public partial class Account
    {
        private string ip = null!, hwid = null!;

        #region Predicates

        public bool IsSameHwid(string hwid) => LastHwid == hwid;

        #endregion

        #region Password logic

        public bool IsPasswordsMatch(string incomingPassword) => 
            GetPasswordHash(incomingPassword) == PasswordHash;

        public void UpdatePassword(string newPassword)
        {
            if (IsPasswordsMatch(newPassword))
                throw new InvalidOperationException("Usernames are same!");

            SetNewPasswordData(newPassword);
            UpdateDatabase();
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
            PasswordSalt = GetSha256(GetRandomString());;
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

        #region Update user data

        public void UpdateUsername(string newUsername)
        {
            Username = newUsername != Username ? newUsername : throw new InvalidOperationException("Usernames are same!");
            UpdateDatabase();
            AltLogger.Instance.LogInfo(new AltAccountEvent(this, "UsernameUpdate", "Username changed"));
        }

        public void UpdateEmail(string newEmail)
        {
            Email = newEmail != Email ? newEmail : throw new InvalidOperationException("Usernames are same!");
            UpdateDatabase();
            AltLogger.Instance.LogInfo(new AltAccountEvent(this, "EmailUpdate", "Email changed"));
        }

        public void UpdateHwid(string newHwid)
        {
            LastHwid = newHwid;
            UpdateDatabase();
        }

        #endregion

        #region On Events

        public void OnConnect(string ip, string hwid)
        {
            this.ip = ip;
            this.hwid = hwid;
            Connections.Add(new ConnectionEvent(ConnectionEventType.Connected, ip, hwid, $"Account connected."));
            UpdateDatabase();
            AltLogger.Instance.LogInfo(new AltAccountEvent(this, "Connect", $"Account connected. HWID: {hwid}, IP: {ip}"));
        }

        public void OnCharacterPeek(Character peekedCharacter)
        {
            ActiveCharacter = peekedCharacter;
            UpdateDatabase();
        }

        public void OnDisconnect()
        {
            ActiveCharacter = null;
            UpdateDatabase();
            Connections.Add(new ConnectionEvent(ConnectionEventType.Disconnected, ip, hwid, $"Account disconnected"));
            AltLogger.Instance.LogInfo(new AltAccountEvent(this, "Disconnect", $"Account disconnected."));
        }

        #endregion

        public override string ToString() => $"{Username}_[{SocialClubId}]";
    }
}