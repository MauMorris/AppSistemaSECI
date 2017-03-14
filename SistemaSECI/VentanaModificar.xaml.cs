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

        string accion = string.Empty;
        int idPaciente = 0;
        int[] llaves;

        public VentanaModificar(int idUsuario)
        {
            nuevoU = new TablasDBHelper();
            idPaciente = idUsuario;
            llaves = nuevoU.RegresaLlavesUsuarioImc(idPaciente);

            paciente = nuevoU.RegresaDatosUsuarioConsulta(llaves[0]);

            InitializeComponent();

            InicializaTB();
            InicializaCB();

            nombreTB_VModificar.Focus();
        }

        private void regresarBoton_VModificar_Click(object sender, RoutedEventArgs e)
        {
            accion = "Cerrar";
            this.Close();
        }

        private void okBoton_VModificar_Click(object sender, RoutedEventArgs e)
        {
            
            PasoParametros();

            if (TodoBien())
            {
                nuevoU = new TablasDBHelper();

                nuevoU.UpdateDatosUsuario(llaves[0], paciente.Codigo, paciente.Nombre, paciente.Apellidos, paciente.Edad, paciente.Escolaridad,
                                            paciente.Sexo, paciente.NombreTutor, paciente.EdadTutor, paciente.TelefonoTutor, paciente.Mail);
                this.Close();
            }
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
                paciente.Mail = mailTB_VModificar.Text;

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

        private bool TodoBien()
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
                paciente.codigoUsuario();
                return true;
            }
        }

        private void InicializaTB()
        {
            nombreTB_VModificar.Text = paciente.Nombre;
            apellidosTB_VModificar.Text = paciente.Apellidos;
            edadTB_VModificar.Text = paciente.Edad.ToString();

            tutorTB_VModificar.Text = paciente.NombreTutor;
            edadTutorTB_VModificar.Text = paciente.EdadTutor.ToString();
            telefonoTB_VModificar.Text = paciente.TelefonoTutor;
            mailTB_VModificar.Text = paciente.Mail;

            escolaridadCB_VModificar.SelectedItem = paciente.Escolaridad;
            sexoCB_VModificar.SelectedItem = paciente.Sexo;
        }

        private void InicializaCB()
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
