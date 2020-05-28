using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adminpro.Models
{
    public class log
    {
        public int LogId { get; set; }
        public DateTime horaLog { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public usuario usuario { get; set; }

    }
}
