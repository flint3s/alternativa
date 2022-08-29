﻿using AbstractResource;
using AbstractResource.Connects;
using GTANetworkAPI;
using NAPIExtensions;

namespace Authorization.ChainsOfResponsibility.RegistrationHandlers
{
    internal class ExistAccountChecker : AbstractHandler
    {
        public ExistAccountChecker(CefConnect cefConnect, AbstractHandler? next) : base(cefConnect, next)
        {
        }

        protected override bool CanHandle(Player player, string login, string password, string email) => 
            player.HasAccountInDb();

        protected override void _Handle(Player player, string login, string password, string email)
        {
            CefConnect.Trigger(
                    player,
                    AuthorizationEvents.RegisterFailureToCef,
                    "User with this Social Club ID already exist"
                );
        }
    }
}