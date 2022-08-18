﻿using Database.Models;
using GTANetworkAPI;
using Logger;
using Logger.EventModels;
using NAPIExtensions;

namespace Authorization
{
    public partial class Authorization
    {
        private void AccountFoundActions(Player player, Account account, string password)
        {
            if (account.IsPasswordsMatch(password))
            {
                player.TriggerEvent(AuthorizationEvents.LoginSuccessToClient);
                account.UpdateHwid(player.Serial);
                player.SetAccount(account);
            }
            else
            {
                CefConnect.TriggerCef(player, AuthorizationEvents.LoginFailureToCef,
                    $"Неверный пароль для пользователя {account.Username}");
            }
        }

        private void AccountNotFoundActions(Player player, string login)
        {
            AltLogger.Instance.LogDevelopment(new AltEvent(this, "OnLoginSubmitFromCef",
                $"Account not found: {login}"));
            CefConnect.TriggerCef(player, AuthorizationEvents.LoginFailureToCef, $"Пользователь {login} не найден");
        }
    }
}