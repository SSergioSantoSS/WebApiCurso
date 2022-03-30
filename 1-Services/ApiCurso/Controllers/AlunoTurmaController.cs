using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCursos.Application.Dtos;
using WebCursos.Application.Interfaces;
using WebCursos.Application.Interfaces.Mappers;
using WebCursos.Domain.Core.Interfaces.Services;

namespace WebCursos.API.Controllers
{
    //[Authorize]
    [Route("[Controller]/[action]")]
    [ApiController]
    public class AlunoTurmaController : ControllerBase
    {
        private readonly IServiceAlunoTurma _serviceAlunoTurma;
        private readonly IMapperAlunoTurma _mapperAlunoTurma
            ;

        public AlunoTurmaController(IMapperAlunoTurma mapperAlunoTurma, IServiceAlunoTurma serviceTurma)
        {
            _mapperAlunoTurma = mapperAlunoTurma;
            _serviceAlunoTurma = serviceTurma;
        }        

        [HttpGet("{turmaId:int}/turma")]
        public ActionResult<string> GetByIdTurma(int turmaId)
        {
            return Ok(_serviceAlunoTurma.GetTurmaId(turmaId));
        }

        [HttpGet("{alunoId:int}/aluno")]
        public ActionResult<string> GetByIdAluno(int alunoId)
        {
            return Ok(_serviceAlunoTurma.GetAlunoId(alunoId));
        }

        //Post API/VALUES/5

        [HttpPost]
        public ActionResult Post([FromBody] AlunoTurmaInsertDto turmaDto)
        {
            try
            {
                if (turmaDto == null)
                    return NotFound();

                var retorno = _serviceAlunoTurma.Add(_mapperAlunoTurma.MapperDtoToEntity(turmaDto));

                switch (retorno)
                {
                    case 0:
                        return UnprocessableEntity("Turma e/ou aluno não localizados.");
                    case 1:
                        return Ok("Aluno cadastrado com sucesso"); 
                    case 2:
                        return UnprocessableEntity("Aluno já cadastrado na turma.");
                    case 3:
                        return UnprocessableEntity("Aluno não cadastrado, turma completa");
                }

                return BadRequest();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpDelete]
        public ActionResult Delete(int alunoId, int turmaId)
        {
            try
            {
                if (alunoId <= 0 || turmaId <= 0)
                    return NotFound();

                if (_serviceAlunoTurma.Delete(alunoId, turmaId))
                {
                    return Ok("Aluno excluído da turma com sucesso.");
                }

                return BadRequest("Não foi possível excluir o aluno da turma");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}













