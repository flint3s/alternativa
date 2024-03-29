﻿using AbstractResource.Connects;
using Database.Models;
using GTANetworkAPI;
using NAPIExtensions;

namespace Authorization.ChainsOfResponsibility.RegistrationHandlers
{
    internal class SuccessRegistrationHandler : AbstractRegistrationHandler
    {
        public SuccessRegistrationHandler(ClientConnect clientConnect, CefConnect cefConnect) : base(
                clientConnect,
                cefConnect,
                null
            )
        {
        }

        protected override string EventName => "RegistrationSuccess";

        protected override string EventDescription => "Register success";

        protected override bool CanHandle(Player player, string login, string password, string email) => true;

        protected override void _Handle(Player player, string login, string password, string email)
        {
            var account = new Account(player.SocialClubId, login, password, email);
            account.PushToContext();
            account.UpdateHwid(player.Serial);
            player.SetAccessLevels(account.VipLevel, account.AdminLevel);
            Log(player);
            ClientConnect.TriggerEvent(player, RegistrationEvents.RegisterSuccess, "Success!");
        }
    }
}