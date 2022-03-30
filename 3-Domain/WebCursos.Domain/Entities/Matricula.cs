using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCursos.Domain.Entities
{
    public class Matricula : Base
    {
        public Matricula()
        {
            Ativo = true;
        }

        public string NumeroMatricula { get; set; }
        public bool Ativo { get; set; }

        public void ChangeMatricula( bool ativo)
        {
            Ativo = ativo;
        }
    }


}
