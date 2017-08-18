using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class OrdenPagada
    {
        public OrdenPago OrdenPago;
        public Sucursal Sucursal;
        public DateTime FechaPago;
        public TablaValor Moneda;
        public decimal Monto;
        public decimal TipoCambio;

        public OrdenPagada() { }

    }
}
