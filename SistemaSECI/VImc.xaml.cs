using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace SistemaSECI
{
    /// <summary>
    /// Lógica de interacción para VentanaModificarSimple.xaml
    /// </summary>
    public partial class VImc : Window
    {
        Imc paciente = new Imc();
        TablasDBHelper nuevoU;
        ExpresionesReg match = new ExpresionesReg();

        int idApoyo = 0;
        int idImcApoyo = 0;
        int idLlavesApoyo = 0;

        int ventanaAnterior = 2;//2 esta asignado para que continue con el flujo del programa

        public VImc(int numeroVentanaAnterior, int idPaciente)
        {
            InitializeComponent();
            InicializaTextBoxes();
            estaturaTB_VImc.Focus();

            ventanaAnterior = numeroVentanaAnterior;
            idApoyo = idPaciente;
        }

        /// Ejecuta tareas iniciales
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            switch (ventanaAnterior)
            {
                case 0:
                    VentanaUsuarioReciente v = new VentanaUsuarioReciente();
                    v.Show();
                    e.Cancel = false;
                    break;
                case 1:
                    VUsuarios f = new VUsuarios();
                    f.Show();
                    e.Cancel = false;
                    break;
                case 2:
                    e.Cancel = false;
                    break;
                default:
                    e.Cancel = false;
                    break;
            }
        }

        private void okBoton_VImc_Click(object sender, RoutedEventArgs e)
        {
            PasoParametros();
            if (TodoBien())
            {
                QueryParametros();
                ventanaAnterior = 2;
                VentanaHome v = new VentanaHome(idLlavesApoyo);
                v.Show();
                this.Close();
            }
        }

        private void PasoParametros()
        {
            double apoyo = 0.0;

            try
            {
                if (Double.TryParse(pesoTB_VImc.Text, out apoyo))
                    paciente.Peso = apoyo;
                else
                    paciente.Peso = 0.0;

                if (Double.TryParse(estaturaTB_VImc.Text, out apoyo))
                    paciente.Estatura = apoyo;
                else
                    paciente.Estatura = 0.0;
            }
            catch (Exception e)
            {
                String errorText = e.Message;
                MessageBox.Show("Error de formato \n" + errorText, "Error de ingreso de informacion",
                                                                    MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private bool TodoBien()
        {
            if (paciente.Estatura == 0.0 | paciente.Peso == 0.0)
            {
                MessageBox.Show("Necesitas llenar uno o mas parámetros", "Error de ingreso de informacion", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else
            {
                try
                {
                    paciente.Imc_Calculo();
                    return true;
                }
                catch (Exception e)
                {
                    String errorText = e.Message;
                    MessageBox.Show("Error de formato \n" + errorText, "Error de ingreso de informacion", MessageBoxButton.OK, MessageBoxImage.Error);
                    return true;
                }
            }
        }

        private void QueryParametros()
        {
            nuevoU = new TablasDBHelper();

            nuevoU.InsertarImc(paciente.Estatura, paciente.Peso, paciente.IMC);

            idImcApoyo = nuevoU.ConsultaIdUltimoImc();

            nuevoU.InsertarLlavesUsuarioImc(idApoyo, idImcApoyo);

            idLlavesApoyo = nuevoU.ConsultaUltimoLlaves();
        }

        private void InicializaTextBoxes()
        {
            estaturaTB_VImc.Text = string.Empty;
            pesoTB_VImc.Text = string.Empty;
        }

        private void ValidarNumero(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !match.Numero(e.Text);
        }

        private void ValidarNumeroConPunto(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !match.NumeroConPunto(e.Text);
        }

        private void PegarNumero(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!match.Numero(text))
                    e.CancelCommand();
            }
            else
                e.CancelCommand();
        }

        private void PegarNumeroConPunto(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!match.NumeroConPunto(text))
                    e.CancelCommand();
            }
            else
                e.CancelCommand();
        }
    }
}
