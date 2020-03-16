namespace AuthorizeNet.Utilities
{
    using System;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Configures 
    /// </summary>
    public static class LogFactory
    {
        private static ILoggerFactory _factory => new LoggerFactory();

        /// <summary>
        /// The logger factory instance used to create logger instances for the XML serializer,
        /// API operations, and HTTP utilities. Use this property to add providers to such as
        /// the debugger factory:
        /// 
        /// <code>
        /// LogFactory.Factory.AddDebug(LogLevel.Debug);
        /// </code>
        /// </summary>
        public static ILoggerFactory Factory => _factory;

        /// <summary>
        /// Get a logger instance for the given class type.
        /// </summary>
        /// <param name="classType"></param>
        /// <returns></returns>
        public static ILogger getLog(Type classType)
        {
            return _factory.CreateLogger(classType.FullName);
        }
    }
}