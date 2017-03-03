using System;
using System.ComponentModel;

namespace SistemaSECI
{
    class Imc: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private double estatura;
        public Double Estatura
        {
            get { return estatura; }
            set
            {
                if (this.estatura != value)
                {
                    this.estatura = value;
                    // notificacion debida al cambio de texto de status 
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CodigoEstatura"));
                }
            }
        }

        private double peso;
        public Double Peso
        {
            get { return peso; }
            set
            {
                if (this.peso != value)
                {
                    this.peso = value;
                    // notificacion debida al cambio de texto de status 
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CodigoPeso"));
                }
            }
        }

        private double imc;
        public Double IMC
        {
            get { return imc; }
            set
            {
                if (this.imc != value)
                {
                    this.imc = value;
                    // notificacion debida al cambio de texto de status 
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CodigoImc"));
                }
            }
        }

        public Imc(){
            Peso = 1.0;
            Estatura = 1.0;
        }

        public Imc(double _peso, double _estatura)
        {
            Peso = _peso;
            Estatura = _estatura;
        }

        public void Imc_Calculo()
        {
            IMC = Peso / (Math.Pow(Estatura/100, 2.0D));
        }
    }
}
