namespace AGAServerDev.Contexts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PDM_ESTADO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PDM_ESTADO()
        {
            PDM_PARTE = new HashSet<PDM_PARTE>();
        }

        [Key]
        [StringLength(2)]
        public string IdEstado { get; set; }

        [StringLength(40)]
        public string Descripcion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PDM_PARTE> PDM_PARTE { get; set; }
    }
}
