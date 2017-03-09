using System.ComponentModel;
using System.Windows;

namespace SistemaSECI
{
    /// Interaction logic for VentanaEjemplosKinect.xaml
    public partial class VentanaEjemplosKinect : Window
    {
        int LlavesUsuarioImc = 0;
        string apoyoCerrar = "CerrarVentana";
        public VentanaEjemplosKinect(int idLlaves)
        {
            InitializeComponent();
            LlavesUsuarioImc = idLlaves;
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
                    VentanaHome v = new VentanaHome(LlavesUsuarioImc);
                    v.Show();
                    e.Cancel = false;
                    break;
                default:
                    VentanaHome f = new VentanaHome(LlavesUsuarioImc);
                    f.Show();
                    e.Cancel = false;
                    break;
            }
        }

        private void botonN1_VNiveles_Click(object sender, RoutedEventArgs e)
        {
            apoyoCerrar = "Jugar";
            VentanaBodyBasics v = new VentanaBodyBasics(1, 4, 3);
            v.Show();
            this.Close();
        }

        private void botonN2_VNiveles_Click(object sender, RoutedEventArgs e)
        {
            apoyoCerrar = "Jugar";
            VentanaBodyBasics v = new VentanaBodyBasics(2, 4, 3);
            v.Show();
            this.Close();
        }

        private void botonN3_VNiveles_Click(object sender, RoutedEventArgs e)
        {
            apoyoCerrar = "Jugar";
            VentanaBodyBasics v = new VentanaBodyBasics(3, 6, 4);
            v.Show();
            this.Close();
        }

        private void botonN4_VNiveles_Click(object sender, RoutedEventArgs e)
        {
            apoyoCerrar = "Jugar";
            VentanaBodyBasics v = new VentanaBodyBasics(4, 6, 4);
            v.Show();
            this.Close();
        }

        private void botonN5_VNiveles_Click(object sender, RoutedEventArgs e)
        {
            apoyoCerrar = "Jugar";
            VentanaBodyBasics v = new VentanaBodyBasics(5, 7, 5);
            v.Show();
            this.Close();
        }

        private void botonN6_VNiveles_Click(object sender, RoutedEventArgs e)
        {
            apoyoCerrar = "Jugar";
            VentanaBodyBasics v = new VentanaBodyBasics(6, 7, 5);
            v.Show();
            this.Close();
        }

        private void botonN7_VNiveles_Click(object sender, RoutedEventArgs e)
        {
            apoyoCerrar = "Jugar";
            VentanaBodyBasics v = new VentanaBodyBasics(7, 7, 5);
            v.Show();
            this.Close();
        }

        private void botonN8_VNiveles_Click(object sender, RoutedEventArgs e)
        {
            apoyoCerrar = "Jugar";
            VentanaBodyBasics v = new VentanaBodyBasics(8, 8, 5);
            v.Show();
            this.Close();
        }

        private void botonN9_VNiveles_Click(object sender, RoutedEventArgs e)
        {
            apoyoCerrar = "Jugar";
            VentanaBodyBasics v = new VentanaBodyBasics(9, 8, 5);
            v.Show();
            this.Close();
        }

        private void botonRegresar_VNiveles_Click(object sender, RoutedEventArgs e)
        {
            apoyoCerrar = "Regresar";
            VentanaJuego v = new VentanaJuego(LlavesUsuarioImc);
            v.Show();
            this.Close();
        }
    }
}
