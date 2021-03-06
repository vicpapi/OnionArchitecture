﻿using Onion.Core.Interfaces.Repository;
using Onion.Infrastructure.ApplicationLog;
using Onion.Infrastructure.ApplicationLog.Helper;
using System;
using System.Text;

namespace Onion.Helpers
{
    public static class Logger
    {
        static ILoggingRepository _logger = new Log4NetRepository(ConfigurationManager.LOG4NET_PATH, ConfigurationManager.LOG4NET_ELEMENTNAME);

        public static void SaveErrorLog(Exception exception)
        {
            StringBuilder error = new StringBuilder(); 
            error.Append($"Host: {Environment.MachineName}\n");
            error.Append($"Source: {exception.Source}\n"); 
            error.Append($"Message: {exception.Message}\n");
            error.Append($"StackTrace: {exception.StackTrace}\n");

            _logger.LogError(error.ToString());
        }

    }
}
