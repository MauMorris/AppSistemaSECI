using Microsoft.Win32;
using System;
using System.Linq;
using System.Text;
using System.Windows;

namespace SistemaSECI
{
    /// <summary>
    /// Lógica de interacción para VentanaHome.xaml
    /// </summary>
    public partial class VentanaHome : Window
    {
        public VentanaHome()
        {
            InitializeComponent();
        }

        private void botonKinect_VHome_Click(object sender, RoutedEventArgs e)
        {
            VentanaJuego v = new VentanaJuego();
            v.Show();
            this.Close();
        }
        private void botonSeci_VHome_Click(object sender, RoutedEventArgs e)
        {
            VentanaSeci v = new VentanaSeci();
            v.Show();
            this.Close();
        }
        private void botonPlanAlimentacion_VHome_Click(object sender, RoutedEventArgs e)
        {
            VentanaDieta v = new VentanaDieta();
            v.Show();
            this.Close();
        }
        private void regresarBoton_VHome_Click(object sender, RoutedEventArgs e)
        {
            VentanaUsuarios v = new VentanaUsuarios();
            v.Show();
            this.Close();
        }
        private void botonSalir_VHome_Click(object sender, RoutedEventArgs e)
        {
            var salida = MessageBox.Show("¿Quieres cerrar tu sesión?","Cerrar sesión", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
            if(salida.Equals(MessageBoxResult.OK))
                this.Close();
        }

        private void botonActualizar_VHome_Click(object sender, RoutedEventArgs e)
        {
            VentanaModificarSimple v = new VentanaModificarSimple();
            v.Owner = this;
            v.ShowDialog();
        }
        private void botonModificar_VHome_Click(object sender, RoutedEventArgs e)
        {
            VentanaModificar v = new VentanaModificar();
            v.Owner = this;
            v.ShowDialog();
        }

        private void botonDocumentos_VHome_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog v = new OpenFileDialog();
            v.Multiselect = false;
            v.Filter = "Todos los Archivos (*.*)|*.*| Presentaciones de Power Point (*.ppt, *.pptx)|*.ppt;*.pptx| PDF files (*.pdf)|*.pdf| Documentos de Word (*.doc, *.docx)|*.doc;*.docx| Archivos de Excel (*.xls, *.xlsx)|*.xls;*.xlsx";
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
                VentanaUsuarios v = new VentanaUsuarios();
                v.Show();
                this.Close();
            }
        }
    }
}
