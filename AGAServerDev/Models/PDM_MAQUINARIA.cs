using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGAServerDev.Models
{
    public class PDM_MAQUINARIA
    {
        public string IdConsumidor { get; set; }
        public string Descripcion { get; set; }
        public string IdSucursal { get; set; }
        public string TipoMaquina { get; set; }
        public Decimal Estado { get; set; }
    }
}