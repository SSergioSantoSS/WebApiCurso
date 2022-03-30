using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCursos.Domain.Core.Interfaces.Repositories;
using WebCursos.Domain.Core.Interfaces.Services;
using WebCursos.Domain.Entities;

namespace WebCursos.Domain.Services
{
    public class ServiceMatricula : ServiceBase<Matricula>, IServiceMatricula
    {
        private readonly IRepositoryMatricula _repositoryMatricula;

        public ServiceMatricula(IRepositoryMatricula repositoryMatricula) : base(repositoryMatricula)
        {
            _repositoryMatricula = repositoryMatricula;
        }

        public IEnumerable<Matricula> GetAll()
        {
            return _repositoryMatricula.GetAll();

            
        }

        public Matricula GetById(int id)
        {
            return _repositoryMatricula.GetById(id);
        }

        public Matricula Add(Matricula matricula)
        {
            var matriculaFind = _repositoryMatricula.GetByMatricula(matricula.NumeroMatricula);

            if (matriculaFind != null) return null;

            _repositoryMatricula.Add(matricula);

            return matricula;

        }

        public bool Update(Matricula matricula)
        {
            var matriculaFind = _repositoryMatricula.GetById(matricula.Id);

            if (matriculaFind == null) return false;

            matriculaFind.ChangeMatricula(matricula.Ativo);

            _repositoryMatricula.Update(matriculaFind);

            return true;
        }

        public Matricula Delete(int id)
        {
            var matriculaFind = _repositoryMatricula.GetById(id);

            if (matriculaFind == null) return null;

            _repositoryMatricula.Delete(matriculaFind);

            return matriculaFind;
;
        }

       
    }
}
