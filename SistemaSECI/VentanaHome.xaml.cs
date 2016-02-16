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
    /// Lógica de interacción para VentanaHome.xaml
    /// </summary>
    public partial class VentanaHome : Window
    {
        public VentanaHome()
        {
            InitializeComponent();
        }

        private void botonKinect_VHome_Click(object sender, RoutedEventArgs e)
        {
            VentanaJuego v = new VentanaJuego();
            v.Show();
            this.Close();
        }
        private void botonSeci_VHome_Click(object sender, RoutedEventArgs e)
        {
            VentanaSeci v = new VentanaSeci();
            v.Show();
            this.Close();
        }
        private void botonPlanAlimentacion_VHome_Click(object sender, RoutedEventArgs e)
        {
            VentanaDieta v = new VentanaDieta();
            v.Show();
            this.Close();
        }
        private void regresarBoton_VHome_Click(object sender, RoutedEventArgs e)
        {
            VentanaUsuarios v = new VentanaUsuarios();
            v.Show();
            this.Hide();
        }
        private void botonSalir_VHome_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("¿Estás seguro?");
            this.Close();
        }

        private void botonActualizar_VHome_Click(object sender, RoutedEventArgs e)
        {
            VentanaModificarSimple v = new VentanaModificarSimple();
            v.Show();
        }
        private void botonModificar_VHome_Click(object sender, RoutedEventArgs e)
        {
            VentanaModificar v = new VentanaModificar();
            v.Show();
        }
    }
}
