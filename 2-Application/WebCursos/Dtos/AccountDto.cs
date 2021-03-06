using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebCursos.Application.Dtos
{
    public class AccountDto
    {     

        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]
        [Required(ErrorMessage = "Por favor, informe o email do usuário.")]
        public string Email { get; set; }


        [MinLength(8, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(20, ErrorMessage = "Por favor, informe no máximo { 2} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe a senha do usuário.")]
        public string Senha { get; set; }


        [Compare("Senha", ErrorMessage = "Senhas não conferem.")]
        [Required(ErrorMessage = "Por favor, confirme a senha do usuário.")]
        public string SenhaConfirmacao { get; set; }


    }
}
