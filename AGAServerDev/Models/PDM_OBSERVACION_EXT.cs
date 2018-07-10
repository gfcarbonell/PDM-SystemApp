using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGAServerDev.Models
{
    public class PDM_OBSERVACION_EXT
    {
        public int IdParte { get; set; }
        public string IdSistema { get; set; }
        public string Sistema { get; set; }
        public int IdObservacion { get; set; }
        public string Observacion { get; set; }
        public string IdAccion { get; set; }
        public string Accion { get; set; }
        public byte Aplica { get; set; }
    }
}