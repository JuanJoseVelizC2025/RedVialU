using RedVialU.Data;
using RedVialU.Modelos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace RedVialU
{
    public partial class Form1 : Form
    {
        private RedVial redVial;

        public Form1()
        {
            InitializeComponent();
            redVial = new RedVial();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var infoCentral = new InformacionInterseccion
            {
                VehiculoEnEspera = 10,
                TipoViaNorte = "Avenida",
                TipoViaSur = "Calle",
                TipoViaEste = "Avenida",
                TipoViaOeste = "Calle",
                TieneSemaforo = true,
                EstadoSemaforo = "Verde",
                TiempoPromedioTransito = 5
            };

            redVial.EstablecerInterseccionCentral(infoCentral);

            DibujarRedInicial();
            LlenarComboBoxConNodos();
        }

        private void DibujarRedInicial()
        {
            panelMapa.Controls.Clear();

            int xCentro = panelMapa.Width / 2;
            int yCentro = panelMapa.Height / 2;
            int size = 60;

            redVial.InterseccionCentral.Nombre = "Centro";

            DibujarNodo(redVial.InterseccionCentral, xCentro, yCentro, "Centro");

            Nodo nodoNorte = new Nodo(new InformacionInterseccion { VehiculoEnEspera = 3, TieneSemaforo = true, EstadoSemaforo = "Rojo" }) { Nombre = "Norte" };
            Nodo nodoSur = new Nodo(new InformacionInterseccion { VehiculoEnEspera = 7, TieneSemaforo = false }) { Nombre = "Sur" };
            Nodo nodoEste = new Nodo(new InformacionInterseccion { VehiculoEnEspera = 5 }) { Nombre = "Este" };
            Nodo nodoOeste = new Nodo(new InformacionInterseccion { VehiculoEnEspera = 8, TieneSemaforo = true, EstadoSemaforo = "Amarillo" }) { Nombre = "Oeste" };

            redVial.ConectarNorte(redVial.InterseccionCentral, nodoNorte);
            redVial.ConectarSur(redVial.InterseccionCentral, nodoSur);
            redVial.ConectarEste(redVial.InterseccionCentral, nodoEste);
            redVial.ConectarOeste(redVial.InterseccionCentral, nodoOeste);

            DibujarNodo(nodoNorte, xCentro, yCentro - (size + 40), "Norte");
            DibujarNodo(nodoSur, xCentro, yCentro + (size + 40), "Sur");
            DibujarNodo(nodoEste, xCentro + (size + 40), yCentro, "Este");
            DibujarNodo(nodoOeste, xCentro - (size + 40), yCentro, "Oeste");
        }

        private void DibujarNodo(Nodo nodo, int x, int y, string texto)
        {
            Button btn = new Button
            {
                Width = 60,
                Height = 60,
                Left = x - 30,
                Top = y - 30,
                Text = texto,
                BackColor = nodo.Info.TieneSemaforo
                    ? nodo.Info.EstadoSemaforo == "Verde" ? Color.Green
                    : nodo.Info.EstadoSemaforo == "Rojo" ? Color.Red
                    : Color.Yellow
                    : Color.Gray,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btn, $"Vehículos: {nodo.Info.VehiculoEnEspera}\n" +
                $"Tiempo: {nodo.Info.TiempoPromedioTransito} min\n" +
                $"Semáforo: {(nodo.Info.TieneSemaforo ? nodo.Info.EstadoSemaforo : "No tiene")}");

            panelMapa.Controls.Add(btn);
        }

        private void btnSimularFlujo_Click(object sender, EventArgs e)
        {
            Nodo origen = redVial.InterseccionCentral;
            Nodo destino = origen.Norte;

            if (destino != null)
            {
                redVial.SimularFlujoVehiculos(origen, destino, 3);
                MessageBox.Show("Se movieron 3 vehículos del nodo central al nodo norte.");
                DibujarRedInicial();
                LlenarComboBoxConNodos();
            }
            else
            {
                MessageBox.Show("No hay nodo conectado al norte.");
            }
        }

        private void btnMayorCongestion_Click(object sender, EventArgs e)
        {
            Nodo congestionado = redVial.ObtenerInterseccionMasCongestionada();
            if (congestionado != null)
            {
                MessageBox.Show($"La intersección más congestionada tiene {congestionado.Info.VehiculoEnEspera} vehículos en espera.");
            }
            else
            {
                MessageBox.Show("No se encontraron intersecciones.");
            }
        }

        private void LlenarComboBoxConNodos()
        {
            cbOrigen.Items.Clear();
            cbDestino.Items.Clear();

            RutaEnlazada nodos = ObtenerTodosLosNodos();
            RutaNodo actual = nodos.Cabeza;

            while (actual != null)
            {
                cbOrigen.Items.Add(actual.Nodo);
                cbDestino.Items.Add(actual.Nodo);
                actual = actual.Siguiente;
            }

            cbOrigen.DisplayMember = "Nombre";
            cbDestino.DisplayMember = "Nombre";
        }


        private RutaEnlazada ObtenerTodosLosNodos()
        {
            RutaEnlazada visitados = new RutaEnlazada();
            RutaEnlazada lista = new RutaEnlazada();
            ColaSimpleNodo cola = new ColaSimpleNodo(); // Usa la nueva cola

            cola.Encolar(redVial.InterseccionCentral);

            while (!cola.EstaVacia())
            {
                Nodo actual = cola.Desencolar();

                if (visitados.Contiene(actual)) continue;

                visitados.Agregar(actual);
                lista.Agregar(actual);

                if (actual.Norte != null) cola.Encolar(actual.Norte);
                if (actual.Sur != null) cola.Encolar(actual.Sur);
                if (actual.Este != null) cola.Encolar(actual.Este);
                if (actual.Oeste != null) cola.Encolar(actual.Oeste);
            }

            return lista;
        }


        private void btnCalcularTiempo_Click(object sender, EventArgs e)
        {
            Nodo origen = cbOrigen.SelectedItem as Nodo;
            Nodo destino = cbDestino.SelectedItem as Nodo;

            if (origen != null && destino != null)
            {
                int tiempo = redVial.CalcularTiempoEstimado(origen, destino);
                if (tiempo >= 0)
                {
                    MessageBox.Show($"El tiempo estimado de recorrido es: {tiempo} unidades.");
                }
                else
                {
                    MessageBox.Show("No se encontró una ruta entre los nodos seleccionados.");
                }
            }
            else
            {
                MessageBox.Show("Por favor selecciona ambos nodos.");
            }
        }

        private void btnBuscarRuta_Click(object sender, EventArgs e)
        {
            Nodo origen = cbOrigen.SelectedItem as Nodo;
            Nodo destino = cbDestino.SelectedItem as Nodo;

            if (origen == null || destino == null)
            {
                MessageBox.Show("Seleccione ambos nodos.");
                return;
            }

            var ruta = redVial.BuscarRuta(origen, destino);

            if (ruta == null)
            {
                MessageBox.Show("No se encontró una ruta.");
                return;
            }

            MessageBox.Show("Ruta encontrada:\n" + ruta.ToString());

            DibujarRedInicial(); // (opcional) vuelve a pintar la red
        }

        private void panelMapa_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

