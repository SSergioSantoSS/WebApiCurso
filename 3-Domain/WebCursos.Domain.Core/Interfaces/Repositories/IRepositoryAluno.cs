using WebCursos.Domain.Entities;

namespace WebCursos.Domain.Core.Interfaces.Repositories
{
    public interface IRepositoryAluno : IRepositoryBase<Aluno>
    {
        Aluno GetByMatricula(string matricula);
        Aluno GetByCpf(string cpf);

        Aluno GetByIdInclude(int? id);
        IEnumerable<Aluno> GetAllInclude();
    }
}
