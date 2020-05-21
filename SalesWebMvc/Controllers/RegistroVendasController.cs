using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Data;
using SalesWebMvc.Models.Servicos;

namespace SalesWebMvc.Controllers
{
    public class RegistroVendasController : Controller
    {
        private readonly RegistroVendasServicos _registroVendasServicos;

        public RegistroVendasController(RegistroVendasServicos registroVendasServicos)
        {
            _registroVendasServicos = registroVendasServicos;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BuscaSimples(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var resultado = _registroVendasServicos.FindByDate(minDate, maxDate);
            return View(resultado);
        }
        public IActionResult BuscaGrupo()
        {
            return View();
        }
    }
}