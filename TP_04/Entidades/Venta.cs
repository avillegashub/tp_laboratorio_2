using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    public class Venta : IFormato
    {

        int id;
        Cliente cliente;
        List<Producto> productos;

        #region Contructores
        public Venta()
        {

        }

        public Venta(int id, Cliente cliente, List<Producto> productos)
        {
            this.id = id;
            this.cliente = cliente;
            this.productos = productos;
        }

        #endregion

        #region Propiedades
        public int Id { get => id; set => id = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public List<Producto> Productos { get => productos; set => productos = value; }

        #endregion

        /// <summary>
        /// Formatea la venta para Archivo Txt
        /// </summary>
        /// <returns></returns>
        public string Formater()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("------------------------------------------------------------------------------");
            sb.AppendLine("Fecha: " + DateTime.Now.ToString("d/M/yyyy"));
            sb.AppendLine("--------------- Cliente");
            sb.AppendLine(cliente.Formater());
            sb.AppendLine("--------------- Productos:");
            foreach (Producto p in productos)
            {
                sb.AppendLine(p.Formater());
            }

            return sb.ToString();
        }
    }
}
