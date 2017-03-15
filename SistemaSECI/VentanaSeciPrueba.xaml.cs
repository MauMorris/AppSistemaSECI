using System.ComponentModel;
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
        string apoyoCerrar = "CerrarVentana";

        public VentanaSeciPrueba(int idParametros, int idLlaves)
        {
            InitializeComponent();

            idLlavesUsuarioImc = idLlaves;
            idParametrosSeci = idParametros;

            nSeci = new Seci();

            nuevoU = new TablasDBHelper();
            nSeci = nuevoU.RegresaParametrosSesion(idParametrosSeci);

            ActualizaTL(nSeci);
        }

        private void regresarBoton_VLogros_Click(object sender, RoutedEventArgs e)
        {
            apoyoCerrar = "Regresar";
            VentanaSeci v = new VentanaSeci(idLlavesUsuarioImc, nSeci.Sesion);
            v.Show();
            this.Close();
        }

        private void okBoton_VSeci_Click(object sender, RoutedEventArgs e)
        {
            apoyoCerrar = "Siguiente";

            switch (nSeci.Sesion)
            {
                case "linea_base":
                    VentanaImagenesSaludables v = new VentanaImagenesSaludables(idParametrosSeci, idLlavesUsuarioImc);
                    v.Show();
                    this.Close();
                    break;
                case "evaluacion":
                    var seleccion = MessageBox.Show("Necesitas hacer tu sesion de linea base", "Evaluacion", MessageBoxButton.OK, MessageBoxImage.Information);
                    if (seleccion.Equals(MessageBoxResult.OK))
                    {
                        apoyoCerrar = "CerrarVentana";
                        this.Close();
                    }
                    break;
                case "replica":
                    var sele = MessageBox.Show("Necesitas hacer tu sesion de linea base", "Replica", MessageBoxButton.OK, MessageBoxImage.Information);
                    if (sele.Equals(MessageBoxResult.OK))
                    {
                        apoyoCerrar = "CerrarVentana";
                        this.Close();
                    }
                    break;
                default:
                    break;
            }
        }

        /// Ejecuta tareas iniciales
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            switch (apoyoCerrar)
            {
                case "Regresar":
                    e.Cancel = false;
                    break;
                case "Siguiente":
                    e.Cancel = false;
                    break;
                case "CerrarVentana":
                    VentanaHome v = new VentanaHome(idLlavesUsuarioImc);
                    v.Show();
                    e.Cancel = false;
                    break;
                default:
                    VentanaHome f = new VentanaHome(idLlavesUsuarioImc);
                    f.Show();
                    e.Cancel = false;
                    break;
            }
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
            tipoSesionLabel_VSeciPrueba.Content = parametrosActual.Sesion;
            seriesLabel_VSeci.Content = parametrosActual.Series;
        }
    }
}
