using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSECI
{
    class Seci
    {
        private String _ReforzadorTipo;
        private String _ReforzadorClase;
        private String _InmediatezInme;
        private String _InmediatezDemo;
        private String _EsfuerzoAlto;
        private String _EsfuerzoBajo;
        private String _ReforzamientoAlto;
        private String _ReforzamientoBajo;

        //variable statica para la instancia, se usa funcion lambda patron Singleton
        private static Seci Instance = null;

        //evitar instanciacion directa
        private Seci()
        {
        }
        public static Seci GetInstance(string A, string B, string C, string D, string E, string F, string G, string H)
        {
            if (Instance == null)
            {
                Instance = new Seci();
                Instance.inicializaDatos(A, B, C, D, E, F, G, H);
            }
            return Instance;
        }

        private void inicializaDatos(string A, string B, string C, string D, string E, string F, string G, string H)
        {
            try
            {
                ReforzadorTipo = A;
                ReforzadorClase = B;

                InmediatezInme = C;
                InmediatezDemo = D;

                EsfuerzoAlto = E;
                EsfuerzoBajo = F;

                ReforzamientoAlto = G;
                ReforzamientoBajo = H;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public string ReforzadorTipo
        {
            get
            {
                return _ReforzadorTipo;
            }

            set
            {
                _ReforzadorTipo = value;
            }
        }

        public string ReforzadorClase
        {
            get
            {
                return _ReforzadorClase;
            }

            set
            {
                _ReforzadorClase = value;
            }
        }

        public string InmediatezInme
        {
            get
            {
                return _InmediatezInme;
            }

            set
            {
                _InmediatezInme = value;
            }
        }

        public string InmediatezDemo
        {
            get
            {
                return _InmediatezDemo;
            }

            set
            {
                _InmediatezDemo = value;
            }
        }

        public string EsfuerzoAlto
        {
            get
            {
                return _EsfuerzoAlto;
            }

            set
            {
                _EsfuerzoAlto = value;
            }
        }

        public string EsfuerzoBajo
        {
            get
            {
                return _EsfuerzoBajo;
            }

            set
            {
                _EsfuerzoBajo = value;
            }
        }

        public string ReforzamientoAlto
        {
            get
            {
                return _ReforzamientoAlto;
            }

            set
            {
                _ReforzamientoAlto = value;
            }
        }

        public string ReforzamientoBajo
        {
            get
            {
                return _ReforzamientoBajo;
            }

            set
            {
                _ReforzamientoBajo = value;
            }
        }
    }
}
