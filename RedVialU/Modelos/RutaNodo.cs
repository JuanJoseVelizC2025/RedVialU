using RedVialU.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RedVialU.Modelos
{
    public class RutaNodo
    {
        public Nodo Nodo { get; set; }

        public RutaNodo Siguiente { get; set; }

        public RutaNodo(Nodo nodo)
        {
            this.Nodo = nodo;
            this.Siguiente = null;
        }

    }


}
