using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGAServerDev.Models
{
    public class AUTH_USER
    { 
        public Int16 CodUsuario { get; set; }
        public string Usuario { get; set; }
        public string Nombre { get; set; }
        public string Contrasenia { get; set; }
        public string CodSucursal { get; set; }
        public string CodModulo { get; set; }
    }
}