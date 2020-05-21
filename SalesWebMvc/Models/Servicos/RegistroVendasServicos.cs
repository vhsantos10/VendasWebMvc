using SalesWebMvc.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMvc.Models.Servicos
{
    public class RegistroVendasServicos
    {
        private readonly SalesWebMvcContext _context;

        public RegistroVendasServicos(SalesWebMvcContext contexto)
        {
            _context = contexto;
        }
        public List<RegistroVendas> FindByDate(DateTime? minDate, DateTime? maxDate )
        {
            var resultado = from obj in _context.RegistroVendas select obj;
            if (minDate.HasValue)
            {
                resultado = resultado.Where(x => x.Data >= minDate.Value);  
            }
            if (maxDate.HasValue)
            {
                resultado = resultado.Where(x => x.Data <= maxDate.Value);
            }
            return resultado
                .Include(x => x.Vendedores)
                .Include(x => x.Vendedores.departamentos)
                .OrderByDescending(x => x.Data)
                .ToList();
        }
    }
}
