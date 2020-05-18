using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Models.Servicos;

namespace SalesWebMvc.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly VendedoresServico _vendedoresServico;

        public VendedoresController(VendedoresServico vendedoresServico)
        {
            _vendedoresServico = vendedoresServico;
        }
        public IActionResult Index()
        {
            var list = _vendedoresServico.FindAll();
            return View(list);
        }
        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Criar(Vendedores vendedores)
        {
            _vendedoresServico.Inserir(vendedores);
            return RedirectToAction(nameof(Index));
        }
    }
}