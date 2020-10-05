using Onion.Core.Interfaces.Repository;
using Onion.Core.Models;
using Onion.DataAccess;
using System.Collections.Generic;
using System.Linq;


namespace Onion.Infrastructure.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationContext context) : base(context)
        {
        }

        public Product GetProduct()
        {
            return this.context.Set<Product>().FirstOrDefault();
        }
    }
}