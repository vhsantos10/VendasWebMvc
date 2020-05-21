using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Models.Servicos;
using SalesWebMvc.Models.Servicos.Exception;
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
            var viewModel = new VendedorFormViewModels { Departamentos = departamentos };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Criar(Vendedores vendedores)
        {
            _vendedoresServico.Inserir(vendedores);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Deletar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _vendedoresServico.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Deletar(int id)
        {
            _vendedoresServico.Remover(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _vendedoresServico.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _vendedoresServico.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            List<Departamentos> departamentos = _departamentoServico.FindAll();
            VendedorFormViewModels viewModels = new VendedorFormViewModels { Vendedores = obj, Departamentos = departamentos };
            return View(viewModels);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int id, Vendedores vendedores)
        {
            if (id != vendedores.Id)
            {
                return BadRequest();
            }
            try
            {
                _vendedoresServico.Editar(vendedores);
                return RedirectToAction(nameof(Index)); 
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }
            
        }
        

        }
    }
