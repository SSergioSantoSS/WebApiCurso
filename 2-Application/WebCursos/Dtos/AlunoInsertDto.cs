using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebCursos.Application.Dtos
{
    public class AlunoInsertDto
    {
        [MinLength(3, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(20, ErrorMessage = "Por favor, informe no máximo {2} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o {0} do usuário.")]
        public string Nome { get; set; }

        [MinLength(11, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(11, ErrorMessage = "Por favor, informe no máximo { 2} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o {0} do usuário.")]
        public string Cpf { get; set; }

        
        [Required(ErrorMessage = "Por favor, informe o {0} do usuário.")]
        public string Email { get; set; }
        public string Telefone { get; set; }        
        public int MatriculaId { get; set; }
    }
}
