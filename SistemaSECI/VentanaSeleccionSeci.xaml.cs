using System.ComponentModel;
using System.Windows;

namespace SistemaSECI
{
    /// <summary>
    /// Lógica de interacción para VentanaSeleccionSeci.xaml
    /// </summary>
    public partial class VentanaSeleccionSeci : Window
    {
        TablasDBHelper nuevoUsuario;

        int idLlavesUsuarioImc = 0;
        string tipoDeSesion = string.Empty;
        string apoyoCerrar = "Home";

        public VentanaSeleccionSeci(int idLlaves)
        {
            idLlavesUsuarioImc = idLlaves;
            InitializeComponent();
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
                case "linea_base":
                    e.Cancel = false;
                    break;
                case "evaluacion":
                    e.Cancel = false;
                    break;
                case "replica":
                    e.Cancel = false;
                    break;
                case "Home":
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

        private void lineaBaseBoton_VSeci_Click(object sender, RoutedEventArgs e)
        {
            tipoDeSesion = Contrato.ParametrosSeci.LINEA_BASE;
            apoyoCerrar = Contrato.ParametrosSeci.LINEA_BASE;

            VentanaSeci v = new VentanaSeci(idLlavesUsuarioImc, tipoDeSesion);
            v.Show();
            this.Close();
        }

        private void evaluacionBoton_VSeleccionSeci_Click(object sender, RoutedEventArgs e)
        {
//            if
            tipoDeSesion = Contrato.ParametrosSeci.EVALUACION;
            apoyoCerrar = Contrato.ParametrosSeci.EVALUACION;

            VentanaSeci v = new VentanaSeci(idLlavesUsuarioImc, tipoDeSesion);
            v.Show();
            this.Close();
        }

        private void tratamientoBoton_VSeleccionSeci_Click(object sender, RoutedEventArgs e)
        {
            tipoDeSesion = Contrato.ParametrosSeci.REPLICA;
            apoyoCerrar = Contrato.ParametrosSeci.REPLICA;

            VentanaSeci v = new VentanaSeci(idLlavesUsuarioImc, tipoDeSesion);
            v.Show();
            this.Close();
        }

        private void regresarBoton_VModificar_Click(object sender, RoutedEventArgs e)
        {
            apoyoCerrar = "Regresar";
            VentanaHome v = new VentanaHome(idLlavesUsuarioImc);
            v.Show();
            this.Close();
        }
    }
}
