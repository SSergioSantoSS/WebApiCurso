using Microsoft.AspNetCore.Mvc;
using WebCursos.Application.Dtos;
using WebCursos.Application.Interfaces.Mappers;
using WebCursos.Domain.Core.Interfaces.Services;

namespace WebCursos.API.Controllers
{
    //[Authorize]
    [Route("[Controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private readonly IServiceTurma _serviceTurma;
        private readonly IMapperTurma _mapperTurma
            ;

        public TurmaController(IMapperTurma mapperTurma, IServiceTurma serviceTurma)
        {
            _mapperTurma = mapperTurma;
            _serviceTurma = serviceTurma;
        }

        //GET API/VALUES

        [HttpGet]
        public ActionResult<IEnumerable<TurmaUpdateDto>> Get()
        {
            return Ok(_serviceTurma.GetAll());
        }

        //GET API/VALUES/5

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var result = _serviceTurma.GetById(id);
            if (result == null)
            {
                return UnprocessableEntity("Turma não localizada.");
            }
            return Ok(result);
        }

        //POST API/VALUES

        [HttpPost]
        public ActionResult Post([FromBody] TurmaInsertDto turmaInsertDto)
        {
            try
            {
                if (turmaInsertDto == null)
                    return NotFound();

                var retorno = _serviceTurma.Add(_mapperTurma.MapperDtoToEntity(turmaInsertDto));

                if (retorno == null)
                {
                    return UnprocessableEntity
                   ("Nome da turma já encontra-se cadastrada.");
                }                

                return Ok("Turma Cadastrado com sucesso!");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //PUT API/VALUES/5

        [HttpPut]
        public ActionResult Put([FromBody] TurmaUpdateDto turmaDto)
        {
            try
            {
                if (turmaDto == null)
                    return NotFound();

                if (_serviceTurma.Update(_mapperTurma.MapperDtoToEntity(turmaDto)))
                {
                    return UnprocessableEntity("Turma não localizada.");
                }

                ;
                return Ok("Turma atualizado com sucesso!");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //DELETE API/VALUES/5

        [HttpDelete]
        public ActionResult Delete(int idTurma)
        {
            try
            {
                if (idTurma <= 0)
                    return NotFound();

                var retorno = _serviceTurma.Delete(idTurma);

                if (retorno == null)
                {
                    return UnprocessableEntity("Turma não localizada.");
                }
                if (retorno.Id == 0)
                {
                    return UnprocessableEntity
                   ("A turma possui pelo menos um aluno cadastrado, não sendo possível sua exclusão.");
                }

                return Ok("Turma excluido com sucesso!");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}













