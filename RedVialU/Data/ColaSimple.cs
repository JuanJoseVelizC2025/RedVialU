using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedVialU.Data
{
    public class NodoColaSimple
    {
        public Nodo Valor;
        public NodoColaSimple Siguiente;

        public NodoColaSimple(Nodo valor)
        {
            Valor = valor;
            Siguiente = null;
        }
    }

    public class ColaSimpleNodo
    {
        private NodoColaSimple frente;
        private NodoColaSimple fin;

        public ColaSimpleNodo()
        {
            frente = null;
            fin = null;
        }

        public bool EstaVacia()
        {
            return frente == null;
        }

        public void Encolar(Nodo valor)
        {
            NodoColaSimple nuevo = new NodoColaSimple(valor);
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

        public Nodo Desencolar()
        {
            if (EstaVacia()) return null;

            Nodo valor = frente.Valor;
            frente = frente.Siguiente;
            if (frente == null)
                fin = null;

            return valor;
        }
    }
}
