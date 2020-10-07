using Microsoft.AspNetCore.Mvc;
using Onion.Core.Interfaces.Services;
using Onion.Core.Models;
using Onion.Models;

namespace Onion.Controllers
{
    public class LoggerController : Controller
    {
        private readonly ILoggerService _loggerService;

        public LoggerController(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        public IActionResult Index(string id)
        { 
            Error model = new Error(); 

            model = _loggerService.GetError(id);

            return View(model);
        }
    }
}