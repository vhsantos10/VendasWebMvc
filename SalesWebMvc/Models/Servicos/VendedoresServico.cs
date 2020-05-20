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
        public void Inserir(Vendedores obj)
        {
            
            _context.Add(obj);
            _context.SaveChanges();
        }
        public Vendedores FindById(int id)
        {
            return _context.Vendedores.FirstOrDefault(p => p.Id == id);
        }
        public void Remover(int id)
        {
            var obj = _context.Vendedores.Find(id);
            _context.Vendedores.Remove(obj);
            _context.SaveChanges();
        }
    }
}
