﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models.Servicos.Exception;

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
            return _context.Vendedores.Include(obj => obj.departamentos).FirstOrDefault(p => p.Id == id);
        }
        public void Remover(int id)
        {
            var obj = _context.Vendedores.Find(id);
            _context.Vendedores.Remove(obj);
            _context.SaveChanges();
        }
        public void Editar(Vendedores obj)
        {
            if (!_context.Vendedores.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id não encontrado");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
            
        }

    }
}
