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
        public int IdParte { get; set; }
        public string IdSucursal { get; set; }
        public string IdMaquinaria { get; set; }
        public string IdImplemento { get; set; }
        public string IdTipoImplemento { get; set; }
        public string IdOperario { get; set; }
        public string IdTurno { get; set; }
        public string IdEstado { get; set; }
        public DateTime? Fecha { get; set; }
        public List<PDM_CHECKLIST> PDM_CHECKLIST { get; set; }
        public List<PDM_OBSERVACION> PDM_OBSERVACION { get; set; }
        public Decimal IdUsuario { get; set; }
    }
}