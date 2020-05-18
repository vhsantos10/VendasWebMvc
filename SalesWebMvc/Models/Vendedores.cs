using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Vendedores
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime dataNascimento { get; set; }
        public double salarioBase { get; set; }

        public Departamentos departamentos { get; set; }
        public ICollection<RegistroVendas> Vendas { get; set; } = new List<RegistroVendas>();

        public Vendedores()
        {

        }

        public Vendedores(int id, string nome, string email, DateTime dataNascimento, double salarioBase, Departamentos departamentos)
        {
            Id = id;
            Nome = nome;
            Email = email;
            this.dataNascimento = dataNascimento;
            this.salarioBase = salarioBase;
            this.departamentos = departamentos;
        }

        public void addVenda(RegistroVendas rv)
        {
            Vendas.Add(rv);
        }
        public void removerVenda(RegistroVendas rv)
        {
            Vendas.Remove(rv);
        }
        public double toatalVendas(DateTime inicial, DateTime final)
        {
            return Vendas.Where(rv => rv.Data >= inicial && rv.Data <= final).Sum(sr => sr.Montante);
        }
    }
}
