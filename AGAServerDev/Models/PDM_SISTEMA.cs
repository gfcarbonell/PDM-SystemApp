namespace AGAServerDev.Contexts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PDM_SISTEMA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PDM_SISTEMA()
        {
            PDM_CHECKLIST = new HashSet<PDM_CHECKLIST>();
            PDM_COMPONENTE = new HashSet<PDM_COMPONENTE>();
            PDM_OBSERVACION = new HashSet<PDM_OBSERVACION>();
        }

        [Key]
        [StringLength(2)]
        public string IdSistema { get; set; }

        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }

        [StringLength(2)]
        public string IdTipoImplemento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PDM_CHECKLIST> PDM_CHECKLIST { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PDM_COMPONENTE> PDM_COMPONENTE { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PDM_OBSERVACION> PDM_OBSERVACION { get; set; }

        public virtual PDM_TIPO_IMPLEMENTO PDM_TIPO_IMPLEMENTO { get; set; }
    }
}
