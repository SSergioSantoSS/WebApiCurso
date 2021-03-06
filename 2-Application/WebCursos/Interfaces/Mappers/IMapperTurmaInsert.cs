using System;
using System.Collections.Generic;
using System.Text;
using WebCursos.Application.Dtos;
using WebCursos.Domain.Entities;

namespace WebCursos.Application.Interfaces.Mappers
{
    public interface IMapperTurmaInsert
    {
        Turma MapperDtoToEntity(TurmaInsertDto turmaDto);
        IEnumerable<TurmaUpdateDto> MapperListTurmasDto(IEnumerable<Turma> turmas);
        TurmaUpdateDto MapperEntityToDto(Turma turma);
    }
}
