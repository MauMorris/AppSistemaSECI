using System;
using System.ComponentModel;

namespace SistemaSECI
{
    class DatosUsuario: INotifyPropertyChanged
    {
        private string codigo;
        public String Codigo
        {
            get { return codigo; }
            set
            {
                if (this.codigo != value)
                {
                    this.codigo = value;
                    // notificacion debida al cambio de texto de status 
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CodigoText"));
                }
            }
        }

        private string nombre;
        public String Nombre
        {
            get { return nombre; }
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
            get { return apellidos; }
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
            get { return edad; }
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
            get { return escolaridad; }
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
            get { return sexo; }
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

        private string nombreTutor;
        public String NombreTutor
        {
            get { return nombreTutor; }
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
            get { return edadTutor; }
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
            get { return telefonoTutor; }
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

        private string mail;
        public String Mail
        {
            get { return mail; }
            set
            {
                if (this.mail != value)
                {
                    this.mail = value;
                    // notificacion debida al cambio de texto de status 
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MailText"));
                }
            }
        }

        public DatosUsuario()
        {
            Codigo = String.Empty;
            Nombre = String.Empty;
            Apellidos = String.Empty;
            Edad = 0;
            Escolaridad = String.Empty;
            Sexo = String.Empty;

            NombreTutor = String.Empty;
            EdadTutor = 0;
            TelefonoTutor = String.Empty;
            Mail = String.Empty;
        }
        /// INotifyPropertyChangedPropertyChanged evento para el control de ventana y cambiar los datos con un binding
        public event PropertyChangedEventHandler PropertyChanged;

        public void codigoUsuario()
        {
            Codigo = Nombre.Substring(0, 1) + Apellidos.Substring(0, 1) +
                        Edad.ToString().Substring(0, 1) + Escolaridad.Substring(0, 1);
        }
    }
}
