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
    public class MatriculaController : ControllerBase
    {
        private readonly IServiceMatricula _serviceMatricula;
        private readonly IMapperMatricula _mapperMatricula;


        public MatriculaController(
            IMapperMatricula mapperMatricula, IServiceMatricula serviceMatricula)
        {

            _mapperMatricula = mapperMatricula;
            _serviceMatricula = serviceMatricula;
        }

        //GET API/VALUES

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_serviceMatricula.GetAll());
        }

        //GET API/VALUES/5

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var result = _serviceMatricula.GetById(id);
            if (result == null)
            {
                return UnprocessableEntity("Matrícula não localizada.");
            }
            return Ok(result);
        }

        //POST API/VALUES

        [HttpPost]
        public ActionResult Post([FromBody] MatriculaInsertDto matriculaDto)
        {
            try
            {
                if (matriculaDto == null)
                    return NotFound();

                var retorno = _serviceMatricula.Add(_mapperMatricula.MapperDtoToEntity(matriculaDto));

                if (retorno == null)
                {
                    return UnprocessableEntity
                    ("Número de matrícula informada já se encontra cadastrada.");
                }
                
                return Ok("Matrícula cadastrada com sucesso!");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //PUT API/VALUES/5

        [HttpPut]
        public ActionResult Put([FromBody] MatriculaUpdateDto matriculaDto)
        {

            try
            {
                if (matriculaDto == null)
                    return NotFound();

                var retorno = _serviceMatricula.Update(_mapperMatricula.MapperDtoToEntity(matriculaDto));

                if (retorno == null)
                {
                    return UnprocessableEntity("Matrpicula não localizada.");
                }
               
                return Ok("Matrícula atualizado com sucesso!");

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

                var retorno = _serviceMatricula.Delete(idAluno);

                if (retorno == null)
                {
                    return UnprocessableEntity("Aluno não localizado.");
                }
                
                return Ok("Aluno excluido com sucesso!");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}

    

    



    


       
    

