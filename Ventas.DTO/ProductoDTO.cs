using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.DTO
{
    public class ProductoDTO
    {
        public int IdProducto { get; set; }

        public string? Nombre { get; set; }

        public int? DescripcionCategoria { get; set; }

        public int? Stock { get; set; }

        public string? PrecioTexto { get; set; }

        public int? EsActivo { get; set; }
    }
}
