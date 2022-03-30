using System;
using System.Collections.Generic;
using System.Text;

namespace WebCursos.Domain.Core.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity :class
    {
        TEntity Add(TEntity obj);
        bool Update(TEntity obj);
        TEntity Delete(int id);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
    }
}
 