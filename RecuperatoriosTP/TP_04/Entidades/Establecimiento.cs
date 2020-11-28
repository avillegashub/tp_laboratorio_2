using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Funcionalidades;

namespace Entidades
{
    public static class Establecimiento
    {
        static List<Producto> productos;
        static List<Cliente> clientes;
        static List<Venta> ventas;
        static string nombreEstablecimiento;

        static Establecimiento()
        {
            productos = new List<Producto>();
            clientes = new List<Cliente>();
            ventas = new List<Venta>();

            Bridge aux = Serializacion<Bridge>.Leer();
            if (aux != null)
                Establecimiento.Ventas = aux.VentasAux;

            SetVentaNum();

            nombreEstablecimiento = "MiMercado";
        }

        #region Propiedades
        public static List<Producto> Productos { get => productos; set => productos = value; }
        public static List<Cliente> Clientes { get => clientes; set => clientes = value; }
        public static List<Venta> Ventas { get => ventas; set => ventas = value; }
        public static string NombreEstablecimiento { get => nombreEstablecimiento; set => nombreEstablecimiento = value; }
        #endregion

        /// <summary>
        /// Obtiene un Cliente si encuentra un DNI
        /// </summary>
        /// <param name="dni"></param>
        /// <returns></returns>
        public static Cliente GetCliente(int dni)
        {
            foreach (Cliente c in clientes)
            {
                if (c.Dni == dni)
                    return c;
            }
            throw new Exception("Cliente no Existe");
        }

        /// <summary>
        /// Devuelve un Producto según el ID
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static Producto GetProducto(int id)
        {
            foreach (Producto item in productos)
            {
                if (item.Id == id)
                    return item;
            }
            throw new Exception("Producto no Existe");
        }

        /// <summary>
        /// Se crea un producto Nuevo
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="precio"></param>
        public static void AgregarProducto(string nombre, string precio)
        {
            if (CompararNombre(nombre) == false)
            {
                productos.Clear();
                DataBase.InsertarProducto(nombre, precio);
                DataBase.TraerProductos();
            }
            else
            {
                throw new ExcepcionNombreRepetido();
            }
        }

        /// <summary>
        /// Agrega un Cliente si el DNI no es repetido
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        public static void AgregarCliente(string nombre, string apellido, string dni)
        {
            try
            {
                GetCliente(int.Parse(dni));
                DataBase.InsertarCliente(nombre, apellido, dni);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Compara nombre que no se repita en lista
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        private static bool CompararNombre(string nombre)
        {
            foreach (Producto p in productos)
            {
                if (p.Nombre == nombre)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Remueve Stock de los Productos
        /// </summary>
        /// <param name="productosVenta"></param>
        public static void RemoverStock(List<Producto> productosVenta)
        {
            foreach (Producto p in productosVenta)
            {
                DataBase.UpdateProducto(p.Id, (Establecimiento.GetProducto(p.Id).Stock - p.Stock).ToString());
            }

        }

        /// <summary>
        /// Obtiene el Id de la última venta para incrementar y usar en la siguiente Venta
        /// </summary>
        /// <returns></returns>
        public static int SetVentaNum()
        {
            return ventas.Count > 0 ? ventas[ventas.Count - 1].Id + 1 : 0;
        }

        /// <summary>
        /// Se crea una Venta, Se guarda el cliente si no está registrado, Guarda un Log de la venta en Archivo .txt Serealiza la venta en Xml
        /// </summary>
        /// <param name="idCliente"></param>
        /// <param name="productos"></param>
        public static void HacerVenta(string idCliente, List<Producto> productos)
        {
            Bridge aux;
           
                ventas.Add(new Venta(SetVentaNum(), Establecimiento.GetCliente(int.Parse(idCliente)), productos));
                RemoverStock(productos);
                ventas[ventas.Count - 1].VentaLog();
                aux = new Bridge(Establecimiento.Ventas);
                Serializacion<Bridge>.Guardar(aux);

        }
    }
}
