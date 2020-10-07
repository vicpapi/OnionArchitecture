using System;
using Onion.Core.Models;

namespace Onion.Core.Interfaces.Services
{
    public interface ILoggerService
    {
        LogInfo GetInfoById(string fileName, string id);
    }
}
