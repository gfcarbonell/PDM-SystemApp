namespace AGAServerDev.Contexts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PDM_CHECKLIST
    {
        [Key]
        public int IdCheckList { get; set; }

        public int IdParte { get; set; }

        [Required]
        [StringLength(2)]
        public string IdSistema { get; set; }

        [Required]
        [StringLength(4)]
        public string IdComponente { get; set; }

        public byte Estado { get; set; }

        public byte? Situacion { get; set; }

        public virtual PDM_COMPONENTE PDM_COMPONENTE { get; set; }

        public virtual PDM_PARTE PDM_PARTE { get; set; }

        public virtual PDM_SISTEMA PDM_SISTEMA { get; set; }
    }
}
