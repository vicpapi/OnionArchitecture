using Onion.Core.Interfaces;
using Onion.Core.Interfaces.Repository;
using Onion.Infrastructure.ApplicationLog;
using Onion.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace Onion.Tests.Onion.Infrastructure.ApplicationLog
{
    public class Log4NetTest
    {
        private ILoggingRepository _loggerRepository = null;
        private string _logFilePath = string.Empty;        

        public Log4NetTest()
        {
            _loggerRepository = new Log4NetRepository("log4net.config", "log4net");
            _logFilePath = GenerateLogFilePath();
        }

        [Fact]
        public void SaveInfo()
        {
            //Arrange
            string message = "Test logger1";                 

            //Act
            _loggerRepository.LogInfo(message);
           
            var logText = File.ReadAllText(_logFilePath);

            //Assert
            Assert.True(logText.Contains(message) == true);
        }


        private string GenerateLogFilePath(string currentDirectory = "", DateTime? logDate = null)
        {
            var returnValue = new StringBuilder();

            if(String.IsNullOrEmpty(currentDirectory))
            {
                currentDirectory = Directory.GetCurrentDirectory();
            }
            
            if(logDate == null)
            {
                logDate = DateTime.Now;
            }
            
            returnValue.Append(String.Format(@"{0}\Logs\{1}.txt", currentDirectory, logDate.Value.ToString("yyyy-MM-dd")));

            return returnValue.ToString();
        }

    }
}
