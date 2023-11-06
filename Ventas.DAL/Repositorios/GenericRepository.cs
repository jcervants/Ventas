using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.DAL.DbContext;
using Ventas.DAL.Repositorios.Contrato;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ventas.DAL.Repositorios
{
    //
    public class GenericRepository<TModelo> : IGenericRepository<TModelo> where TModelo : class
    {
        private readonly VentasContext _dbContext;

        public GenericRepository(VentasContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<TModelo> Obtener(Expression<Func<TModelo, bool>> filtro)
        {
            try
            {   return (Console.WriteLine("hell"));
            }
            catch {
                throw new NotImplementedException();
             }
        }

        public async Task<TModelo> Crear(TModelo modelo)
        {
            try
            {
                _dbContext.Set<TModelo>().Add(modelo);
                await _dbContext.SaveChangesAsync();
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
                _dbContext.Set<TModelo>().Update(modelo);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> Eliminar(TModelo modelo)   
        {
            try { 
                _dbContext.Set<TModelo>().Update(modelo);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
     }

        public Task<IQueryable<TModelo>> Consultar(Expression<Func<TModelo, bool>> filtro = null)
        {
            try
            {
                IQueryable<TModelo> queryModelo
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

    
     
     }

}
