using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace SistemaSECI
{
    /// <summary>
    /// Lógica de interacción para VentanaComparacion.xaml
    /// </summary>
    public partial class VentanaComparacion : Window
    {
        string apoyoCerrar = "CerrarVentana";

        List<Pares> parejas = new List <Pares>();
        int idParametros;
        int idLlaves;
        List<string> seleccion = new List<string>();
        string apoyo;

        public VentanaComparacion(int idParametrosSeci, int idLlavesUI, List<string> seleccionAnterior)
        {
            idParametros = idParametrosSeci;
            idLlaves = idLlavesUI;
            seleccion = seleccionAnterior;
            int tamaño = seleccion.Count();

            for (int i = 0; i < tamaño; i++)
            {
                apoyo = seleccion.ElementAt(0);
                foreach (string x in seleccion)
                {
                    if (apoyo != x)
                        parejas.Add(new Pares(apoyo, x));
                }
                seleccion.Remove(apoyo);
            }

            foreach (Pares x in parejas)
            {
                System.Console.WriteLine("Pareja " + x.Par0 + x.Par1);
            }

            InitializeComponent();
        }


        /// Ejecuta tareas iniciales
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            switch (apoyoCerrar)
            {
                case "Cerrar":
                    e.Cancel = false;
                    break;
                case "Regresar":
                    e.Cancel = false;
                    break;
                case "CerrarVentana":
//                    VentanaHome v = new VentanaHome(idLlaves);
//                    v.Show();
                    e.Cancel = false;
                    break;
                default:
//                    VentanaHome f = new VentanaHome(idLlaves);
//                    f.Show();
                    e.Cancel = false;
                    break;
            }
        }

        private void b1_comida(object sender, RoutedEventArgs e)
        {
        }

        private void b2_comida(object sender, RoutedEventArgs e)
        {
        }

    }
}
