using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

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

        DatosUsuario paciente = new DatosUsuario();
        ManejadorTablas nuevoU;

        public VentanaModificar()
        {
            InitializeComponent();
            InicializaComboBox();
            nombreTextBox_VModificar.Focus();
        }

        private void okBoton_VModificar_Click(object sender, RoutedEventArgs e)
        {
            PasoParametros();
            if (EverythingOK())
            {
                QueryParametros();
                this.Close();
            }
        }
        private void regresarBoton_VModificar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
                paciente.Nombre = nombreTextBox_VModificar.Text;
                paciente.Apellidos = apellidosTextBox_VModificar.Text;
                paciente.Escolaridad = escolaridadComboBox_VModificar.Text;
                paciente.Sexo = sexoComboBox_VModificar.Text;
                paciente.NombreTutor = tutorTextBox_VModificar.Text;
                paciente.TelefonoTutor = telefonoTutorTextBox_VModificar.Text;

                if (Int32.TryParse(edadTextBox_VModificar.Text, out apoyo))
                    paciente.Edad = apoyo;
                else
                    paciente.Edad = 0;

                if (Double.TryParse(estaturaTextBox_VModificar.Text, out apoyo2))
                    paciente.Estatura = apoyo2;
                else
                    paciente.Estatura = 0;

                if (Double.TryParse(pesoTextBox_VModificar.Text, out apoyo2))
                    paciente.Peso = apoyo2;
                else
                    paciente.Peso = 0;

                if (Int32.TryParse(edadTutorTextBox_VModificar.Text, out apoyo))
                    paciente.EdadTutor = apoyo;
                else
                    paciente.EdadTutor = 0;
            }
            catch (Exception e)
            {
                String errorText = e.Message;
                MessageBox.Show("Error de formato \n" + errorText, "Error de ingreso de informacion", MessageBoxButton.OK, MessageBoxImage.Error);
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
                    MessageBox.Show("Error de formato \n" + errorText, "Error de ingreso de informacion", MessageBoxButton.OK, MessageBoxImage.Error);
                    return true;
                }
            }
        }

        private void QueryParametros()
        {
            nuevoU = new ManejadorTablas();
            string codigoUsuario = paciente.Nombre.Substring(1, 1) + paciente.Apellidos.Substring(1, 2) +
                                    paciente.Edad.ToString().Substring(0, 1);

            nuevoU.UpdateDatosUsuario(2, codigoUsuario, paciente.Nombre, paciente.Apellidos, paciente.Edad, paciente.Escolaridad,
                                        paciente.Sexo, paciente.Estatura, paciente.Peso, paciente.Imc,
                                        paciente.NombreTutor, paciente.EdadTutor, paciente.TelefonoTutor);
        }

        private void PegarTexto(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!NumeroPermitido(text))
                    e.CancelCommand();
            }
            else
                e.CancelCommand();
        }

        private void InicializaComboBox()
        {
            escolaridadComboBox_VModificar.Items.Add(escP);
            escolaridadComboBox_VModificar.Items.Add(escS);
            escolaridadComboBox_VModificar.Items.Add(escPr);
            escolaridadComboBox_VModificar.Items.Add(escL);

            sexoComboBox_VModificar.Items.Add(sexoM);
            sexoComboBox_VModificar.Items.Add(sexoF);
        }
    }
}
