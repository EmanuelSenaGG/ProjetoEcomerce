using ProjetoEcomerce.Models;


namespace ProjetoEcomerce.Repositorio
{
    public interface IUsuarioRepositoriocs
    {
        int UserLogin(UsuarioModel usuario);
        UsuarioModel CreateUser(UsuarioModel usuario);
    }
}
