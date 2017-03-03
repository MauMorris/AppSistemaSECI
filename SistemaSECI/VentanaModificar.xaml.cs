using System;
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
        TablasDBHelper nuevoU;
        ExpresionesReg match = new ExpresionesReg();

        public VentanaModificar(int idUsuario)
        {
            InitializeComponent();
            InicializaComboBox();
            nombreTB_VModificar.Focus();
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

        private void ValidarNumero(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !match.Numero(e.Text);
        }

        private void ValidarTexto(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !match.Texto(e.Text);
        }

        private void ValidarTelefono(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !match.Telefono(e.Text);
        }

        private void ValidarMail(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !match.Mail(e.Text);
        }

        private void PegarTexto(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!match.Texto(text))
                    e.CancelCommand();
            }
            else
                e.CancelCommand();
        }

        private void PegarNumero(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!match.Numero(text))
                    e.CancelCommand();
            }
            else
                e.CancelCommand();
        }

        private void PegarMail(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!match.Mail(text))
                    e.CancelCommand();
            }
            else
                e.CancelCommand();
        }

        private void PegarTelefono(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!match.Telefono(text))
                    e.CancelCommand();
            }
            else
                e.CancelCommand();
        }

        private void PasoParametros()
        {
            int apoyo = 0;

            try
            {
                paciente.Nombre = nombreTB_VModificar.Text;
                paciente.Apellidos = apellidosTB_VModificar.Text;
                paciente.Escolaridad = escolaridadCB_VModificar.Text;
                paciente.Sexo = sexoCB_VModificar.Text;
                paciente.NombreTutor = tutorTB_VModificar.Text;
                paciente.TelefonoTutor = telefonoTB_VModificar.Text;

                if (Int32.TryParse(edadTB_VModificar.Text, out apoyo))
                    paciente.Edad = apoyo;
                else
                    paciente.Edad = 0;


                if (Int32.TryParse(edadTutorTB_VModificar.Text, out apoyo))
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
                paciente.Edad == 0 | paciente.EdadTutor == 0)
            {
                MessageBox.Show("Necesitas llenar uno o mas parámetros", "Error de ingreso de informacion", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else
            {
                try
                {
//                    paciente.Estatura /= 100;
//                    paciente.IMC = paciente.Imc_Calculo(paciente.Estatura, paciente.Peso);
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
            nuevoU = new TablasDBHelper();
            string codigoUsuario = paciente.Nombre.Substring(0, 1) + paciente.Apellidos.Substring(0, 1) +
                                    paciente.Edad.ToString().Substring(0, 1);

            nuevoU.UpdateDatosUsuario(2, codigoUsuario, paciente.Nombre, paciente.Apellidos, paciente.Edad, paciente.Escolaridad,
                                        paciente.Sexo, paciente.NombreTutor, paciente.EdadTutor, paciente.TelefonoTutor, paciente.Mail);
        }

        private void InicializaComboBox()
        {
            escolaridadCB_VModificar.Items.Add(escP);
            escolaridadCB_VModificar.Items.Add(escS);
            escolaridadCB_VModificar.Items.Add(escPr);
            escolaridadCB_VModificar.Items.Add(escL);

            sexoCB_VModificar.Items.Add(sexoM);
            sexoCB_VModificar.Items.Add(sexoF);
        }
    }
}
