using WebCursos.Domain.Entities;

namespace WebCursos.Domain.Core.Interfaces.Services
{
    public interface IServiceAuth 
    {
        string Validate(string email, string senha);
    }
}
