using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adminpro.Models
{
    public class tipoPago
    {
        public int TipoPagoId { get; set; }
        public int TipoPago { get; set; }

        public ICollection<facturacion> facturaciones { get; set; }
    }
}
