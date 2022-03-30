using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCursos.Domain.Core.Interfaces.Repositories;
using WebCursos.Domain.Entities;

namespace WebCursos.Infrastructure.Data.Repositories
{
    public class RepositoryMatricula : RepositoryBase<Matricula>, IRepositoryMatricula
    {
        private readonly SqlContext sqlContext;
        public RepositoryMatricula(SqlContext sqlContext) :
            base(sqlContext)
        {
            this.sqlContext = sqlContext;
        }
        public Matricula GetByMatricula(string matricula)
        {
            return sqlContext.Matriculas.Where(m => m.NumeroMatricula == matricula).FirstOrDefault();
        }
    }
}
