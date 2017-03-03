using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Windows;

namespace SistemaSECI
{
    /// <summary>
    /// Lógica de interacción para VentanaHome.xaml
    /// </summary>
    public partial class VentanaHome : Window
    {
        TablasDBHelper paciente;

        DatosUsuario pacienteActual = new DatosUsuario();
        Imc ImcActual = new Imc();

        int idLlaves = 0;
        int[] llaves = { 0, 0};

        string apoyoCerrar = "CerrarVentana";

        public VentanaHome(int idLlavesUsuarioImc)
        {
            InitializeComponent();
            idLlaves = idLlavesUsuarioImc;

            paciente = new TablasDBHelper();
            llaves = paciente.RegresaLlavesUsuarioImc(idLlaves);

            pacienteActual = paciente.RegresaDatosUsuarioConsulta(llaves[0]);
            ImcActual = paciente.RegresaImcUsuarioConsulta(llaves[1]);

            ActualizaTL(pacienteActual, ImcActual);
    }

        /// Ejecuta tareas iniciales
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            switch (apoyoCerrar)
            {
                case "Cerrar":
                    e.Cancel = false;
                    break;
                case "Salir":
                    e.Cancel = false;
                    break;
                case "Borrar":
                    e.Cancel = false;
                    break;
                case "Kinect":
                    e.Cancel = false;
                    break;
                case "CerrarVentana":
                    VUsuarios v = new VUsuarios();
                    v.Show();
                    e.Cancel = false;
                    break;
                default:
                    VUsuarios f = new VUsuarios();
                    f.Show();
                    e.Cancel = false;
                    break;
            }
        }

        private void botonKinect_VHome_Click(object sender, RoutedEventArgs e)
        {
            VentanaJuego v = new VentanaJuego(idLlaves);
            apoyoCerrar = "Kinect";
            v.Show();
            this.Close();
        }

        private void botonSeci_VHome_Click(object sender, RoutedEventArgs e)
        {
            VentanaSeci v = new VentanaSeci(idLlaves);
            apoyoCerrar = "Seci";
            v.Show();
            this.Close();
        }

        private void botonPlanAlimentacion_VHome_Click(object sender, RoutedEventArgs e)
        {
            VentanaDieta v = new VentanaDieta(idLlaves);
            apoyoCerrar = "Alimentacion";
            v.Show();
            this.Close();
        }

        private void cerrarSesionBoton_VHome_Click(object sender, RoutedEventArgs e)
        {
            var salida = MessageBox.Show("¿Quieres cerrar la sesión actual?", "Cerrar sesión", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
            if (salida.Equals(MessageBoxResult.OK))
            {
                VUsuarios v = new VUsuarios();
                apoyoCerrar = "Cerrar";
                v.Show();
                this.Close();
            }
        }

        private void botonSalir_VHome_Click(object sender, RoutedEventArgs e)
        {
            var salida = MessageBox.Show("¿Quieres salir del programa?","Salir del programa", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
            if (salida.Equals(MessageBoxResult.OK))
            {
                apoyoCerrar = "Salir";
                this.Close();
            }
        }

        private void botonModificar_VHome_Click(object sender, RoutedEventArgs e)
        {
            VentanaModificar v = new VentanaModificar(idLlaves);
            v.Owner = this;
            v.ShowDialog();
        }

        private void botonDocumentos_VHome_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog v = new OpenFileDialog();
            v.Multiselect = false;
            v.Filter = "Todos los Archivos (*.*)|*.*| Presentaciones de Power Point (*.ppt, *.pptx)|*.ppt;*.pptx| PDF files (*.pdf)|*.pdf| Documentos de Word (*.doc, *.docx)|*.doc;*.docx| Archivos de Excel (*.xls, *.xlsx)|*.xls;*.xlsx|Presentacion Prezi (*.exe)|*.exe";
            v.Title = "Documentos del paciente";
            v.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (v.ShowDialog().Equals(true))
                System.Diagnostics.Process.Start(v.FileName);
        }

        private void botonBorrar_VHome_Click(object sender, RoutedEventArgs e)
        {
            var borrar = MessageBox.Show("¡Borrarás de forma permanente a este usuario!","Borrar usuario",MessageBoxButton.OKCancel,MessageBoxImage.Warning);
            if (borrar.Equals(MessageBoxResult.OK))
            {
                MessageBox.Show("Paciente borrado");

                VUsuarios v = new VUsuarios();
                v.Show();
                this.Close();
            }
        }

        private void ActualizaTL(DatosUsuario pacienteActual, Imc ImcActual)
        {
            nombreL_VHome.Content = pacienteActual.Nombre;
            apellidosL_VHome.Content = pacienteActual.Apellidos;
            edadL_VHome.Content = "Edad: " + pacienteActual.Edad + " años";
            escolaridadL_VHome.Content = pacienteActual.Escolaridad;
            sexoL_VHome.Content = pacienteActual.Sexo;
            pesoL_VHome.Content = "Peso: " + ImcActual.Peso + " Kg";
            estaturaL_VHome.Content = "Estatura: " + ImcActual.Estatura + " cm";
            imcL_VHome.Content = "IMC: " + Math.Round(ImcActual.IMC, 2);
            tutorL_VHome.Content = pacienteActual.NombreTutor;
            edadTutorL_VHome.Content = "Edad: " + pacienteActual.EdadTutor + " años";
            telefonodL_VHome.Content = pacienteActual.TelefonoTutor;
            mailL_VHome.Content = pacienteActual.Mail;
            codigoL_VHome.Content = "Codigo: " + pacienteActual.Codigo;
        }
    }
}
