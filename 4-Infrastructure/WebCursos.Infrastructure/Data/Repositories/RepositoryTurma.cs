using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebCursos.Domain.Core.Interfaces.Repositories;
using WebCursos.Domain.Entities;

namespace WebCursos.Infrastructure.Data.Repositories
{
    
    public class RepositoryTurma : RepositoryBase<Turma>, IRepositoryTurma
    {
        private readonly SqlContext _sqlContext;
        public RepositoryTurma(SqlContext sqlContext) :
            base(sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public Turma GetByNomeInclude(string nome)
        {
            return _sqlContext.Turmas.Where(x => x.Nome == nome).FirstOrDefault();
        }

        public Turma GetByIdInclude(int id)
        {
            return _sqlContext.Turmas.Where(x => x.Id == id).FirstOrDefault();
        }

    }
}
