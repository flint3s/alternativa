﻿using AbstractResource;

/*
 * wiki: https://www.notion.so/Authorization-44a4b5377f2848c59d1772d89dde092d
 */

namespace Authorization
{
    public abstract class AuthorizationEvents : AltAbstractResourceEvents
    {
        public const string LoginSubmitFromCef = "CEF:SERVER:Authorization:LoginSubmit";

        public const string RegisterSubmitFromCef = "CEF:SERVER:Authorization:RegisterSubmit";

        public const string PlayerReadyFromClient = "CLIENT:SERVER:Authorization:PlayerReady";

        # region To Client Events

        public const string PermanentlyBanned = "SERVER:CLIENT:Authorization:PermanentBan";

        public const string TemporaryBanned = "SERVER:CLIENT:Authorization:TempBan";

        public const string FirstConnectionToClient = "SERVER:CLIENT:Authorization:FirstConnection";

        public const string NeedLoginToClient = "SERVER:CLIENT:Authorization:NeedLogin";

        public const string LoginSuccessToClient = "SERVER:CLIENT:Authorization:LoginSuccess";

        public const string RegisterSuccessToClient = "SERVER:CLIENT:Authorization:RegisterFailure";

        # endregion

        # region To CEF events

        public const string LoginFailureToCef = "SERVER:CEF:Authorization:LoginFailure";

        public const string RegisterFailureToCef = "SERVER:CEF:Authorization:RegisterFailure";

        #endregion
    }
}