
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Onion.Core.Interfaces.Repository;
using Onion.Core.BusinessRules;

namespace Onion.CustomAttributes
{
    public class LogAttribute : ActionFilterAttribute, IAsyncActionFilter
    {
        #region Fields 

        private ILoggingRepository _loggerRepository;
        private string _text;
        private LogEnum _logType;

        #endregion

        #region Constructor

        public LogAttribute(LogEnum logType, string text)
        {
            _logType = logType;
            _text = text;
        }

        #endregion

        #region Methods

        async Task IAsyncActionFilter.OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            _loggerRepository = context.HttpContext.RequestServices.GetService<ILoggingRepository>();

            switch (_logType)
            {
                case LogEnum.Info:
                    _loggerRepository.LogInfo(_text);
                    break;
                case LogEnum.Debug:
                    _loggerRepository.LogDebug(_text);
                    break;
                case LogEnum.Warn:
                    _loggerRepository.LogWarn(_text);
                    break;
                case LogEnum.Error:
                    break;
                case LogEnum.Fatal:
                    _loggerRepository.LogFatal(_text);
                    break;
                default:
                    break;
            }

            await next();

        }

        #endregion
    }
}
