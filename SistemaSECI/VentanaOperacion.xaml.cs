using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SistemaSECI
{
    /// <summary>
    /// Lógica de interacción para VentanaOperacion.xaml
    /// </summary>
    public partial class VentanaOperacion : Window
    {
        string apoyoCerrar = "CerrarVentana";

        public VentanaOperacion()
        {
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

    }
}
