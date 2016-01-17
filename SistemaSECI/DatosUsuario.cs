using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSECI
{
    class DatosUsuario
    {
        private String _Nombre;
        private String _Apellido;
        private int _Edad;
        private String _Escolaridad;
        private String _Sexo;
        private decimal _Estatura;
        private decimal _Peso;

        private String _NombreTutor;
        private int _EdadTutor;
        private Int64 _TelefonoTutor;
        public string Nombre
        {
            get
            {
                return _Nombre;
            }

            set
            {
                _Nombre = value;
            }
        }
        public string Apellido
        {
            get
            {
                return _Apellido;
            }

            set
            {
                _Apellido = value;
            }
        }
        public int Edad
        {
            get
            {
                return _Edad;
            }

            set
            {
                _Edad = value;
            }
        }
        public string Escolaridad
        {
            get
            {
                return _Escolaridad;
            }

            set
            {
                _Escolaridad = value;
            }
        }
        public string Sexo
        {
            get
            {
                return _Sexo;
            }

            set
            {
                _Sexo = value;
            }
        }
        public decimal Estatura
        {
            get
            {
                return _Estatura;
            }

            set
            {
                _Estatura = value;
            }
        }
        public decimal Peso
        {
            get
            {
                return _Peso;
            }

            set
            {
                _Peso = value;
            }
        }
        public string NombreTutor
        {
            get
            {
                return _NombreTutor;
            }

            set
            {
                _NombreTutor = value;
            }
        }
        public int EdadTutor
        {
            get
            {
                return _EdadTutor;
            }

            set
            {
                _EdadTutor = value;
            }
        }
        public long TelefonoTutor
        {
            get
            {
                return _TelefonoTutor;
            }

            set
            {
                _TelefonoTutor = value;
            }
        }
        public DatosUsuario()
        {
            Nombre = "Vacio";
            Apellido = "Vacio";
            Edad = 0;
            Escolaridad = "Vacio";
            Sexo = "Vacio";
            Estatura = 0.0m;
            Peso = 0.0m;

            NombreTutor = "Vacio";
            EdadTutor = 0;
            TelefonoTutor = 0;
        }

    }
}
