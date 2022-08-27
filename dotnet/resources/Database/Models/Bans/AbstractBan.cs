﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Models.Bans
{
    public abstract partial class AbstractBan : AbstractModel
    {
        // EF Core .ctor
        protected AbstractBan()
        {
        }

        protected AbstractBan(Account givenBy, Account givenTo, BanReason reason, string? description)
        {
            GivenBy = givenBy;
            GivenTo = givenTo;
            Reason = reason;
            Description = description;
        }

        public Guid Id { get; private set; }

        public BanReason Reason { get; private set;}

        public string? Description { get; private set; }

        public virtual Account GivenTo { get; private set; }

        public virtual Account GivenBy { get; private set; }

        [NotMapped] public DateTime StartDate => CreatedDate;
    }
}