using System;
using System.Collections.Generic;
using System.Text;
using WebCursos.Domain.Entities;
using WebCursos.Domain.Core.Interfaces.Repositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebCursos.Infrastructure.Data.Repositories
{
    public class RepositoryAlunoTurma : RepositoryBase<AlunoTurma>, IRepositoryAlunoTurma
    {
        private readonly SqlContext _sqlContext;
        public RepositoryAlunoTurma(SqlContext sqlContext ) :         
            base(sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public IEnumerable<AlunoTurma> GetByIdAlunoInclude(int alunoId)
        {
            return _sqlContext.AlunoTurmas.Where(x => x.AlunoId == alunoId).Include(x => x.Turmas);
        }

        public IEnumerable<AlunoTurma> GetByIdTrumaInclude(int turmaId)
        {
            return _sqlContext.AlunoTurmas.Where(x => x.TurmaId == turmaId).Include(x => x.Alunos);
        }

        public IEnumerable<AlunoTurma> GetByIdAluno(int alunoId)
        {
            return _sqlContext.AlunoTurmas.Where(x => x.AlunoId == alunoId);
        }

        public IEnumerable<AlunoTurma> GetByIdTruma(int turmaId)
        {
            return _sqlContext.AlunoTurmas.Where(x => x.TurmaId == turmaId);
        }
    }
}
