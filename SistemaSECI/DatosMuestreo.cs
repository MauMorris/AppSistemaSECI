
using System;

namespace SistemaSECI
{
    class DatosMuestreo
    {
        private string imagen1;
        private string imagen2;
        private string resultado;
        private string tiempo;

        public string Imagen1
        {
            get
            {
                return imagen1;
            }

            set
            {
                imagen1 = value;
            }
        }

        public string Imagen2
        {
            get
            {
                return imagen2;
            }

            set
            {
                imagen2 = value;
            }
        }

        public string Resultado
        {
            get
            {
                return resultado;
            }

            set
            {
                resultado = value;
            }
        }

        public string Tiempo
        {
            get
            {
                return tiempo;
            }

            set
            {
                tiempo = value;
            }
        }

        public DatosMuestreo()
        {
            imagen1 = string.Empty;
            imagen2 = string.Empty;
            resultado = string.Empty;
            tiempo = string.Empty;
        }
        public DatosMuestreo(string i1, string i2, string res, string tim)
        {
            imagen1 = i1;
            imagen2 = i2;
            resultado = res;
            tiempo = tim;
        }
    }
}
