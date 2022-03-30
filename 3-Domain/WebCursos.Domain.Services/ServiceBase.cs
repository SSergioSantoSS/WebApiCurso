using System;
using System.Collections.Generic;
using System.Text;
using WebCursos.Domain.Core.Interfaces.Repositories;
using WebCursos.Domain.Core.Interfaces.Services;

namespace WebCursos.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            this.repository = repository;

        }
        public TEntity Add(TEntity obj)
        {
            repository.Add(obj);
            return obj;
        }

        public TEntity Delete(int id)
        {
            var entity = GetById(id);
            repository.Delete(entity);
            return entity;
        }

        public IEnumerable<TEntity> GetAll()
        {
           return repository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return repository.GetById(id);
        }

        public bool Update(TEntity obj)
        {
            repository.Update(obj);
            return true;
        }
    }
}
