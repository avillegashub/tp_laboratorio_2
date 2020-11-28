using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Funcionalidades;



namespace HardCode
{
    class ConsoleT
    {
        static void Main(string[] args)
        {

            DataBase.TraerClientes();
            List<Producto> listaVenta = new List<Producto>();
            try
            {
                Establecimiento.AgregarProducto("PruebaUno", "1");
                Establecimiento.AgregarProducto("PruebaUno", "2"); // Nombre Repetido
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                Console.Clear();
            }
            try
            {
                Establecimiento.AgregarProducto("PruebaDos", "3");
                listaVenta.Add(Establecimiento.GetProducto(Establecimiento.Productos[Establecimiento.Productos.Count-2].Id));
                listaVenta.Add(Establecimiento.GetProducto(Establecimiento.Productos[Establecimiento.Productos.Count-1].Id));
                listaVenta.Add(Establecimiento.GetProducto(1));
                Establecimiento.HacerVenta(Establecimiento.Clientes[0].Dni.ToString(), listaVenta); // se Hace una Venta
                Console.WriteLine(Establecimiento.Ventas[Establecimiento.Ventas.Count - 1].Formater());
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
            finally
            {
                //Para funcionalidad de Ejemplo
                DataBase.BorrarProducto("PruebaUno");
                DataBase.BorrarProducto("PruebaDos");
            }



        }
    }
}
