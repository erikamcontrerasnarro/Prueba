using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGORITMOS
{
    public class ChangeString
    {
        enum abecedario { a, b, c, d, e, f, g, h, i, j, k, l, m, n, ñ, o, p, q, r, s, t, u, v, w, x, y, z}

        public String build (String parametro) {

            List<string> listAbc = Enum.GetValues(typeof(abecedario)).Cast<abecedario>().Select(v => v.ToString()).ToList();

            StringBuilder resultado = new StringBuilder();

            foreach (char c in parametro)
            {

                int pos = 0;
                char car = c;
                string carLow = car.ToString().ToLower();

                if (listAbc.Contains(carLow))
                {
                    pos = listAbc.FindIndex(x => x.Equals(carLow));
                    pos += 1;

                    if (pos == listAbc.Count) { pos = 0; }

                    carLow = listAbc.ElementAt<string>(pos);

                    if (c.ToString().Equals(car.ToString().ToLower()) == false) { carLow = carLow.ToUpper(); }

                    car = carLow[0];
                }

                resultado.Append(car.ToString());
            }


           return resultado.ToString();
        }

    }
}
