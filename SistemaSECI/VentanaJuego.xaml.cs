using System.Windows;

namespace SistemaSECI
{
    /// <summary>
    /// Lógica de interacción para VentanaJuego.xaml
    /// </summary>
    public partial class VentanaJuego : Window
    {
        int idUsuario = 0;
        int idLlaves = 0;
        TablasDBHelper DBUsuario;

        public VentanaJuego(int id)
        {
            InitializeComponent();
            DBUsuario = new TablasDBHelper();
            idLlaves = id;
        }

        private void botonLogros_VInicioJuego_Click(object sender, RoutedEventArgs e)
        {
            VentanaLogros v = new VentanaLogros();
            v.Owner = this;
            v.ShowDialog();
        }
        private void botonAjustesPrograma_VInicioJuego_Click(object sender, RoutedEventArgs e)
        {
            VentanaAjustesPrograma v = new VentanaAjustesPrograma();
            v.Owner = this;
            v.ShowDialog();
        }
        private void botonJugar_VInicioJuego_Click(object sender, RoutedEventArgs e)
        {
            VentanaEjemplosKinect v = new VentanaEjemplosKinect(idLlaves);
            v.Show();
            this.Close();
        }
        private void botonRegresar_VInicioJuego_Click(object sender, RoutedEventArgs e)
        {
            VentanaHome v = new VentanaHome(idLlaves);
            v.Show();
            this.Close();
        }
    }
}
