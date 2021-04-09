namespace AuthorizeNet.Utilities
{
    using System;
    using Microsoft.Extensions.Logging;

    public static class LogFactory
    {
        public static ILogger getLog(Type classType)
        {
            using var loggerFactory = LoggerFactory.Create(builder => builder.AddDebug());
            return loggerFactory.CreateLogger(classType.FullName);
        }
    }
}