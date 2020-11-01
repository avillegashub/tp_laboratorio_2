using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    abstract class Universitario : Persona
    {
        int legajo;

        #region Metodos

        new bool Equals(object obj)
        {
            return false;
        }

        protected string MostrarDatos()
        {
            return null;
        }

        public static bool operator == (Universitario pg1, Universitario pg2)
            {
            return false;
            }
        
        public static bool operator != (Universitario pg1, Universitario pg2)
            {
            return (!(pg1 == pg2));
            }

        protected virtual string ParticiparenClase()
        {
            return null;
        }
       

        #endregion

        #region Constructores
        Universitario()
        {

        }

        Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
        {

        }
        #endregion


    }
}
