using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace SistemaSECI
{
    class ExpresionesReg
    {
        private Regex caracteresPermitidos;
        bool invalid = false;

        public ExpresionesReg()
        {
            caracteresPermitidos = new Regex("");
        }

        public bool Numero(string text)
        {
            caracteresPermitidos = new Regex("[^0-9]+");
            return !caracteresPermitidos.IsMatch(text);
        }

        public bool NumeroConPunto(string text)
        {
            caracteresPermitidos = new Regex("[^0-9.]+");
            return !caracteresPermitidos.IsMatch(text);
        }

        public bool Texto(string text)
        {
            caracteresPermitidos = new Regex("[^a-zA-Z]+");
            return !caracteresPermitidos.IsMatch(text);
        }

        public bool Telefono(string text)
        {
            caracteresPermitidos = new Regex("[^0-9-]");
            return !caracteresPermitidos.IsMatch(text);
        }

        public bool TextoNumeros(string text)
        {
            caracteresPermitidos = new Regex("[^a-zA-Z0-9]");
            return !caracteresPermitidos.IsMatch(text);
        }

        public bool Mail(string strIn)
        {
            invalid = false;

            if (string.IsNullOrEmpty(strIn))
                return false;

            // Use IdnMapping class to convert Unicode domain names.
            try
            {
                strIn = Regex.Replace(strIn, @"(@)(.+)$", this.DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

            if (invalid)
                return false;
            // Return true if strIn is in valid e-mail format.
            try
            {
                return !Regex.IsMatch(strIn,
                      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        private string DomainMapper(Match match)
        {
            // IdnMapping class with default property values.
            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException)
            {
                invalid = true;
            }
            return match.Groups[1].Value + domainName;
        }
    }
}
