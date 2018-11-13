using Exercise1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4_5
{
    class ProgramG
    {

        public static void RunMainProgram(List<double> initXs, List<double> initYs, out List<double> resXs, out List<double> resYs, int exp)
        {
            List<Point> points = new List<Point>();
            for (int i = 0; i < initXs.Count; i++)
            {
                points.Add(new Point() { x = initXs[i], y = initYs[i] });
            }

            var Gaus = new GausMethod((uint)exp, (uint)exp);
            var d = new double[exp];

            for (var j = 0; j < exp; j++)
            {
                var f = 0.0;
                for (var i = 0; i < points.Count; i++)
                {
                    f += points[i].y * Math.Pow(points[i].x, j);
                }
                d[j] = f;
                for (var k = 0; k < exp; k++)
                {
                    var c = 0.0;
                    for (var i = 0; i < points.Count; i++)
                    {
                        c += Math.Pow(points[i].x, k + j);
                    }
                    Gaus.Matrix[j][k] = c;
                }
            }
            Gaus.RightPart = d;

            resXs = new List<double>();
            resYs = new List<double>();

            var matrix2d = Gaus.To2D(Gaus.Matrix);
            var equation = new LinearEquation(matrix2d, Gaus.RightPart);
            equation.Gauss();

            for (var z = initXs[0]; z < initXs[initXs.Count - 1]; z += 0.1)
            {
                resXs.Add(z);
                var res = equation.x[0];
                for (var e = 0; e < exp; e++)
                {
                    res += equation.x[e] * Math.Pow(z, e);
                }
                resYs.Add(res);
            }

        }
    }

    class Point
    {
        public double x { get; set; }
        public double y { get; set; }
    }

    class GausMethod
    {
        public uint RowCount;
        public uint ColumCount;
        public double[][] Matrix { get; set; }  
        public double[] RightPart { get; set; }
        public double[] Answ { get; set; }

        public GausMethod(uint Row, uint Colum)
        {
            RightPart = new double[Row];
            Answ = new double[Row];
            Matrix = new double[Row][];

            for (int i = 0; i < Row; i++)
                Matrix[i] = new double[Colum];

            RowCount = Row;
            ColumCount = Colum;

            for (int i = 0; i < Row; i++)
            {
                Answ[i] = 0;
                RightPart[i] = 0;
                for (int j = 0; j < Colum; j++)
                    Matrix[i][j] = 0;
            }
        }

        public T[,] To2D<T>(T[][] source)
        {
            try
            {
                int FirstDim = source.Length;
                int SecondDim = source.GroupBy(row => row.Length).Single().Key; // throws InvalidOperationException if source is not rectangular

                var result = new T[FirstDim, SecondDim];
                for (int i = 0; i < FirstDim; ++i)
                    for (int j = 0; j < SecondDim; ++j)
                        result[i, j] = source[i][j];

                return result;
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("The given jagged array is not rectangular.");
            }
        }

    }
}
