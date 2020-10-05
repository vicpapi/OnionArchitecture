using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Onion.Core.Interfaces.Repository
{
    public interface IGenericRepository<TEntidad>
    {
        List<TEntidad> SelectAll();

        TEntidad Single(Expression<Func<TEntidad, bool>> expresion);

        List<TEntidad> Select(Expression<Func<TEntidad, bool>> expresion);

        void Create(TEntidad entidad);

        void Create(List<TEntidad> lista);

        void Update(TEntidad source);

        void Delete(Expression<Func<TEntidad, bool>> expresion);
    }
}
