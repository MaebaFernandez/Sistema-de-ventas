using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adminpro.Models
{
    public class provincia
    {
        public int ProvinciaId { get; set; }
        public string NombreProvincia { get; set; }
        public departamento departamento { get; set; }
        public ICollection<destinoCompra> destinoCompras { get; set; }
    }
}
