using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SistemaSECI
{
    /// <summary>
    /// Lógica de interacción para VentanaNuevoUsuario.xaml
    /// </summary>
    public partial class VentanaNuevoUsuario : Window
    {
        private String sexoM = "Masculino";
        private String sexoF = "Femenino";

        private String escP = "Primaria";
        private String escS = "Secundaria";
        private String escPr = "Preparatoria";
        private String escL = "Licenciatura";

        DatosUsuario paciente = new DatosUsuario();

        public VentanaNuevoUsuario()
        {
            InitializeComponent();
            InicializaTextBoxes();
            InicializaComboBox();
            nombreTextBox_VNuevoUsuario.Focus();
        }
        private void RegresarBoton_VNuevoUsuario_Click(object sender, RoutedEventArgs e)
        {
            VentanaUsuarios v = new VentanaUsuarios();
            v.Show();
            this.Close();
        }
        private void OkBoton_VNuevoUsuario_Click(object sender, RoutedEventArgs e)
        {
            PasoParametros();
            if (EverythingOK())
            {
                QueryParametros();
                VentanaHome v = new VentanaHome();
                v.Show();
                this.Close();
            }
        }

        private void EscolaridadComboBox_VNuevoUsuario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
        private void SexoComboBox_VNuevoUsuario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private static bool NumeroPermitido(string text)
        {
            Regex numPermitido = new Regex("[^0-9]+");
            return !numPermitido.IsMatch(text);
        }
        private void ValidacionNumerosTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !NumeroPermitido(e.Text);
        }

        private static bool NumeroPermitidoConPunto(string text)
        {
            Regex numPunto = new Regex("[^0-9.]+");
            return !numPunto.IsMatch(text);
        }
        private void ValidacionNumerosPuntoTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !NumeroPermitidoConPunto(e.Text);
        }

        private static bool TextoPermitido(string text)
        {
            Regex textoPermitido = new Regex("[^a-zA-Z]+");
            return !textoPermitido.IsMatch(text);
        }
        private void ValidacionTextoTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !TextoPermitido(e.Text);
        }

        private static bool NumeroTelefonicoPermitido(string text)
        {
            Regex numTel = new Regex("[^0-9-]");
            return !numTel.IsMatch(text);
        }
        private void ValidacionNumeroTelefonicoTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !NumeroTelefonicoPermitido(e.Text);
        }

        private void PasoParametros()
        {
            int apoyo = 0;
            Double apoyo2 = 0;

            try
            {
                paciente.Nombre = nombreTextBox_VNuevoUsuario.Text;
                paciente.Apellidos = apellidosTextBox_VNuevoUsuario.Text;
                paciente.Escolaridad = escolaridadComboBox_VNuevoUsuario.Text;
                paciente.Sexo = sexoComboBox_VNuevoUsuario.Text;
                paciente.NombreTutor = tutorTextBox_VNuevoUsuario.Text;
                paciente.TelefonoTutor = telefonoTutorTextBox_VNuevoUsuario.Text;

                if (Int32.TryParse(edadTextBox_VNuevoUsuario.Text, out apoyo))
                    paciente.Edad = apoyo;
                else
                    paciente.Edad = 0;

                if (Double.TryParse(estaturaTextBox_VNuevoUsuario.Text, out apoyo2))
                    paciente.Estatura = apoyo2;
                else
                    paciente.Estatura = 0;

                if (Double.TryParse(pesoTextBox_VNuevoUsuario.Text, out apoyo2))
                    paciente.Peso = apoyo2;
                else
                    paciente.Peso = 0;

                if (Int32.TryParse(edadTutorTextBox_VNuevoUsuario.Text, out apoyo))
                    paciente.EdadTutor = apoyo;
                else
                    paciente.EdadTutor = 0;
            }
            catch(Exception e)
            {
                String errorText = e.Message;
                MessageBox.Show("Error de formato /n" + errorText, "Error de ingreso de informacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool EverythingOK()
        {
            if (paciente.Nombre == String.Empty | paciente.Apellidos == String.Empty |
                paciente.Escolaridad == String.Empty | paciente.Sexo == String.Empty |
                paciente.NombreTutor == String.Empty | paciente.TelefonoTutor == String.Empty |
                paciente.Edad == 0 | paciente.Estatura == 0 | paciente.Peso == 0 | paciente.EdadTutor == 0)
            {
                MessageBox.Show("Necesitas llenar uno o mas parámetros", "Error de ingreso de informacion", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else
            {
                try
                {
                    paciente.Imc = paciente.Imc_Calculo(paciente.Estatura, paciente.Peso);
                    return true;
                }
                catch (Exception e)
                {
                    String errorText = e.Message;
                    MessageBox.Show("Error de formato /n" + errorText, "Error de ingreso de informacion", MessageBoxButton.OK, MessageBoxImage.Error);
                    return true;
                }
            }
        }

        private void QueryParametros()
        {
        }

        private void PegarTexto(object sender, DataObjectPastingEventArgs e)
        {
            if(e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String) e.DataObject.GetData(typeof(String));
                if(!NumeroPermitido(text))
                    e.CancelCommand();
            }
            else
                e.CancelCommand();
        }

        private void InicializaTextBoxes()
        {
            nombreTextBox_VNuevoUsuario.Text = String.Empty;
            apellidosTextBox_VNuevoUsuario.Text = String.Empty;
            edadTextBox_VNuevoUsuario.Text = String.Empty;
            estaturaTextBox_VNuevoUsuario.Text = String.Empty;
            pesoTextBox_VNuevoUsuario.Text = String.Empty;
            tutorTextBox_VNuevoUsuario.Text = String.Empty;
            edadTutorTextBox_VNuevoUsuario.Text = String.Empty;
            telefonoTutorTextBox_VNuevoUsuario.Text = String.Empty;
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
    }
}