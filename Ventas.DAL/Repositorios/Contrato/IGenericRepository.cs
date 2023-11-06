using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using System.Linq.Expressions;
//Contrato a respetar para interactuar con nuestros modelos
namespace Ventas.DAL.Repositorios.Contrato
{
    public interface IGenericRepository<TModel> where TModel : class
    {
        //Methods CRUD

        //obtenemos un modelo producto, categoria
        //Modelo para obtener segun función
        Task<TModel> Obtener(Expression<Func<TModel,bool>> filtro);
        Task<TModel> Crear(TModel modelo);
        Task<bool> Editar(TModel modelo);
        Task<bool> Eliminar(TModel modelo);
        //Metodo para devolver una query
        Task<IQueryable<TModel>>Consultar(Expression<Func<TModel, bool>> filtro=null);
    }

}
