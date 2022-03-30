using WebCursos.Domain.Entities;
using WebCursos.Domain.Core.Interfaces.Repositories;
using System.Data.SqlClient;

namespace WebCursos.Infrastructure.Data.Repositories
{
    public class RepositoryUsuario : RepositoryBase<Usuario>, IRepositoryUsuario
    {
        private readonly SqlContext _sqlContext;
        public RepositoryUsuario(SqlContext sqlContext) : base(sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public Usuario Obter(string email, string senha)
        {
            var usuario = _sqlContext.Usuarios.Where(u => u.Email == email && u.Senha == senha).FirstOrDefault();

            return usuario;
        }

        public Usuario Obter(string email)
        {
            var usuario = _sqlContext.Usuarios.Where(u => u.Email == email).FirstOrDefault();

            return usuario;
        }
        

    }
}


