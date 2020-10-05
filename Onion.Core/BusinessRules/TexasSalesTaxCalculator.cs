using Onion.Core.Interfaces.BusinessRules;
using Onion.Core.Interfaces.Repository;
using Onion.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.Core.BusinessRules
{
    public class TexasSalesTaxCalculator : ISalesTaxCalculator
    {       
        public decimal GetTaxes(int id, decimal salesTaxPercentage, IGenericRepository<ProductDetails> productDetailRepository)
        {
            decimal taxCalculate = 0;

            var productDetails = productDetailRepository.Single(s => s.ProductId == id);

            if (productDetails != null)
            {
                taxCalculate = productDetails.Price * salesTaxPercentage;
            }

            return taxCalculate;
        }
    }
}
