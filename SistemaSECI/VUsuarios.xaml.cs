using System.ComponentModel;
using System.Windows;

namespace SistemaSECI
{
    /// <summary>
    /// Lógica de interacción para VentanaUsuarios.xaml
    /// </summary>
    public partial class VUsuarios : Window
    {
        string accion = string.Empty;

        public VUsuarios()
        {
            InitializeComponent();
        }

        /// Ejecuta cuando cierras la ventana
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if(accion == string.Empty)
            {
                var salida = MessageBox.Show("¿Estas seguro de querer salir del programa?", "Salir del programa", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
                if (salida.Equals(MessageBoxResult.OK))
                    e.Cancel = false;
                else
                    e.Cancel = true;
            }
        }

        private void botonUNuevo_VUsuarios_Click(object sender, RoutedEventArgs e) //abre ventana de nuevo usuario
        {
            accion = "usuarioNuevo";
            VentanaNuevoUsuario v = new VentanaNuevoUsuario();
            v.Show();
            this.Close();
        }

        private void botonUExistente_VUsuarios_Click(object sender, RoutedEventArgs e)//abre ventana de usuario existente
        {
            accion = "usuarioExistente";
            VentanaUsuarioReciente v = new VentanaUsuarioReciente();
            v.Show();
            this.Close();
        }
    }
}
