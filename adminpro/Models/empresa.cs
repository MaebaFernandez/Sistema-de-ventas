using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace adminpro.Models
{
    public class empresa
    {
        public int EmpresaId { get; set; }
        public string NombreEmpresa { get; set; }
        public string Direccion { get; set; }
        public string Logo { get; set; }
        public string Ubicacion { get; set; }
        public int Telefono { get; set; }
        public string Mision { get; set; }
        public string vision { get; set; }
        public int Nit { get; set; }

        public ICollection<sucursal> sucursales { get; set; }
    }
}
