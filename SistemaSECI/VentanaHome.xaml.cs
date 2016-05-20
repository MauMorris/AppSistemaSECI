using System;
using System.Linq;
using System.Text;
using System.Windows;

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
            var salida = MessageBox.Show("¿Quieres cerrar la sesión?","Cerrar sesión", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
            if(salida.Equals(MessageBoxResult.OK))
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

        private void botonDocumentos_VHome_Click(object sender, RoutedEventArgs e)
        {
            VentanaDocumentos v = new VentanaDocumentos();
            v.Show();
        }
        private void botonBorrar_VHome_Click(object sender, RoutedEventArgs e)
        {
            var borrar = MessageBox.Show("¡Borrarás de forma permanente a este usuario!","Borrar usuario",MessageBoxButton.OKCancel,MessageBoxImage.Warning);
            if (borrar.Equals(MessageBoxResult.OK))
            {
                MessageBox.Show("Paciente borrado");
                VentanaUsuarios v = new VentanaUsuarios();
                v.Show();
                this.Close();
            }
        }
    }
}
