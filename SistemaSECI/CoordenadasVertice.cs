
namespace SistemaSECI
{
    class CoordenadasVertice
    {
        private float posicionW = 0;                        /// Posicion de profundidad del vertice
        public float W
        {
            get { return this.posicionW; }
            set { this.posicionW = value; }
        }

        private float posicionX = 0;                        /// Posicion de profundidad del vertice
        public float X
        {
            get { return this.posicionX; }
            set { this.posicionX = value; }
        }

        private float posicionY = 0;                        /// Posicion de profundidad del vertice
        public float Y
        {
            get { return this.posicionY; }
            set { this.posicionY = value; }
        }

        private float posicionZ = 0;                        /// Posicion de profundidad del vertice
        public float Z
        {
            get { return this.posicionZ; }
            set { this.posicionZ = value; }
        }

        public CoordenadasVertice()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

        public CoordenadasVertice(float pX, float pY, float pZ)
        {
            X = pX;
            Y = pY;
            Z = pZ;
        }
    }
}