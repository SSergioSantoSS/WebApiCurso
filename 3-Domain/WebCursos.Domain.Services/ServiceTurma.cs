using System;
using System.Collections.Generic;
using System.Text;
using WebCursos.Domain.Core.Interfaces.Repositories;
using WebCursos.Domain.Core.Interfaces.Services;
using WebCursos.Domain.Entities;

namespace WebCursos.Domain.Services
{
    public class ServiceTurma : ServiceBase<Turma>, IServiceTurma
    {
        private readonly IRepositoryTurma _repositoryTurma;
        private readonly IRepositoryAlunoTurma _repositoryAlunoTurma;

        public ServiceTurma(IRepositoryTurma repositoryTurma, IRepositoryAlunoTurma repositoryAlunoTurma) : base(repositoryTurma)
        {
            _repositoryTurma = repositoryTurma;
            _repositoryAlunoTurma = repositoryAlunoTurma;
        }

        public Turma GetById(int id)
        {
            return _repositoryTurma.GetById(id);
        }

        public IEnumerable<Turma> GetAll()
        {
            return _repositoryTurma.GetAll();
        }

        public Turma Add(Turma turma)
        {
            var turmaFind = _repositoryTurma.GetByNomeInclude(turma.Nome);

            if (turmaFind != null) return null;

            _repositoryTurma.Add(turma);

            return turma;
        }

        public bool Update(Turma turma)
        {
            var turmaFind = _repositoryTurma.GetById(turma.Id);

            if (turmaFind == null) return false;

            turmaFind.ChangeTurma(turma.AnoLetivo, turma.IsAtivo);

            _repositoryTurma.Update(turmaFind);

            return true;
        }

        public Turma Delete(int id)
        {
            var turmaFind = _repositoryTurma.GetByIdInclude(id);
            var alunoTurma = _repositoryAlunoTurma.GetByIdTruma(id).FirstOrDefault();

            if (turmaFind == null) return null;

            if (alunoTurma != null)
            {
                return new Turma();
            }

            _repositoryTurma.Delete(turmaFind);

            return turmaFind;
        }

    }
}
