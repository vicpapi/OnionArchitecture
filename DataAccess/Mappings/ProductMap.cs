using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onion.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onion.DataAccess.Mappings
{
    public class ProductMap
    {
        public ProductMap(EntityTypeBuilder<Product> entityBuilder)
        {

            entityBuilder.HasKey(p => p.ProductId);
        }

    }
}
