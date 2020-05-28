using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adminpro.Models
{
    public class facturacion
    {
       public int FacturacionId { get; set; }
        public DateTime Fecha { get; set; }
        public string QR { get; set; }
        public compra compra { get; set; }
        public tipoPago tipoPago { get; set; }
        public usuario usuario { get; set; }
        public empresa empresa { get; set; }
        public sucursal sucursal { get; set; }
    }
}
