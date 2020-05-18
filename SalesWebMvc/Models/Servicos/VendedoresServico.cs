using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Data;
using SalesWebMvc.Models;

namespace SalesWebMvc.Models.Servicos
{
    public class VendedoresServico
    {
        private readonly SalesWebMvcContext _context;

        public VendedoresServico(SalesWebMvcContext salesWebMvcContext)
        {
            _context = salesWebMvcContext;
        }
        public List<Vendedores> FindAll()
        {
            return _context.Vendedores.ToList();
        }
    }
}
