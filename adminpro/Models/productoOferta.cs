using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adminpro.Models
{
    public class productoOferta
    {
        public int ProductoOfertaId { get; set; }
        public producto producto { get; set; }
        public oferta oferta { get; set; }
    }
}
