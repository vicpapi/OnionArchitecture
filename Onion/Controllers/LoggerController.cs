using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Onion.Models;

namespace Onion.Controllers
{
    public class LoggerController : Controller
    {
        public IActionResult Index(string id)
        {
            var xml = "<log>" + System.IO.File.ReadAllText(@"C:\Users\Victor Ayala\source\repos\OnionArchitecture\OnionArchitecture\Onion\bin\Debug\netcoreapp3.1\Logs\2020-10-06.xml") + "</log>";

            ErrorViewModel model = new ErrorViewModel();
            XDocument xDoc = XDocument.Parse(xml);

            model = (from rsElement in xDoc.Descendants("LogEntry")
                     from accItem in rsElement.Descendants("Message")
                     where accItem.FirstAttribute.Value == id
                     select new ErrorViewModel
                     {
                         Message = accItem.Value
                     }).FirstOrDefault();

            return View(model);
        }
    }
}