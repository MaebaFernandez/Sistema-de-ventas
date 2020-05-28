using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adminpro.Models
{
    public class categoria
    {
        public int CategoriaId { get; set; }
        public string NombreCategoria { get; set; }
        public ICollection<producto> productos { get; set; }
    }
}
