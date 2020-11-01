using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;


namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        string apellido;
        int dni;
        ENacionalidad nacionalidad;
        string nombre;

        #region Propiedades

        public string Apellido
        {
            get => apellido;
            set
            {
                try
                {
                    apellido = ValidarNombreApellido(value);
                }
                catch (Exception)
                {
                    throw new Exception("Apellido Inválido");
                }
                   
            }
        }

        public string Nombre
        {
            get => nombre;
            set
            {
                try
                {
                    nombre = ValidarNombreApellido(value);
                }
                catch (Exception)
                {
                    throw new Exception("Nombre Inválido");
                }
            }
        }
        public ENacionalidad Nacionalidad { get => nacionalidad; set => nacionalidad = value; }
        public int Dni
        {
            get => dni;
            set
            {
                  dni =  ValidarDni(nacionalidad, value);
            }
        }
        public string StringToDNI
        {
            set
            {
                   dni = ValidarDni(nacionalidad, value);
            }
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

        protected Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
                Nombre = nombre;
                Apellido = apellido;
                Nacionalidad = nacionalidad;
        }
        protected Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
                Dni = dni;
        }

        protected Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
                StringToDNI = dni;
        }


        #endregion

        #region Metodos
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Nombre);
            sb.AppendLine(Apellido);
            sb.AppendLine(Dni.ToString());
            sb.AppendLine(nacionalidad.ToString());
            return sb.ToString();
        }
        /// <summary>
        /// Valida el Dni al instanciarse una Persona
        /// </summary>
        /// <param name="nacionalidad">Dato de referencia</param>
        /// <param name="dato">dato a validar</param>
        /// <returns>Retorna el Dni Validado</returns>
        /// <exception cref="NacionalidadInvalidaException"></exception>
        int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (dato > 0 && dato < 99999999)
            {
                if ((dato < 90000000 && nacionalidad == ENacionalidad.Argentino) ||
                    (dato > 89999999 && nacionalidad == ENacionalidad.Extranjero))
                    return dato;
                else
                    throw new NacionalidadInvalidaException();
            }
            else
            {
                throw new NacionalidadInvalidaException("Error: Formato inválido");
            }

        }
        /// <summary>
        /// Valida el Dni al instanciarse una Persona
        /// </summary>
        /// <param name="nacionalidad">Dato de referencia</param>
        /// <param name="dato">dato a validar</param>
        /// <returns>Retorna el Dni Validado</returns>
        /// <exception cref="DniInvalidoException"></exception>
        /// <exception cref="NacionalidadInvalidaException"></exception>
        int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int aux;
                if( !(Int32.TryParse(dato, out aux)))
                {
                throw new DniInvalidoException("Error: DNI solo puede contener numeros");
                }
                ValidarDni(nacionalidad, aux);
                return aux;
        }
        /// <summary>
        /// Valida que el Dato tenga el formato indicado
        /// </summary>
        /// <param name="dato">Dato a ser validado</param>
        /// <returns>string Dato validado</returns>
        string ValidarNombreApellido(string dato)
        {
            foreach (char c in dato)
            {
                if (((c < 'a' || c > 'z') && (c < 'A' || c > 'Z')) && !(c == 'á' || c == 'é' || c == 'í' || c == 'ó' || c == 'ú'))
                {
                    throw new Exception();
                }
            }
            return dato;
        }

        #endregion
    }
}
