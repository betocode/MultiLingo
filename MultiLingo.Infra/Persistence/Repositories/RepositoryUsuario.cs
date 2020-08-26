using MultiLingo.Domain.Arguments.Usuario;
using MultiLingo.Domain.Entities;
using MultiLingo.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultiLingo.Infra.Persistence.Repositories
{
  
  
    public class RepositoryUsuario : IRepositoryUsuario
    {
        private readonly MultiLingoContext _context;
        public RepositoryUsuario(MultiLingoContext context)
        {
            _context = context;
        }

        public Usuario Create(Usuario user)
        {
             _context.Usuario.Add(user);
            return user;
        }

        public Usuario FindByLogin(string login)
        {
            var entity = _context.Usuario.Where(x => x.Login.Equals(login)).FirstOrDefault();
            return entity;
        }

        public Usuario Login(UsuarioRequest user)
        {
            var entity = _context.Usuario.Where(x => x.Login.Equals(user.Login) && x.Senha.Equals(x.Senha)).FirstOrDefault();
            return entity;
        }
    }
}
