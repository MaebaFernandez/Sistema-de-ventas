using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace adminpro.Models
{
    public class compra
    {
        public int CompraId { get; set; }
        public DateTime HoraCompra { get; set; }
        public int PrecioTotal { get; set; }
        public string TiempoEntrega { get; set; }
        public int CargoEnvio { get; set; }
        public DateTime fechadeEnvio { get; set; }
        public usuario usuario{ get; set; }
        public reserva reserva { get; set; }
        public estadoCompra EstadoCompra { get; set; }
        public ICollection<facturacion> facturacions  { get; set; }
        public ICollection<notificacion> notificaciones { get; set; }

    }
}
