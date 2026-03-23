using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaLogin.Models;
using System.Diagnostics;

namespace PruebaTecnicaLogin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Perfil()
        {
            // Opcional: Validar que haya sesión para entrar aquí
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UsuarioCorreo")))
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
