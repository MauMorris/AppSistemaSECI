using System;
using System.Windows;

namespace SistemaSECI
{
    /// <summary>
    /// Interaction logic for VentanaImagenes.xaml
    /// </summary>
    public partial class VentanaImagenes : Window
    {
        int idLlaves = 0;
        int idParametros = 0;
        public VentanaImagenes()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            VentanaSeciPrueba v = new VentanaSeciPrueba(idParametros, idLlaves);
            v.Show();
            this.Close();
        }
    }
}
