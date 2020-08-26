using MultiLingo.Domain.Arguments.Usuario;
using MultiLingo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiLingo.Domain.Interfaces.Repositories
{
    public interface IRepositoryUsuario
    {

        Usuario Create(Usuario user);

        Usuario Login(UsuarioRequest user);

        Usuario FindByLogin(string login);
    }
}
