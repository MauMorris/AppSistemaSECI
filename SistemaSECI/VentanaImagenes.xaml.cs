using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace SistemaSECI
{
    /// <summary>
    /// Interaction logic for VentanaImagenes.xaml
    /// </summary>
    public partial class VentanaImagenes : Window
    {
        int idLlaves = 0;
        int idParametros = 0;
        List<string> botonesAlta;

        string apoyoCerrar = "CerrarVentana";

        int elegidas = 0;
        bool[] botones;
        int numBotones = 20;


        public VentanaImagenes(int idParametrosSeci, int idLlavesUI, List<string> seleccionAnterior)
        {
            botones = new bool[numBotones];

            idParametros = idParametrosSeci;
            idLlaves = idLlavesUI;
            botonesAlta = seleccionAnterior;

            for (int i = 0; i < numBotones; i++)
                botones[i] = false;

            InitializeComponent();
        }

        private void bSiguiente_VImagenes_Click(object sender, RoutedEventArgs e)
        {
            if (elegidas == 5)
            {
                apoyoCerrar = "Siguiente";
                VentanaComparacion v = new VentanaComparacion(idParametros, idLlaves, botonesAlta);
                v.Show();
                this.Close();
            }
            else
                MessageBox.Show("Necesitas seleccionar 5 imagenes", "Error", MessageBoxButton.OK);
        }

        /// Ejecuta tareas iniciales
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            switch (apoyoCerrar)
            {
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

        private void b11_comida(object sender, RoutedEventArgs e)
        {
            if (botones[0] == false)
            {
                if (elegidas < 5)
                {
                    elegidas++;
                    Button b1 = (Button)sender;
                    CreaSombra(b1);

                    botonesAlta.Add("c_1.jpg");
                    botones[0] = true;
                }
            }
        }

        private void b12_comida(object sender, RoutedEventArgs e)
        {
            if (botones[1] == false)
            {
                if (elegidas < 5)
                {
                    elegidas++;
                    Button b1 = (Button)sender;
                    CreaSombra(b1);

                    botonesAlta.Add("c_2.jpg");
                    botones[1] = true;
                }
            }
        }

        private void b13_comida(object sender, RoutedEventArgs e)
        {
            if (botones[2] == false)
            {
                if (elegidas < 5)
                {
                    elegidas++;
                    Button b1 = (Button)sender;
                    CreaSombra(b1);

                    botonesAlta.Add("c_3.jpg");
                    botones[2] = true;
                }
            }
        }

        private void b14_comida(object sender, RoutedEventArgs e)
        {
            if (botones[3] == false)
            {
                if (elegidas < 5)
                {
                    elegidas++;
                    Button b1 = (Button)sender;
                    CreaSombra(b1);

                    botonesAlta.Add("c_4.jpg");
                    botones[3] = true;
                }
            }
        }

        private void b15_comida(object sender, RoutedEventArgs e)
        {
            if (botones[4] == false)
            {
                if (elegidas < 5)
                {
                    elegidas++;
                    Button b1 = (Button)sender;
                    CreaSombra(b1);

                    botonesAlta.Add("c_5.jpg");
                    botones[4] = true;
                }
            }
        }

        private void b21_comida(object sender, RoutedEventArgs e)
        {
            if (botones[5] == false)
            {
                if (elegidas < 5)
                {
                    elegidas++;
                    Button b1 = (Button)sender;
                    CreaSombra(b1);

                    botonesAlta.Add("c_6.jpg");
                    botones[5] = true;
                }
            }
        }

        private void b22_comida(object sender, RoutedEventArgs e)
        {
            if (botones[6] == false)
            {
                if (elegidas < 5)
                {
                    elegidas++;
                    Button b1 = (Button)sender;
                    CreaSombra(b1);

                    botonesAlta.Add("c_7.jpg");
                    botones[6] = true;
                }
            }
        }

        private void b23_comida(object sender, RoutedEventArgs e)
        {
            if (botones[7] == false)
            {
                if (elegidas < 5)
                {
                    elegidas++;
                    Button b1 = (Button)sender;
                    CreaSombra(b1);

                    botonesAlta.Add("c_8.jpg");
                    botones[7] = true;
                }
            }
        }

        private void b24_comida(object sender, RoutedEventArgs e)
        {
            if (botones[8] == false)
            {
                if (elegidas < 5)
                {
                    elegidas++;
                    Button b1 = (Button)sender;
                    CreaSombra(b1);

                    botonesAlta.Add("c_9.jpg");
                    botones[8] = true;
                }
            }
        }

        private void b25_comida(object sender, RoutedEventArgs e)
        {
            if (botones[9] == false)
            {
                if (elegidas < 5)
                {
                    elegidas++;
                    Button b1 = (Button)sender;
                    CreaSombra(b1);

                    botonesAlta.Add("c_10.jpg");
                    botones[9] = true;
                }
            }
        }

        private void b31_comida(object sender, RoutedEventArgs e)
        {
            if (botones[10] == false)
            {
                if (elegidas < 5)
                {
                    elegidas++;
                    Button b1 = (Button)sender;
                    CreaSombra(b1);

                    botonesAlta.Add("c_11.jpg");
                    botones[10] = true;
                }
            }
        }

        private void b32_comida(object sender, RoutedEventArgs e)
        {
            if (botones[11] == false)
            {
                if (elegidas < 5)
                {
                    elegidas++;
                    Button b1 = (Button)sender;
                    CreaSombra(b1);

                    botonesAlta.Add("c_12.jpg");
                    botones[11] = true;
                }
            }
        }

        private void b33_comida(object sender, RoutedEventArgs e)
        {
            if (botones[12] == false)
            {
                if (elegidas < 5)
                {
                    elegidas++;
                    Button b1 = (Button)sender;
                    CreaSombra(b1);

                    botonesAlta.Add("c_13.jpg");
                    botones[12] = true;
                }
            }
        }

        private void b34_comida(object sender, RoutedEventArgs e)
        {
            if (botones[13] == false)
            {
                if (elegidas < 5)
                {
                    elegidas++;
                    Button b1 = (Button)sender;
                    CreaSombra(b1);

                    botonesAlta.Add("c_14.jpg");
                    botones[13] = true;
                }
            }
        }

        private void b35_comida(object sender, RoutedEventArgs e)
        {
            if (botones[14] == false)
            {
                if (elegidas < 5)
                {
                    elegidas++;
                    Button b1 = (Button)sender;
                    CreaSombra(b1);

                    botonesAlta.Add("c_15.jpg");
                    botones[14] = true;
                }
            }
        }

        private void b41_comida(object sender, RoutedEventArgs e)
        {
            if (botones[15] == false)
            {
                if (elegidas < 5)
                {
                    elegidas++;
                    Button b1 = (Button)sender;
                    CreaSombra(b1);

                    botonesAlta.Add("c_16.jpg");
                    botones[15] = true;
                }
            }
        }

        private void b42_comida(object sender, RoutedEventArgs e)
        {
            if (botones[16] == false)
            {
                if (elegidas < 5)
                {
                    elegidas++;
                    Button b1 = (Button)sender;
                    CreaSombra(b1);

                    botonesAlta.Add("c_17.jpg");
                    botones[16] = true;
                }
            }
        }

        private void b43_comida(object sender, RoutedEventArgs e)
        {
            if (botones[17] == false)
            {
                if (elegidas < 5)
                {
                    elegidas++;
                    Button b1 = (Button)sender;
                    CreaSombra(b1);

                    botonesAlta.Add("c_18.jpg");
                    botones[17] = true;
                }
            }
        }

        private void b44_comida(object sender, RoutedEventArgs e)
        {
            if (botones[18] == false)
            {
                if (elegidas < 5)
                {
                    elegidas++;
                    Button b1 = (Button)sender;
                    CreaSombra(b1);

                    botonesAlta.Add("c_19.jpg");
                    botones[18] = true;
                }
            }
        }

        private void b45_comida(object sender, RoutedEventArgs e)
        {
            if (botones[19] == false)
            {
                if (elegidas < 5)
                {
                    elegidas++;
                    Button b1 = (Button)sender;
                    CreaSombra(b1);

                    botonesAlta.Add("c_20.jpg");
                    botones[19] = true;
                }
            }
        }

        private void CreaSombra(Button user)
        {
            DropShadowEffect myGlowEffect = new DropShadowEffect();

            // Set the color of the glow to blue.
            Color myGlowColor = new Color();
            myGlowColor.ScA = 1;
            myGlowColor.ScB = 1;
            myGlowColor.ScG = 0;
            myGlowColor.ScR = 0;

            myGlowEffect.Color = myGlowColor;
            // Set the direction of where the shadow is cast to 320 degrees.
            myGlowEffect.Direction = 320;
            // Set the depth of the shadow being cast.
            myGlowEffect.ShadowDepth = 8;
            // Set the shadow opacity to half opaque or in other words - half transparent.
            // The range is 0-1.
            myGlowEffect.Opacity = 0.5;
            // Apply the bitmap effect to the Button.
            user.Effect = (Effect) myGlowEffect;
        }
    }
}
