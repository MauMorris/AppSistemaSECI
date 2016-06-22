using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SistemaSECI
{
    /// <summary>
    /// Lógica de interacción para VentanaModificarSimple.xaml
    /// </summary>
    public partial class VentanaModificarSimple : Window
    {
        DatosUsuario paciente = new DatosUsuario();
        ManejadorTablas nuevoU;

        public VentanaModificarSimple()
        {
            InitializeComponent();
            InicializaTextBoxes();
            estaturaTextBox_VModificarSimple.Focus();
        }

        private void okBoton_VModificarSimple_Click(object sender, RoutedEventArgs e)
        {
            PasoParametros();
            if (EverythingOK())
            {
                QueryParametros();
                this.Close();
            }
        }

        private static bool NumeroPermitidoConPunto(string text)
        {
            Regex numPunto = new Regex("[^0-9.]+");
            return !numPunto.IsMatch(text);
        }
        private void ValidacionNumerosPuntoTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !NumeroPermitidoConPunto(e.Text);
        }

        private void PasoParametros()
        {
            Double apoyo2 = 0;
            try
            {
                if (Double.TryParse(estaturaTextBox_VModificarSimple.Text, out apoyo2))
                    paciente.Estatura = apoyo2;
                else
                    paciente.Estatura = 0;

                if (Double.TryParse(pesoTextBox_VModificarSimple.Text, out apoyo2))
                    paciente.Peso = apoyo2;
                else
                    paciente.Peso = 0;
            }
            catch (Exception e)
            {
                String errorText = e.Message;
                MessageBox.Show("Error de formato \n" + errorText, "Error de ingreso de informacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool EverythingOK()
        {
            if (paciente.Estatura == 0 | paciente.Peso == 0)
            {
                MessageBox.Show("Necesitas llenar uno o mas parámetros", "Error de ingreso de informacion", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else
            {
                try
                {
                    paciente.Imc = paciente.Imc_Calculo(paciente.Estatura, paciente.Peso);
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
            nuevoU = new ManejadorTablas();
            nuevoU.InsertIMC(paciente.Estatura, paciente.Peso, paciente.Imc);
            nuevoU.UpdateIMC(1, paciente.Estatura, paciente.Peso, paciente.Imc);
        }

        private void PegarTexto(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!NumeroPermitidoConPunto(text))
                    e.CancelCommand();
            }
            else
                e.CancelCommand();
        }

        private void InicializaTextBoxes()
        {
            estaturaTextBox_VModificarSimple.Text = string.Empty;
            pesoTextBox_VModificarSimple.Text = string.Empty;
        }
    }
}
