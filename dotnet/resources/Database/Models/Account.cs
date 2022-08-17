﻿using System.Collections.Generic;
using Database.Models.AccountEvents;

namespace Database.Models
{
    public partial class Account : AbstractModel
    {
        private Account()
        {
        }

        public Account(ulong socialClubId, string username, string password, string email)
        {
            SocialClubId = socialClubId;
            Username = username;
            Email = email;
            SetNewPasswordData(password);
            ActiveCharacter = null;
        }

        public ulong SocialClubId { get; private set; }

        public string Username { get; private set; }

        public string PasswordHash { get; private set; } = null!;

        public string PasswordSalt { get; private set; } = null!;

        public string Email { get; private set; }

        public string LastHwid { get; private set; } = null!;

        public Character? ActiveCharacter { get; private set; }

        public List<Character> Characters { get; } = new List<Character>();

        public List<ConnectionEvent> Connections { get; } = new List<ConnectionEvent>();
    }
}