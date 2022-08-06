﻿using System.Threading.Tasks;
using Logger.EventModels;

/*
 * Wiki: https://www.notion.so/Logger-736d00518e2f4599997fdfa501310ec9
 */


namespace Logger
{
    public abstract class AltLogger
    {
        public abstract Task Log(LogLevel level, AltAbstractEvent serverAltAbstractEvent);

        public async Task LogInfo(AltAbstractEvent serverAltAbstractEvent) => await Log(LogLevel.Info, serverAltAbstractEvent);

        public async Task LogDevelopment(AltAbstractEvent serverAltAbstractEvent) => await Log(LogLevel.Development, serverAltAbstractEvent);

        public async Task LogWarning(AltAbstractEvent serverAltAbstractEvent) => await Log(LogLevel.Warning, serverAltAbstractEvent);

        public async Task LogCritical(AltAbstractEvent serverAltAbstractEvent) => await Log(LogLevel.Critical, serverAltAbstractEvent);

        public async Task LogEvent(AltAbstractEvent serverAltAbstractEvent) => await Log(LogLevel.Event, serverAltAbstractEvent);
    }
}