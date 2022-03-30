using WebCursos.Domain.Entities;

namespace WebCursos.Domain.Core.Interfaces.Repositories
{
    public interface IRepositoryAlunoTurma : IRepositoryBase<AlunoTurma>
    {
        IEnumerable<AlunoTurma> GetByIdAlunoInclude(int alunoId);
        IEnumerable<AlunoTurma> GetByIdTrumaInclude(int turmaId);
        IEnumerable<AlunoTurma> GetByIdAluno(int alunoId);
        IEnumerable<AlunoTurma> GetByIdTruma(int turmaId);

    }
}
