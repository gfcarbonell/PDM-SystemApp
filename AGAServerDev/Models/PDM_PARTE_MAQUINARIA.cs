using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGAServerDev.Models
{
    public class PDM_PARTE_MAQUINARIA
    {
        public int IdParteDiario { get; set; }
        public int IdParte { get; set; }
        public string IdConsumidor { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        public string IdActividad { get; set; }
        public string IdLabor { get; set; }
        public Decimal HorometroInicio { get; set; }
        public Decimal HorometroFinal { get; set; }
    }
}