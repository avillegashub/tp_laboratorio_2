using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Archivos;

namespace Clases_Instanciables
{
    public class Jornada : Texto
    {

        List<Alumno> alumnos;
        Universidad.EClases clase;
        Profesor instructor;

        #region Propiedades
        public List<Alumno> Alumnos { get => alumnos; set => alumnos = value; }
        public Universidad.EClases Clase { get => clase; set => clase = value; }
        public Profesor Instructor { get => instructor; set => instructor = value; }
        #endregion

        #region Constructores
        public Jornada()
        {
            alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor)
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Guarda los datos jornada en .txt
        /// </summary>
        /// <param name="jornada">Jornada a ser guardada</param>
        /// <returns>true si se pudo guardar la jornada</returns>
        /// <exception cref="ArchivosException">description</exception>
        public static bool Guardar(Jornada jornada)
        {
            jornada.Guardar("jornada.txt", jornada.ToString());
            return true;
        }
        /// <summary>
        /// Lee el arhivo con las jornadas previamente guardadas
        /// </summary>
        /// <returns>string con los datos alamacenados</returns>
        /// <exception cref="ArchivosException">description</exception>
        public static string Leer()
        {
            string retorno;
            Jornada j = new Jornada();
            
            j.Leer("jornada.txt", out retorno);
            return retorno;
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (!(j == a))
            {
                j.alumnos.Add(a);
                return j;
            }
            throw new Excepciones.AlumnoRepetidoException();
        }
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno alm in j.alumnos)
            {
                if (alm == a)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator !=(Jornada j, Alumno a)
        {
            return (!(j == a));
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"CLASE DE: {clase} POR: ");
            sb.Append(instructor.MostrarDatos());
            sb.AppendLine("ALUMNOS:");
            foreach (Alumno a in Alumnos)
            {
                sb.Append(a.MostrarDatos());
                sb.AppendLine(" ");
            }
                sb.Append("<----------------------->");
            return sb.ToString();
        }

        #endregion
    }
}
