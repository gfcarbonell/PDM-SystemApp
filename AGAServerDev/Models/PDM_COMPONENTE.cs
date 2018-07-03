namespace AGAServerDev.Contexts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PDM_COMPONENTE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PDM_COMPONENTE()
        {
            PDM_CHECKLIST = new HashSet<PDM_CHECKLIST>();
        }

        [Key]
        [StringLength(4)]
        public string IdComponente { get; set; }

        [Required]
        [StringLength(2)]
        public string IdSistema { get; set; }

        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PDM_CHECKLIST> PDM_CHECKLIST { get; set; }

        public virtual PDM_SISTEMA PDM_SISTEMA { get; set; }
    }
}
