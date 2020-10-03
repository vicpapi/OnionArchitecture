using Onion.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onion.Core.Interfaces.Repository
{
    public interface IProductDetailsRepository
    {
        ProductDetails GetProductDetail(int id);
        decimal GetTaxes(int id);

    }
}
