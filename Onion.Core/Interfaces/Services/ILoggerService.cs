using Onion.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.Core.Interfaces.Services
{
    public interface ILoggerService
    {
        Error GetError(string id);
    }
}
