using System;
using System.Collections.Generic;
using System.Text;
using WebCursos.Application.Dtos;
using WebCursos.Domain.Entities;

namespace WebCursos.Application.Interfaces.Mappers
{
    public interface IMapperAlunoInsert
    {
        AlunoUpdateDto MapperDtoToEntity(AlunoInsertDto alunoDto);
        IEnumerable<AlunoInsertDto> MapperListAlunosDto(IEnumerable<Aluno> alunos);
        AlunoInsertDto MapperEntityToDto(Aluno aluno);
    }
}
