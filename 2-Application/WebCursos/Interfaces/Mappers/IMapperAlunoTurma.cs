using System;
using System.Collections.Generic;
using System.Text;
using WebCursos.Application.Dtos;
using WebCursos.Domain.Entities;

namespace WebCursos.Application.Interfaces.Mappers
{
    public interface IMapperAlunoTurma
    {
        AlunoTurma MapperDtoToEntity(AlunoTurmaInsertDto alunoDto);
    }
}
