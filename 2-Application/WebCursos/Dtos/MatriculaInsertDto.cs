using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCursos.Application.Dtos
{
    public class MatriculaInsertDto
    {
        
        [Required(ErrorMessage = "Por favor, informe o {0} do usuário.")]
        public string NumeroMatricula { get; set; }
    }
}
