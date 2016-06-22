using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace SistemaSECI
{
    /// <summary>
    /// Lógica de interacción para VentanaUsuarios.xaml
    /// </summary>
    public partial class VentanaUsuarios : Window
    {
        public VentanaUsuarios()
        {
            InitializeComponent();
        }

        private void botonUNuevo_VUsuarios_Click(object sender, RoutedEventArgs e)
        {
            VentanaNuevoUsuario v = new VentanaNuevoUsuario();
            v.Show();
            this.Close();
        }

        private void botonUExistente_VUsuarios_Click(object sender, RoutedEventArgs e)
        {
            VentanaUsuarioReciente v = new VentanaUsuarioReciente();
            v.Show();
            this.Close();
        }
    }
}
