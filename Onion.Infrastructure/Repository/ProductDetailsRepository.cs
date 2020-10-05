using Onion.Core.Interfaces.Repository;
using Onion.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onion.Infrastructure.Repository
{
    public class ProductDetailsRepository : IProductDetailsRepository
    {
        private IRepository<ProductDetails> productDetailsRepository;

        public ProductDetailsRepository(IRepository<ProductDetails> productDetailsRepository)
        {
            this.productDetailsRepository = productDetailsRepository;
        }

        public ProductDetails GetProductDetail(int id)
        {
            return productDetailsRepository.Single(s=> s.ProductId == id);
        }
    }
}
