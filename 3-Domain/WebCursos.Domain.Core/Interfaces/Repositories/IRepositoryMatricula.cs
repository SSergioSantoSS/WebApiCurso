using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCursos.Domain.Entities;

namespace WebCursos.Domain.Core.Interfaces.Repositories
{
    public interface IRepositoryMatricula : IRepositoryBase<Matricula>
    {
        Matricula GetByMatricula(string numMatricula);
    }
}
