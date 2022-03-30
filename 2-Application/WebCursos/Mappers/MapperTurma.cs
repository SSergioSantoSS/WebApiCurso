using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCursos.Application.Dtos;
using WebCursos.Domain.Entities;


namespace WebCursos.Application.Interfaces.Mappers
{
    public class MapperTurma : IMapperTurma
    {

        public Turma MapperDtoToEntity(TurmaUpdateDto turmaDto)
        {
            var turma = new Turma()
            {
                Id = turmaDto.Id,
                IsAtivo = turmaDto.IsAtivo,
                Nome = turmaDto.Nome,
                AnoLetivo = turmaDto.AnoLetivo
            };
            return turma;
        }


        public Turma MapperDtoToEntity(TurmaInsertDto turmaDto)
        {
            var turma = new Turma()
            {
                Nome = turmaDto.Nome,
                AnoLetivo = turmaDto.AnoLetivo
            };
            return turma;
        }

        public TurmaUpdateDto MapperEntityToDto(Turma turma)
        {
            if (turma == null)
            {
                return null;
            }
            var turmaDto = new TurmaUpdateDto()
            {
                Id = turma.Id,
               IsAtivo = turma.IsAtivo,
                Nome = turma.Nome
            };
            return turmaDto;
        }

        public IEnumerable<TurmaUpdateDto> MapperListTurmasDto(IEnumerable<Turma> turmas)
        {
            var dto = turmas.Select(x => new TurmaUpdateDto { Id = x.Id, IsAtivo = x.IsAtivo, Nome = x.Nome});
            return dto;
        }
    }
}
