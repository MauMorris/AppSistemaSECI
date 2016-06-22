using System;
using System.ComponentModel;

namespace SistemaSECI
{
    class Alimentacion: INotifyPropertyChanged
    {
        /// INotifyPropertyChangedPropertyChanged evento para el control de ventana y cambiar los datos con un binding
        public event PropertyChangedEventHandler PropertyChanged;

        private string dia;
        public String Dia
        {
            get { return dia; }
            set
            {
                if (this.dia != value)
                {
                    this.dia = value;
                    // notificacion debida al cambio de texto de status 
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DiaSemanaText"));
                }
            }
        }

        private string desayuno;
        public String Desayuno
        {
            get { return desayuno; }
            set
            {
                if (this.desayuno != value)
                {
                    this.desayuno = value;
                    // notificacion debida al cambio de texto de status
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DesayunoText"));
                }
            }
        }

        private string almuerzo;
        public String Almuerzo
        {
            get { return almuerzo; }
            set
            {
                if (this.almuerzo != value)
                {
                    this.almuerzo = value;
                    // notificacion debida al cambio de texto de status 
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AlmuerzoText"));
                }
            }
        }

        private string comida;
        public String Comida
        {
            get { return comida; }
            set
            {
                if (this.comida != value)
                {
                    this.comida = value;
                    // notificacion debida al cambio de texto de status 
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ComidaText"));
                }
            }
        }

        private string merienda;
        public String Merienda
        {
            get { return merienda; }
            set
            {
                if (this.merienda != value)
                {
                    this.merienda = value;
                    // notificacion debida al cambio de texto de status 
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MeriendaText"));
                }
            }
        }

        private string cena;
        public String Cena
        {
            get { return cena; }
            set
            {
                if (this.cena != value)
                {
                    this.cena = value;
                    // notificacion debida al cambio de texto de status 
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CenaText"));
                }
            }
        }

        private int rubrica;
        public int Rubrica
        {
            get { return rubrica; }
            set
            {
                if (this.rubrica != value)
                {
                    this.rubrica = value;
                    // notificacion debida al cambio de texto de status 
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RubricaText"));
                }
            }
        }

        private string comentarios;
        public String Comentarios
        {
            get { return comentarios; }
            set
            {
                if (this.comentarios != value)
                {
                    this.comentarios = value;
                    // notificacion debida al cambio de texto de status 
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ComentariosText"));
                }
            }
        }

        private int sesion;
        public int Sesion
        {
            get { return sesion; }
            set
            {
                if (this.sesion != value)
                {
                    this.sesion = value;
                    // notificacion debida al cambio de texto de status 
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SesionText"));
                }
            }
        }
    }
}
