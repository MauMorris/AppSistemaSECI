using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace SistemaSECI
{
    /// <summary>
    /// Lógica de interacción para VentanaSeci.xaml
    /// </summary>
    public partial class VentanaSeci : Window
    {
        String tipoReforzador = "Comidas";
        String tipoReforzadorAdd = "Personalizar";
        String[] claseReforzador = {"Niño","Niña"};

        int[] pAltoReforzamiento = {5, 10, 20};
        int[] pBajoReforzamiento = {20, 40, 60};

        int idLlaves = 0;
        int idSeciParametros = 0;

        string tipoDeSesion = string.Empty;
        string apoyoCerrar = "CerrarVentana";

        Seci paciente = new Seci();
        TablasDBHelper nuevoU;

        public VentanaSeci(int LlavesId, string tipoSesion)
        {
            InitializeComponent();
            inicializaComboBoxes();

            idLlaves = LlavesId;
            tipoDeSesion = tipoSesion;

            tipoSesionLabel_VSeci.Content = tipoDeSesion;
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
                    VentanaHome v = new VentanaHome(idLlaves);
                    v.Show();
                    e.Cancel = false;
                    break;
                default:
                    VentanaHome f = new VentanaHome(idLlaves);
                    f.Show();
                    e.Cancel = false;
                    break;
            }
        }

        private void okBoton_VSeci_Click(object sender, RoutedEventArgs e)
        {
            nuevoU = new TablasDBHelper();

            PasoParametros();
            if (EverythingOK())
            {
                nuevoU.InsertarParametrosSesion(paciente.ReforzadorTipo, paciente.ReforzadorClase, 5, paciente.InmediatezI,
                                            paciente.InmediatezD, paciente.EsfuerzoAlto, paciente.EsfuerzoBajo,
                                            paciente.ReforzamientoAlto, paciente.ReforzamientoBajo, tipoDeSesion);

                idSeciParametros = nuevoU.ConsultaIdUltimoParametrosSeci();

                apoyoCerrar = "Siguiente";

                VentanaSeciPrueba v = new VentanaSeciPrueba(idSeciParametros, idLlaves);
                v.Show();
                this.Close();
            }
        }

        private void regresarBoton_VLogros_Click(object sender, RoutedEventArgs e)
        {
            apoyoCerrar = "Regresar";

            VentanaSeleccionSeci v = new VentanaSeleccionSeci(idLlaves);
            v.Show();
            this.Close();
        }

        private void IniInmediatezD()
        {
            string apoyo = "";
            for (int i = 10; i < 60; i+=10)
            {
                apoyo = i + " minutos";
                inmediatezDemoCB_VSeci.Items.Add(apoyo);
            }
            inmediatezDemoCB_VSeci.Items.Add("1 hora");
            for (int j = 2; j <= 6; j+=2)
            {
                apoyo = j + " horas";
                inmediatezDemoCB_VSeci.Items.Add(apoyo);
            }
            inmediatezDemoCB_VSeci.Items.Add("12 horas");
            inmediatezDemoCB_VSeci.Items.Add("Mañana");
        }

        private void inicializaComboBoxes()
        {
            reforzadorTipoCB_VSeci.Items.Add(tipoReforzador);
            reforzadorTipoCB_VSeci.Items.Add(tipoReforzadorAdd);

            foreach (String reforzador in claseReforzador)
                reforzadorClaseCB_VSeci.Items.Add(reforzador);

            inmediatezInmeCB_VSeci.Items.Add("Inmediato");
            IniInmediatezD();

            for (int i = 2; i < 10; i++)
                esfuerzoAltoCB_VSeci.Items.Add(i);

            esfuerzoBajoCB_VSeci.Items.Add(1);

            foreach (int altoReforzamiento in pAltoReforzamiento)
                reforzamientoAltoCB_VSeci.Items.Add(altoReforzamiento);

            foreach (int bajoReforzamiento in pBajoReforzamiento)
                reforzamientoBajoCB_VSeci.Items.Add(bajoReforzamiento);
        }

        private void esfuerzoAltoCB_VSeci_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            esfuerzoBajoCB_VSeci.Items.Clear();

            if (int.Parse(esfuerzoAltoCB_VSeci.SelectedItem.ToString()) > 4)
                for (int i = 1; i < int.Parse(esfuerzoAltoCB_VSeci.SelectedItem.ToString()) - 2; i++)
                    esfuerzoBajoCB_VSeci.Items.Add(i);
            else
                esfuerzoBajoCB_VSeci.Items.Add(1);
        }

        private void reforzadorClaseCB_VSeci_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string colores = String.Empty;
            if (reforzadorClaseCB_VSeci.SelectedItem.ToString().Equals("niño"))
                colores = "green";
            else
                colores = "blue";
        }

        private void reforzadorTipoCB_VSeci_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (reforzadorTipoCB_VSeci.SelectedItem.ToString().Equals(tipoReforzadorAdd))
            {
                var seleccion = MessageBox.Show("Seleccione las imagenes desde un folder especifico", "Agregar nuevo reforzador", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (seleccion.Equals(MessageBoxResult.Yes))
                {
                    OpenFileDialog v = new OpenFileDialog();
                    v.Multiselect = true;
                    v.Filter = "JPG files (*.jpg)|*.jpg| TIFF files (*.tiff)|*.tiff| PNG files(*.png)|*.png";
                    v.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                    if (v.ShowDialog().Equals(true))
                    {
                        reforzadorTipoCB_VSeci.Items.Add("NuevoComidas");
                    }
                }
            }
        }

        private void PasoParametros()
        {
            int apoyo = 0;

            try
            {
                paciente.ReforzadorTipo = reforzadorTipoCB_VSeci.SelectedItem.ToString();
                paciente.ReforzadorClase = reforzadorClaseCB_VSeci.SelectedItem.ToString();

                paciente.InmediatezI = inmediatezInmeCB_VSeci.SelectedItem.ToString();
                paciente.InmediatezD = inmediatezDemoCB_VSeci.SelectedItem.ToString();

                if (Int32.TryParse(esfuerzoBajoCB_VSeci.SelectedItem.ToString(), out apoyo))
                    paciente.EsfuerzoBajo = apoyo;
                else
                    paciente.EsfuerzoBajo = 0;

                if (Int32.TryParse(esfuerzoAltoCB_VSeci.SelectedItem.ToString(), out apoyo))
                    paciente.EsfuerzoAlto = apoyo;
                else
                    paciente.EsfuerzoAlto = 0;

                if (Int32.TryParse(reforzamientoAltoCB_VSeci.SelectedItem.ToString(), out apoyo))
                    paciente.ReforzamientoAlto = apoyo;
                else
                    paciente.ReforzamientoAlto = 0;

                if (Int32.TryParse(reforzamientoBajoCB_VSeci.SelectedItem.ToString(), out apoyo))
                    paciente.ReforzamientoBajo = apoyo;
                else
                    paciente.ReforzamientoBajo = 0;
            }
            catch (Exception e)
            {
                String errorText = e.Message;
                MessageBox.Show("Error de formato \n" + errorText, "Error de ingreso de informacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool EverythingOK()
        {
            if (paciente.ReforzadorTipo == String.Empty | paciente.ReforzadorClase == String.Empty |
                paciente.InmediatezI == String.Empty | paciente.InmediatezD == String.Empty |
                paciente.EsfuerzoAlto == 0 | paciente.EsfuerzoBajo == 0 |
                paciente.ReforzamientoAlto == 0 | paciente.ReforzamientoBajo == 0)
            {
                MessageBox.Show("Necesitas llenar uno o mas parámetros", "Error de ingreso de informacion", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else
                return true;
        }

    }
}

