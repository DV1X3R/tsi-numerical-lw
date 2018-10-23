using System;

namespace Exercise1
{
    class LinearEquation
    {
        private double[,] a;
        private double[] b;

        public LinearEquation(double[,] a, double[] b)
        {
            this.a = a;
            this.b = b;
        }

        public void ShowAB()
        {
            for (int row = 0; row < a.GetLength(0); row++)
            {
                Console.Write("| ");
                for (int col = 0; col < a.GetLength(1); col++)
                    Console.Write(string.Format("{0,3} ", a[row, col]));
                Console.WriteLine(string.Format("| {0,3} |", b[row]));
            }
        }

        public void Gauss()
        {
            double[,] a = this.a;
            double[] b = this.b;
            double[] x = new double[b.Length];

            Console.WriteLine(" Source Matrix: ");
            ShowAB();

            // 1. Прямой ход
            for (int i = 1; i < a.GetLength(0); i++)
            { // Текущая строка
                for (int k = 0; k < i; k++)
                { // Индекс элемента в строке (слева от главной диагонали)
                    b[i] -= b[k] * (a[i, k] / a[k, k]);
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
                for(int xi = a.GetLength(0) - 1; xi > i; xi--)
                { // i < n
                    x[i] -= ((a[i, xi] * x[xi]) / a[i, i]);
                }
            }

            Console.WriteLine(string.Format(" x1 = {0} \n x2 = {1} \n x3 = {2} ", x[0], x[1], x[2]));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var eq = new LinearEquation(new double[,] { { 1, -2, 1 }, { 2, -5, -1 }, { -7, 0, 1 } }, new double[] { 2, -1, -2 });
            eq.Gauss();

            Console.ReadLine();
        }
    }
}
