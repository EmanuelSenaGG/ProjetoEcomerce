using Microsoft.AspNetCore.Mvc;
using ProjetoEcomerce.Data;
using ProjetoEcomerce.Models;


namespace ProjetoEcomerce.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositoriocs
    {
        private readonly UsuarioContext _DatabaseUser;
        public UsuarioRepositorio(UsuarioContext databaseUser)
        {
            _DatabaseUser = databaseUser;
        }
        public UsuarioModel CreateUser(UsuarioModel usuario)
        {
            try
            {
                var UserExist = _DatabaseUser.Usuarios.FirstOrDefault(u => u.Email == usuario.Email);
                if (UserExist == null)
                {
                    _DatabaseUser.Add(usuario);
                    _DatabaseUser.SaveChanges();

                    return usuario;
                }
                return null;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UserLogin(UsuarioModel userInput)
        {
            try
            {
                var senha = userInput.Password;
                var usuario = _DatabaseUser.Usuarios.FirstOrDefault(u => u.Email == userInput.Email);
                if (usuario != null)
                {
                    if (usuario.Password == senha)
                    {
                        return 1;

                    }
                    return 0;

                }
                return 0;
            }

            catch (Exception ex) { throw ex; }
        }
    }
}

