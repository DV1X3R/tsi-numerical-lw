using Exercise1;
using System;
using System.Linq;

namespace Exercise3
{
    internal class ConditionFinder
    {
        private LinearEquation equation;
        private LinearEquation equationWithDelta;

        public double Condition { get; set; }

        public ConditionFinder(double[,] a, double[] b)
        {
            equation = new LinearEquation(a, b);
            equation.Gauss();

            var bWithDelta = (double[])b.Clone();
            SetDelta(bWithDelta);

            equationWithDelta = new LinearEquation(a, bWithDelta);
            equationWithDelta.Gauss();

            Condition = (VectorNorm(equationWithDelta.x) / VectorNorm(equation.x) * VectorNorm(b) / VectorNorm(bWithDelta));
        }

        private void SetDelta(double[] b)
        {
            var maxValue = b.Max(e => Math.Abs(e));
            var index = Array.FindIndex(b, e => e == maxValue);
            b[index] = maxValue + maxValue * 0.01;
        }

        public double VectorNorm(double[] v)
        {
            return v.Sum(e => Math.Abs(e));
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var eq = new ConditionFinder(new double[,] { { 2, -1, -1 }, { 1, 3, -2 }, { 1, 2, 3 } }, new double[] { 5, 7, 10 });
           // var eq = new ConditionFinder(new double[,] { { 0.78, 0.563 }, { 0.913, 0.659 } }, new double[] { 0.217, 0.254 });

            Console.WriteLine($"Cond(A) = {eq.Condition}");
            Console.ReadLine();
        }
    }
}

