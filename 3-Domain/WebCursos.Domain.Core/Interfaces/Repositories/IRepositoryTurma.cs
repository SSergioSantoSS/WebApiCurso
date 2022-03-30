using WebCursos.Domain.Entities;

namespace WebCursos.Domain.Core.Interfaces.Repositories
{
    public interface IRepositoryTurma : IRepositoryBase<Turma>
    {
        Turma GetByNomeInclude(string nome);
        Turma GetByIdInclude(int id);
    }
}
