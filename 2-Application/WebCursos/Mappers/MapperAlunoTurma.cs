using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCursos.Application.Dtos;
using WebCursos.Domain.Entities;


namespace WebCursos.Application.Interfaces.Mappers
{
    public class MapperAlunoTurma : IMapperAlunoTurma
    {

        public AlunoTurma MapperDtoToEntity(AlunoTurmaInsertDto alunoDto)
        {
            var aluno = new AlunoTurma()
            {
                TurmaId = alunoDto.TurmaId,
                AlunoId = alunoDto.AlunoId
            };
            return aluno;
        }
    }
}
