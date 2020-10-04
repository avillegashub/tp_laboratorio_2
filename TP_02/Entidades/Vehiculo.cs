﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo
    {
        public enum EMarca
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda, HarleyDavidson
        }
        public  enum ETamanio
        {
            Chico, Mediano, Grande
        }

        EMarca marca;
        string chasis;
        ConsoleColor color;

        protected Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.marca = marca;
            this.chasis = chasis;
            this.color = color;
        }


        /// <summary>
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        public virtual short Tamanio { get;  }

        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"CHASIS: {this.chasis}\r\n" );
            sb.Append($"MARCA : {this.marca}\r\n");
            sb.Append($"COLOR : {this.color}\r\n");
            sb.Append("---------------------");

            return sb.ToString();
        }

        public virtual string Mostrar()
        {
            return this.ToString();
        }
        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis == v2.chasis);
        }
        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return (!(v1.chasis == v2.chasis));
        }
    }
}
