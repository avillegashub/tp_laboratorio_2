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

        double numero;

        /// <summary>
        /// Recibe un String y valida que sea numérico.
        /// </summary>
        /// <param name="num"></param>
        void SetNumero(string num)
        {
            numero = ValidarNumero(num);
        }

        /// <summary>
        /// Sobrecarga del operador "+" para dos parametros tipo Numero
        /// </summary>
        /// <param name="num1"></param> 
        /// <param name="num2"></param>
        /// <returns>retorna La suma de ambos parametros</returns>
        public static double operator + (Numero num1, Numero num2)
        {
                return num1.numero + num2.numero;
        }
        /// <summary>
        /// Sobrecarga del operador "-" para dos parametros tipo Numero
        /// </summary>
        /// <param name="num1"></param> 
        /// <param name="num2"></param>
        /// <returns>retorna La resta de ambos parametros</returns>
        public static double operator - (Numero num1, Numero num2)
        {
            return num1.numero - num2.numero;
        }
        /// <summary>
        /// Sobrecarga del operador "*" para dos parametros tipo Numero
        /// </summary>
        /// <param name="num1"></param> 
        /// <param name="num2"></param>
        /// <returns>retorna La multiplicacion de ambos parametros</returns>
        public static double operator * (Numero num1, Numero num2)
        {
            return num1.numero * num2.numero;
        }
        /// <summary>
        /// Sobrecarga del operador "/" para dos parametros tipo Numero
        /// </summary>
        /// <param name="num1"></param> 
        /// <param name="num2"></param>
        /// <returns>retorna La division de ambos parametros</returns>
        public static double operator / (Numero num1, Numero num2)
        {
            if (num2.numero != 0)
                return num1.numero / num2.numero;
            else
                return double.MinValue;

        }
        /// <summary>
        /// Recibe un string, verifica que sea binario y convierte el binario a decimal
        /// </summary>
        /// <param name="binario"></param>string para ser convertido
        /// <returns>Un string con la conversion</returns>
        public string BinarioDecimal(string binario)
        {
            double bin;
                if (EsBinario(binario))
                {
                    bin = (double)Convert.ToInt64(binario, 2);
                }
                else
                {
                    return "Valor inválido";
                }
            return bin.ToString();
        }
        /// <summary>
        /// recibe un double y lo convierte a Binario
        /// </summary>
        /// <param name="numero"></param> Numero para ser convertido
        /// <returns>Un string con la conversion</returns>
        public string DecimalBinario(double numero)
        {
            double decimalNum = numero;

            double restante;
            int redondeo;
            string resultado = string.Empty;
            while (decimalNum > 0.09)
            {
                restante = decimalNum % 2;
                decimalNum /= 2;
                redondeo = (int)restante;
                resultado = redondeo.ToString() + resultado;
            }

            if (resultado == "")
                resultado = "0";
            return resultado;
        }
        /// <summary>
        /// Recibe el string, lo convierte a double, lo convierte a Binario
        /// </summary>
        /// <param name="numero"></param>string para ser convertido
        /// <returns>El string en Binario</returns>
        public string DecimalBinario(string numero)
        {
            double numAux = double.Parse(numero);
            return DecimalBinario(numAux);
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
        /// <summary>
        /// Constructor inicializador
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }
        /// <summary>
        /// Constructor con parámetro double
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
        {
            this.numero = numero;
        }
        /// <summary>
        /// Constructor con parámetro string
        /// </summary>
        /// <param name="numero"></param>
        public Numero(string numero)
        {
            SetNumero(numero);
        }
        /// <summary>
        /// Recibe un String y valida que sea numérico
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns>Retorna el numero si es valido, 0 si es invalido</returns>
        double ValidarNumero(string strNumero)
        {
            double retorno;
            double.TryParse(strNumero, out retorno);
            return retorno;
        }

        
    }
}
