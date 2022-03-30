using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCursos.API.Security;
using WebCursos.Application.Dtos;
using WebCursos.Domain.Core.Interfaces.Services;
using WebCursos.Infrastructure.Data.Repositories;

namespace ProjetoAPI01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IServiceAuth _serviceAuth;

        public AuthController(IServiceAuth serviceAuth)
        {
            _serviceAuth = serviceAuth;
        }

        [HttpPost]
        public IActionResult Post(AuthDto authDto)
        {
            try
            {
                var token = _serviceAuth.Validate(authDto.Email, authDto.Senha);
                
                if (!string.IsNullOrEmpty(token))
                {
                    //autenticar o usuario!
                    return Ok(
                    new
                    {
                        Mensagem = "Usuário autenticado com sucesso",
                        AccessToken = token
                    }
                   );
                }
                else
                {
                    return StatusCode(401, "Acesso negado, usuário/senha inválido.");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Erro: " + e.Message);
            }
        }
    }
}