﻿using System;

namespace Database.Models.Bans
{
    public class TemporaryBan : AbstractBan
    {
        protected TemporaryBan()
        {
        }
        
        public TemporaryBan(DateTime endTime, Account givenBy, BanReason reason = BanReason.Other,
            string? description = null) : base(
                givenBy,
                reason,
                description
            ) => EndTime = endTime;

        public DateTime EndTime { get; private set; }
    }
}