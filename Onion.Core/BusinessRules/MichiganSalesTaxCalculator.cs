﻿using Onion.Core.Interfaces.Repository;
using Onion.Core.Models;

namespace Onion.Core.BusinessRules
{
    public class MichiganSalesTaxCalculator //: ISalesTaxCalculator
    {
        private const decimal _salesTaxPercentage = .065M;

        public decimal GetTaxes(int id, IGenericRepository<ProductDetails> productDetailRepository)
        {            
            decimal taxCalculate = 0;

            var productDetails = productDetailRepository.Single(s=> s.ProductId == id);

            if (productDetails != null)
            {
                taxCalculate = productDetails.Price * _salesTaxPercentage;
            }

            return taxCalculate;
        }
    }
}
