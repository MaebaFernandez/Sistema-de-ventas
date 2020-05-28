using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adminpro.Models
{
    public class notificacion
    {
        public int NotificacionId { get; set; }
        public string EstadoNotificacion { get; set; }
        public DateTime Hora { get; set; }
        public DateTime Fecha { get; set; }

        public compra compra { get; set; }

    }
}
