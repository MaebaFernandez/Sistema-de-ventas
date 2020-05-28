using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adminpro.Models
{
    public class oferta
    {
        public int OfertaId { get; set; }
        public string Descripcion { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int Descuento { get; set; }
        public int EstadoOferta { get; set; }

        public usuario usuario { get; set; }
        public tipoOferta tipoOferta { get; set; }



    }
}
