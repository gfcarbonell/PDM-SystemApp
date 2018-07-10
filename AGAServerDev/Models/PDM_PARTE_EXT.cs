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

        public PDM_PARTE_EXT()
        {
            PDM_OPERARIO = new HashSet<PDM_OPERARIO>();
        }


        public int IdParte { get; set; }

        [Column(TypeName = "date")]
        public DateTime Fecha { get; set; }

        [Required]
        [StringLength(3)]
        public string IdSucursal { get; set; }

        [Required]
        [StringLength(12)]
        public string IdMaquinaria { get; set; }

        [Required]
        [StringLength(2)]
        public string IdTipoImplemento { get; set; }

        [Required]
        [StringLength(12)]
        public string IdImplemento { get; set; }

        [Required]
        [StringLength(6)]
        public string IdOperario { get; set; }

        [Required]
        [StringLength(2)]
        public string IdTurno { get; set; }

        [StringLength(2)]
        public string IdEstado { get; set; }

        public byte? Situacion { get; set; }

        public virtual ICollection<PDM_OPERARIO> PDM_OPERARIO { get; set; }
    }
}