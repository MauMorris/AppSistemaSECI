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
    /// Lógica de interacción para VentanaModificarSimple.xaml
    /// </summary>
    public partial class VentanaModificarSimple : Window
    {
        public VentanaModificarSimple()
        {
            InitializeComponent();
            InicializaTextBoxes();
        }
        private void okBoton_VModificarSimple_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void InicializaTextBoxes()
        {
            estaturaTextBox_VModificarSimple.Text = string.Empty;
            pesoTextBox_VModificarSimple.Text = string.Empty;
        }
    }
}
