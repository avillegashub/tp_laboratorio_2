﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    public static class Calculadora
    {

        private static string ValidarOperador(char operador)
        {
            if (char.IsWhiteSpace(operador))
            {
                return "+";
            }
            return operador.ToString();
        }

        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = -1;

            
            
            switch (string.IsNullOrEmpty(operador) ? "+" : ValidarOperador(Convert.ToChar(operador)))
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
            }
            return resultado;

        }
    }
}
