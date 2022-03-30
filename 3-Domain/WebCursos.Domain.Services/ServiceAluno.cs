using WebCursos.Domain.Core.Interfaces.Repositories;
using WebCursos.Domain.Core.Interfaces.Services;
using WebCursos.Domain.Entities;

namespace WebCursos.Domain.Services
{
    public class ServiceAluno : ServiceBase<Aluno>, IServiceAluno
    {
        private readonly IRepositoryAluno _repositoryAluno;
        private readonly IRepositoryAlunoTurma _repositoryAlunoTurma;

        public ServiceAluno(IRepositoryAluno repositoryAluno, IRepositoryAlunoTurma repositoryMatricula) : base(repositoryAluno)
        {
            _repositoryAluno = repositoryAluno;
            _repositoryAlunoTurma = repositoryMatricula;
        }

        public Aluno GetByMatricula(string matricula)
        {
            return _repositoryAluno.GetByMatricula(matricula);
        }

        public Aluno GetById(int id)
        {
            return _repositoryAluno.GetByIdInclude(id);
        }

        public IEnumerable<Aluno> GetAll()
        {
            return _repositoryAluno.GetAllInclude();
        }

        public Aluno Add(Aluno aluno)
        {
            var alunoFind = _repositoryAluno.GetByCpf(aluno.Cpf);

            if (alunoFind != null) return null;

            var alunoList = _repositoryAluno.GetAll();

            var matriculFind = alunoList.FirstOrDefault(x => x.Id == aluno.MatriculaId);

            if (matriculFind != null)
            {
                return new Aluno();
            }            

            _repositoryAluno.Add(aluno);

            return aluno;
        }

        public bool Update(Aluno aluno)
        {
            var alunoFind = _repositoryAluno.GetById(aluno.Id);

            if (alunoFind == null) return false;

            alunoFind.ChangeAluno(aluno.Nome, aluno.Email, aluno.Telefone);

            _repositoryAluno.Update(alunoFind);

            return true;
        }

        public Aluno Delete(int id)
        {
            var alunoFind = _repositoryAluno.GetById(id);
            var alunoTurma = _repositoryAlunoTurma.GetByIdAluno(id).FirstOrDefault();

            if (alunoFind == null) return null;

            if (alunoTurma != null)
            {
                return new Aluno();
            }

            _repositoryAluno.Delete(alunoFind);

            return alunoFind;
        }

    }
}
