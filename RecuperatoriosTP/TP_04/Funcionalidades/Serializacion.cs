using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;




namespace Funcionalidades
{
 
    public class Serializacion<T> where T : class
    {
        /// <summary>
        /// Serealiza datos en XML
        /// </summary>
        /// <param name="datos">Puntero a donde se asigna el contenido del documento</param>
        /// <returns>Retorna true si pudo leer el Documento</returns>
        static public bool Guardar(T datos)
        {
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(AppDomain.CurrentDomain.BaseDirectory + "Ventas.xml", System.Text.Encoding.UTF8))
                {
                    Type asd = datos.GetType();
                    XmlSerializer ser = new XmlSerializer(datos.GetType());
                    ser.Serialize(writer, datos);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Obtiene contenido de Archivo XML
        /// </summary>
        public static T Leer( )
        {
            try
            {
                using (var reader = new StreamReader("Ventas.xml"))
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(T));

                    return (T)deserializer.Deserialize(reader);
                }
            }
            catch (Exception )
            {
                return null;
            }
        }



    }
}
