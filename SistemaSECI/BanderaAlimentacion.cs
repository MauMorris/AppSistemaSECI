using System;

namespace SistemaSECI
{
    class BanderaAlimentacion
    {
        private int bandera;
        public int Bandera
        {
            get
            {
                return bandera;
            }

            set
            {
                bandera = value;
            }
        }

        private bool click;
        public bool Click
        {
            get
            {
                return click;
            }

            set
            {
                click = value;
            }
        }

        public BanderaAlimentacion()
        {
            Bandera = (int) DiaSemana.lunes;
            Click = false;
        }
    }
}
