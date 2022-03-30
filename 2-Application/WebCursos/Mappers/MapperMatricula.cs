using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCursos.Application.Dtos;
using WebCursos.Domain.Entities;


namespace WebCursos.Application.Interfaces.Mappers
{
    public class MapperMatricula : IMapperMatricula
    {

        public Matricula MapperDtoToEntity(MatriculaInsertDto matriculaDto)
        {
            var matricula = new Matricula()
            {
                NumeroMatricula = matriculaDto.NumeroMatricula
                
            };
            return matricula;
        }

        public Matricula MapperDtoToEntity(MatriculaUpdateDto matriculaDto)
        {
            var matricula = new Matricula()
            {
                Id = matriculaDto.Id,
                Ativo = matriculaDto.Ativo

            };
            return matricula;
        }


    }
}
