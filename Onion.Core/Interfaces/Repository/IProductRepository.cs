using Onion.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onion.Core.Interfaces.Repository
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Product GetProduct();        
    }
}
