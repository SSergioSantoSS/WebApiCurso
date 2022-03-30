using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCursos.Application.Dtos;
using WebCursos.Domain.Entities;


namespace WebCursos.Application.Interfaces.Mappers
{
    public class MapperAuth : IMapperAuth
    {       
       
        public Auth MapperDtoToEntity(AuthDto authDto)
        {
            var auth = new Auth()
            {
                
               Email = authDto.Email,
                Senha= authDto.Senha
            };
            return auth;
        }

        public AuthDto MapperEntityToDto(Auth auth)
        {
            var authDto = new AuthDto()
            {
               
                Email= auth.Email,
                Senha = auth.Senha
            };
            return authDto;
        }

        public IEnumerable<AuthDto> MapperListAuthsDto(IEnumerable<Auth> auths)
        {
            var dto = auths.Select(x => new AuthDto { Email = x.Email, Senha = x.Senha});
            return dto;
        }
    }
}
