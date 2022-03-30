using System;
using System.Collections.Generic;
using System.Text;
using WebCursos.Domain.Entities;

namespace WebCursos.Domain.Core.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity>  where TEntity : class
    {
        void Add(TEntity Obj);
        void Update(TEntity Obj);
        void Delete(TEntity Obj);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
    }
}
