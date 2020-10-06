using Onion.Core.Models;

namespace Onion.Core.Interfaces.Repository
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Product GetProduct();
    }
}
