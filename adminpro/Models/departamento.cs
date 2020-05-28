using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace adminpro.Models
{
    public class departamento
    {
        public int DepartamentoId { get; set; }
        public string NombreDepartamento { get; set; }
        public ICollection<provincia> provincias { get; set; }
    }
}
