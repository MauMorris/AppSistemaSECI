using System.Windows;

namespace SistemaSECI
{
    /// <summary>
    /// Lógica de interacción para VentanaSeciPrueba.xaml
    /// </summary>
    public partial class VentanaSeciPrueba : Window
    {
        ManejadorTablas nuevoU;

        public VentanaSeciPrueba()
        {
            InitializeComponent();
            QueryParametros();
        }

        private void regresarBoton_VLogros_Click(object sender, RoutedEventArgs e)
        {
            VentanaSeci v = new VentanaSeci();
            v.Show();
            this.Close();
        }

        private void okBoton_VSeci_Click(object sender, RoutedEventArgs e)
        {
            VentanaImagenesSaludables v = new VentanaImagenesSaludables();
            v.Show();
            this.Close();
        }

        private void QueryParametros()
        {
            nuevoU = new ManejadorTablas();
            nuevoU.ReadParametrosSesion();
        }

    }
}
