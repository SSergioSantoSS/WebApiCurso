using WebCursos.Domain.Entities;

namespace WebCursos.Domain.Core.Interfaces.Repositories
{
    public interface IRepositoryUsuario : IRepositoryBase<Usuario>
    {
        Usuario Obter(string email, string senha);        
        Usuario Obter(string email);     
    }
}
