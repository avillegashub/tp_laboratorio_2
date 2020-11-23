using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto : IFormato
    {
        int id;
        string nombre;
        float precio;
        int stock;

        #region Constructores

        public Producto()
        {

        }

        public Producto(string nombre, float precio, int stock)
        {
            this.nombre = nombre;
            this.precio = precio;
            this.stock = stock;
        }

        public Producto(int id, string nombre, float precio, int stock)
        {
            this.id = id;
            this.nombre = nombre;
            this.precio = precio;
            this.stock = stock;
        }
        #endregion

        #region Propiedades

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public float Precio { get => precio; set => precio = value; }
        public int Stock { get => stock; set => stock = value; }

        #endregion

        /// <summary>
        /// Añade Producto a Lista
        /// </summary>
        /// <param name="productos"></param>
        /// <param name="producto"></param>
        /// <returns></returns>
        public static bool operator +(List<Producto> productos, Producto producto)
        {
            foreach (Producto p in productos)
            {
                if (p.id == producto.id && p.stock+1<= producto.stock)
                {
                    p.stock++;
                    return true;
                }
            }
            productos.Add(new Producto(producto.id, producto.nombre, producto.precio, 1));
            return true;
        }

        /// <summary>
        /// Modifica la cantidad de Stock  de un Producto en la lista
        /// </summary>
        /// <param name="productos"></param>
        /// <param name="id"></param>
        /// <param name="cantidad"></param>
        public static void AgregarCantidad(List<Producto> productos, int id, int cantidad)
        {
            foreach (Producto p in productos)
            {
                if (p.id == id)
                {
                    if(p.stock+cantidad <= Establecimiento.GetProducto(id).stock)
                    {
                        p.stock += cantidad;
                    }
                    else
                    {
                        p.stock = Establecimiento.GetProducto(id).stock;
                    }
                }
            }
        }

        /// <summary>
        /// Formatea los Datos para Archivar
        /// </summary>
        /// <returns></returns>
        public string Formater()
        {
            return $"ID:  {id,10} Nombre: {nombre,10} Precio: {precio.ToString("n2"),10} Stock: {stock,10}";
        }
    }
}
