using System;
using System.Collections.Generic;
using System.Text;
using WebCursos.Domain.Core.Interfaces.Repositories;
using WebCursos.Domain.Core.Interfaces.Services;
using WebCursos.Domain.Entities;
using WebCursos.Domain.Services.Utils;

namespace WebCursos.Domain.Services
{
    public class ServiceUsuario : ServiceBase<Usuario>, IServiceUsuario
    {
        private readonly IRepositoryUsuario repositoryUsuario;

        public ServiceUsuario(IRepositoryUsuario repositoryUsuario) : base(repositoryUsuario)
        {   
            this.repositoryUsuario = repositoryUsuario;
        }

        public Usuario GetById(int id)
        {
            return repositoryUsuario.GetById(id);
        }

        public IEnumerable<Usuario> GetAll()
        {
            return repositoryUsuario.GetAll();
        }

        public bool Add(Usuario usuario)
        {
            var usuarioFind = repositoryUsuario.Obter(usuario.Email);

            if (usuarioFind != null) return false;

            var senha = new Criptografia().CriarHash(usuario.Senha);

            usuario.SetSenhaCriptogrtafada(senha);

            repositoryUsuario.Add(usuario);

            return true;
        }

        public bool Update(Usuario usuario)
        {
            var usuarioFind = repositoryUsuario.GetById(usuario.Id);

            if (usuarioFind == null) return false;

            var senha = new Criptografia().CriarHash(usuario.Senha);

            usuarioFind.ChangeUsuario(usuario.Nome, usuario.Email, senha);

            repositoryUsuario.Update(usuarioFind);

            return true;
        }

        public bool Delete(int id)
        {
            var usuarioFind = repositoryUsuario.GetById(id);

            if (usuarioFind == null) return false;

            repositoryUsuario.Delete(usuarioFind);

            return true;
        }
    }
}
