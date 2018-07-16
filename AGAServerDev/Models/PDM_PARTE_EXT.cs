using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AGAServerDev.Models
{
    public class PDM_PARTE_EXT
    {

        public int IdParte { get; set; }
        public DateTime Fecha { get; set; }
        public string IdSucursal { get; set; }
        public string IdMaquinaria { get; set; }
        public string IdTipoImplemento { get; set; }
        public string IdImplemento { get; set; }
        public string IdOperario { get; set; }
        public string IdTurno { get; set; }
        public string IdEstado { get; set; }
        public byte? Situacion { get; set; }

        public virtual ICollection<PDM_OPERARIO> PDM_OPERARIO { get; set; }
    }
}