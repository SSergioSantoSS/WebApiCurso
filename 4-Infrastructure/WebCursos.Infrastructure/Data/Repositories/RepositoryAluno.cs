using System;
using System.Collections.Generic;
using System.Text;
using WebCursos.Domain.Entities;
using WebCursos.Domain.Core.Interfaces.Repositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebCursos.Infrastructure.Data.Repositories
{
    public class RepositoryAluno : RepositoryBase<Aluno>, IRepositoryAluno
    {
        private readonly SqlContext sqlContext;
        public RepositoryAluno(SqlContext sqlContext ) :         
            base(sqlContext)
        {
            this.sqlContext = sqlContext;
        }

        public Aluno GetByMatricula(string matricula)
        {
            return sqlContext.Alunos.Where(a => a.Matricula.NumeroMatricula == matricula).Include(x => x.Matricula).FirstOrDefault(); 
        }

        public Aluno GetByCpf(string cpf)
        {
            return sqlContext.Alunos.Where(a => a.Cpf == cpf).Include(x => x.Matricula).FirstOrDefault();
        }

        public Aluno GetByIdInclude(int? id)
        {
            return sqlContext.Alunos.Where(x => x.Id == id).Include(x => x.Matricula).FirstOrDefault();
        }

        public IEnumerable<Aluno> GetAllInclude()
        {
            return sqlContext.Alunos.Include(x => x.Matricula);
        }
    }
}
