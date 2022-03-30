using System;
using System.Collections.Generic;
using System.Text;

namespace WebCursos.Domain.Entities
{
    public class Aluno : Base
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public int MatriculaId { get; set; }
        public virtual Matricula Matricula { get; set; }

        public void ChangeAluno(string name, string email, string telefone)
        {
            Nome = name;
            Email = email;
            Telefone = telefone;
        }
    }
}
