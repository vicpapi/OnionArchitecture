﻿using Altair.Infrastructure.Logger.Interfaces;
using log4net;
using log4net.Config;
using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Xml;

namespace Altair.Infrastructure.Logger.Repository
{
    public class Log4NetRepository : ILog4NetRepository
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(Log4NetRepository));

        public Log4NetRepository(string path, string elementName)
        {
            try
            {
                XmlDocument log4netConfig = new XmlDocument();

                using (var fs = File.OpenRead(path))
                {
                    log4netConfig.Load(fs);

                    var repo = LogManager.CreateRepository(
                            Assembly.GetEntryAssembly(),
                            typeof(log4net.Repository.Hierarchy.Hierarchy));

                    XmlConfigurator.Configure(repo, log4netConfig[elementName]);

                    // The first log to be written 
                    _logger.Info("Log System Initialized");
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Error", ex);
            }
        }

        public void LogInfo(string message)
        {
            _logger.Info(message);
        }

        public void LogDebug(string message)
        {
            _logger.Debug(message);
        }

        public void LogWarn(string message)
        {
            _logger.Warn(message);
        }

        public void LogError(string message)
        {
            _logger.Error(message);
        }

        public void LogFatal(string message)
        {
            _logger.Fatal(message);
        }
    }
}
