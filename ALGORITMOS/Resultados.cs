using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGORITMOS
{
    class Resultados
    {
        static void Main(string[] args)
        {

            bool principal = false;
            bool continuar = false;

            do
            {

                Console.WriteLine(String.Format("{0}", String.Empty.PadRight(50, '*')));

                Console.WriteLine("RESULTADOS DE ALGORITMOS");
                Console.WriteLine("1 : PROGRAMA CHANGE_STRING");
                Console.WriteLine("2 : PROGRAMA ORDER_RANGE");
                Console.WriteLine("3 : PROGRAMA MONEY_PARTS");
                Console.WriteLine();
                Console.Write("Ingrese el número del programa: ");

                int opcion = 0;

                while (!Int32.TryParse(Console.ReadLine(), out opcion)||(opcion!=1 && opcion != 2 && opcion != 3) ) {
                    Console.Write("Opción no válida. Ingrese el número del programa: ");
                }

                Console.WriteLine(String.Format("{0}",String.Empty.PadRight(30,'*')));

                String parametro = String.Empty;
                String resultado = String.Empty;

                switch (opcion)
                {
                    case 1:

                        ChangeString objChangeString = new ChangeString();
                        Console.WriteLine("1 : PROGRAMA CHANGE_STRING");

                        do
                        {
                            Console.WriteLine();
                            Console.Write("Ingrese una cadena: ");
                            parametro = Console.ReadLine();
                            resultado = objChangeString.build(parametro);
                            Console.WriteLine("Resultado: {0}", resultado);

                            Console.WriteLine(String.Format("{0}", String.Empty.PadRight(20, '-')));
                            Console.WriteLine("C = Continuar / M = Menu inicial / Otros = Salir ");
                            string sopc = Console.ReadLine().Trim().ToUpper();
                            continuar = sopc.Equals("C");
                            principal = sopc.Equals("M");

                        } while (continuar);

                        break;

                    case 2:

                        OrderRange objOrderRange = new OrderRange();
                        Console.WriteLine("2 : PROGRAMA ORDER_RANGE");

                        do
                        {

                            Console.WriteLine();
                            Console.Write("Ingrese una lista de números enteros positivos separados por comas: ");
                            parametro = Console.ReadLine();
                            resultado = objOrderRange.build(parametro);
                            Console.WriteLine("Resultado: {0}", resultado);

                            Console.WriteLine(String.Format("{0}", String.Empty.PadRight(20, '-')));
                            Console.WriteLine("C = Continuar / M = Menu inicial / Otros = Salir ");
                            string sopc = Console.ReadLine().Trim().ToUpper();
                            continuar = sopc.Equals("C");
                            principal = sopc.Equals("M");

                        } while (continuar);

                        break;

                    case 3:

                        MoneyParts objMoneyParts = new MoneyParts();
                        Console.WriteLine("3 : PROGRAMA MONEY_PARTS");

                        do {
                            Console.WriteLine();
                            Console.Write("Ingrese un monto en soles: ");
                            parametro = Console.ReadLine();
                            resultado = objMoneyParts.build(parametro);
                            Console.WriteLine("Resultado: {0}", resultado);

                            Console.WriteLine(String.Format("{0}", String.Empty.PadRight(20, '-')));
                            Console.WriteLine("C = Continuar / M = Menu inicial / Otros = Salir ");
                            string sopc = Console.ReadLine().Trim().ToUpper();
                            continuar = sopc.Equals("C");
                            principal = sopc.Equals("M");

                        } while (continuar);

                        break;
                }

            } while (principal);

        }
    }
}
