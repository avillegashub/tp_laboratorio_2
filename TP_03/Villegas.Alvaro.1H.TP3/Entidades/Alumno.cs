using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace Clases_Instanciables
{
    sealed class Alumno : Universitario
    {
        Eclases claseQueToma;
        EEstadoCuenta estadoCuenta;

        #region Tipos Anidados

        public enum EEstadoCuenta
        {
            AlDia,
            Duedor,
            Becado
        }


        #endregion

        #region Constructores

        Alumno()
        {

        }

        Alumno(int id, string nombre, string apellido, string dni, ENa)

        #endregion
    }
}
