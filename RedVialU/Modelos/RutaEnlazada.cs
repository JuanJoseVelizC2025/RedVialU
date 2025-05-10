using RedVialU.Data;
using RedVialU.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedVialU.Data
{
    public class RutaEnlazada
    {
        public RutaNodo Cabeza;

        public RutaEnlazada()
        {
            Cabeza = null;
        }

        public void Agregar(Nodo nodo)
        {
            RutaNodo nuevo = new RutaNodo(nodo);

            if (Cabeza == null)
            {
                Cabeza = nuevo;
            }
            else
            {
                RutaNodo actual = Cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevo;
            }
        }

        public bool Contiene(Nodo nodo)
        {
            RutaNodo actual = Cabeza;
            while (actual != null)
            {
                if (actual.Nodo == nodo)
                    return true;
                actual = actual.Siguiente;
            }
            return false;
        }

        public RutaEnlazada ClonarYAgregar(Nodo nuevoNodo)
        {
            RutaEnlazada clon = new RutaEnlazada();
            RutaNodo actual = Cabeza;

            while (actual != null)
            {
                clon.Agregar(actual.Nodo);
                actual = actual.Siguiente;
            }

            clon.Agregar(nuevoNodo);
            return clon;
        }

        public override string ToString()
        {
            RutaNodo actual = Cabeza;
            string ruta = "";
            while (actual != null)
            {
                ruta += actual.Nodo.Nombre;
                if (actual.Siguiente != null)
                    ruta += "->";
                actual = actual.Siguiente;
            }
            return ruta;
        }
    }
}

