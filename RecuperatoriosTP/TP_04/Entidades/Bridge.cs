using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Bridge 
    {
        List<Venta> ventasAux;
        public Bridge()
        {
            List<Venta> ventasAux = new List<Venta>();
        }

        public Bridge(List<Venta> ventasAux)
        {
            this.ventasAux = ventasAux;
        }

        public List<Venta> VentasAux { get => ventasAux; set => ventasAux = value; }
    }
}
