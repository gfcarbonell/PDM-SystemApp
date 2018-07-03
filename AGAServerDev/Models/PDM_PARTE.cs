namespace AGAServerDev.Contexts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PDM_PARTE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PDM_PARTE()
        {
            PDM_CHECKLIST = new HashSet<PDM_CHECKLIST>();
            PDM_OBSERVACION = new HashSet<PDM_OBSERVACION>();
        }

        [Key]
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

        [Column(TypeName = "smalldatetime")]
        public DateTime FechaCreacion { get; set; }

        public short UsuarioCreacion { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? FechaModificacion { get; set; }

        public short? UsuarioModificacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PDM_CHECKLIST> PDM_CHECKLIST { get; set; }

        public virtual PDM_ESTADO PDM_ESTADO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PDM_OBSERVACION> PDM_OBSERVACION { get; set; }

        public virtual PDM_TIPO_IMPLEMENTO PDM_TIPO_IMPLEMENTO { get; set; }
    }
}
