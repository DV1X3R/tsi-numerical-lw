using System;

namespace Exercise1
{
    class LinearEquation
    {
        private double[,] a;
        private double[] b;

        public LinearEquation(double[,] a, double[] b)
        {
            this.a = (double[,])a.Clone();
            this.b = (double[])b.Clone();
        }

        private void ShowAB()
        {
            for (int row = 0; row < a.GetLength(0); row++)
            {
                Console.Write("| ");
                for (int col = 0; col < a.GetLength(1); col++)
                    Console.Write(string.Format("{0,5} ", Math.Round(a[row, col], 2)));
                Console.WriteLine(string.Format("| {0,5} |", Math.Round(b[row], 2)));
            }
        }

        private void SortLead(int i)
        {
            var m = i;

            for (int l = i; l < a.GetLength(0); l++)
                if (Math.Abs(a[m, i]) < Math.Abs(a[l, i]))
                    m = l;

            if (m != i)
            {
                double tmp;
                
                for (int s = 0; s < a.GetLength(1); s++)
                {
                    tmp = a[i, s];
                    a[i, s] = a[m, s];
                    a[m, s] = tmp;
                }

                tmp = b[i];
                b[i] = b[m];
                b[m] = tmp;
            }

            Console.WriteLine(string.Format("\n Sort.", i));
            ShowAB();
            Console.WriteLine();

        }

        public void Gauss()
        {
            var a = (double[,])this.a.Clone();
            var b = (double[])this.b.Clone();
            var x = new double[b.Length];

            var watch = System.Diagnostics.Stopwatch.StartNew();

            Console.WriteLine(" Source Matrix: ");
            ShowAB();

            // 1. Прямой ход
            for (int i = 0; i < a.GetLength(0); i++)
            { // Текущая строка
                SortLead(i); // Выбор ведущего элемента
                for (int k = 0; k < i; k++)
                { // Проход по элементам слева от главной диагонали)
                    b[i] -= b[k] * (a[i, k] / a[k, k]); // Вычитание элементов матрицы B
                    for (int j = a.GetLength(1) - 1; j >= 0; j--)
                    { // Вычитание элементов матрицы А
                        a[i, j] -= a[k, j] * (a[i, k] / a[k, k]);
                    }
                }

                Console.WriteLine(string.Format("\n Step {0}.", i));
                ShowAB();
                Console.WriteLine();
            }

            // 2. Обратный ход
            for (int i = a.GetLength(0) - 1; i >= 0; i--)
            {
                x[i] = b[i] / a[i, i]; // x_n
                for (int xi = a.GetLength(0) - 1; xi > i; xi--)
                { // i < n
                    x[i] -= ((a[i, xi] * x[xi]) / a[i, i]);
                }
                Console.WriteLine(string.Format(" x{0} = {1}", i + 1, x[i]));
            }

            watch.Stop();
            Console.WriteLine("\nTime elapsed (s): {0}", watch.Elapsed.TotalSeconds);
            Console.WriteLine("Time elapsed (ms): {0}", watch.Elapsed.TotalMilliseconds);
            Console.WriteLine("Time elapsed (ns): {0}", watch.Elapsed.TotalMilliseconds * 1000000);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var eq = new LinearEquation(new double[,] { { 1, -2, 1 }, { 2, -5, -1 }, { -7, 0, 1 } }, new double[] { 2, -1, -2 });
            //var eq = new LinearEquation(new double[,] { { 5, -5, -3, 4 }, { 1, -4, 6, -4 }, { -2, -5, 4, -5 } , { -3, -3, 5, -5 } }, new double[] { -11, -10, -12, 8 });
            //var eq = new LinearEquation(new double[,] { {0.78, 0.563 }, { 0.913, 0.659 } }, new double[] { 0.217, 0.254 });
            eq.Gauss();

            Console.ReadLine();
        }
    }
}
