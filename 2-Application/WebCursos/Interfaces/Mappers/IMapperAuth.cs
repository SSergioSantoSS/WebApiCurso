using System;
using System.Collections.Generic;
using System.Text;
using WebCursos.Application.Dtos;
using WebCursos.Domain.Entities;

namespace WebCursos.Application.Interfaces.Mappers
{
    public interface IMapperAuth
    {
        Auth MapperDtoToEntity(AuthDto authDto);
        IEnumerable<AuthDto> MapperListAuthsDto(IEnumerable<Auth> auths);
        AuthDto MapperEntityToDto(Auth auth);
    }
}
