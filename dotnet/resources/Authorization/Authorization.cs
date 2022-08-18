using System;
using System.Linq;
using System.Threading.Tasks;
using AbstractResource;
using Authorization.ChainOfResponsibility;
using Database;
using Database.Models;
using GTANetworkAPI;
using Logger;
using Logger.EventModels;
using NAPIExtensions;

/*
 * wiki: https://www.notion.so/Authorization-44a4b5377f2848c59d1772d89dde092d
 */

namespace Authorization
{
    public partial class Authorization : AltAbstractResource
    {
        private readonly AbstractHandler connectHandler;

        public Authorization()
        {
            var loginStatusSender = new LoginStatusSender();
            var temporaryBansChecker = new TemporaryBanChecker(loginStatusSender);
            var permanentBansChecker = new PermanentBanChecker(temporaryBansChecker);
            var existAccountChecker = new ExistAccountChecker(permanentBansChecker);
            var hwidBansChecker = new HwidBansChecker(existAccountChecker);
            connectHandler = hwidBansChecker;
        }
        
        // Здесь ивент от клиента (а не PlayerConnected), о том, что он готов к логину
        // (посылается после загрузки основных браузеров)
        [RemoteEvent(AuthorizationEvents.PlayerReadyFromClient)]
        private void OnPlayerConnectedAndReady(Player player) => connectHandler.Handle(player);

        #region RemoteEvents

        [RemoteEvent(AuthorizationEvents.LoginSubmitFromCef)]
        public void OnLoginSubmitFromCef(Player player, string login, string password)
        {
            using var db = new AlternativaContext();

            var account = db.Accounts.FirstOrDefault(a => a.Username == login);

            if (account != null)
                AccountFoundActions(player, account, password);
            else
                AccountNotFoundActions(player, login);
        }

        [RemoteEvent(AuthorizationEvents.RegisterSubmitFromCef)]
        public async Task OnRegisterSubmitFromCef(Player player, string login, string password, string email)
        {
            AltLogger.Instance.LogInfo(new AltAccountEvent(this, "Set Username", ""));
            await using var db = new AlternativaContext();

            var account = new Account(player.SocialClubId, login, password, email);

            db.Accounts.Add(account);
            await db.SaveChangesAsync();

            // player.SetAccount(account);
        }

        #endregion

        [Command("testacc")]
        public async Task TestAccount(Player player, string newEmail)
        {
            await using var db = new AlternativaContext();
            var account = player.GetAccount();

            if (account == null)
            {
                player.SendChatMessage("Ты не авторизован");
                return;
            }

            account.UpdateEmail(newEmail);
            db.Update(account);
            await db.SaveChangesAsync();

            NAPI.Task.Run(() => player.SendChatMessage($"Ты авторизован как {account.Username} with email {account.Email}"));
        }
    }
}