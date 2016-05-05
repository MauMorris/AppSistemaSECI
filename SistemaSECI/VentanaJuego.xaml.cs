using System;
using System.Collections.Generic;
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
    /// Lógica de interacción para VentanaJuego.xaml
    /// </summary>
    public partial class VentanaJuego : Window
    {
        public VentanaJuego()
        {
            InitializeComponent();
        }
        private void botonEstadisticasUsuario_VInicioJuego_Click(object sender, RoutedEventArgs e)
        {
            VentanaEstadisticas v = new VentanaEstadisticas();
            v.Show();
        }
        private void botonLogros_VInicioJuego_Click(object sender, RoutedEventArgs e)
        {
            VentanaLogros v = new VentanaLogros();
            v.Show();
        }
        private void botonAjustesPrograma_VInicioJuego_Click(object sender, RoutedEventArgs e)
        {
        }
        private void botonJugar_VInicioJuego_Click(object sender, RoutedEventArgs e)
        {
            VentanaEjemplosKinect v = new VentanaEjemplosKinect();
            v.Show();
            this.Close();
        }
        private void botonRegresar_VInicioJuego_Click(object sender, RoutedEventArgs e)
        {
            VentanaHome v = new VentanaHome();
            v.Show();
            this.Close();
        }
    }
}
