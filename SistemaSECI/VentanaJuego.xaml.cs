using System.ComponentModel;
using System.Windows;

namespace SistemaSECI
{
    /// <summary>
    /// Lógica de interacción para VentanaJuego.xaml
    /// </summary>
    public partial class VentanaJuego : Window
    {
        int idLlaves = 0;
        string apoyoCerrar = "CerrarVentana";

        TablasDBHelper DBUsuario;

        public VentanaJuego(int id)
        {
            InitializeComponent();
            DBUsuario = new TablasDBHelper();
            idLlaves = id;
        }

        /// Ejecuta tareas iniciales
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            switch (apoyoCerrar)
            {
                case "Regresar":
                    e.Cancel = false;
                    break;
                case "Jugar":
                    e.Cancel = false;
                    break;
                case "CerrarVentana":
                    VentanaHome v = new VentanaHome(idLlaves);
                    v.Show();
                    e.Cancel = false;
                    break;
                default:
                    VentanaHome f = new VentanaHome(idLlaves);
                    f.Show();
                    e.Cancel = false;
                    break;
            }
        }

        private void botonLogros_VInicioJuego_Click(object sender, RoutedEventArgs e)
        {
            VentanaLogros v = new VentanaLogros();
            v.Owner = this;
            v.ShowDialog();
        }
        private void botonAjustesPrograma_VInicioJuego_Click(object sender, RoutedEventArgs e)
        {
            VentanaAjustesPrograma v = new VentanaAjustesPrograma();
            v.Owner = this;
            v.ShowDialog();
        }
        private void botonJugar_VInicioJuego_Click(object sender, RoutedEventArgs e)
        {
            apoyoCerrar = "Jugar";
            VentanaEjemplosKinect v = new VentanaEjemplosKinect(idLlaves);
            v.Show();
            this.Close();
        }
        private void botonRegresar_VInicioJuego_Click(object sender, RoutedEventArgs e)
        {
            apoyoCerrar = "Regresar";
            VentanaHome v = new VentanaHome(idLlaves);
            v.Show();
            this.Close();
        }
    }
}
