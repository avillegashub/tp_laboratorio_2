using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcionalidades
{
    class Excepciones : Exception
    {
        public Excepciones()
        {

        }

        public Excepciones(string message)
        {

        }

        public Excepciones(string message, Exception ex)
        {

        }

    }
    public class ExcepcionErrorBaseDato : Exception
    {
        public ExcepcionErrorBaseDato():base("No se pudo Cargar los Datos")
        {

        }

    }
    public class ExcepcionNombreRepetido : Exception
    {
        public ExcepcionNombreRepetido()
        {

        }

    }
    
    
}
