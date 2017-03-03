using System;
using System.ComponentModel;
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

        DatosUsuario paciente;
        TablasDBHelper nuevoUsuario;

        ExpresionesReg match = new ExpresionesReg();

        string accion = string.Empty;
        int idPaciente = 0;
        public static readonly int numeroNuevoUsuario = 1;

        public VentanaNuevoUsuario()
        {
            InitializeComponent();

            InicializaTB();
            InicializaCB();

            nombreTB_VNuevoUsuario.Focus();

            paciente = new DatosUsuario();
        }

        private void RegresarBoton_VNuevoUsuario_Click(object sender, RoutedEventArgs e)
        {
            accion = "usuarios";
            VUsuarios v = new VUsuarios();
            v.Show();
            this.Close();
        }

        private void OkBoton_VNuevoUsuario_Click(object sender, RoutedEventArgs e)
        {
            PasoParametros();

            if (TodoBien())
            {
                nuevoUsuario = new TablasDBHelper();

                nuevoUsuario.InsertarDatosUsuario(paciente.Codigo, paciente.Nombre, paciente.Apellidos, paciente.Edad, paciente.Escolaridad,
                                            paciente.Sexo, paciente.NombreTutor, paciente.EdadTutor, paciente.TelefonoTutor, paciente.Mail);
                idPaciente = nuevoUsuario.ConsultaIdUltimoUsuario();
                //quiero que me regrese el Id del usuario para tenerlo presente en lo que sigue de las pruebas

                accion = "imc";
                VImc v = new VImc(numeroNuevoUsuario, idPaciente);
                //crear objeto ventana imc con el numero de Id del usuario para tenerlo presente en lo subsecuente
                v.Show();
                this.Close();
            }
        }

        /// Ejecuta cuando cierras la ventana
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (accion == string.Empty)
            {
                VUsuarios v = new VUsuarios();
                v.Show();
                e.Cancel = false;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void PasoParametros()
        {
            int apoyo = 0;

            try
            {
                paciente.Nombre = nombreTB_VNuevoUsuario.Text;
                paciente.Apellidos = apellidosTB_VNuevoUsuario.Text;

                paciente.Escolaridad = escolaridadCB_VNuevoUsuario.Text;
                paciente.Sexo = sexoCB_VNuevoUsuario.Text;
                paciente.NombreTutor = tutorTB_VNuevoUsuario.Text;

                paciente.TelefonoTutor = telefonoTB_VNuevoUsuario.Text;
                paciente.Mail = mailTB_VNuevoUsuario.Text;

                if (Int32.TryParse(edadTB_VNuevoUsuario.Text, out apoyo))
                    paciente.Edad = apoyo;
                else
                    paciente.Edad = 0;

                if (Int32.TryParse(edadTutorTB_VNuevoUsuario.Text, out apoyo))
                    paciente.EdadTutor = apoyo;
                else
                    paciente.EdadTutor = 0;
            }
            catch(Exception e)
            {
                String errorText = e.Message;
                MessageBox.Show("Error de formato \n" + errorText, "Error de ingreso de informacion", 
                                                                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool TodoBien()
        {
            if (paciente.Nombre == String.Empty | paciente.Apellidos == String.Empty |
                paciente.Escolaridad == String.Empty | paciente.Sexo == String.Empty |
                paciente.NombreTutor == String.Empty | paciente.TelefonoTutor == String.Empty |
                paciente.Edad == 0 | paciente.EdadTutor == 0)
            {
                MessageBox.Show("Necesitas llenar uno o mas parámetros", "Error de ingreso de informacion", 
                                                                    MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else
            {
                paciente.codigoUsuario();
                return true;
            }
        }

        private void EscolaridadCB_VNuevoUsuario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
        private void SexoCB_VNuevoUsuario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void ValidarTexto(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !match.Texto(e.Text);
        }

        private void ValidarNumero(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !match.Numero(e.Text);
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
                String text = (String) e.DataObject.GetData(typeof(String));
                if (!match.Numero(text))
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

        private void InicializaTB()
        {
            nombreTB_VNuevoUsuario.Text = String.Empty;
            apellidosTB_VNuevoUsuario.Text = String.Empty;
            edadTB_VNuevoUsuario.Text = String.Empty;

            tutorTB_VNuevoUsuario.Text = String.Empty;
            edadTutorTB_VNuevoUsuario.Text = String.Empty;
            telefonoTB_VNuevoUsuario.Text = String.Empty;
            mailTB_VNuevoUsuario.Text = String.Empty;
        }

        private void InicializaCB()
        {
            escolaridadCB_VNuevoUsuario.Items.Add(escP);
            escolaridadCB_VNuevoUsuario.Items.Add(escS);
            escolaridadCB_VNuevoUsuario.Items.Add(escPr);
            escolaridadCB_VNuevoUsuario.Items.Add(escL);

            sexoCB_VNuevoUsuario.Items.Add(sexoM);
            sexoCB_VNuevoUsuario.Items.Add(sexoF);
        }
    }
}