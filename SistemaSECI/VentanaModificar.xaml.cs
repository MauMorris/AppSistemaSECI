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
    /// Lógica de interacción para VentanaModificar.xaml
    /// </summary>
    public partial class VentanaModificar : Window
    {
        String sexoM = "Masculino";
        String sexoF = "Femenino";

        String escP = "Primaria";
        String escS = "Secundaria";
        String escPr = "Preparatoria";
        String escL = "Licenciatura";

        public VentanaModificar()
        {
            InitializeComponent();
            nombreTextBox_VModificar.Focus();
            escolaridadComboBox_VModificar.Items.Add(escP);
            escolaridadComboBox_VModificar.Items.Add(escS);
            escolaridadComboBox_VModificar.Items.Add(escPr);
            escolaridadComboBox_VModificar.Items.Add(escL);

            sexoComboBox_VModificar.Items.Add(sexoM);
            sexoComboBox_VModificar.Items.Add(sexoF);
        }

        private void okBoton_VModificar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void regresarBoton_VModificar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
