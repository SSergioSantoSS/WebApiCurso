using Microsoft.AspNetCore.Mvc;
using WebCursos.Application.Dtos;
using WebCursos.Application.Interfaces.Mappers;
using WebCursos.Domain.Core.Interfaces.Services;
using WebCursos.Domain.Entities;
using WebCursos.Infrastructure.Data.Repositories;

namespace WebCursos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IServiceUsuario _serviceUsuario;
        private readonly IMapperUsuario _mapper;

        public AccountController(IServiceUsuario serviceUsuario, IMapperUsuario mapper)
        {
            _serviceUsuario = serviceUsuario;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Post(UsuarioInserDto usuariotDto, [FromServices] RepositoryUsuario repositoryUsuario)
        {
            try
            {
                var retorno = _serviceUsuario.Add(_mapper.MapperDtoToEntity(usuariotDto));

                //verificar se o email informado ja esta cadastrado no banco..
                if (retorno == null)
                {
                    //retornando erro HTTP 422
                    return UnprocessableEntity
                    ("O email informado já encontra-se cadastrado. Por favor, tente outro.");
                }               

                //retornar resposta de sucesso HTTP 200
                return Ok("Usuário cadastrado com sucesso.");
            }

            catch (Exception e)
            {
                //INTERNAL SERVER ERROR
                return StatusCode(500, e.Message);
            }
        }
        
        
    }
}














