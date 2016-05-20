using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace SistemaSECI
{
    /// <summary>
    /// Lógica de interacción para VentanaUsuarioReciente.xaml
    /// </summary>
    public partial class VentanaUsuarioReciente : Window
    {
        int numeroUsuarios = 0;

        public VentanaUsuarioReciente()
        {
            InitializeComponent();
        }

        /// Ejecuta tareas iniciales
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (checkDBConnection())
                    numeroUsuarios = QueryConteo();
                for (int i = 0; i < numeroUsuarios; i++)
                {
                    InicializaComboBox();
                }
            }
            catch (InvalidOperationException)
            {

            }

        }

        private void okBoton_VUsuarioReciente_Click(object sender, RoutedEventArgs e)
        {
            VentanaHome v = new VentanaHome();
            v.Show();
            this.Close();
        }

        private void regresarBoton_VUsuarioReciente_Click(object sender, RoutedEventArgs e)
        {
            VentanaUsuarios v = new VentanaUsuarios();
            v.Show();
            this.Close();
        }

        private int QueryConteo()
        {
            return 0;
        }
        private bool checkDBConnection()
        {
            return true;
        }

        private void InicializaTextLabel()
        {
            nombreTextLabel_VUsuarioReciente.Content = string.Empty;
            apellidosTextLabel_VUsuarioReciente.Content = string.Empty;
            edadTextLabel_VUsuarioReciente.Content = string.Empty;
            escolaridadTextLabel_VUsuarioReciente.Content = string.Empty;
            sexoTextLabel_VUsuarioReciente.Content = string.Empty;
            estaturaTextLabel_VUsuarioReciente.Content = string.Empty;
            pesoTextLabel_VUsuarioReciente.Content = string.Empty;
            imcTextLabel_VUsuarioReciente.Content = string.Empty;
            tutorTextLabel_VUsuarioReciente.Content = string.Empty;
            edadTutorTextLabel_VUsuarioReciente.Content = string.Empty;
            telefonoTextLabel_VUsuarioReciente.Content = string.Empty;
        }

        private void InicializaComboBox()
        {
            for (int i = 0; i < numeroUsuarios; i++)
            {
                usuarioRecienteComboBox_VUsuarioReciente.Items.Add("0");
            }
        }

        private void usuarioRecienteComboBox_VUsuarioReciente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
