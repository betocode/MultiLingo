using MultiLingo.Domain.Arguments.Usuario;
using MultiLingo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiLingo.Domain.Interfaces.Services
{
    public interface IServiceUsuario
    {
        UsuarioResponse Create(UsuarioRequest user);

        UsuarioResponse Login(UsuarioRequest user);



        Usuario FindByLogin(string login);
    }
}
