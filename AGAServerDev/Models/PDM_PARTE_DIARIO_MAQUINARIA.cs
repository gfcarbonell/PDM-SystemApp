using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGAServerDev.Models
{
    public class PDM_PARTE_DIARIO_MAQUINARIA
    {
        public int IdParte { get; set; }
        public List<PDM_PARTE_MAQUINARIA> TablaDiario { get; set; }
        public int IdUsuario { get; set; }
    }
}