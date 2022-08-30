﻿using System;
using GTANetworkAPI;

namespace Database.Models
{
    public partial class Character : AbstractModel
    {
        protected Character()
        {
        }

        public Character(Account account, string firstname, string lastname, DateTime birthday)
        {
            Account = account;
            FirstName = firstname;
            LastName = lastname;
            Birthday = birthday;
            InGameTime = TimeSpan.Zero;
        }

        #region Main Data

        public Guid Id { get; private set; }

        public virtual Account Account { get; private set; }
        
        public TimeSpan InGameTime { get; private set; } = TimeSpan.Zero;
        
        #endregion

        public Vector3 LastPosition { get; private set; }
        
        public TimeSpan TimeToReborn { get; private set; } = TimeSpan.Zero;
        
        #region Biography

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public DateTime Birthday { get; private set; }
        
        #endregion

        #region Finances
        
        public long Cash { get; set; }

        #endregion
    }
}