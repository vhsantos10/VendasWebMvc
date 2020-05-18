using SalesWebMvc.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;

namespace SalesWebMvc.Models.Servicos
{
    public class DepartamentoServico
    {
        private readonly SalesWebMvcContext _cotexto;

        public DepartamentoServico(SalesWebMvcContext salesWebMvcContext)
        {
            _cotexto = salesWebMvcContext;
        }
        public List<Departamentos> FindAll()
        {
            return _cotexto.Departamentos.OrderBy(p => p.Nome).ToList();
        }
    }
}
