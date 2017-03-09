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
                VentanaImagenes v = new VentanaImagenes(idParametros, idLlaves);
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
