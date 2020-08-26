using MultiLingo.Domain.Arguments.Usuario;
using MultiLingo.Domain.Entities;

namespace MultiLingo.Domain.Interfaces.Services
{
    public interface IServiceUsuario
    {
        UsuarioResponse Create(UsuarioRequest user);

        UsuarioResponse Login(UsuarioRequest user);



        Usuario FindByLogin(string login);
    }
}
