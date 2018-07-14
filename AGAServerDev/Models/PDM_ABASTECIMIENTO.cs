using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGAServerDev.Models
{
    public class PDM_ABASTECIMIENTO
    {
        public int IdParte { get; set; }
        public List<PDM_COMBUSTIBLE> TablaCombustible { get; set; }
        public Decimal IdUsuario { get; set; }
    }
}