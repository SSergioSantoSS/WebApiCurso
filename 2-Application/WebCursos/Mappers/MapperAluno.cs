using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCursos.Application.Dtos;
using WebCursos.Domain.Entities;


namespace WebCursos.Application.Interfaces.Mappers
{
    public class MapperAluno : IMapperAluno
    {

        public Aluno MapperDtoToEntity(AlunoUpdateDto alunoDto)
        {
            var aluno = new Aluno()
            {
                Id = alunoDto.Id,
                Nome = alunoDto.Nome,
                Cpf = alunoDto.Cpf,
                Email = alunoDto.Email,
                Telefone = alunoDto.Telefone
            };
            return aluno;
        }

        public AlunoUpdateDto MapperEntityToDto(Aluno aluno)
        {
            if (aluno == null)
            {
                return null;
            }
            var alunoDto = new AlunoUpdateDto()
            {
                Id = aluno.Id,
                Nome = aluno.Nome
            };
            return alunoDto;
        }

        public Aluno MapperDtoToEntity(AlunoInsertDto alunoDto)
        {
            var aluno = new Aluno()
            {
                Nome = alunoDto.Nome,
                Cpf = alunoDto.Cpf,
                Email = alunoDto.Email,
                Telefone = alunoDto.Telefone,
                MatriculaId = alunoDto.MatriculaId
            };
            return aluno;
        }


        public IEnumerable<AlunoUpdateDto> MapperListAlunosDto(IEnumerable<Aluno> alunos)
        {
            var dto = alunos.Select(x => new AlunoUpdateDto { Id = x.Id, Nome = x.Nome });
            return dto;
        }
    }
}
