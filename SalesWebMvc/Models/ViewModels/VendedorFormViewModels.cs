using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models.ViewModels
{
    public class VendedorFormViewModels
    {
        public Vendedores Vendedores { get; set; }
        public ICollection<Departamentos> Departamentos { get; set; }
    }
}
