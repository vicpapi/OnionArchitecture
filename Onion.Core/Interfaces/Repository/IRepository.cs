using System;
using System.Collections.Generic;
using Onion.Core.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Onion.Core.Interfaces.Repository
{
    public interface IRepository<TEntidad>
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
