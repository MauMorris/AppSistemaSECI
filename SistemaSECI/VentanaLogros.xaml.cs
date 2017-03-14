using System.Windows;

namespace SistemaSECI
{
    /// <summary>
    /// Lógica de interacción para VentanaLogros.xaml
    /// </summary>
    public partial class VentanaLogros : Window
    {
        public VentanaLogros()
        {
            InitializeComponent();
        }

        private void regresarBoton_VLogros_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
