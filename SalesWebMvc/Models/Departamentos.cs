using Microsoft.AspNetCore.JsonPatch.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class Departamentos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Vendedores> Vendedores { get; set; } = new List<Vendedores>();

        public Departamentos()
        {

        }

        public Departamentos(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
        public void addVendedores(Vendedores vendedores)
        {
            Vendedores.Add(vendedores);
        }
        public double totalVendas(DateTime inicial, DateTime final, string Nome)
        {
            return Vendedores.Sum(Vendedores => Vendedores.toatalVendas(inicial, final));
        }
    }
}
