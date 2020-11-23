using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Entidades
{
    public static class ExtensionArchivo
    {
        /// <summary>
        /// Adjunta una la venta en Archivo .txt
        /// </summary>
        /// <param name="venta"></param>
        public static void VentaLog(this Venta venta)
        {
                try
                {
                    using (StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "LogVentas.txt", true))
                        sw.WriteLine(venta.Formater());
                }
                catch (Exception)
                {
                    
                }
        }

    }
}
