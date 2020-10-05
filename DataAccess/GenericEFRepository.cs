using Microsoft.EntityFrameworkCore;
using Onion.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Onion.DataAccess
{

    public class GenericEFRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        #region Properties

        protected DbContext context { get; set; }

        protected DbContext Context
        {
            get { return this.context; }
        }

        #endregion

        public GenericEFRepository(DbContext context)
        {
            this.context = context;
        }


        #region  Public Methods

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.context != null)
                {
                    this.context.Dispose();
                    this.context = null;
                }
            }
        }

        public List<TEntity> SelectAll()
        {
            return this.entity.ToList();
        }

        public TEntity Single(Expression<Func<TEntity, bool>> expression)
        {            
            return this.entity.SingleOrDefault(expression);
        }

        public List<TEntity> Select(Expression<Func<TEntity, bool>> expression)
        {
            return this.entity.Where(expression).ToList();
        }

        public void Create(TEntity entity)
        {
            this.entity.Add(entity);
            this.context.SaveChanges();
        }

        public void Create(List<TEntity> list)
        {
            foreach (TEntity entity in list)
            {
                this.Create(entity);
            }
            this.context.SaveChanges();
        }

        public void Update(TEntity source)
        {
            ((DbContext)this.context).Entry(source).State = EntityState.Modified;
        }

        public void Delete(Expression<Func<TEntity, bool>> expression)
        {
            List<TEntity> list = this.Select(expression);
            foreach (TEntity entity in list)
            {
                this.entity.Remove(entity);
            }
            this.context.SaveChanges();
        }

        #endregion

        #region  Private Methods

        private DbSet<TEntity> entity
        {
            get { return this.context.Set<TEntity>(); }
        }

        #endregion

    }
}
