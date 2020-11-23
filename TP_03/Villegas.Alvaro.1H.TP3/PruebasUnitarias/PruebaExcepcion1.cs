using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Instanciables;
using Excepciones;
using EntidadesAbstractas;

namespace PruebasUnitarias
{
    [TestClass]
    public class PruebaExcepcion1
    {
        [TestMethod]
        public void PruebaFormatoInvalido()
        {   
            //Comprueba la excepcion cuando se le da un dni con formato invalido
            try
            {
                Alumno alumnoPrueba = new Alumno(11, "Probador", "ProbadorSon", "111111111111", EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.SPD, Alumno.EEstadoCuenta.AlDia);
                Assert.Fail("No tira la Excepcion");
            }
            catch (DniInvalidoException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        [TestMethod]
        public void PruebaFormatoInvalasdido()
        {
            //Comprueba la excepcion cuando se le da un dni con formato invalido
            try
            {
                Alumno alumnoPrueba = new Alumno(11, "Probador", "ProbadorSon", "111111111111", EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.SPD, Alumno.EEstadoCuenta.AlDia);
                Assert.Fail("No tira la Excepcion");
            }
            catch (DniInvalidoException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
