using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class OrdenPago
    {
        public Int32 Id;
        public decimal Monto;
        public TablaValor Moneda;
        public TablaValor Estado;
        public string FechaPago;

        public OrdenPago() { }

    }
}
