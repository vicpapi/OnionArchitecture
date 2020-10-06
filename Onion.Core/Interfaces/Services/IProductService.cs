using System.Collections.Generic;
using Onion.Core.Models;

namespace Onion.Core.Interfaces.Services
{
    public interface IProductService
    {
        IEnumerable<ProductDetails> GetProductsDetails();
    }
}
