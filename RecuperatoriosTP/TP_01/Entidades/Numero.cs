using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {

        private double numero;


        public string SetNumero
        {
            set
            {
                numero = ValidarNumero(value);
            }
        }

        #region Constructores

        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }
        #endregion

        #region Metodos




        /// <summary>
        /// Recibe un string, verifica que sea binario y convierte el binario a decimal
        /// </summary>
        /// <param name="binario"></param>string para ser convertido
        /// <returns>Un string con la conversion</returns>
        public string BinarioDecimal(string binario)
        {
            if (EsBinario(binario))
            {
                return Convert.ToInt64(binario, 2).ToString();
            }
            else
            {
                return "Valor inválido";
            }
        }
        /// <summary>
        /// recibe un double y lo convierte a Binario
        /// </summary>
        /// <param name="numero"></param> Numero para ser convertido
        /// <returns>Un string con la conversion</returns>
        public string DecimalBinario(double numero)
        {
            return Convert.ToString((int)numero,2);
        }
        /// <summary>
        /// Recibe el string, lo convierte a double, lo convierte a Binario
        /// </summary>
        /// <param name="numero"></param>string para ser convertido
        /// <returns>El string en Binario</returns>
        public string DecimalBinario(string numero)
        {
            double numAux;
            if ( double.TryParse(numero, out numAux))
            {
               
                return DecimalBinario(numAux);
            }
            else
            {
                return "Valor inválido";
            }
            
        }
        /// <summary>
        /// Verifica que el string sea binario.
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>true si es binario, false si no es binario</returns>
        bool EsBinario(string binario)
        {
           

            foreach (var c in binario)
                if (c != '0' && c != '1')
                    return false;
            return true;
        }

        double ValidarNumero(string strNumero)
        {
            double retorno;
            double.TryParse(strNumero, out retorno);
            return retorno;
        }

        #endregion

        #region Operadores
        public static double operator +(Numero num1, Numero num2)
        {
            return num1.numero + num2.numero;
        }

        public static double operator -(Numero num1, Numero num2)
        {
            return num1.numero - num2.numero;
        }

        public static double operator *(Numero num1, Numero num2)
        {
            return num1.numero * num2.numero;
        }

        public static double operator /(Numero num1, Numero num2)
        {
            if (num2.numero != 0)
                return num1.numero / num2.numero;
            else
                return double.MinValue;

        }

        #endregion
    }
}
