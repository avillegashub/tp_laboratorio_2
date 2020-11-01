using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        int legajo;

        public int Legajo { get => legajo; }

        #region Metodos

        public override bool Equals(object obj)
        {
            if(obj.GetType() == this.GetType())
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Muestra los dato con Formato
        /// </summary>
        /// <returns>string con los datos formateados</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"NOMBRE COMPLETO: {Apellido}, {Nombre}");
            sb.AppendLine($"NACIONALIDAD: {Nacionalidad}");
            sb.AppendLine($"LEGAJO NÚMERO: {Legajo}");

            return sb.ToString();
        }
        

        public static bool operator == (Universitario pg1, Universitario pg2)
            {
            
            if(pg1.Equals( pg2) && (pg1.Dni == pg2.Dni || pg1.Legajo == pg2.Legajo))
            return true;
                return false;
            }
        
        public static bool operator != (Universitario pg1, Universitario pg2)
            {
            return (!(pg1 == pg2));
            }

        protected abstract string ParticiparEnClase();
        
       

        #endregion

        #region Constructores
        public Universitario()
        {

        }

        protected Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base (nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion


    }
}
