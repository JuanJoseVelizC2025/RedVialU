using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedVialU.Data;


namespace RedVialU.Data
{
    public class Nodo
    {
        
       public string Nombre { get; set; }
        public InformacionInterseccion Info { get; set; }

        public Nodo Norte { get; set; }
        public Nodo Sur { get; set; }
        public Nodo Este { get; set; }
        public Nodo Oeste { get; set; }
        public int PosicionX { get; set; }
        public int PosicionY { get; set; }


        public Nodo(InformacionInterseccion info)
        {
            Info = info;
            Norte = null;
            Sur = null;
            Este = null;
            Oeste = null;

        }
            
    }
}

