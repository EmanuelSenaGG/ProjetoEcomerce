using Microsoft.AspNetCore.Mvc;
using ProjetoEcomerce.Models;
using ProjetoEcomerce.Repositorio;
using Firebase.Auth;


namespace ProjetoEcomerce.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositoriocs _usuarioRepositoriocs;
        FirebaseAuthProvider auth = new FirebaseAuthProvider(
                            new FirebaseConfig("AIzaSyC-j6SfIXqKD2ONh3UczR1u-cGdQ9jtJ9c"));


        public UsuarioController(IUsuarioRepositoriocs usuarioRepositorio)
        {
            _usuarioRepositoriocs = usuarioRepositorio;


        }


        [HttpPost]
        public async Task<IActionResult> UserCreated(UsuarioModel usuario)
        {
            try
            {
                FirebaseAuthLink firebaseAuthLink = null;

                firebaseAuthLink = await auth.CreateUserWithEmailAndPasswordAsync(usuario.Email, usuario.Password);

                if (firebaseAuthLink.FirebaseToken != null)
                {
                   
                    var usuarioAdd = _usuarioRepositoriocs.CreateUser(usuario);

                    TempData["CreateMessage"] = "Já pode logar e comprar! Você foi cadastrado com sucesso!";                    
                }
                return RedirectToAction("Login", "Home");

            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = "Já existe um usuario com esse email!";
               
                return RedirectToAction("CreateUser", "Home");
            }
        }




        [HttpPost]
        public async Task<IActionResult> Login(UsuarioModel usuario)
        {
            try
            {
                if (usuario.Email == "admin" && usuario.Password == "admin")
                {
                    return RedirectToAction("Admin", "Manager");
                }

                FirebaseAuthLink firebaseAuthLink = null;

                firebaseAuthLink = await auth.SignInWithEmailAndPasswordAsync(usuario.Email, usuario.Password);

                if (firebaseAuthLink.FirebaseToken != null)
                {
                    HttpContext.Session.SetString("_UserToken", firebaseAuthLink.FirebaseToken);
                    var usertoken = HttpContext.Session.GetString("_UserToken");

                    HttpContext.Session.SetString("UsuarioID", firebaseAuthLink.User.LocalId.ToString());

                    var logon = _usuarioRepositoriocs.UserLogin(usuario);

                    if (logon == 1)
                    {
                        return View();
                    }
                }
                TempData["LoginErrorMessage"] = "Usuario ou senha incorretos!";
                return RedirectToAction("Login", "Home");
            }


            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
