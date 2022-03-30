using WebCursos.Domain.Entities;

namespace WebCursos.Domain.Core.Interfaces.Services
{
    public interface IServiceAlunoTurma : IServiceBase<AlunoTurma>
    {
        int Add(AlunoTurma alunoTurma);
        bool Delete(int alunoId, int turmaId);
        IEnumerable<AlunoTurma> GetTurmaId(int turmaId);
        IEnumerable<AlunoTurma> GetAlunoId(int alunoId);
    }
}
