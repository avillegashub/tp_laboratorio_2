using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace Clases_Instanciables
{
    [Serializable]
    public class Universidad : Xml<Universidad>
    {

        List<Alumno> alumnos;
        List<Jornada> jornada;
        List<Profesor> profesores;

        #region Propiedades

        public List<Alumno> Alumnos { get => alumnos; set => alumnos = value; }
        public List<Jornada> Jornada { get => jornada; set => jornada = value; }
        public List<Profesor> Profesores { get => profesores; set => profesores = value; }
        public Jornada this[int i]
        {
            get { return this.jornada[i]; }
            set { this.jornada[i] = value; }
        }

        #endregion

        #region Constructores

        public Universidad()
        {
            Alumnos = new List<Alumno>();
            Profesores = new List<Profesor>();
            Jornada = new List<Jornada>();
        }
        

        #endregion

        #region Tipos Anidados
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Guarda una Universidad en formato .xml
        /// </summary>
        /// <param name="uni">Dato a ser guardado</param>
        /// <returns>true si se pudo guardar</returns>
        /// <exception cref="ArchivosException">description</exception>
        public static bool Guardar(Universidad uni)
        {
            uni.Guardar("Universidad.xml", uni);
            return true;
        }
        /// <summary>
        /// Lee un archivo y devuelve los datos
        /// </summary>
        /// <returns>Universidad si se pudo leer el archivo</returns>
        /// <exception cref="ArchivosException">description</exception>
        public static Universidad Leer()
        {
            Universidad aux = new Universidad();
            object dos = new object();
            aux.Leer("Universidad.xml", out aux);
            return aux;
        }
        /// <summary>
        /// Muestra los datos de Universidad con Formato para mostrar
        /// </summary>
        /// <param name="uni">Dato a ser mostrardo</param>
        /// <returns>string con los datos del objeto con formateados</returns>
        private string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Jornada j in Jornada)
            {
                sb.AppendLine( j.ToString());
            }
            return sb.ToString();
        }

        #endregion

        #region SobreCargas

        public static bool operator !=(Universidad g, Alumno a)
        {
            return (!(g == a));
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return (!(g == i));
        }

        public static Profesor operator !=(Universidad u, EClases clase)
        {
            return u.Profesores[0];
        }

        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno alum in g.alumnos)
            {
                if (alum == a)
                {
                    throw new Excepciones.AlumnoRepetidoException();
                }
            }
            return false;
        }

        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor p in g.profesores)
            {
                if (p == i)
                {
                    return true;
                }
            }
            return false;
        }

        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor p in u.profesores)
            {
                if (p == clase)
                {
                    return p;
                }
            }
            throw new Excepciones.SinProfesorException();
        }

        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada j = new Jornada();

            foreach (Profesor p in g.profesores)
            {
                if (p == clase)
                {
                    j.Instructor = p;
                    break;
                }
                else if (g.profesores.Last<Profesor>() == p)
                {
                    throw new Excepciones.SinProfesorException();
                }
            }
            foreach (Alumno a in g.alumnos)
            {
                if (a == clase)
                {
                    j += a;
                }
            }
            j.Clase = clase;
            g.Jornada.Add(j);


            return g;
        }
        public static Universidad operator +(Universidad g, Alumno a)
        {

            if (g != a || g.alumnos.Count == 0)
            {
                g.alumnos.Add(a);
            }

            return g;
        }
        public static Universidad operator +(Universidad g, Profesor i)
        {
            try
            {
                if (g != i)
                {
                    g.profesores.Add(i);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return g;
        }

        public override string ToString()
        {
            return MostrarDatos(this);
        }

        #endregion

    }
}
