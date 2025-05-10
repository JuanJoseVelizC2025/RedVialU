using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedVialU.Data;

namespace RedVialU.Data
{
    public class InformacionInterseccion
    {
        public int VehiculoEnEspera { get; set; }
        public string TipoViaNorte { get; set; }
        public string TipoViaSur { get; set; }
        public string TipoViaEste { get; set; }
        public string TipoViaOeste { get; set; }
        public bool TieneSemaforo { get; set; }
        public string EstadoSemaforo { get; set; }
        public double TiempoPromedioTransito { get; set; }

        public InformacionInterseccion()
        {
            VehiculoEnEspera = 0;
            TipoViaNorte = "Ninguna";
            TipoViaSur = "Ninguna";
            TipoViaEste = "Ninguna";
            TipoViaOeste = "Ninguna";
            TieneSemaforo = false;
            EstadoSemaforo = "Ninguna";
            TiempoPromedioTransito = 0.0;
        }
    }
}
