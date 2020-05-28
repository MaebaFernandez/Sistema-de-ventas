using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace adminpro.Models
{
    public class reserva
    {
        public int ReservaId { get; set; }
        public DateTime FechaReserva { get; set; }
        public int CantidadProducto { get; set; }
        public int EstadoReserva { get; set; }
        public int Precio { get; set; }
        
        public producto producto { get; set; }

        public ICollection<compra> compras { get; set; }
    }
}
