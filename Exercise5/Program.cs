using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5
{
    class Program
    {
        static void Main(string[] args)
        {
            var pointsCoint = 0;
            bool ok = false;
            do
            {
                Console.WriteLine("Points couunt");
                var line = Console.ReadLine();
                ok = int.TryParse(line, out pointsCoint);
                if (ok && pointsCoint < 2)
                    ok = false;
                if (!ok)
                    Console.WriteLine("Error");
            } while (!ok);
            var points = new List<Point>();
            for (var i = 0; i < pointsCoint; i++)
            {
                var point = new Point();
                Console.WriteLine("Enter point for" + (i + 1).ToString());
                do
                {
                    Console.WriteLine("X: ");
                    var line = Console.ReadLine();
                    double temp;
                    ok = double.TryParse(line, out temp);
                    point.x = temp;
                    if (!ok)
                    {
                        Console.WriteLine("Error");
                        continue;
                    }
                } while (!ok);
                do//todo vynesti v otdelnuju funkciju
                {
                    Console.WriteLine("Y: ");
                    var line = Console.ReadLine();
                    double temp;
                    ok = double.TryParse(line, out temp);
                    point.y = temp;
                    if (!ok)
                        Console.WriteLine("Error");
                } while (!ok);
                points.Add(point);
            }
            //---
            int exp;
            Console.Clear();
            do
            {
                Console.WriteLine("Exponent : ");
                var line = Console.ReadLine();
                ok = int.TryParse(line, out exp);
                if (ok && exp < 1)
                    ok = false;
                if (!ok)
                    Console.WriteLine("Error");
            } while (!ok);

            //---
            Console.Clear();
            Console.WriteLine("X      Y");
            for (var i = 0; i < pointsCoint; i++)
            {
                Console.Write("{0,3}", points[i].x);
                Console.WriteLine("{0,3}", points[i].y);
            }

            RunMainProgram(points);

            var matrix = new List<List<double>>();
            var d = new List<double>();
            for (var i = 0; i < pointsCoint + 1; i++)
            {
                var newList = new List<double>();
                for (var j = 0; j < pointsCoint + 1; j++)
                {
                    newList.Add(Math.Pow(points[i].x, (i + j)));
                }
                matrix.Add(newList);
            }
            for (var i = 0; i < pointsCoint + 1; i++)
            {
                d.Add(points[i].y * Math.Pow(points[i].x, i - 1));

            }

            Console.ReadKey();
        }

        private static void RunMainProgram(List<Point> points)
        {

        }
    }
}
//http://simenergy.ru/math-analysis/digital-processing/85-ordinary-least-squares