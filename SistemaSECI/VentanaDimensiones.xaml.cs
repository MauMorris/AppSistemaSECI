using System.ComponentModel;
using System.Windows;

namespace SistemaSECI
{
    /// <summary>
    /// Lógica de interacción para VentanaDimensiones.xaml
    /// </summary>
    public partial class VentanaDimensiones : Window
    {
        string apoyoCerrar = "CerrarVentana";

        public VentanaDimensiones()
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
