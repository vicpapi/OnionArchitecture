using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onion.Core.Models
{
    public class ProductDetails : BaseEntity
    {
        public int StockAvailable { get; set; }
        public decimal Price { get; set; }
    }
}
