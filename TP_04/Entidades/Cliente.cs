using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    public class Cliente : IFormato
    {
        int id;
        string nombre;
        string apellido;
        int dni;

        #region Propiedades

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public int Dni { get => dni; set => dni = value; }
        #endregion

        #region Constructores

        public Cliente()
        {

        }

        public Cliente(int id, string nombre, string apellido, int dni)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Dni = dni;
        }


        public Cliente(string nombre, string apellido, int dni)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Dni = dni;
        }
        #endregion

        /// <summary>
        /// Busca DNI en lista
        /// </summary>
        /// <param name="dni"></param>
        /// <returns></returns>
        public static bool BuscarCliente(int dni)
        {
            foreach (Cliente c in Establecimiento.Clientes)
            {
                if (c.dni == dni)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Formatea los Datos para Archivar
        /// </summary>
        /// <returns></returns>
        public string Formater()
        {
            return $"Dni: {dni,10} Nombre: {nombre,10} Apellido: {apellido,10}";
        }
    }
}
