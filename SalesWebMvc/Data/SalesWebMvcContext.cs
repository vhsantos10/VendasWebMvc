﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models;

namespace SalesWebMvc.Data
{
    public class SalesWebMvcContext : DbContext
    {
        public SalesWebMvcContext (DbContextOptions<SalesWebMvcContext> options)
            : base(options)
        {
        }

        public DbSet<Departamentos> Departamentos { get; set; }
        public DbSet<RegistroVendas> RegistroVendas { get; set; }
        public DbSet<Vendedores> Vendedores { get; set; }
    }
}
