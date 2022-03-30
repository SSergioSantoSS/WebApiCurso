using WebCursos.Domain.Entities;

namespace WebCursos.Domain.Core.Interfaces.Services
{
    public interface IServiceAluno : IServiceBase<Aluno>
    {       
        public Aluno GetByMatricula(string matricula);
    }
}
