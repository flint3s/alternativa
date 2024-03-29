﻿using AbstractResource.Connects;
using GTANetworkAPI;
using NAPIExtensions;

namespace Authorization.ChainsOfResponsibility.PlayerConnectedHandlers
{
    internal class HwidBansChecker : AbstractConnectionHandler
    {
        public HwidBansChecker(ClientConnect clientConnect, AbstractConnectionHandler? next = null) : base(
                clientConnect,
                next
            )
        {
        }

        protected override string EventDescription => "Connect failure cause player's HWID banned";

        protected override bool CanHandle(Player player) => player.GetBanByHwid() != null;

        protected override void _Handle(Player player)
        {
            var hwidBan = player.GetBanByHwid()!;
            Log(player);
            ClientConnect.TriggerEvent(player, PlayerConnectedEvents.PermanentlyBanned, hwidBan.Reason, hwidBan.Description);
        }
    }
}