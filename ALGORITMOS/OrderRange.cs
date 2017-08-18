using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGORITMOS
{
    class OrderRange
    {

        public String build(String parametro)
        {
            StringBuilder resultado = new StringBuilder();

            try
            {
                if (parametro.Length > 0)
                {
                    if (parametro[0] == '[' && parametro[parametro.Length - 1] == ']')
                    {
                        parametro = parametro.Replace("[", String.Empty);
                        parametro = parametro.Replace("]", String.Empty);
                    }

                    List<int> lista = parametro.Split(',').ToList().ConvertAll(int.Parse );
                    lista.Sort();

                    String pares = String.Empty;
                    String impares = String.Empty;

                    foreach (int i in lista)
                    {
                        if (i % 2 == 0)
                            pares = String.Format("{0},", pares + i);
                        else
                            impares = String.Format("{0},", impares + i);
                   }

                    if (pares.Length>0) pares = pares.Remove(pares.Length - 1, 1);
                    if (impares.Length > 0) impares = impares.Remove(impares.Length - 1, 1);

                    if (lista[0] % 2 == 0)
                        resultado.AppendFormat("[{0}] [{1}]", pares, impares);
                    else
                        resultado.AppendFormat("[{0}] [{1}]", impares, pares);
                }
            }
            catch {resultado.Append("Error, ingrese una lista de números enteros positivos separados por comas.");}

            return resultado.ToString();
        }


    }
}
