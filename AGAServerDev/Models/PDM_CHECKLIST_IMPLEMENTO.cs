using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGAServerDev.Models
{
    public class PDM_CHECKLIST_IMPLEMENTO
    {
        public string IdSistema { get; set; }
        public string Sistema { get; set; }
        public string IdComponente { get; set; }
        public string Componente { get; set; }
        public Byte Situacion { get; set; }
    }
}