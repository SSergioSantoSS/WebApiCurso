using WebCursos.Domain.Core.Interfaces.Repositories;
using WebCursos.Domain.Core.Interfaces.Services;
using WebCursos.Domain.Entities;

namespace WebCursos.Domain.Services
{
    public class ServiceAlunoTurma : ServiceBase<AlunoTurma>, IServiceAlunoTurma
    {
        private readonly IRepositoryAlunoTurma _repositoryAlunoTurma;
        private readonly IRepositoryAluno _repositoryAluno;
        private readonly IRepositoryTurma _repositoryTurma;

        public ServiceAlunoTurma(IRepositoryAlunoTurma repositoryAlunoTurma, IRepositoryAluno repositoryAluno, IRepositoryTurma repositoryTurma) : base(repositoryAlunoTurma)
        {
            _repositoryAlunoTurma = repositoryAlunoTurma;
            _repositoryAluno = repositoryAluno;
            _repositoryTurma = repositoryTurma;
        }

        public int Add(AlunoTurma alunoTurma)
        {
            var alunoFind = _repositoryAluno.GetById(alunoTurma.AlunoId);
            var turmaFind = _repositoryTurma.GetById(alunoTurma.TurmaId);
            var alunoTurmaLista = _repositoryAlunoTurma.GetAll();

            if (alunoFind == null || turmaFind == null) return 0;

            var listaTurma = alunoTurmaLista.Where(x => x.TurmaId == alunoTurma.TurmaId);
            var listaAlunoTurma = listaTurma.Where(x => x.AlunoId == alunoTurma.AlunoId).FirstOrDefault();

            if (listaAlunoTurma != null)
            {
                return 2;
            }
            if (listaTurma.Count() <= 4)
            {
                _repositoryAlunoTurma.Add(alunoTurma);
                return 1;
            }
            else
            {
                return 3;
            }

        }

        public bool Delete(int alunoId, int turmaId)
        {
            var alunoTurma = (_repositoryAlunoTurma.GetByIdAluno(alunoId)).Where(x => x.TurmaId == turmaId).FirstOrDefault();

            if (alunoTurma == null) return false;

            _repositoryAlunoTurma.Delete(alunoTurma);

            return true;
        }

        public IEnumerable<AlunoTurma> GetTurmaId(int turmaId)
        {
            return _repositoryAlunoTurma.GetByIdTrumaInclude(turmaId);
        }

        public IEnumerable<AlunoTurma> GetAlunoId(int alunoId)
        {
            return _repositoryAlunoTurma.GetByIdAlunoInclude(alunoId);
        }
    }
}
