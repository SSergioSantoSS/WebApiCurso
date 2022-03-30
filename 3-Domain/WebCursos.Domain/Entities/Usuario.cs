using System;
using System.Collections.Generic;
using System.Text;

namespace WebCursos.Domain.Entities
{
    public class Usuario : Base
    {

        public string Email { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Senha { get; set; }

        public void ChangeUsuario(string email, string nome, string senha)
        {
            Email = email;
            Nome = nome;
            Senha = senha;
        }

        public void SetSenhaCriptogrtafada(string senha)
        {
            Senha = senha;
            DataCriacao = DateTime.Now;
        }

    }
}
