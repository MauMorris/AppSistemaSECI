using Microsoft.Win32;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SistemaSECI
{
    /// <summary>
    /// Interaction logic for VentanaDieta.xaml
    /// </summary>
    public partial class VentanaDieta : Window
    {
        Alimentacion[] semana;

        Alimentacion comodin;

        int bandera;

        public VentanaDieta()
        {
            InitializeComponent();

            bandera = (int) diasSemana.lunes;
            semana = new Alimentacion[7];
            comodin = new Alimentacion();

            InicializaTextBoxes();

            desayunoTextBox_VDieta.Focus();
            lBox_VDieta.SelectedItem = LunesTBlock_VDieta;
        }

        private void lBox_VDieta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            guardaDatosTextBox(comodin);
            InicializaTextBoxes();

            switch (lBox_VDieta.SelectedItem.ToString())
            {
                case "LUNES":
                    banderaDatos(bandera, comodin, semana[0]);
                    bandera = (int) diasSemana.lunes;
                    desayunoTextBox_VDieta.Text = "Lunes";
                    break;
                case "MARTES":
                    banderaDatos(bandera, comodin, semana[1]);
                    bandera = (int) diasSemana.martes;
                    almuerzoTextBox_VDieta.Text = "Martes";
                    break;
                case "MIERCOLES":
                    banderaDatos(bandera, comodin, semana[2]);
                    bandera = (int) diasSemana.miercoles;
                    break;
                case "JUEVES":
                    banderaDatos(bandera, comodin, semana[3]);
                    bandera = (int) diasSemana.jueves;
                    break;
                case "VIERNES":
                    banderaDatos(bandera, comodin, semana[4]);
                    bandera = (int) diasSemana.viernes;
                    break;
                case "SABADO":
                    banderaDatos(bandera, comodin, semana[5]);
                    bandera = (int) diasSemana.sabado;
                    break;
                case "DOMINGO":
                    banderaDatos(bandera, comodin, semana[6]);
                    bandera = (int) diasSemana.domingo;
                    break;
                default:
                    break;
            }
        }

        private void banderaDatos(int bandera, Alimentacion comodin, Alimentacion diaActual)
        {
                    switch (bandera)
                    {
                        case (int)diasSemana.lunes:
                            semana[0] = comodin;
                            recuperaDatosTextBox(diaActual);
                            break;
                        case (int) diasSemana.martes:
                            semana[1] = comodin;
                            recuperaDatosTextBox(diaActual);
                            break;
                        case (int) diasSemana.miercoles:
                            semana[2] = comodin;
                            recuperaDatosTextBox(diaActual);
                            break;
                        case (int) diasSemana.jueves:
                            semana[3] = comodin;
                            recuperaDatosTextBox(diaActual);
                            break;
                        case (int) diasSemana.viernes:
                            semana[4] = comodin;
                            recuperaDatosTextBox(diaActual);
                            break;
                        case (int) diasSemana.sabado:
                            semana[5] = comodin;
                            recuperaDatosTextBox(diaActual);
                            break;
                        case (int) diasSemana.domingo:
                            semana[6] = comodin;
                            recuperaDatosTextBox(diaActual);
                            break;
                        default:
                            break;
                    }
        }

        private void InicializaTextBoxes()
        {
            desayunoTextBox_VDieta.Text = String.Empty;
            almuerzoTextBox_VDieta.Text = String.Empty;
            comidaTextBox_VDieta.Text = String.Empty;
            meriendaTextBox_VDieta.Text = String.Empty;
            cenaTextBox_VDieta.Text = String.Empty;
            rubricaTextBox_VDieta.Text = String.Empty;
            comentarioTextBox_VDieta.Text = String.Empty;            
        }

        private void recuperaDatosTextBox(Alimentacion comodin)
        {
            desayunoTextBox_VDieta.Text = comodin.Desayuno;
            almuerzoTextBox_VDieta.Text = comodin.Almuerzo;
            comidaTextBox_VDieta.Text = comodin.Comida;
            meriendaTextBox_VDieta.Text = comodin.Merienda;
            cenaTextBox_VDieta.Text = comodin.Cena;
            rubricaTextBox_VDieta.Text = comodin.Rubrica.ToString();
            comentarioTextBox_VDieta.Text = comodin.Comentarios;
        }

        private void guardaDatosTextBox(Alimentacion comodin)
        {
            int result = 0;

            comodin.Desayuno = desayunoTextBox_VDieta.Text;
            comodin.Almuerzo = almuerzoTextBox_VDieta.Text;
            comodin.Comida = comidaTextBox_VDieta.Text;
            comodin.Merienda = meriendaTextBox_VDieta.Text;
            comodin.Cena = cenaTextBox_VDieta.Text;

            if (Int32.TryParse(rubricaTextBox_VDieta.Text, out result))
                comodin.Rubrica = result;
            else
                comodin.Rubrica = 0;

            comodin.Comentarios = comentarioTextBox_VDieta.Text;
        }

        private void regresarBoton_VDieta_Click(object sender, RoutedEventArgs e)
        {
            VentanaHome v = new VentanaHome();
            v.Show();
            this.Close();
        }

        private void videoBoton_VDieta_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/?hl=es-419&gl=MX");
        }

        private void guiaBoton_VDieta_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog v = new OpenFileDialog();
            v.Multiselect = false;
            v.Filter = "Presentaciones de Power Point (*.ppt, *.pptx)|*.ppt;*.pptx| PDF files (*.pdf)|*.pdf| Documentos de Word (*.doc, *.docx)|*.doc;*.docx| Archivos de Excel (*.xls, *.xlsx)|*.xls;*.xlsx| Todos los Archivos (*.*)|*.*";
            v.Title = "Seleccion para el paciente";
            v.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (v.ShowDialog().Equals(true))
                System.Diagnostics.Process.Start(v.FileName);
        }

        private static bool NumeroPermitido(string text)
        {
            Regex numPermitido = new Regex("[^0-9]");
            return !numPermitido.IsMatch(text);
        }

        private void ValidacionNumeroTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !NumeroPermitido(e.Text);
        }

        private static bool DatoPermitido(string text)
        {
            Regex datoPermitido = new Regex("[^a-zA-Z0-9]");
            return !datoPermitido.IsMatch(text);
        }

        private void ValidacionTextoNumeroSignoTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !DatoPermitido(e.Text);
        }

        private void PegarTexto(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!DatoPermitido(text))
                    e.CancelCommand();
            }
            else
                e.CancelCommand();
        }

        private void OkBoton_VDieta_Click(object sender, RoutedEventArgs e)
        {
            VentanaHome v = new VentanaHome();
            v.Show();
            this.Close();
        }
    }
}
