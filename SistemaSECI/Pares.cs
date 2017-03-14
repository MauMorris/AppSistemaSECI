
namespace SistemaSECI
{
    class Pares
    {
        private string par0;
        private string par1;

        public string Par0
        {
            get
            { return par0; }
            set
            { par0 = value; }
        }

        public string Par1
        {
            get
            { return par1; }
            set
            { par1 = value; }
        }

        public Pares(string p0, string p1)
        {
            par0 = p0;
            par1 = p1;
        }
    }
}
