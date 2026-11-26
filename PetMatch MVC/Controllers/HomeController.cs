using Microsoft.AspNetCore.Mvc;
using PetMatch.Models;
using Projeto_PetMatch_MVC.Models;

namespace PetMatch.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string? busca)
        {
            var query = _context.animais
                .Where(a => a.status == "disponivel")
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(busca))
            {
                query = query.Where(a =>
                    a.nome.Contains(busca) ||
                    a.especie.Contains(busca) ||
                    a.localizacao.Contains(busca));
            }

            var listaAnimais = query.OrderByDescending(a => a.criado_em).ToList();
            ViewBag.BuscaAtual = busca;

            return View(listaAnimais);
        }
    }
}