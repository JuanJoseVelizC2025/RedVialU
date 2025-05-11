using RedVialU.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedVialU.Data
{
    public class NodoColaRuta
    {
        public RutaEnlazada Ruta;
        public NodoColaRuta Siguiente;

        public NodoColaRuta(RutaEnlazada ruta)
        {
            Ruta = ruta;
            Siguiente = null;
        }
    }

    public class ColaNodo
    {
        private NodoColaRuta frente;
        private NodoColaRuta fin;

        public ColaNodo()
        {
            frente = null;
            fin = null;
        }

        public bool EstaVacia()
        {
            return frente == null;
        }

        public void Encolar(RutaEnlazada ruta)
        {
            NodoColaRuta nuevo = new NodoColaRuta(ruta);
            if (EstaVacia())
            {
                frente = nuevo;
                fin = nuevo;
            }
            else
            {
                fin.Siguiente = nuevo;
                fin = nuevo;
            }
        }

        public RutaEnlazada Desencolar()
        {
            if (EstaVacia())
                return null;

            RutaEnlazada ruta = frente.Ruta;
            frente = frente.Siguiente;
            if (frente == null)
                fin = null;
            return ruta;
        }
        
    }
}
