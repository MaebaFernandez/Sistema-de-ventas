using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace adminpro.Models
{
    public class destinoCompra
    {
        public int DestinoCompraId { get; set; }
        public string Zona { get; set; }
        public string Calle { get; set; }
        public string NumeroCasa { get; set; }
        public compra compra { get; set; }
        public provincia provincia { get; set; }
       

    }
}
