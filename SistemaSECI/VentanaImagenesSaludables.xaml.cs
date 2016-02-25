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
    /// Interaction logic for VentanaImagenesSaludables.xaml
    /// </summary>
    public partial class VentanaImagenesSaludables : Window
    {
        public VentanaImagenesSaludables()
        {
            InitializeComponent();
        }

        private void botonSiguiente_Click(object sender, RoutedEventArgs e)
        {
            VentanaImagenes v = new VentanaImagenes();
            v.Show();
            this.Close();
        }
    }
}
