using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebCursos.Application.Dtos
{
    public class TurmaInsertDto
    {
        [MinLength(3, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(20, ErrorMessage = "Por favor, informe no máximo { 2} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o {0} da turma.")]
        public string Nome { get; set; }

      
        [Required(ErrorMessage = "Por favor, informe o {0} do usuário.")]
        public int AnoLetivo { get; set; }
    }
}
