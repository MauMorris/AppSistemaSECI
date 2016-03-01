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
    /// Interaction logic for VentanaEjemplosKinect.xaml
    /// </summary>
    public partial class VentanaEjemplosKinect : Window
    {
        public VentanaEjemplosKinect()
        {
            InitializeComponent();
        }

        private void botonAudio_VEjemplos_Click(object sender, RoutedEventArgs e)
        {
            VentanaAudioBasics v = new VentanaAudioBasics();
            v.Show();
            this.Close();
        }

        private void botonBody_VEjemplos_Copy_Click(object sender, RoutedEventArgs e)
        {
            VentanaBodyBasics v = new VentanaBodyBasics();
            v.Show();
            this.Close();
        }

        private void botonAudio_VEjemplos_Copy_Click(object sender, RoutedEventArgs e)
        {
            VentanaJuego v = new VentanaJuego();
            v.Show();
            this.Close();
        }
    }
}
