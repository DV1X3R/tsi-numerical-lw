using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise6_7
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 0, b = 0;
            double eps = 0.00001;
            Console.Write("from a= ");
            try
            {
                a = Convert.ToDouble(Console.ReadLine());
            }
            catch
            {
                Console.Write("error a!");
                Console.ReadKey();
                return;
            }
            Console.Write("to b= ");
            try
            {
                b = Convert.ToDouble(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("error b! ");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("simple method {0}", HalfMethod.Calc(a, b, eps));

            Console.WriteLine();
            Console.WriteLine("Hord {0}", HordMethod.Calc(a, b, eps));

            Console.ReadKey(); return;
        }

        public static double f(double x)
        {
            return Math.Pow(x, 2) * Math.Sin(x) - 18;
        }
    }
}
