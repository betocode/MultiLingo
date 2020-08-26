using MultiLingo.Domain.Arguments.Usuario;
using MultiLingo.Domain.Entities;

namespace MultiLingo.Domain.Interfaces.Repositories
{
    public interface IRepositoryUsuario
    {

        Usuario Create(Usuario user);

        Usuario Login(UsuarioRequest user);

        Usuario FindByLogin(string login);
    }
}
