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
    /// Lógica de interacción para VentanaNuevoUsuario.xaml
    /// </summary>
    public partial class VentanaNuevoUsuario : Window
    {
        String sexoM = "Masculino";
        String sexoF = "Femenino";

        String escP = "Primaria";
        String escS = "Secundaria";
        String escPr = "Preparatoria";
        String escL = "Licenciatura";
        public VentanaNuevoUsuario()
        {
            InitializeComponent();
            nombreTextBox_VNuevoUsuario.Focus();
            escolaridadComboBox_VNuevoUsuario.Items.Add(escP);
            escolaridadComboBox_VNuevoUsuario.Items.Add(escS);
            escolaridadComboBox_VNuevoUsuario.Items.Add(escPr);
            escolaridadComboBox_VNuevoUsuario.Items.Add(escL);

            sexoComboBox_VNuevoUsuario.Items.Add(sexoM);
            sexoComboBox_VNuevoUsuario.Items.Add(sexoF);

        }

        private void regresarBoton_VNuevoUsuario_Click(object sender, RoutedEventArgs e)
        {
            VentanaUsuarios v = new VentanaUsuarios();
            v.Show();
            this.Close();
        }

        private void okBoton_VNuevoUsuario_Click(object sender, RoutedEventArgs e)
        {
            VentanaHome v = new VentanaHome();
            v.Show();
            this.Close();
        }
    }
}
