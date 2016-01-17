using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        int i=0;
        public VentanaNuevoUsuario()
        {
            InitializeComponent();

            nombreTextBox_VNuevoUsuario.Focus();
            InicializaComboBox();
        }
        private void regresarBoton_VNuevoUsuario_Click(object sender, RoutedEventArgs e)
        {
            VentanaUsuarios v = new VentanaUsuarios();
            v.Show();
            this.Close();
        }
        private void okBoton_VNuevoUsuario_Click(object sender, RoutedEventArgs e)
        {
            PasoParametros();
            VentanaHome v = new VentanaHome();
            v.Show();
            this.Close();
        }
        private void nombreTextBox_VNuevoUsuario_TextChanged(object sender, TextChangedEventArgs e)
        {
                
        }
        private void apellidosTextBox_VNuevoUsuario_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
        private void edadTextBox_VNuevoUsuario_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
        private void estaturaTextBox_VNuevoUsuario_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
        private void pesoTextBox_VNuevoUsuario_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
        private void tutorTextBox_VNuevoUsuario_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
        private void edadTutorTextBox_VNuevoUsuario_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
        private void telefonoTutorTextBox_VNuevoUsuario_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
        private Double Imc_Calculo(double estatura, double peso)
        {
            return peso/(Math.Pow(estatura, 2.0D));
        }
        private void ValidacionNumerosTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex r = new Regex("[^0-9]+-");
            e.Handled = r.IsMatch(e.Text);
        }
        private void PasoParametros()
        {
            DatosUsuario d = new DatosUsuario();

            d.Nombre = nombreTextBox_VNuevoUsuario.Text;
            d.Apellido = apellidosTextBox_VNuevoUsuario.Text;
            d.Edad = Int32.Parse(edadTextBox_VNuevoUsuario.Text);
            d.Escolaridad = escolaridadComboBox_VNuevoUsuario.Text;
            d.Sexo = sexoComboBox_VNuevoUsuario.Text;
            d.Estatura = Decimal.Parse(estaturaTextBox_VNuevoUsuario.Text);
            d.Peso = Decimal.Parse(pesoTextBox_VNuevoUsuario.Text);
            d.NombreTutor = tutorTextBox_VNuevoUsuario.Text;
            d.EdadTutor = Int32.Parse(edadTutorTextBox_VNuevoUsuario.Text);
            d.TelefonoTutor = Int64.Parse(telefonoTutorTextBox_VNuevoUsuario.Text);
        }
        private void InicializaComboBox()
        {
            escolaridadComboBox_VNuevoUsuario.Items.Add(escP);
            escolaridadComboBox_VNuevoUsuario.Items.Add(escS);
            escolaridadComboBox_VNuevoUsuario.Items.Add(escPr);
            escolaridadComboBox_VNuevoUsuario.Items.Add(escL);

            sexoComboBox_VNuevoUsuario.Items.Add(sexoM);
            sexoComboBox_VNuevoUsuario.Items.Add(sexoF);
        }

        private void OcultarTexto(object sender, RoutedEventArgs e)
        {
           if( e.Equals(nombreTextBox_VNuevoUsuario))
            {
                nombreTextBox_VNuevoUsuario.Clear();
            }
        }

        private void escolaridadComboBox_VNuevoUsuario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
