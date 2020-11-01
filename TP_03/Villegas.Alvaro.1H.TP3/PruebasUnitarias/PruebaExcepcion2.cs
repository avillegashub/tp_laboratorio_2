using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Instanciables;
using Excepciones;
using EntidadesAbstractas;

namespace PruebasUnitarias
{
    [TestClass]
    public class PruebaExcepcion2
    {
        [TestMethod]
        public void PruebaApellidoInvalido()
        {
            //Comprueba la excepcion cuando se le da un nombre con formato invalido
            try
            {
                Alumno alumnoPrueba = new Alumno(11, "Probador", "Probad0rS0n", "99999999", EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.SPD, Alumno.EEstadoCuenta.AlDia);
                Assert.Fail("No tira la Excepcion");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
