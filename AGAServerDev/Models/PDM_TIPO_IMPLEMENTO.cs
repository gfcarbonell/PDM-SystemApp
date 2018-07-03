namespace AGAServerDev.Contexts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PDM_TIPO_IMPLEMENTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PDM_TIPO_IMPLEMENTO()
        {
            PDM_PARTE = new HashSet<PDM_PARTE>();
            PDM_SISTEMA = new HashSet<PDM_SISTEMA>();
        }

        [Key]
        [StringLength(2)]
        public string IdTipoImplemento { get; set; }

        [Required]
        [StringLength(30)]
        public string Descripcion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PDM_PARTE> PDM_PARTE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PDM_SISTEMA> PDM_SISTEMA { get; set; }
    }
}
