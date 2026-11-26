using Microsoft.AspNetCore.Mvc;
using PetMatch.Models;
using Projeto_PetMatch_MVC.Models;

namespace PetMatch.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(string email, string senha)
        {
            var user = _context.usuarios.FirstOrDefault(u => u.email == email && u.senha == senha);

            if (user == null)
            {
                ViewBag.Erro = "E-mail ou senha inválidos.";
                return View();
            }

            HttpContext.Session.SetInt32("UsuarioId", user.id);
            HttpContext.Session.SetString("UsuarioNome", user.nome);
            HttpContext.Session.SetString("UsuarioPerfil", user.perfil);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Cadastrar() => View();

        [HttpPost]
        public IActionResult Cadastrar(usuario novoUsuario)
        {
            if (_context.usuarios.Any(u => u.email == novoUsuario.email))
            {
                ViewBag.Erro = "Este e-mail já está cadastrado.";
                return View(novoUsuario);
            }

            novoUsuario.perfil = "usuario"; // Todo cadastro público entra como usuário comum
            novoUsuario.criado_em = DateTime.Now;

            _context.usuarios.Add(novoUsuario);
            _context.SaveChanges();

            return RedirectToAction("Login");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}