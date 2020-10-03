using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Altair.Infrastructure.UoW;
using Microsoft.EntityFrameworkCore;
using Onion.Core.Interfaces.Repository;
using Onion.Core.Models;
using Onion.DataAccess;

namespace Onion.Infrastructure.Repository
{
    public class Repository<T> : GenericRepository<T>, IRepository<T> where T : class
    {         

        public Repository(ApplicationContext contexto) : base(contexto)
        { 
        }
         
    }
}