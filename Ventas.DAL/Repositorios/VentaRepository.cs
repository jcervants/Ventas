using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.DAL.DbContext;
using Ventas.DAL.Repositorios.Contrato;
using Ventas.Model;

namespace Ventas.DAL.Repositorios
{
    //heredamos de los repositorios genericos
    public class VentaRepository: GenericRepository<Venta>, IVentaRepository
    {
        private readonly VentasContext _dbContext;
        public VentaRepository(VentasContext dbContext): base(dbContext)
        { _dbContext = dbContext; }

        public async Task<Venta> Registrar(Venta modelo)
        {
            Venta ventaGenerada = new Venta();
            //comenzamos con las transacciones
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    foreach (DetalleVenta dv in modelo.DetalleVenta)
                    {
                        Producto productoEncontrado = _dbContext.Productos.Where(p => p.IdProducto == dv.IdProducto).First();
                        productoEncontrado.Stock = productoEncontrado.Stock - dv.Cantidad;
                        _dbContext.Productos.Update(productoEncontrado);
                    }
                    await _dbContext.SaveChangesAsync();
                    //devolver el 1er nro de documento
                    NumeroDocumento correlativo = _dbContext.NumeroDocumentos.First();
                    correlativo.UltimoNumero = correlativo.UltimoNumero + 1;
                    correlativo.FechaRegistro = DateTime.Now;

                    _dbContext.NumeroDocumentos.Update(correlativo);
                    await _dbContext.SaveChangesAsync();
                    int cantidadDigitos = 4;
                    string ceros = string.Concat(Enumerable.Repeat("0", cantidadDigitos));
                    string numeroVenta = ceros + correlativo.UltimoNumero.ToString();
                    numeroVenta = numeroVenta.Substring(numeroVenta.Length - cantidadDigitos, cantidadDigitos);
                    modelo.NumeroDocumento = numeroVenta;
                    await _dbContext.Ventas.AddAsync(modelo);
                    await _dbContext.SaveChangesAsync();
                    ventaGenerada = modelo;
                    transaction.Commit();

                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }return ventaGenerada;
            }
        }
    }
}
