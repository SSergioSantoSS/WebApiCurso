using System;
using System.Collections.Generic;
using System.Text;
using WebCursos.Application.Dtos;
using WebCursos.Domain.Entities;

namespace WebCursos.Application.Interfaces.Mappers
{
    public interface IMapperUsuario
    {
        Usuario MapperDtoToEntity(UsuarioInserDto usuarioDto);
        IEnumerable<UsuarioInserDto> MapperListUsuariosDto(IEnumerable<Usuario> usuarios);
        UsuarioInserDto MapperEntityToDto(Usuario usuario);
    }
}
