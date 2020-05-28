using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adminpro.Models
{
    public class tipoOferta
    {
        public int TipoOfertaId { get; set; }
        public string TipoOferta { get; set; }

        public ICollection<oferta> ofertas { get; set; }
    }
}
