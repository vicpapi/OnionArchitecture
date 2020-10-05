using Onion.Core.Interfaces.Repository;
using Onion.DataAccess;

namespace Onion.Infrastructure.Repository
{
    public class Repository<T> : GenericEFRepository<T>, IRepository<T> where T : class
    {         
        public Repository(ApplicationContext context) : base(context)
        { 
        }         
    }
}