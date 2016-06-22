using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSECI
{
    class Vertice
    {
        private float posicionW = 0;                        /// Posicion de profundidad del vertice
        public float PosicionW
        {
            get { return this.posicionW; }
            set { this.posicionW = value; }
        }

        private float posicionX = 0;                        /// Posicion de profundidad del vertice
        public float PosicionX
        {
            get { return this.posicionX; }
            set { this.posicionX = value; }
        }

        private float posicionY = 0;                        /// Posicion de profundidad del vertice
        public float PosicionY
        {
            get { return this.posicionY; }
            set { this.posicionY = value; }
        }

        private float posicionZ = 0;                        /// Posicion de profundidad del vertice
        public float PosicionZ
        {
            get { return this.posicionZ; }
            set { this.posicionZ = value; }
        }

        public Vertice()
        {
            PosicionX = 0;
            PosicionY = 0;
            PosicionZ = 0;
        }

        public Vertice(float pX, float pY, float pZ)
        {
            PosicionX = pX;
            PosicionY = pY;
            PosicionZ = pZ;
        }
    }
}
