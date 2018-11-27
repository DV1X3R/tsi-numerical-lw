using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise6_7
{
    public static class HalfMethod
    {
        public static double Calc(double a, double b, double eps)
        {
            double c = 0, fc, fa = Program.f(a), fb = Program.f(b);
            int lich = 0;

            if (Math.Abs(a) < eps || Math.Abs(b) < eps)
            {
                return 0;
            };
            do
            {
                c = a + 0.5 * (b - a);
                fc = Convert.ToDouble(Program.f(c));
                lich++;
                if (Math.Abs(fc) < eps) break;
                if (fa * fc < 0) b = c; else a = c;
                Console.WriteLine("N = " + lich + "   exp = " + Math.Abs(a - b) + "   x = " + c);
            }
            while (Math.Abs(a - b) > eps);
            Console.WriteLine("x={0}, ={1}!", c, lich);
            return c;
        }
    }
}
