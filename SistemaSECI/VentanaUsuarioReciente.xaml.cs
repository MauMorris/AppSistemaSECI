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
    /// Lógica de interacción para VentanaUsuarioReciente.xaml
    /// </summary>
    public partial class VentanaUsuarioReciente : Window
    {
        public VentanaUsuarioReciente()
        {
            InitializeComponent();
        }

        private void okBoton_VUsuarioReciente_Click(object sender, RoutedEventArgs e)
        {
            VentanaHome v = new VentanaHome();
            v.Show();
            this.Close();
        }

        private void regresarBoton_VUsuarioReciente_Click(object sender, RoutedEventArgs e)
        {
            VentanaUsuarios v = new VentanaUsuarios();
            v.Show();
            this.Close();
        }
    }
}
