using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Instanciables;

namespace PruebasUnitarias
{
    [TestClass]
    public class PruebaInstancia
    {
        [TestMethod]
        public void PruebaInstanciadoColeccion()//Prueba la instancia de las colecciones dentro de Universidad
        {
            Universidad universidadPrueba = new Universidad();

            Assert.IsNotNull(universidadPrueba.Alumnos);

        }
    }
}
