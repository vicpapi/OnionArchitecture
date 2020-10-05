using Onion.Core.Interfaces.Repository;
using Onion.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.Core.Interfaces.BusinessRules
{
    public interface ISalesTaxCalculator
    {
        decimal GetTaxes(int id, decimal salesTaxPercentage, IGenericRepository<ProductDetails> productDetailRepository);
    }
}
