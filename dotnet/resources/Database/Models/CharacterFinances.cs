﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Database.Models.Economics.Banks;
using Database.Models.Economics.CryptoWallets;
using GTANetworkAPI;

namespace Database.Models
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public class CharacterFinances
    {
        private long _cash;
        public Guid Id { get; protected set; }
        
        public Character Owner { get; protected set; }
        
        public Guid OwnerId { get; protected set; }

        public long Cash
        {
            get => _cash;
            set
            {
                _cash = value;
                ((Player)Owner).SetOwnSharedData(CharacterConstants.CharacterMoneyCash, value);
            }
        }

        public List<BankAccount> BankAccounts { get; } = new List<BankAccount>();

        public BankAccount MainBankAccount { get; protected set; }

        public List<CryptoWallet> CryptoWallets { get; } = new List<CryptoWallet>();
    }
}