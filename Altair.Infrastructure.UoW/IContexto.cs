using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;

namespace Altair.Infrastructure.UoW
{
    public interface IContexto : IDisposable
    {
        #region Métodos

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        int SaveChanges();

        #endregion
    }
}
