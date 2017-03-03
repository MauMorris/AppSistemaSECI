using System;
using System.ComponentModel;

namespace SistemaSECI
{
    class Seci: INotifyPropertyChanged
    {
        /// INotifyPropertyChangedPropertyChanged evento para el control de ventana y cambiar los datos con un binding
        public event PropertyChangedEventHandler PropertyChanged;

        private string sesion;
        public String Sesion
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

        private string reforzadorTipo;
        public String ReforzadorTipo
        {
            get { return reforzadorTipo; }
            set
            {
                if (this.reforzadorTipo != value)
                {
                    this.reforzadorTipo = value;
                    // notificacion debida al cambio de texto de status 
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ReforzadorTipoText"));
                }
            }
        }

        private string reforzadorClase;
        public String ReforzadorClase
        {
            get { return reforzadorClase; }
            set
            {
                if (this.reforzadorClase != value)
                {
                    this.reforzadorClase = value;
                    // notificacion debida al cambio de texto de status 
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ReforzadorClaseText"));
                }
            }
        }

        private string inmediatezI;
        public String InmediatezI
        {
            get { return inmediatezI; }
            set
            {
                if (this.inmediatezI != value)
                {
                    this.inmediatezI = value;
                    // notificacion debida al cambio de texto de status 
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("InmediatezInmediatoText"));
                }
            }
        }

        private string inmediatezD;
        public String InmediatezD
        {
            get { return inmediatezD; }
            set
            {
                if (this.inmediatezD != value)
                {
                    this.inmediatezD = value;
                    // notificacion debida al cambio de texto de status 
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("InmediatezDemoradoText"));
                }
            }
        }

        private int esfuerzoAlto;
        public int EsfuerzoAlto
        {
            get { return esfuerzoAlto; }
            set
            {
                if (this.esfuerzoAlto != value)
                {
                    this.esfuerzoAlto = value;
                    // notificacion debida al cambio de texto de status 
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("EsfuerzoAltoText"));
                }
            }
        }

        private int esfuerzoBajo;
        public int EsfuerzoBajo
        {
            get { return esfuerzoBajo; }
            set
            {
                if (this.esfuerzoBajo != value)
                {
                    this.esfuerzoBajo = value;
                    // notificacion debida al cambio de texto de status 
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("EsfuerzoBajoText"));
                }
            }
        }

        private int reforzamientoAlto;
        public int ReforzamientoAlto
        {
            get { return reforzamientoAlto; }
            set
            {
                if (this.reforzamientoAlto != value)
                {
                    this.reforzamientoAlto = value;
                    // notificacion debida al cambio de texto de status
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ReforzamientoAltoText"));
                }
            }
        }

        private int reforzamientoBajo;
        public int ReforzamientoBajo
        {
            get { return reforzamientoBajo; }
            set
            {
                if (this.reforzamientoBajo != value)
                {
                    this.reforzamientoBajo = value;
                    // notificacion debida al cambio de texto de status 
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ReforzamientoBajoText"));
                }
            }
        }

    }
}
