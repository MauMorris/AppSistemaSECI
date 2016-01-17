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
    /// Lógica de interacción para VentanaUsuarios.xaml
    /// </summary>
    public partial class VentanaUsuarios : Window
    {
        public VentanaUsuarios()
        {
            InitializeComponent();
        }

        private void botonUsuarioNuevo_VUsuarios_Click(object sender, RoutedEventArgs e)
        {
            VentanaNuevoUsuario v = new VentanaNuevoUsuario();
            v.Show();
            this.Close();
        }

        private void botonUsuarioExistente_VUsuarios_Click(object sender, RoutedEventArgs e)
        {
            VentanaUsuarioReciente v = new VentanaUsuarioReciente();
            v.Show();
            this.Close();
        }
    }
}
