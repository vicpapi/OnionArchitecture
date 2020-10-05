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

    public class GenericEFRepository<TEntidad> : IGenericRepository<TEntidad> where TEntidad : class
    {
        #region Propiedades

        protected DbContext contexto { get; set; }

        protected DbContext Contexto
        {
            get { return this.contexto; }
        }

        #endregion

        public GenericEFRepository(DbContext contexto)
        {
            this.contexto = contexto;
        }


        #region Métodos Públicos

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.contexto != null)
                {
                    this.contexto.Dispose();
                    this.contexto = null;
                }
            }
        }

        public List<TEntidad> SelectAll()
        {
            return this.entidad.ToList();
        }

        public TEntidad Single(Expression<Func<TEntidad, bool>> expresion)
        {            
            return this.entidad.SingleOrDefault(expresion);
        }

        public List<TEntidad> Select(Expression<Func<TEntidad, bool>> expresion)
        {
            return this.entidad.Where(expresion).ToList();
        }

        public void Create(TEntidad entity)
        {
            this.entidad.Add(entity);
            this.contexto.SaveChanges();
        }

        public void Create(List<TEntidad> lista)
        {
            foreach (TEntidad entidad in lista)
            {
                this.Create(entidad);
            }
            this.contexto.SaveChanges();
        }

        public void Update(TEntidad source)
        {
            ((DbContext)this.contexto).Entry(source).State = EntityState.Modified;
        }

        public void Delete(Expression<Func<TEntidad, bool>> expresion)
        {
            List<TEntidad> lista = this.Select(expresion);
            foreach (TEntidad entidad in lista)
            {
                this.entidad.Remove(entidad);
            }
            this.contexto.SaveChanges();
        }

        #endregion

        #region Métodos Privados

        private DbSet<TEntidad> entidad
        {
            get { return this.contexto.Set<TEntidad>(); }
        }

        #endregion

    }
}
