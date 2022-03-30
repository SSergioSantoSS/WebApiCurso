using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCursos.Application.Dtos;
using WebCursos.Domain.Entities;


namespace WebCursos.Application.Interfaces.Mappers
{
    public class MapperUsuario : IMapperUsuario
    {

        public Usuario MapperDtoToEntity(UsuarioInserDto usuarioDto)
        {
            var usuario = new Usuario()
            {
                Senha = usuarioDto.Senha,
                Email = usuarioDto.Email,
                Nome = usuarioDto.Nome
                
                
            };
            return usuario;
        }

        public UsuarioInserDto MapperEntityToDto(Usuario usuario)
        {
            var usuarioDto = new UsuarioInserDto()
            {
                Senha = usuario.Senha,
                Email = usuario.Email,
                Nome = usuario.Nome

            };
            return usuarioDto;
        }

        public IEnumerable<UsuarioInserDto> MapperListUsuariosDto(IEnumerable<Usuario> usuarios)
        {
            var dto = usuarios.Select(x => new UsuarioInserDto { Senha = x.Senha, Email= x.Email, Nome = x.Nome });
            return dto;
        }
    }
}
