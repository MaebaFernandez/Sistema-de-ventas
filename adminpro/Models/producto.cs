using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adminpro.Models
{
    public class producto
    {
        public int ProductoId { get; set; }
        public string Imagen { get; set; }
        public string Descripcion { get; set; }
        public string Peso { get; set; }
        public int Cantidad { get; set; }
        public string Tamaño { get; set; }
        public int Precio { get; set; }
        public string NombreProducto { get; set; }
        public categoria categoria { get; set; }
        public sucursal sucursal { get; set; }
        public ICollection<reserva> reservas { get; set; }
        public ICollection<productoOferta> ProductoOfertas { get; set; }

    }
}
