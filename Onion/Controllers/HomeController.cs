using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Onion.Core.Interfaces.Repository;
using Onion.Models;

namespace Onion.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILoggingRepository _loggerRepository;

        public HomeController(ILoggingRepository loggerRepository)
        {
            _loggerRepository = loggerRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var exceptionHandlerPathFeature =  HttpContext.Features.Get<IExceptionHandlerPathFeature>(); 

            StringBuilder error = new StringBuilder();
            error.Append($"ErrorId: {HttpContext.TraceIdentifier}\n");
            error.Append($"Application: {this.GetType().Namespace}\n");
            error.Append($"Host: {Environment.MachineName}\n");
            error.Append($"Source: {exceptionHandlerPathFeature.Error.Source}\n");
            error.Append($"Message: {exceptionHandlerPathFeature.Error.Message}\n");
            error.Append($"StackTrace: {exceptionHandlerPathFeature.Error.StackTrace}\n");

            _loggerRepository.LogError(error.ToString());

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
