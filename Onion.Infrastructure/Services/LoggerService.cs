using Onion.Core.Interfaces.Services;
using Onion.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Onion.Infrastructure.Services
{
    public  class LoggerService : ILoggerService
    {
        public Error GetError(string id)
        {
            //2020-10-06

            var xml = "<log>" + System.IO.File.ReadAllText(@$"C:\Users\Victor Ayala\source\repos\OnionArchitecture\OnionArchitecture\Onion\bin\Debug\netcoreapp3.1\Logs\{DateTime.Now.ToString("yyyy-MM-dd")}.xml") + "</log>";

            Error model = new Error();
            XDocument xDoc = XDocument.Parse(xml);

            model = (from rsElement in xDoc.Descendants("LogEntry")
                     from accItem in rsElement.Descendants("Message")
                     where accItem.FirstAttribute.Value == id
                     select new Error
                     {
                         Message = accItem.Value
                     }).FirstOrDefault();

            return model;
        }
    }
}
