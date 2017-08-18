using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST
{
    class Program
    {
        static void Main(string[] args)
        {
            string mensaje = string.Empty;

            using (NEGOCIO.Banco objBanco = new NEGOCIO.Banco())
            {
                MODELO.Banco banco = objBanco.BuscarPorId(5, out mensaje);

                if (banco != null) {
                    Console.WriteLine("{0}. {1} | {2}", banco.Id, banco.Nombre, banco.Direccion);
                }

                List<MODELO.Banco> lista = objBanco.ListarTodos(out mensaje);

                Console.WriteLine("Todos");

                foreach (MODELO.Banco b in lista) {
                    Console.WriteLine("{0}. {1} | {2}", b.Id, b.Nombre, b.Direccion);
                }

            }

            Console.ReadKey();

        }
    }
}
