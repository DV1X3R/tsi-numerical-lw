using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise6_7
{
    class HordMethod
    {
        public static double Calc(double a, double b, double eps)
        {
            double x_next = 0;
            double tmp;
            var lich = 0;
            do
            {
                lich++;
                tmp = x_next;
                x_next = b - Program.f(b) * (a - b) / (Program.f(a) - Program.f(b));
                a = b;
                b = tmp;

                Console.WriteLine("N = " + lich + "   exp = " + Math.Abs(x_next - b) + "   x = " + x_next);

            } while (Math.Abs(x_next - b) > eps);

            return x_next;
        }
    }
}
