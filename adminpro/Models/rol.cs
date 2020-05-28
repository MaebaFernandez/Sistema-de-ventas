using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adminpro.Models
{
    public class rol
    {
        public int RolId { get; set; }
        public string TipoRol { get; set; }

        public ICollection<usuario> usuarios{ get; set; }
    }
}
