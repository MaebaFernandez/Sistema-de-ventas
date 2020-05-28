using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adminpro.Models
{
    public class estadoCompra
    {
        public int EstadoCompraId { get; set; }
        public DateTime FechaDeEntrega { get; set; }
        public string UbicacionActualCompra { get; set; }
        public destinoCompra destinoCompra { get; set; }
        public sucursal sucursal { get; set; }
        public ICollection<compra> compras { get; set; }
    }
}
