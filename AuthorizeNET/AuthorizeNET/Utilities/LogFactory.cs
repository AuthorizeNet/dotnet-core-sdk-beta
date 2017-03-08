namespace AuthorizeNET.Utilities
{
    using System;
    using Microsoft.Extensions.Logging;

    public static class LogFactory
    {
        private static ILoggerFactory LoggerFactory => new LoggerFactory().AddDebug(LogLevel.Debug);

        public static ILogger getLog(Type classType)
        {
            return LoggerFactory.CreateLogger(classType.FullName);
        }
    }
}