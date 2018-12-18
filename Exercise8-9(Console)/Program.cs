using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise8_9_Console_
{
    class Program
    {
        static void Main(string[] args)
        {
            Euler(0.05);
          //  KoshiEuler(0.05);
            Console.ReadLine();
        }

        static double Function(double t, double y)
        {
            return 0.8*y-0.15* Math.Pow(y,2);
        }

        public static void Euler(double h)
        {
            double maxT = 10;
            var n = maxT / h;
            double y0 = 1;
            var yPrev = y0;

            var stupidCounter = 0;
            //Console.WriteLine($"y{stupidCounter} = {y0}");
            Console.WriteLine($"0,{y0}");

            for (double i = 0 + h; i <= maxT; i += h)
            {
                stupidCounter++;
                var y = yPrev + h * Function(i, yPrev);
                //Console.WriteLine($"y{stupidCounter} = {y}");
                Console.WriteLine($"{i},{y}");

                yPrev = y;
            }
        }

        public static void KoshiEuler(double h)
        {
            double maxT = 10;
            var n = maxT / h;
            double y0 = 1;
            var yPrev = y0;

            var stupidCounter = 0;
            //Console.WriteLine($"y{stupidCounter} = {y0}");
            Console.WriteLine($"0,{y0}");

            for (double i = 0 + h; i <= maxT; i += h)
            {
                stupidCounter++;

                double nextT;
                if (i + h <= maxT) {
                    nextT = i + h;
                    var y = yPrev + h / 2 * (Function(i, yPrev) + afagag(h,nextT));
                    //Console.WriteLine($"y{stupidCounter} = {y}");
                    Console.WriteLine($"{i},{y}");

                    yPrev = y;
                }
            }
        }

        public static double afagag(double h, double requiredX)
        {
            double maxT = 10;
            var n = maxT / h;
            double y0 = 1;
            var yPrev = y0;
           
            for (double i = 0 + h; i <= maxT; i += h)
            {
                var y = yPrev + h * Function(i, yPrev);
                yPrev = y;

                if (i == requiredX) return y;
            }
            return 0;
        }
    }
}
