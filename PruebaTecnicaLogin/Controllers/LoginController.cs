using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaLogin.Models;

namespace PruebaTecnicaLogin.Controllers
{


    public class LoginController : Controller
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }


      
        [HttpPost]
        public IActionResult Acceder(string correo, string clave)
        {
            // 1. Buscar al usuario
            var user = _context.Usuarios.FirstOrDefault(u => u.Correo == correo);

            if (user == null)
            {
                ViewBag.Error = "Usuario no encontrado.";
                return View("Index");
            }

            // REINICIO POR TIEMPO CUMPLIDO ---
            // Si el bloqueo ya pasó, limpiamos los intentos antes de validar la clave
            if (user.BloqueadoHasta.HasValue && user.BloqueadoHasta.Value <= DateTime.Now)
            {
                user.IntentosFallidos = 0; 
                user.BloqueadoHasta = null;
                _context.SaveChanges();
            }

            // Verificar si está bloqueado (Lógica de los 20 min)
            if (user.BloqueadoHasta.HasValue && user.BloqueadoHasta.Value > DateTime.Now)
            {
                var dif = user.BloqueadoHasta.Value - DateTime.Now; 
                ViewBag.Error = $"Cuenta bloqueada. Reintente en {dif.Minutes}m {dif.Seconds}s.";
                return RedirectToAction("Bloqueado");
            }

            //  Validar la clave
            if (user.Clave == clave)
            {
                
                user.IntentosFallidos = 0;
                user.BloqueadoHasta = null;
                _context.SaveChanges();

                
                HttpContext.Session.SetString("UsuarioCorreo", user.Correo);

                return RedirectToAction("Perfil", "Home");
            }
            else
            {
                // FALLO: Aumentamos el contador
                user.IntentosFallidos = (user.IntentosFallidos ?? 0) + 1;

                if (user.IntentosFallidos >= 5)
                {
                    // BLOQUEO DE 15 MINUTOS
                    user.BloqueadoHasta = DateTime.Now.AddMinutes(15);
                    ViewBag.Error = "Has alcanzado el límite de 5 intentos. Cuenta bloqueada por 15 minutos.";
                    return RedirectToAction("Bloqueado");
                }
                else
                {
                    ViewBag.Error = $"Contraseña incorrecta. Intento {user.IntentosFallidos} de 5.";
                }

                _context.SaveChanges();
                return View("Index");
            }
        }


        public IActionResult Salir()
        {
            HttpContext.Session.Clear(); 
            return RedirectToAction("Index", "Login");
        }


        [HttpGet]
        public IActionResult RefrescarSesion()
        {
            // Esto reinicia el contador de 20 minutos en el servidor
            return Ok();
        }


        [HttpGet]
        public IActionResult Confirm()
        {
         
            return View();
        }

        [HttpGet]
        public IActionResult Bloqueado()
        {
            return View();
        }

    }



}
