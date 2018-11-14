using Exercise1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4_5
{
    class Mnk
    {
        public LinearEquation eq { get; private set; }
        public double exp { get; private set; }

        public void Recalculate(List<double> initXs, List<double> initYs, int exp)
        {
            var a = new double[exp, exp];
            var b = new double[exp];
            this.exp = exp;

            for (var j = 0; j < exp; j++)
            {
                var f = 0.0;
                for (var i = 0; i < initXs.Count; i++)
                {
                    f += initYs[i] * Math.Pow(initXs[i], j);
                }
                b[j] = f;
                for (var k = 0; k < exp; k++)
                {
                    var c = 0.0;
                    for (var i = 0; i < initXs.Count; i++)
                    {
                        c += Math.Pow(initXs[i], k + j);
                    }
                    a[j, k] = c;
                }
            }

            eq = new LinearEquation(a, b);
            eq.Gauss();
        }

        public double GetY(double x)
        {
            double res = 0.0;
            for (int e = 0; e < exp; e++)
            {
                res += eq.x[e] * Math.Pow(x, e);
            }
            return res;
        }
    }
}
