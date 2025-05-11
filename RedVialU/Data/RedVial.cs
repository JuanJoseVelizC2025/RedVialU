using RedVialU.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RedVialU.Data
{
    public class RedVial
    {
        public Nodo? InterseccionCentral { get; set; }
        

        public RedVial()
        {
            InterseccionCentral = null;
        }

        public void EstablecerInterseccionCentral(InformacionInterseccion info)
        {
            InterseccionCentral = new Nodo(info);
        }

        public void ConectarNorte(Nodo origen, Nodo destino)
        {
            origen.Norte = destino;
            destino.Sur = origen;
        }

        public void ConectarSur(Nodo origen, Nodo destino)
        {
            origen.Sur = destino;
            destino.Norte = origen;
        }

        public void ConectarEste(Nodo origen, Nodo destino)
        {
            origen.Este = destino;
            destino.Oeste = origen;
        }

        public void ConectarOeste(Nodo origen, Nodo destino)
        {
            origen.Oeste = destino;
            destino.Este = origen;
        }

        public void SimularFlujoVehiculos(Nodo origen, Nodo destino, int cantidad)
        {
            if (origen.Info.VehiculoEnEspera >= cantidad)
            {
                origen.Info.VehiculoEnEspera -= cantidad;
                destino.Info.VehiculoEnEspera += cantidad;
            }
        }

        public Nodo ObtenerInterseccionMasCongestionada()
        {
            Nodo nodoMasCongestionado = null;
            int maxVehiculos = -1;

            HashSet<Nodo> visitados = new HashSet<Nodo>();
            Queue<Nodo> cola = new Queue<Nodo>();
            cola.Enqueue(InterseccionCentral);

            while (cola.Count > 0)
            {
                Nodo actual = cola.Dequeue();
                if (visitados.Contains(actual)) continue;

                visitados.Add(actual);

                if (actual.Info.VehiculoEnEspera > maxVehiculos)
                {
                    maxVehiculos = actual.Info.VehiculoEnEspera;
                    nodoMasCongestionado = actual;
                }

                if (actual.Norte != null) cola.Enqueue(actual.Norte);
                if (actual.Sur != null) cola.Enqueue(actual.Sur);
                if (actual.Este != null) cola.Enqueue(actual.Este);
                if (actual.Oeste != null) cola.Enqueue(actual.Oeste);
            }

            return nodoMasCongestionado;
        }

        public int CalcularTiempoEstimado(Nodo origen, Nodo destino)
        {
            if (origen == null || destino == null) return -1;

            Dictionary<Nodo, int> tiempos = new Dictionary<Nodo, int>();
            Queue<Nodo> cola = new Queue<Nodo>();
            HashSet<Nodo> visitados = new HashSet<Nodo>();

            cola.Enqueue(origen);
            tiempos[origen] = (int)origen.Info.TiempoPromedioTransito;

            while (cola.Count > 0)
            {
                Nodo actual = cola.Dequeue();
                if (actual == destino)
                    return tiempos[actual];

                visitados.Add(actual);

                Nodo[] vecinos = new Nodo[4];
                vecinos[0] = actual.Norte;
                vecinos[1] = actual.Sur;
                vecinos[2] = actual.Este;
                vecinos[3] = actual.Oeste;

                foreach (var vecino in vecinos)
                {
                    if (vecino != null && !visitados.Contains(vecino))
                    {
                        if (!tiempos.ContainsKey(vecino) || tiempos[vecino] > tiempos[actual] + vecino.Info.TiempoPromedioTransito)
                        {
                            tiempos[vecino] = (int)(tiempos[actual] + vecino.Info.TiempoPromedioTransito);
                            cola.Enqueue(vecino);
                        }
                    }
                }
            }

            return -1;
        }

        public (RutaEnlazada ruta, int tiempoTotal) SimularRutaVehicular(Nodo origen, Nodo destino, int cantidadVehiculos)
        {
            if (origen == null || destino == null)
                return (null, -1);

            ColaNodo cola = new ColaNodo(); // Cola de rutas
            RutaEnlazada rutaInicial = new RutaEnlazada();
            rutaInicial.Agregar(origen);
            cola.Encolar(rutaInicial);

            RutaEnlazada visitados = new RutaEnlazada();

            while (!cola.EstaVacia())
            {
                RutaEnlazada rutaActual = cola.Desencolar();
                RutaNodo actualRutaNodo = rutaActual.Cabeza;

                // Obtener el último nodo de la ruta
                while (actualRutaNodo.Siguiente != null)
                    actualRutaNodo = actualRutaNodo.Siguiente;

                Nodo actual = actualRutaNodo.Nodo;

                if (actual == destino)
                {
                    int tiempoTotal = 0;
                    RutaNodo nodoRuta = rutaActual.Cabeza;

                    while (nodoRuta != null && nodoRuta.Siguiente != null)
                    {
                        Nodo desde = nodoRuta.Nodo;
                        Nodo hacia = nodoRuta.Siguiente.Nodo;

                        tiempoTotal += (int)desde.Info.TiempoPromedioTransito;

                        if (desde.Info.TieneSemaforo && desde.Info.EstadoSemaforo == "Rojo")
                            tiempoTotal += 3;

                        SimularFlujoVehiculos(desde, hacia, cantidadVehiculos);

                        nodoRuta = nodoRuta.Siguiente;
                    }

                    return (rutaActual, tiempoTotal);
                }

                if (!visitados.Contiene(actual))
                {
                    visitados.Agregar(actual);

                    // Explorar vecinos
                    if (actual.Norte != null && !rutaActual.Contiene(actual.Norte))
                        cola.Encolar(rutaActual.ClonarYAgregar(actual.Norte));

                    if (actual.Sur != null && !rutaActual.Contiene(actual.Sur))
                        cola.Encolar(rutaActual.ClonarYAgregar(actual.Sur));

                    if (actual.Este != null && !rutaActual.Contiene(actual.Este))
                        cola.Encolar(rutaActual.ClonarYAgregar(actual.Este));

                    if (actual.Oeste != null && !rutaActual.Contiene(actual.Oeste))
                        cola.Encolar(rutaActual.ClonarYAgregar(actual.Oeste));
                }
            }

            return (null, -1); // No se encontró una ruta
        }

        



    }
}

