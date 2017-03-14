using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace SistemaSECI
{
    /// <summary>
    /// Interaction logic for VentanaImagenesSaludables.xaml
    /// </summary>
    public partial class VentanaImagenesSaludables : Window
    {
        int idLlaves = 0;
        int idParametros = 0;
        string apoyoCerrar = "CerrarVentana";

        int elegidas = 0;
        bool[] botones;
        int numBotones = 20;
        List<string> botonesAlta = new List<string>();

        public VentanaImagenesSaludables(int idParametrosSeci, int idLlavesUI)
        {
            idParametros = idParametrosSeci;
            idLlaves = idLlavesUI;

            botones = new bool[numBotones];

            for (int i = 0; i < numBotones; i++)
                botones[i] = false;

            InitializeComponent();
        }

        private void botonSiguiente_Click(object sender, RoutedEventArgs e)
        {
            if (elegidas == 5)
            {
                apoyoCerrar = "Siguiente";
                VentanaImagenes v = new VentanaImagenes(idParametros, idLlaves, botonesAlta);
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

                    botonesAlta.Add("s_1.jpg");                   
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

                    botonesAlta.Add("s_2.jpg");
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

                    botonesAlta.Add("s_3.jpg");
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

                    botonesAlta.Add("s_4.jpg");
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

                    botonesAlta.Add("s_5.jpg");
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

                    botonesAlta.Add("s_6.jpg");
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

                    botonesAlta.Add("s_7.jpg");
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

                    botonesAlta.Add("s_8.jpg");
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

                    botonesAlta.Add("s_9.jpg");
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

                    botonesAlta.Add("s_10.jpg");
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

                    botonesAlta.Add("s_11.jpg");
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

                    botonesAlta.Add("s_12.jpg");
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

                    botonesAlta.Add("s_13.jpg");
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

                    botonesAlta.Add("s_14.jpg");
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

                    botonesAlta.Add("s_15.jpg");
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

                    botonesAlta.Add("s_16.jpg");
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

                    botonesAlta.Add("s_17.jpg");
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

                    botonesAlta.Add("s_18.jpg");
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

                    botonesAlta.Add("s_19.jpg");
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

                    botonesAlta.Add("s_20.jpg");
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
