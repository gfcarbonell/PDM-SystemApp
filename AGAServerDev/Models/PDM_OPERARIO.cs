using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGAServerDev.Models
{
    public class PDM_OPERARIO
    {
        public string IdOperario { get; set; }
        public string IdPersonal { get; set; }
        public string Nombre { get; set; }
        public Decimal Estado { get; set; }
        public Decimal Maquinaria { get; set; }

        public virtual PDM_PARTE_EXT PDM_PARTE_EXT { get; set; }
    }
}