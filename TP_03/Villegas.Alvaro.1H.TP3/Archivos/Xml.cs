using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.InteropServices;

namespace Archivos
{

    public class Xml<T> : IArchivo<T>
    {
        string path = AppDomain.CurrentDomain.BaseDirectory;
        /// <summary>
        /// Obtiene un dato genérico para ser guardado en formato XML
        /// </summary>
        /// <param name="archivo">Nombre del archivo a guardar</param>
        /// <param name="datos">Dato a ser guardado</param>
        /// <returns>Retorna true si pudo crear/guardar el Documento</returns>
        /// <exception cref="ArchivosException">description</exception>
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(path + archivo, System.Text.Encoding.UTF8))
                {

                    XmlSerializer ser = new XmlSerializer(datos.GetType());
                    ser.Serialize(writer, datos);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Excepciones.ArchivosException(ex.InnerException);
            }
        }
        /// <summary>
        /// Obtiene un archivo para obtener su contenido
        /// </summary>
        /// <param name="archivo">Nombre del archivo a leer</param>
        /// <param name="datos">Puntero a donde se asigna el contenido del documento</param>
        /// <returns>Retorna true si pudo leer el Documento</returns>
        /// <exception cref="ArchivosException">description</exception>
        public bool Leer(string archivo, out T datos)
        {
            try
            {
                using (XmlTextReader reader = new XmlTextReader(path + archivo))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    datos = (T)ser.Deserialize(reader);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Excepciones.ArchivosException(ex.InnerException);
            }
        }
    }
}
