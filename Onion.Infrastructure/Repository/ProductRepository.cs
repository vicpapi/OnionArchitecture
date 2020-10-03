using Altair.Infrastructure.UoW;
using Onion.Core.Interfaces.Repository;
using Onion.Core.Models;
using Onion.DataAccess;
using Onion.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onion.Infrastructure.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public Product GetProduct()
        {
            return this.contexto.Set<Product>().FirstOrDefault();

        }
    }
}