using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onion.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onion.DataAccess
{
    public class ProductDetailMap
    {
        public ProductDetailMap(EntityTypeBuilder<ProductDetails> entityBuilder)
        {
            entityBuilder.HasKey(p => p.ProductId);
            entityBuilder.Property(p => p.StockAvailable).IsRequired();
            entityBuilder.Property(p => p.Price);
        }
    }
}
