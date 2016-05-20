using System;
using System.Collections.Generic;
using System.Windows;

namespace SistemaSECI
{
    /// Interaction logic for VentanaEjemplosKinect.xaml
    public partial class VentanaEjemplosKinect : Window
    {
        public VentanaEjemplosKinect()
        {
            InitializeComponent();
        }

        private void botonN1_VNiveles_Click(object sender, RoutedEventArgs e)
        {
            VentanaBodyBasics v = new VentanaBodyBasics(1, 4, 3);
            v.Show();
            this.Close();
        }

        private void botonN2_VNiveles_Click(object sender, RoutedEventArgs e)
        {
            VentanaBodyBasics v = new VentanaBodyBasics(2, 4, 3);
            v.Show();
            this.Close();
        }

        private void botonN3_VNiveles_Click(object sender, RoutedEventArgs e)
        {
            VentanaBodyBasics v = new VentanaBodyBasics(3, 6, 4);
            v.Show();
            this.Close();
        }

        private void botonN4_VNiveles_Click(object sender, RoutedEventArgs e)
        {
            VentanaBodyBasics v = new VentanaBodyBasics(4, 6, 4);
            v.Show();
            this.Close();
        }

        private void botonN5_VNiveles_Click(object sender, RoutedEventArgs e)
        {
            VentanaBodyBasics v = new VentanaBodyBasics(5, 7, 5);
            v.Show();
            this.Close();
        }

        private void botonN6_VNiveles_Click(object sender, RoutedEventArgs e)
        {
            VentanaBodyBasics v = new VentanaBodyBasics(6, 7, 5);
            v.Show();
            this.Close();
        }

        private void botonN7_VNiveles_Click(object sender, RoutedEventArgs e)
        {
            VentanaBodyBasics v = new VentanaBodyBasics(7, 7, 5);
            v.Show();
            this.Close();
        }

        private void botonN8_VNiveles_Click(object sender, RoutedEventArgs e)
        {
            VentanaBodyBasics v = new VentanaBodyBasics(8, 8, 5);
            v.Show();
            this.Close();
        }

        private void botonN9_VNiveles_Click(object sender, RoutedEventArgs e)
        {
            VentanaBodyBasics v = new VentanaBodyBasics(9, 8, 5);
            v.Show();
            this.Close();
        }

        private void botonRegresar_VNiveles_Click(object sender, RoutedEventArgs e)
        {
            VentanaJuego v = new VentanaJuego();
            v.Show();
            this.Close();
        }
    }
}
