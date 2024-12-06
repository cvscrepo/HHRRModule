﻿using HHRRModule.DAL.Repositorios.Contrato;
using HHRRModule.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HHRRModule.DAL.Repositorios
{
    public class GenericRepository<TModelo> : IGenericRepository<TModelo> where TModelo : class
    {
        private readonly HhrrmoduleContext _dbcomercialContext;

        public GenericRepository(HhrrmoduleContext dbcomercialContext)
        {
            _dbcomercialContext = dbcomercialContext;
        }

        public async Task<TModelo> Obtener(Expression<Func<TModelo, bool>> filtro)
        {
            try
            {
                TModelo modelo = await _dbcomercialContext.Set<TModelo>().FirstOrDefaultAsync(filtro);
                return modelo;
            }
            catch
            {
                throw;
            }
        }

        public async Task<TModelo> Crear(TModelo modelo)
        {
            try
            {
                //Base de datos.especificarElModeloATrabajar
                _dbcomercialContext.Set<TModelo>().Add(modelo);
                await _dbcomercialContext.SaveChangesAsync();

                return modelo;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(TModelo modelo)
        {
            try
            {
                _dbcomercialContext.Set<TModelo>().Update(modelo);
                await _dbcomercialContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(TModelo modelo)
        {
            try
            {
                _dbcomercialContext.Remove(modelo);
                await _dbcomercialContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }


        public async Task<bool> Eliminar(IQueryable<TModelo> modelo)
        {
            try
            {
                _dbcomercialContext.RemoveRange(modelo);
                await _dbcomercialContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IQueryable<TModelo>> Consultar(Expression<Func<TModelo, bool>> filtro = null)
        {
            try
            {
                IQueryable<TModelo> modelo = filtro == null ? _dbcomercialContext.Set<TModelo>() : _dbcomercialContext.Set<TModelo>().Where(filtro);
                return modelo;
            }
            catch
            {
                throw;
            }
        }
    }
}
