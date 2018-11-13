using Exercise1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4_5
{
    class ProgramG
    {

        public static void RunMainProgram(List<double> initXs, List<double> initYs, out List<double> resXs, out List<double> resYs, int exp)
        {
            var a = new double[exp, exp];
            var b = new double[exp];

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

            resXs = new List<double>();
            resYs = new List<double>();

            var equation = new LinearEquation(a, b);
            equation.Gauss();

            for (var z = initXs[0]; z < initXs[initXs.Count - 1]; z += 0.1)
            {
                resXs.Add(z);
                var res = equation.x[0];
                for (var e = 0; e < exp; e++)
                {
                    res += equation.x[e] * Math.Pow(z, e);
                }
                resYs.Add(res);
            }
        }
    }
}
