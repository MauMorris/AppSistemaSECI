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
    /// Lógica de interacción para VentanaSeciPrueba.xaml
    /// </summary>
    public partial class VentanaSeciPrueba : Window
    {
        public VentanaSeciPrueba()
        {
            InitializeComponent();
        }

        private void regresarBoton_VLogros_Click(object sender, RoutedEventArgs e)
        {
            VentanaHome v = new VentanaHome();
            v.Show();
            this.Close();
        }

        private void okBoton_VSeci_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
