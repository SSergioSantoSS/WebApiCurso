using System;
using System.Collections.Generic;
using System.Text;
using WebCursos.Application.Dtos;
using WebCursos.Domain.Entities;

namespace WebCursos.Application.Interfaces.Mappers
{
    public interface IMapperAluno
    {
        Aluno MapperDtoToEntity(AlunoUpdateDto alunoDto);
        Aluno MapperDtoToEntity(AlunoInsertDto alunoDto);
        IEnumerable<AlunoUpdateDto> MapperListAlunosDto(IEnumerable<Aluno> alunos);
        AlunoUpdateDto MapperEntityToDto(Aluno aluno);
    }
}
