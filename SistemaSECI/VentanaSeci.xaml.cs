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
    /// Lógica de interacción para VentanaSeci.xaml
    /// </summary>
    public partial class VentanaSeci : Window
    {
        public VentanaSeci()
        {
            InitializeComponent();
        }

        private void okBoton_VSeci_Click(object sender, RoutedEventArgs e)
        {
            VentanaSeciPrueba v = new VentanaSeciPrueba();
            v.Show();
            this.Close();
        }
    }
}
