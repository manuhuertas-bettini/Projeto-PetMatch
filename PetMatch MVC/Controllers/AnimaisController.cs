using Microsoft.AspNetCore.Mvc;
using PetMatch.Models;
using Projeto_PetMatch_MVC.Models;

namespace PetMatch.Controllers
{
    public class AnimaisController : Controller
    {
        private readonly AppDbContext _context;

        public AnimaisController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Criar()
        {
            if (HttpContext.Session.GetInt32("UsuarioId") == null)
                return RedirectToAction("Login", "Auth");

            return View();
        }

        [HttpPost]
        public IActionResult Criar(animai novoPet)
        {
            var usuarioId = HttpContext.Session.GetInt32("UsuarioId");
            if (usuarioId == null)
                return RedirectToAction("Login", "Auth");

            novoPet.usuario_id = usuarioId.Value;
            novoPet.status = "disponivel";
            novoPet.criado_em = DateTime.Now;

            _context.animais.Add(novoPet);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}