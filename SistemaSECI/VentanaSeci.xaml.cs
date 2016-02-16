using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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

        int[] pAltoReforzamiento = {5, 10};
        int[] pBajoReforzamiento = {20, 60};

        public VentanaSeci()
        {
            InitializeComponent();
            inicializaComboBoxes();
        }
        private void okBoton_VSeci_Click(object sender, RoutedEventArgs e)
        {
            VentanaSeciPrueba v = new VentanaSeciPrueba();
            v.Show();
            this.Close();
        }
        private void IniReforzadorTipoCB()
        {
            reforzadorTipoCB_VSeci.Items.Add(tipoReforzador);
            reforzadorTipoCB_VSeci.Items.Add(tipoReforzadorAdd);
        }
        private void IniReforzadorClaseCB()
        {
            for(int i = 0; i < claseReforzador.Length; i++)
                reforzadorClaseCB_VSeci.Items.Add(claseReforzador[i]);
        }
        private void IniInmediatezInmeCB()
        {
            inmediatezInmeCB_VSeci.Items.Add("1 minuto");
            string apoyo = "";
            for (int i = 2; i <= 5; i++)
            {
                apoyo = i + " minutos";
                inmediatezInmeCB_VSeci.Items.Add(apoyo);
            }
        }
        private void IniInmediatezDemoCB()
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
        private void IniEsfuerzoAltoCB()
        {
            for (int i = 2; i < 10; i++)
                esfuerzoAltoCB_VSeci.Items.Add(i);
        }
        private void IniEsfuerzoBajoCB()
        {
            esfuerzoBajoCB_VSeci.Items.Add(1);
        }
        private void IniReforzamientoAltoCB()
        {
            for(int i = 0; i < pAltoReforzamiento.Length; i++)
                reforzamientoAltoCB_VSeci.Items.Add(pAltoReforzamiento[i]);
        }
        private void IniReforzamientoBajoCB()
        {
            for(int i = 0; i < pBajoReforzamiento.Length; i++)
                reforzamientoBajoCB_VSeci.Items.Add(pBajoReforzamiento[i]);
        }
        private void inicializaComboBoxes()
        {
            IniReforzadorTipoCB();
            IniReforzadorClaseCB();

            IniInmediatezInmeCB();
            IniInmediatezDemoCB();

            IniEsfuerzoAltoCB();
            IniEsfuerzoBajoCB();

            IniReforzamientoAltoCB();
            IniReforzamientoBajoCB();
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
        }
        private void reforzadorTipoCB_VSeci_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (reforzadorTipoCB_VSeci.SelectedItem.ToString() == tipoReforzadorAdd)
            {
                agregarNuevoReforzador();
            }
        }
        private void agregarNuevoReforzador()
        {
            MessageBox.Show("Seleccione las imagenes desde un folder especifico");
            OpenFileDialog v = new OpenFileDialog();
            v.Multiselect = true;
            v.Filter = "JPG files (*.jpg)|*.jpg| TIFF files (*.tiff)|*.tiff| PNG files(*.png)|*.png";
            v.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            if (v.ShowDialog() == true)
                reforzadorTipoCB_VSeci.Items.Add("NuevoComidas");
                           
        }
        private void agregarSeci()
        {
            String A = reforzadorTipoCB_VSeci.SelectedItem.ToString();
            String B = reforzadorClaseCB_VSeci.SelectedItem.ToString();

            String C = inmediatezInmeCB_VSeci.SelectedItem.ToString();
            String D = inmediatezDemoCB_VSeci.SelectedItem.ToString();

            String E = esfuerzoAltoCB_VSeci.SelectedItem.ToString();
            String F = esfuerzoBajoCB_VSeci.SelectedItem.ToString();

            String G = reforzamientoAltoCB_VSeci.SelectedItem.ToString();
            String H = reforzamientoBajoCB_VSeci.SelectedItem.ToString();

//            Seci nuevo = Instance.GetInstance(A, B, C, D, E, F, G, H);

        }        
    }
}

