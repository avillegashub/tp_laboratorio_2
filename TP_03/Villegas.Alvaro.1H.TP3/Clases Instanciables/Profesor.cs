using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Clases_Instanciables
{
    public class Profesor : Universitario
    {


        Queue<Universidad.EClases> clasesDelDia;
        static Random random;

        #region Constructores

        public Profesor()
        {

        }
        static Profesor()
        {
            random = new Random(DateTime.Now.Millisecond);
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base( id,  nombre,  apellido, dni ,  nacionalidad)
        {
            clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();
            _randomClases();
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Asigna una clase Aleatoriamente
        /// </summary>
        void _randomClases()
        {
            
            switch (random.Next(0, 4))
            {
                case 3:
                    clasesDelDia.Enqueue(Universidad.EClases.Laboratorio);
                    break;
                case 1:
                    clasesDelDia.Enqueue(Universidad.EClases.Legislacion);
                    break;
                case 2:
                    clasesDelDia.Enqueue(Universidad.EClases.Programacion);
                    break;
                case 0:
                    clasesDelDia.Enqueue(Universidad.EClases.SPD);
                    break;
            }
        }
        /// <summary>
        /// Muestra los datos de la Clase con formato para mostrar
        /// </summary>
        /// <returns>string datos formateados</returns>
        public new string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.MostrarDatos());
            sb.AppendLine(ParticiparEnClase());
            return sb.ToString();
        }
        /// <summary>
        /// Obtiene las clases en las que participa el Profesor, con formato para mostrar
        /// </summary>
        /// <returns>string datos formateado</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DIA:");
            foreach (Universidad.EClases c in clasesDelDia)
            {
                sb.AppendLine(c.ToString());
            }
            return sb.ToString();
        }

        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            foreach (Universidad.EClases c in i.clasesDelDia )
            {
                if (c == clase)
                    return true;
            }
            return false;
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return (!(i == clase));
        }

        public override string ToString()
        {
            return base.ToString();
        }
        #endregion
    }
}
