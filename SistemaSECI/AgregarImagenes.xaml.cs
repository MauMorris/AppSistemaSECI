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
    /// Interaction logic for AgregarImagenes.xaml
    /// </summary>
    public partial class AgregarImagenes : Window
    {
        public AgregarImagenes()
        {
            InitializeComponent();
        }

        private void okBoton_VAgregarImagenes_Click(object sender, RoutedEventArgs e)
        {
            VarGlobal.GlobalEnd = "1";
            string nuevo = "Nuevo Reforzador";
//            reforzadorTipoCB_VSeci.Items.Add(nuevo);
            this.Close();
        }

        private void regresarBoton_VAgregarImagenes_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
