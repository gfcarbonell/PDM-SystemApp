using AGAServerDev.Contexts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AGAServerDev.Models
{
    public class PDM_PARTE_DIARIO
    {
        public string IdSucursal { get; set; }
        public string IdMaquinaria { get; set; }
        public string IdImplemento { get; set; }
        public string IdTipoImplemento { get; set; }
        public string IdOperario { get; set; }
        public string IdTurno { get; set; }
        public PDM_CHECKLIST[] TablaCheckList { get; set; }
        public PDM_OBSERVACION[] TablaObservacion { get; set; }
        public Decimal IdUsuario { get; set; }
    }
}