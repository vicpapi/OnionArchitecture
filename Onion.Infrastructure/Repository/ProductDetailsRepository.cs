using Onion.Core.Interfaces.Repository;
using Onion.Core.Models;
using Onion.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onion.Infrastructure.Repository
{
    public class ProductDetailsRepository : GenericEFRepository<ProductDetails>, IProductDetailsRepository
    {
        public ProductDetailsRepository(ApplicationContext context) : base(context)
        {
        }

        public ProductDetails GetProductDetail(int id)
        {
            return this.context.Set<ProductDetails>().Single(s=> s.ProductId == id);
        }
    }
}
