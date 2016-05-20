using System;
using System.ComponentModel;

namespace SistemaSECI
{
    class DatosUsuario: INotifyPropertyChanged
    {
        private string nombre;
        public String Nombre
        {
            get
            { return nombre; }
            set
            {
                if (this.nombre != value)
                {
                    this.nombre = value;
                    // notificacion debida al cambio de texto de status 
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NombreText"));
                }
            }
        }

        private string apellidos;
        public String Apellidos
        {
            get
            { return apellidos; }
            set
            {
                if (this.apellidos != value)
                {
                    this.apellidos = value;
                    // notificacion debida al cambio de texto de status 
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ApellidosText"));
                }
            }
        }

        private int edad;
        public int Edad
        {
            get
            { return edad; }
            set
            {
                if (this.edad != value)
                {
                    this.edad = value;
                    // notificacion debida al cambio de texto de status 
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("EdadText"));
                }
            }
        }

        private string escolaridad;
        public String Escolaridad
        {
            get
            { return escolaridad; }

            set
            {
                if (this.escolaridad != value)
                {
                    this.escolaridad = value;
                    // notificacion debida al cambio de texto de status 
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("EscolaridadText"));
                }
            }
        }

        private string sexo;
        public String Sexo
        {
            get
            { return sexo; }
            set
            {
                if (this.sexo != value)
                {
                    this.sexo = value;
                    // notificacion debida al cambio de texto de status 
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SexoText"));
                }
            }
        }

        private double estatura;
        public double Estatura
        {
            get
            { return estatura; }
            set
            {
                if (this.estatura != value)
                {
                    this.estatura = value;
                    // notificacion debida al cambio de texto de status 
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("EstaturaText"));
                }
            }
        }

        private double peso;
        public double Peso
        {
            get
            { return peso; }
            set
            {
                if (this.peso != value)
                {
                    this.peso = value;
                    // notificacion debida al cambio de texto de status 
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PesoText"));
                }
            }
        }

        private double imc;
        public double Imc
        {
            get
            { return imc; }
            set
            {
                if (this.imc != value)
                {
                    this.imc = value;
                    // notificacion debida al cambio de texto de status 
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IMCText"));
                }
            }
        }

        private string nombreTutor;
        public String NombreTutor
        {
            get
            { return nombreTutor; }
            set
            {
                if (this.nombreTutor != value)
                {
                    this.nombreTutor = value;
                    // notificacion debida al cambio de texto de status 
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NombreTutorText"));
                }
            }
        }

        private int edadTutor;
        public int EdadTutor
        {
            get
            { return edadTutor; }
            set
            {
                if (this.edadTutor != value)
                {
                    this.edadTutor = value;
                    // notificacion debida al cambio de texto de status 
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("EdadTutorText"));
                }
            }
        }

        private string telefonoTutor;
        public String TelefonoTutor
        {
            get
            { return telefonoTutor; }
            set
            {
                if (this.telefonoTutor != value)
                {
                    this.telefonoTutor = value;
                    // notificacion debida al cambio de texto de status 
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TelefonoTutorText"));
                }
            }
        }

        public DatosUsuario()
        {
            Nombre = String.Empty;
            Apellidos = String.Empty;
            Edad = 0;
            Escolaridad = String.Empty;
            Sexo = String.Empty;
            Estatura = 0.0;
            Peso = 0.0;
            Imc = 0.0;

            NombreTutor = String.Empty;
            EdadTutor = 0;
            TelefonoTutor = String.Empty;
        }

        public Double Imc_Calculo(double estatura, double peso)
        {
            return peso / (Math.Pow(estatura, 2.0D));
        }

        /// INotifyPropertyChangedPropertyChanged evento para el control de ventana y cambiar los datos con un binding
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
