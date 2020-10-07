using System;
using Microsoft.AspNetCore.Mvc;
using Onion.Core.Interfaces.Services;

namespace Onion.Controllers
{
    public class LoggerController : Controller
    {
        private readonly ILoggerService _loggerService;

        public LoggerController(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        public IActionResult Index(string fileName, string id)
        { 
            var model = _loggerService.GetInfoById(fileName, id);

            return View(model);
        }
    }
}