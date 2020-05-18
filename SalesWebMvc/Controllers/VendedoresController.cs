using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Models.Servicos;
using SalesWebMvc.Models.ViewModels;

namespace SalesWebMvc.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly VendedoresServico _vendedoresServico;
        private readonly DepartamentoServico _departamentoServico;
        public VendedoresController(VendedoresServico vendedoresServico, DepartamentoServico departamentoServico)
        {
            _vendedoresServico = vendedoresServico;
            _departamentoServico = departamentoServico;
        }
        public IActionResult Index()
        {
            var list = _vendedoresServico.FindAll();
            return View(list);
        }
        public IActionResult Criar()
        {
            var departamentos = _departamentoServico.FindAll();
            var viewModel = new VendedorFormViewModels { Departamentos = departamentos};
            return View(viewModel);
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