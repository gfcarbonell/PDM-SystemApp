namespace AGAServerDev.Contexts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PDM_ACCION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PDM_ACCION()
        {
            PDM_OBSERVACION = new HashSet<PDM_OBSERVACION>();
        }

        [Key]
        [StringLength(3)]
        public string IdAccion { get; set; }

        [Required]
        [StringLength(80)]
        public string Descripcion { get; set; }

        public byte Aplica { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PDM_OBSERVACION> PDM_OBSERVACION { get; set; }
    }
}
