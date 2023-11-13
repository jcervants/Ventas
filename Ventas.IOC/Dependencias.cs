using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.DAL.DbContext;
using Ventas.DAL.Repositorios;
using Ventas.DAL.Repositorios.Contrato;
using Ventas.Utility;

namespace Ventas.IOC
{
    public static class Dependencias
    {
        public static void InyectarDependencias(this IServiceCollection services, IConfiguration configuration)
        {
            //referencia cadena conexion
            services.AddDbContext<VentasContext>(options =>{
                options.UseSqlServer(configuration.GetConnectionString("conexionSQL"));
            });
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IVentaRepository, VentaRepository>();

            services.AddAutoMapper(typeof(AutoMapperProfile));
        }
    }
}
