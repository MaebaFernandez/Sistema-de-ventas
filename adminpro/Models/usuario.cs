using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adminpro.Models
{
    public class usuario
    {
        public int UsuarioId { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string CI { get; set; }
        public int Telefono { get; set; }
        public string Dirreccion { get; set; }
        public string Ubicacion { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string CargoIglesia { get; set; }
        public string NombrePastor { get; set; }
        public string CorreoElectronico { get; set; }
        public rol rol { get; set; }
        public ICollection<oferta> ofertas { get; set; }
        public ICollection<log> logs { get; set; }
        public ICollection<compra> compras { get; set; }
        public ICollection<notificacion> notificaciones { get; set; }
  

    }
}
