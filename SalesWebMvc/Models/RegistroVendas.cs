using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models.Enums;
using SalesWebMvc.Models;

namespace SalesWebMvc.Models
{
    public class RegistroVendas
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double Montante { get; set; }
        public Status status { get; set; }
        public Vendedores Vendedores { get; set; }

        public RegistroVendas()
        {

        }

        public RegistroVendas(int id, DateTime data, double montante, Status status, Vendedores vendedores)
        {
            Id = id;
            Data = data;
            Montante = montante;
            this.status = status;
            Vendedores = vendedores;
        }
    }
}
