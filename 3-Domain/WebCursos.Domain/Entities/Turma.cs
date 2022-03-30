using System;
using System.Collections.Generic;
using System.Text;

namespace WebCursos.Domain.Entities
{
    public class Turma : Base
    {
        public Turma()
        {
            IsAtivo = true;
        }

        public string Nome { get; set; }
        public int AnoLetivo { get; set; }
        public bool IsAtivo { get; set; }

        public void ChangeTurma(int anoLetivo, bool isAtivo)
        {
            AnoLetivo = anoLetivo;
            IsAtivo = isAtivo;
        }

    }
}
