using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1 - Solve example 1");
                Console.WriteLine("2 - Solve example 2");
                Console.WriteLine("3 - Exit");

                var choice = Console.ReadLine();


                switch (choice)
                {
                    case "1":
                        Solve1();
                        break;
                    case "2":
                        Solve2();
                        break;
                    case "3":
                        return;
                    default:
                        break;
                }
                Console.ReadLine();
                Console.Clear();
            }
        }


        private static void Solve1()
        {
            Console.Clear();

            var initXs = new List<double> { -2, -1.5, -1, -0.5, 0, 0.5, 1, 1.5, 2 };
            var initYs = initXs.Select(e => Function(e)).ToList();

            var resXs = new List<double>();
            var resYs = new List<double>();

            int step;
            while (true)
            {
                Console.WriteLine("Enter size of step (positive number):");
                var input = Console.ReadLine();
                if (Int32.TryParse(input, out step)) break;
                Console.Clear();
            }

            for (double i = 0; i < 1; i += (1.0F / step))
            {
                var resX = Approx(initXs.Count - 1, i, initXs);
                var resY = Approx(initYs.Count - 1, i, initYs);

                resXs.Add(resX);
                resYs.Add(resY);
            }

            Console.WriteLine("X");

            foreach (var number in resXs)
                Console.WriteLine(number);

            Console.WriteLine("Y");

            foreach (var number in resYs)
                Console.WriteLine(number);
        }

        private static void Solve2()
        {
            Console.Clear();

            var xs = new List<double> { -3.2, -2.1, 0.4, 0.7, 2, 2.5, 2.777 };
            var ys = new List<double> { 10, -2, 0, -7, 7, 0, 0 };

            var resXs = new List<double>();
            var resYs = new List<double>();

            int step;
            while (true)
            {
                Console.WriteLine("Enter size of step (positive number):");
                var input = Console.ReadLine();
                if (Int32.TryParse(input, out step)) break;
                Console.Clear();
            }

            for (double i = 0; i < 1; i += (1.0F / step))
            {
                var resX = Approx(xs.Count - 1, i, xs);
                var resY = Approx(ys.Count - 1, i, ys);

                resXs.Add(resX);
                resYs.Add(resY);
            }

            Console.WriteLine("X");

            foreach (var number in resXs)
                Console.WriteLine(number);

            Console.WriteLine("Y");

            foreach (var number in resYs)
                Console.WriteLine(number);
        }

        static double Function(double x)
        {
            return Math.Sin(x * 5) * Math.Exp(x);
        }

        public static double Approx(int n, double t, List<double> x)
        {

            double sum = 0;

            for(int i = 0; i < x.Count ; i++)
            {
                sum += x[i] * F(i, n, t);
            }

            return sum;

        }

        static double F(int i, int n, double t)
        {
            return C(i, n) * Math.Pow(t, i) * Math.Pow(1 - t, n - i);
        }


        static double C(int k, int n)
        {
            return (Factorial(n) / (Factorial(k) * Factorial(n - k)));
        }


        static int Factorial(int i)
        {
            if (i <= 1)
                return 1;
            return i * Factorial(i - 1);
        }
    }
}
