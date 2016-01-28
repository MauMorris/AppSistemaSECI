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
        public VentanaNuevoUsuario()
        {
            InitializeComponent();
            InicializaTextBoxes();
            InicializaComboBox();
            nombreTextBox_VNuevoUsuario.Focus();
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
        private void escolaridadComboBox_VNuevoUsuario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
        private void sexoComboBox_VNuevoUsuario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
        private Double Imc_Calculo(double estatura, double peso)
        {
            return peso / (Math.Pow(estatura, 2.0D));
        }
        private static bool TextoPermitido(string text)
        {
            Regex r = new Regex("[^0-9]+");
            return !r.IsMatch(text);
        }
        private void ValidacionNumerosTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !TextoPermitido(e.Text);
        }
        private static bool TextoPermitidoConPunto(string text)
        {
            Regex r = new Regex("[^0-9.]+");
            return !r.IsMatch(text);
        }
        private void ValidacionNumerosPuntoTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !TextoPermitidoConPunto(e.Text);
        }
        private void PegarTexto(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!TextoPermitido(text))
                    e.CancelCommand();
            }
            else
                e.CancelCommand();
        }

        private void PasoParametros()
        {
            DatosUsuario d = new DatosUsuario();
            int apoyo=0;
            Decimal apoyo2 = 0;
            d.Nombre = nombreTextBox_VNuevoUsuario.Text;
            d.Apellido = apellidosTextBox_VNuevoUsuario.Text;

            if (!Int32.TryParse(edadTextBox_VNuevoUsuario.Text, out apoyo))
            {
                String x = "no se puede";
                // Whatever
            }
            else
                d.Edad = apoyo;

            //            d.Edad = Int32.Parse(edadTextBox_VNuevoUsuario.Text);
            d.Escolaridad = escolaridadComboBox_VNuevoUsuario.Text;
            d.Sexo = sexoComboBox_VNuevoUsuario.Text;

            if(!Decimal.TryParse(estaturaTextBox_VNuevoUsuario.Text, out apoyo2))
            {
                String x = "no se puede";
                // Whatever
            }
            else
                d.Estatura = apoyo2;
            //            d.Estatura = Decimal.Parse(estaturaTextBox_VNuevoUsuario.Text);
//            d.Peso = Decimal.Parse(pesoTextBox_VNuevoUsuario.Text);
            d.NombreTutor = tutorTextBox_VNuevoUsuario.Text;

//            d.EdadTutor = Int32.Parse(edadTutorTextBox_VNuevoUsuario.Text);
//            d.TelefonoTutor = Int64.Parse(telefonoTutorTextBox_VNuevoUsuario.Text);
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
        private void InicializaTextBoxes()
        {
            nombreTextBox_VNuevoUsuario.Text = string.Empty;
            apellidosTextBox_VNuevoUsuario.Text = string.Empty;
            edadTextBox_VNuevoUsuario.Text = string.Empty;
            estaturaTextBox_VNuevoUsuario.Text = string.Empty;
            pesoTextBox_VNuevoUsuario.Text = string.Empty;
            tutorTextBox_VNuevoUsuario.Text = string.Empty;
            edadTutorTextBox_VNuevoUsuario.Text = string.Empty;
            telefonoTutorTextBox_VNuevoUsuario.Text = string.Empty;
/*            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                if (obj is TextBox)
                    ((TextBox)obj).Text = null;
                InicializaTextBoxes(VisualTreeHelper.GetChild(obj, i));
            }*/
        }
    }
}