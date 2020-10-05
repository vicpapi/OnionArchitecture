using Onion.Core.Interfaces.BusinessRules;
using Onion.Core.Interfaces.Repository;
using Onion.Core.Models;

namespace Onion.Core.BusinessRules
{
    public class SalesTaxCalculator : ISalesTaxCalculator
    {
        public decimal GetTaxes(int id, decimal salesTaxPercentage, IGenericRepository<ProductDetails> productDetailRepository)
        {
            decimal taxCalculate = 0;

            var productDetails = productDetailRepository.Single(s=> s.ProductId == id);

            if (productDetails != null)
            {
                taxCalculate = productDetails.Price * salesTaxPercentage;
            }

            return taxCalculate;
        }

        public decimal GetTaxes(int id, IGenericRepository<ProductDetails> productDetailRepository)
        {
            decimal tax = 0.06m;
            decimal taxCalculate = 0;

            var productDetail = productDetailRepository.Single(s => s.ProductId == id);

            if (productDetail != null)
            {
                taxCalculate = (tax * productDetail.Price) + productDetail.Price;
            }

            return taxCalculate;

        }
    }
}
