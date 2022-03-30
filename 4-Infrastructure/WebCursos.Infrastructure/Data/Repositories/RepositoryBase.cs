using Microsoft.EntityFrameworkCore;
using WebCursos.Domain.Core.Interfaces.Repositories;
using WebCursos.Domain.Entities;

namespace WebCursos.Infrastructure.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly SqlContext _sqlContext;
        private readonly DbSet<TEntity> _db;
        public RepositoryBase(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
            _db = _sqlContext.Set<TEntity>();
        }

        public void Add(TEntity obj)
        {
            try
            {
                _db.Add(obj);
                _sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Delete(TEntity obj)
        {
            try
            {
                _db.Remove(obj);
                _sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _db.ToList();
        }

        public TEntity GetById(int id)
        {
            var result = _db.Find(id);
            
            return result;
        }

        public Usuario Obter(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity obj)
        {
            try
            {
                _db.Update(obj);
                _sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
