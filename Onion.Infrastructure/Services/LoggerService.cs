using Onion.Core.Interfaces.Services;
using Onion.Core.Models;
using System;
using System.Linq;
using System.Xml.Linq;

namespace Onion.Infrastructure.Services
{
    public  class LoggerService : ILoggerService
    {
        public LogInfo GetInfoById(string fileName, string id)
        {
            var path = new Uri(System.Reflection.Assembly
                                .GetExecutingAssembly()
                                .GetName()
                                .CodeBase)
                        .LocalPath;

            path = System.IO.Path.GetDirectoryName(path);

            var relativePath = System.IO.File.ReadAllText(
                                System.IO.Path.Combine(Environment.CurrentDirectory,
                                    path + "/Logs/" + fileName));

            var xml = "<log>" + relativePath + "</log>";

            var xDoc = XDocument.Parse(xml);

            var model = (from rsElement in xDoc.Descendants("LogEntry")
                            from accItem in rsElement.Descendants("Message")
                            where accItem.FirstAttribute.Value == id.ToString()
                        select new LogInfo
                        {
                            Message = accItem.Value
                        }).FirstOrDefault();

            return model;
        }
    }
}
