using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    abstract class Persona
    {
        string apellido;
        int dni;
        ENacionalidad nacionalidad;
        string nombre;

        #region Propiedades

        public string Apellido { get => apellido; set => apellido = value; }
        public int Dni { get => dni; set => dni = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        private ENacionalidad Nacionalidad { get => nacionalidad; set => nacionalidad = value; }
        public string StringToDNI
        {
            set { }
        }
        #endregion

        #region Tipos Anidados
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        #endregion

        #region Constructores

        protected Persona()
        {

        }

        Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {

        }
        Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
        {

        }

        Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
        {

        }


        #endregion

        #region Metodos
        public override string ToString()
        {
            return base.ToString();
        }

        int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            return 0;
        }
        int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            return 0;
        }
        string ValidarNombreApellido(string dato)
        {
            return null;
        }

        #endregion
    }
}
