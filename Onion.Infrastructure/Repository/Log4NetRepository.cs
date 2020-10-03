using Altair.Infrastructure.Logger.Repository;  
using Onion.Core.Interfaces.Repository; 

namespace Onion.Infrastructure.Repository
{
    public class LogNetRepository : Log4NetRepository, ILog4NetRepository
    {
        public LogNetRepository(string path, string elementName) : base(path, elementName)
        {
        }
    }
}
