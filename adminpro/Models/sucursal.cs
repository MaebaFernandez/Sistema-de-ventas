using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace adminpro.Models
{
    public class sucursal
    {
        public int SucursalId { get; set; }
        public string NombreSucursal { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public string Ubicacion { get; set; }

        public empresa empresa { get; set; }
        public ICollection<producto> productos { get; set; }


    }


}
