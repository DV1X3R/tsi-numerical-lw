using System;
using System.Collections.Generic;

namespace Exercise4_5
{
    static class Bezier
    {
        public static double Approx(int n, double t, List<double> x)
        {
            double sum = 0;

            for (int i = 0; i < x.Count; i++)
            {
                sum += x[i] * F(i, n, t);
            }

            return sum;
        }

        public static double F(int i, int n, double t)
        {
            return C(i, n) * Math.Pow(t, i) * Math.Pow(1 - t, n - i);
        }


        public static double C(int k, int n)
        {
            return (Factorial(n) / (Factorial(k) * Factorial(n - k)));
        }


        public static int Factorial(int i)
        {
            if (i <= 1)
                return 1;
            return i * Factorial(i - 1);
        }
    }
}
