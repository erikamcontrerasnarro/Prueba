using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGORITMOS
{

    class MoneyParts
    {
        decimal[] denominaciones = {0.05m, 0.1m, 0.2m, 0.5m, 1, 2, 5, 10, 20, 50, 100, 200};

        public String build(String parametro)
        {
            StringBuilder resultado = new StringBuilder();

            decimal dec = decimal.Zero;

            try
            {

                if (parametro.Contains(",")) throw new System.Exception();

                dec = Convert.ToDecimal(parametro, CultureInfo.InvariantCulture);

                int pos = 0;
                bool cadena = false;
                decimal num = dec;
                string comb = string.Empty;
                List<string> combinaciones = new List<string>();

                for ( int posDen=0; posDen <= denominaciones.Length - 1; posDen++) {

                    if (denominaciones[posDen] > dec) break;
                    bool finaliza = false;

                    while (denominaciones[posDen] <= dec && finaliza == false)
                    {
                        decimal den = denominaciones[posDen];
                        decimal mod = dec % den;

                        if (mod == 0){
                            int cociente = (int)(dec / den);
                            for (int i=1; i<= cociente; i++) {
                                comb += String.Format(CultureInfo.InvariantCulture,"{0:0.##},", den);
                            }
                            if (comb.Length > 0) comb = comb.Remove(comb.Length - 1, 1);
                            combinaciones.Add(String.Format("[{0}]",comb));
                            if (cadena == false)
                            {
                                num = dec;
                                pos = posDen;
                            }
                            else {
                                dec = num;
                                posDen = pos;
                            }
                            finaliza = true;
                            comb = string.Empty;
                            cadena = false;
                            continue;
                        }
                        else
                        {
                            int cociente = (int)(dec / den);
                            for (int i = 1; i <= cociente; i++)
                            {
                                comb += String.Format(CultureInfo.InvariantCulture, "{0:0.##},", den);
                            }
                            if (denominaciones.Contains(mod))
                            {
                                comb += String.Format(CultureInfo.InvariantCulture, "{0:0.##},", mod);
                                if (comb.Length > 0) comb = comb.Remove(comb.Length - 1, 1);
                                combinaciones.Add(String.Format("[{0}]", comb));
                                if (cadena == false)
                                {
                                    num = dec;
                                    pos = posDen;
                                }
                                else
                                {
                                    dec = num;
                                    posDen = pos;
                                }
                                finaliza = true;
                                comb = string.Empty;
                                cadena = false;
                            }
                            else
                            {
                                if (cadena == false)
                                {
                                    cadena = true;
                                    num = dec;
                                    pos = posDen;
                                }
                                dec = mod;
                                posDen = 0;

                                for (int i = pos; i >= 0; i--) {
                                    if (denominaciones[i] <= mod) {
                                        posDen = i;
                                        break;
                                    }
                                }
                                posDen-= 1;
                            }
                            break;
                        }
                    }
                }

                String res = String.Empty;
                foreach (string c in combinaciones) {
                    res += String.Format("{0},", c);
                }
                if (res.Length > 0) res = res.Remove(res.Length - 1, 1);
                resultado.Append(String.Format("[{0}]", res));

            }
            catch { resultado.Append("Error, ingrese un monto válido (separador decimal '.' )"); }

            return resultado.ToString();
        }

    }
}
