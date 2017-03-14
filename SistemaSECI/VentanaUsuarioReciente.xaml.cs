using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace SistemaSECI
{
    /// <summary>
    /// Lógica de interacción para VentanaUsuarioReciente.xaml
    /// </summary>
    public partial class VentanaUsuarioReciente : Window
    {
        TablasDBHelper nuevaBD;
        DatosUsuario usuario = new DatosUsuario();

        bool usuarioEncontrado = false;
        string accion = string.Empty;
        string apoyoClaveUsuario = string.Empty;
        public static readonly int numeroUsuarioReciente = 0;
        int apoyoId = 0;
        string senderClave = string.Empty;

        List<int> consultaDeIds;
        Dictionary <string, int> DatosId = new Dictionary <string, int>();
        public VentanaUsuarioReciente()
        {
            InitializeComponent();
            InicializaTL();
        }

        /// Ejecuta tareas iniciales
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                nuevaBD = new TablasDBHelper();

                consultaDeIds = nuevaBD.RegresaTodosId();
                foreach (int i in consultaDeIds)
                {
                    apoyoClaveUsuario = nuevaBD.RegresaUsuarioConsulta(i);
                    usuariosCB_VUsuarioReciente.Items.Add(apoyoClaveUsuario);
                    DatosId.Add(apoyoClaveUsuario, i);
                }
            }
            catch (InvalidOperationException)
            {
            }
        }

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

        private void okBoton_VUsuarioReciente_Click(object sender, RoutedEventArgs e)
        {
            if (usuarioEncontrado == true)
            {
                accion = "imc";
                VImc v = new VImc(numeroUsuarioReciente, apoyoId);
                v.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Aun no has seleccionado un usuario \n", 
                    "Error de ingreso de informacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void regresarBoton_VUsuarioReciente_Click(object sender, RoutedEventArgs e)
        {
            accion = "usuarios";
            VUsuarios v = new VUsuarios();
            v.Show();
            this.Close();
        }

        private void InicializaTL()
        {
            nombreTL_VUsuarioReciente.Content = string.Empty;
            apellidosTL_VUsuarioReciente.Content = string.Empty;
            edadTL_VUsuarioReciente.Content = string.Empty;
            escolaridadTL_VUsuarioReciente.Content = string.Empty;
            sexoTL_VUsuarioReciente.Content = string.Empty;
            tutorTL_VUsuarioReciente.Content = string.Empty;
            edadTutorTL_VUsuarioReciente.Content = string.Empty;
            telefonoTL_VUsuarioReciente.Content = string.Empty;
            mailTL_VUsuarioReciente.Content = string.Empty;
            codigoIdTL_VUsuarioReciente.Content = string.Empty;
        }

        private void ActualizaTL(DatosUsuario paciente)
        {
            nombreTL_VUsuarioReciente.Content = paciente.Nombre;
            apellidosTL_VUsuarioReciente.Content = paciente.Apellidos;
            edadTL_VUsuarioReciente.Content = paciente.Edad;
            escolaridadTL_VUsuarioReciente.Content = paciente.Escolaridad;
            sexoTL_VUsuarioReciente.Content = paciente.Sexo;
            tutorTL_VUsuarioReciente.Content = paciente.NombreTutor;
            edadTutorTL_VUsuarioReciente.Content = paciente.EdadTutor;
            telefonoTL_VUsuarioReciente.Content = paciente.TelefonoTutor;
            mailTL_VUsuarioReciente.Content = paciente.Mail;
            codigoIdTL_VUsuarioReciente.Content = paciente.Codigo;
        }

        private void usuariosCB_VUsuarioReciente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            senderClave = usuariosCB_VUsuarioReciente.SelectedItem.ToString();
                if (DatosId.ContainsKey(senderClave))
                {
                    if(DatosId.TryGetValue(senderClave, out apoyoId))
                        usuario = nuevaBD.RegresaDatosUsuarioConsulta(apoyoId);
                    usuarioEncontrado = true;
                }
            ActualizaTL(usuario);
        }
    }
}
