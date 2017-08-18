using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class Sucursal
    {
        public int Id;
        public string Nombre;
        public string Direccion;
        public DateTime FechaReg;
        public Sucursal() { }

        public Sucursal(DataRow row)
        {
            Id = int.Parse(row["Id"].ToString());
            Nombre = row["Nombre"].ToString();
            Direccion = row["Direccion"].ToString();
            FechaReg = DateTime.Parse(row["FechaReg"].ToString());
        }

    }
}
