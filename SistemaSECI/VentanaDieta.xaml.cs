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
    /// Interaction logic for VentanaDieta.xaml
    /// </summary>
    public partial class VentanaDieta : Window
    {

        public VentanaDieta()
        {
            InitializeComponent();
        }
        private void lBox_VDieta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (lBox_VDieta.SelectedItem.ToString())
            {
                case "LUNES":

                    break;
                case "MARTES":
                    break;
                case "MIERCOLES":
                    break;
                case "JUEVES":
                    break;
                case "VIERNES":
                    break;
                case "SABADO":
                    break;
                case "DOMINGO":
                    break;
                default:
                    break;
            }
        }

        private void regresarBoton_VDieta_Click(object sender, RoutedEventArgs e)
        {
            VentanaHome v = new VentanaHome();
            v.Show();
            this.Close();
        }
    }
}
