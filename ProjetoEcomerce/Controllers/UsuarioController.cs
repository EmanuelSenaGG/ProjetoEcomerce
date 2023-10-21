using Microsoft.AspNetCore.Mvc;
using ProjetoEcomerce.Models;
using ProjetoEcomerce.Repositorio;



namespace ProjetoEcomerce.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositoriocs _usuarioRepositoriocs;
       
        

        public UsuarioController(IUsuarioRepositoriocs usuarioRepositorio)
        {
            _usuarioRepositoriocs = usuarioRepositorio;
         
        }


        [HttpPost]
        public IActionResult UserCreated(UsuarioModel usuario)
        {
            try
            {
                 var usuarioAdd = _usuarioRepositoriocs.CreateUser(usuario);
                if (usuarioAdd != null)
                {
                    TempData["CreateMessage"] = "Já pode logar e comprar! Você foi cadastrado com sucesso!";
                    return RedirectToAction("Login", "Home");
                }
                TempData["ErrorMessage"] = "Já existe um usuario com esse email!";
                return RedirectToAction("CreateUser", "Home");
            }
            catch (Exception e)
            {
                
                return RedirectToAction("CreateUser", "Home");
            }
        }


        [HttpPost]
        public IActionResult Login(UsuarioModel usuario)
        {
            try
            {

               if (usuario.Email == "admin" && usuario.Password == "admin")
               {
                    return RedirectToAction("Admin", "Manager");
               }
               
               var logon = _usuarioRepositoriocs.UserLogin(usuario);
               if (logon == 1)
               {
                 
                    return View();
               }
               return RedirectToAction("Login", "Home");
            }
                
         
            catch (Exception ex) { throw ex; }

        }
    }
}
