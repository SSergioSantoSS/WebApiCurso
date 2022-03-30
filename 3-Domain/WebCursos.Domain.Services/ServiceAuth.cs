using System;
using System.Collections.Generic;
using System.Text;
using WebCursos.Domain.Core.Interfaces.Repositories;
using WebCursos.Domain.Core.Interfaces.Services;
using WebCursos.Domain.Entities;
using WebCursos.Domain.Services.Utils;

namespace WebCursos.Domain.Services
{
    public class ServiceAuth : IServiceAuth
    {
        private readonly IRepositoryUsuario _repositoryUsuario;
        private readonly TokenService _tokenService;

        public ServiceAuth(IRepositoryUsuario repositoryUsuario, TokenService tokenService)
        {
            _repositoryUsuario = repositoryUsuario;
            _tokenService = tokenService;
        }

        public string Validate(string email, string senha)
        {
            var token = string.Empty;
            var usuario = _repositoryUsuario.Obter(email);

            if (usuario == null) return token;

            var senhaCriptografada = new Criptografia().CriarHash(senha);

            if (senhaCriptografada != usuario.Senha) return token;

            token = _tokenService.GerarToken(email);

            return token;
        }
    }
}
