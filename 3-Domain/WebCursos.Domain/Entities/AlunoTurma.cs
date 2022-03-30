using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCursos.Domain.Entities
{
    public class AlunoTurma
    {
        public int Id { get; set; }
        public int TurmaId { get; set; }
        public int AlunoId { get; set; }
        public virtual Turma Turmas { get; set; }
        public virtual Aluno Alunos { get; set; }
    }
}
