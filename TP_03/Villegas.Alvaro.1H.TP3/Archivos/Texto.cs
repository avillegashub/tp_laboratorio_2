using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string> 
    {
        string path = AppDomain.CurrentDomain.BaseDirectory;
        /// <summary>
        /// Obtiene una jornada y la guarda en formato .txt
        /// </summary>
        /// <param name="archivo">Nombre del archivo a guardar</param>
        /// <param name="datos">Dato a ser guardado</param>
        /// <returns>Retorna true si pudo guardar el dato</returns>
        /// <exception cref="ArchivosException">description</exception>
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path+archivo, true))
                sw.WriteLine(datos);
                return true;
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex.InnerException);
            }
        }
        /// <summary>
        /// Lee el archivo que especifica el parámetro. Devuelve el string del Archivo al puntero datos
        /// </summary>
        /// <param name="archivo">Nombre del archivo</param>
        /// <param name="datos">Puntero a string donde quiere el texto del archivo</param>
        /// <returns>Retorna true si pudo Leer el archivo</returns>
        /// <exception cref="ArchivosException">description</exception>
        public bool Leer(string archivo, out string datos)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path+archivo))
                {
                    datos = sr.ReadToEnd();
                    return true; 
                }
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex.InnerException);
            }
        }
    }
}
