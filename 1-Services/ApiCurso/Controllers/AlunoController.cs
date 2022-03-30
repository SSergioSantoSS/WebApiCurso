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
    [Route("[Controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IServiceAluno _serviceAluno;
        private readonly IMapperAluno _mapperAluno;


        public AlunoController(
            IMapperAluno mapperAluno, IServiceAluno serviceAluno)
        {

            _mapperAluno = mapperAluno;
            _serviceAluno = serviceAluno;
        }

        //GET API/VALUES

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_serviceAluno.GetAll());
        }

        //GET API/VALUES/5

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var result = _serviceAluno.GetById(id);
            if (result == null)
            {
                return UnprocessableEntity("Aluno não localizado.");
            }
            return Ok(result);
        }

        //POST API/VALUES

        [HttpPost]
        public ActionResult Post([FromBody] AlunoInsertDto alunoDto)
        {
            try
            {
                if (alunoDto == null)
                    return NotFound();

                var retorno = _serviceAluno.Add(_mapperAluno.MapperDtoToEntity(alunoDto));

                if (retorno == null)
                {
                    return UnprocessableEntity
                    ("O CPF informado já encontra-se cadastrado.");
                }

                if (retorno.Id == 0)
                {
                    return UnprocessableEntity
                    ("Matrícula já cadastrada em outro aluno");
                }
                
                return Ok("Aluno cadastrado com sucesso!");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //PUT API/VALUES/5

        [HttpPut]
        public ActionResult Put([FromBody] AlunoUpdateDto alunoDto)
        {

            try
            {
                if (alunoDto == null)
                    return NotFound();
                
                if (!_serviceAluno.Update(_mapperAluno.MapperDtoToEntity(alunoDto)))
                {
                    return UnprocessableEntity("Aluno não localizado.");
                }
               
                return Ok("Aluno atualizado com sucesso!");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //DELETE API/VALUES/5

        [HttpDelete]
        public ActionResult Delete(int idAluno)
        {
            try
            {
                if (idAluno <= 0)
                    return NotFound();

                var retorno = _serviceAluno.Delete(idAluno);

                if (retorno == null)
                {
                    return UnprocessableEntity("Aluno não localizado.");
                }
                if (retorno.Id == 0)
                {
                    return UnprocessableEntity("Aluno não pode ser exluído, pois está cadastrado em uma turma.");
                }
                
                return Ok("Aluno excluído com sucesso!");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}

    

    



    


       
    

