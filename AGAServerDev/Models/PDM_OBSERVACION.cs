namespace AGAServerDev.Contexts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PDM_OBSERVACION
    {
        [Key]
        public int IdObservacion { get; set; }

        public int IdParte { get; set; }

        [Required]
        [StringLength(2)]
        public string IdSistema { get; set; }

        [Required]
        [StringLength(150)]
        public string Observacion { get; set; }

        [StringLength(3)]
        public string IdAccion { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? FechaAprobacion { get; set; }

        public byte? UsuarioAprobacion { get; set; }

        public virtual PDM_ACCION PDM_ACCION { get; set; }

        public virtual PDM_PARTE PDM_PARTE { get; set; }

        public virtual PDM_SISTEMA PDM_SISTEMA { get; set; }
    }
}
