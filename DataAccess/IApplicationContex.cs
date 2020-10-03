using Microsoft.EntityFrameworkCore;
using Onion.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.DataAccess
{
    public interface IApplicationDbContext
    {
        public DbSet<Product> Product { get; set; }
         
    }
}
