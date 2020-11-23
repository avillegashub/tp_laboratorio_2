using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using Funcionalidades;

namespace UnitTestProject1
{
    [TestClass]
    public class TestsUnitarios
    {
        [TestMethod]
        public void ValidarUsuario()
        {
            try
            {
            DataBase.validaUsuario(000000, null);
                Assert.Fail();
            }
            catch (Exception)
            {

               
            }
            
        }
        [TestMethod]
        public void NombreRepetido()
        {
            DataBase.TraerProductos();

            try
            {

                Establecimiento.AgregarProducto(Establecimiento.Productos[1].Nombre, "0");
                Assert.Fail();
            }
            catch (Exception)
            {
                
                
            }
        }
        [TestMethod]
        public void AgregarCliente()
        {
            DataBase.TraerClientes();
            try
            {
                Establecimiento.AgregarCliente("nombrePrueba", "apellidoPrueba", "1");
                Assert.IsNotNull(Establecimiento.GetCliente(1));
            }
            catch (Exception)
            {
            }
        }
    }
}
