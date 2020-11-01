using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;



namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        Universidad.EClases claseQueToma;
        EEstadoCuenta estadoCuenta;

        #region Tipos Anidados

        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }


        #endregion

        #region Constructores

        Alumno()
        {

        }
        
        Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases clasesQueToma) : base( id,  nombre,  apellido,  dni,  nacionalidad)
        {
            this.claseQueToma = clasesQueToma;
            
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases clasesQueToma, EEstadoCuenta estadoCuenta):this(id, nombre, apellido, dni, nacionalidad, clasesQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Muestra los Datos del Alumno
        /// </summary>
        /// <returns>Retorna string con los datos del Alumno</returns>
        public new string MostrarDatos() 
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.MostrarDatos());
            sb.AppendLine($"ESTADO DE CUENTA: {estadoCuenta}");
            sb.AppendLine(ParticiparEnClase());
            return sb.ToString();
        }
        /// <summary>
        /// Obtiene las clases en las que el alumno participa
        /// </summary>
        /// <returns>string con la clase que participa el alumno con formato</returns>
        protected override string ParticiparEnClase()
        {
            return $"TOMA CLASE DE: {claseQueToma}";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine(claseQueToma.ToString());
            sb.AppendLine(estadoCuenta.ToString());
            return sb.ToString();
        }

        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            if( a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                return true;
            }
            return false;
        }
         public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            if( a.claseQueToma == clase)
            {
                return false;
            }
            return true;
        }

        #endregion
    }
}
