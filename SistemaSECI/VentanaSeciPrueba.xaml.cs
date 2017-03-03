using System.Windows;

namespace SistemaSECI
{
    /// <summary>
    /// Lógica de interacción para VentanaSeciPrueba.xaml
    /// </summary>
    public partial class VentanaSeciPrueba : Window
    {
        TablasDBHelper nuevoU;
        Seci nSeci;
        int idLlavesUsuarioImc = 0;
        int idParametrosSeci = 0;
        public VentanaSeciPrueba(int idParametros, int idLlaves)
        {
            InitializeComponent();
            idLlavesUsuarioImc = idLlaves;
            idParametrosSeci = idParametros;
            nSeci = new Seci();
            QueryParametros();
            ActualizaTL(nSeci);
        }

        private void regresarBoton_VLogros_Click(object sender, RoutedEventArgs e)
        {
            VentanaSeci v = new VentanaSeci(idLlavesUsuarioImc);
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
            nuevoU = new TablasDBHelper();
            nSeci = nuevoU.RegresaParametrosSesion(idParametrosSeci);
        }
        private void ActualizaTL(Seci parametrosActual)
        {
            reforzadorTipoLabel_VSeciPrueba.Content = parametrosActual.ReforzadorTipo;
            reforzadorClaseLabel_VSeciPrueba.Content = parametrosActual.ReforzadorClase;
            inmediatezInmeLabel_VSeciPrueba.Content = parametrosActual.InmediatezI;
            inmediatezDemoLabel_VSeciPrueba.Content = parametrosActual.InmediatezD;
            esfuerzoAltoLabel_VSeciPrueba.Content = parametrosActual.EsfuerzoAlto;
            esfuerzoBajoLabel_VSeciPrueba.Content = parametrosActual.EsfuerzoBajo;
            reforzamientoAltoLabel_VSeciPrueba.Content = parametrosActual.ReforzamientoAlto;
            reforzamientoBajoLabel_VSeciPrueba.Content = parametrosActual.ReforzamientoBajo;
        }
    }
}
