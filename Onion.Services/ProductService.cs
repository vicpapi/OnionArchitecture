using System.Collections.Generic;
using Onion.Core.Interfaces.Repository;
using Onion.Core.Interfaces.Services;
using Onion.Core.Models;

namespace Onion.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<ProductDetails> GetProductsDetails()
        {
            var products = _productRepository.SelectAll();

            var productDetails = new List<ProductDetails>();

            foreach (var product in products)
            {
                productDetails.Add(product.ProductDetails);
            }

            return productDetails;
        }
    }
}
