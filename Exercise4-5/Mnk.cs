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

            var result = Gaus.Solve();
            if (result == 0)
            {
                var w = 0.0;
                for (var i = 0; i < exp; i++)
                {
                    #region calc func

                    for (double z = initXs[0]; z < initXs[initXs.Count-1]; z += 0.1)
                    {
                        resXs.Add(z);
                        var res = Gaus.Answ[0];
                        for (var e = 0; e < exp - 2; e++)
                        {
                            res += Gaus.Answ[e + 1] * Math.Pow(z, e + 1);

                        }
                        resYs.Add(res);
                    }

                    
                    #endregion
                    //w += Math.Pow((res - points[i].y), 2);
                }
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



            #region 0 mass

            for (int i = 0; i < Row; i++)

            {

                Answ[i] = 0;

                RightPart[i] = 0;

                for (int j = 0; j < Colum; j++)

                    Matrix[i][j] = 0;

            }

            #endregion

        }



        private void SortRows(int SortIndex)

        {



            double MaxElement = Matrix[SortIndex][SortIndex];

            int MaxElementIndex = SortIndex;

            for (int i = SortIndex + 1; i < RowCount; i++)

            {

                if (Matrix[i][SortIndex] > MaxElement)

                {

                    MaxElement = Matrix[i][SortIndex];

                    MaxElementIndex = i;

                }

            }



            #region Sort -> max to up

            if (MaxElementIndex > SortIndex)

            {

                double Temp;



                Temp = RightPart[MaxElementIndex];

                RightPart[MaxElementIndex] = RightPart[SortIndex];

                RightPart[SortIndex] = Temp;



                for (int i = 0; i < ColumCount; i++)

                {

                    Temp = Matrix[MaxElementIndex][i];

                    Matrix[MaxElementIndex][i] = Matrix[SortIndex][i];

                    Matrix[SortIndex][i] = Temp;

                }

            }

            #endregion

        }



        public int Solve()

        {

            if (RowCount != ColumCount)

            {

                Console.WriteLine("No solution");

                return 1;

            }



            for (int i = 0; i < RowCount - 1; i++)

            {

                SortRows(i);

                for (int j = i + 1; j < RowCount; j++)

                {

                    if (Matrix[i][i] != 0)

                    {

                        double MultElement = Matrix[j][i] / Matrix[i][i];

                        for (int k = i; k < ColumCount; k++)

                            Matrix[j][k] -= Matrix[i][k] * MultElement;

                        RightPart[j] -= RightPart[i] * MultElement;

                    }

                }

            }



            Console.WriteLine(this.ToString());



            for (int i = (int)(RowCount - 1); i >= 0; i--)

            {

                Answ[i] = RightPart[i];



                for (int j = (int)(RowCount - 1); j > i; j--)

                    Answ[i] -= Matrix[i][j] * Answ[j];



                if (Matrix[i][i] == 0)

                    if (RightPart[i] == 0)

                    {

                        Console.WriteLine("Many answers");

                        return 2;

                    }

                    else

                    {

                        Console.WriteLine("No solution");

                        return 1;

                    }



                Answ[i] /= Matrix[i][i];



            }

            return 0;

        }



        public void fillMatrix(int[] mat)

        {

            if (mat.Length != RowCount * ColumCount)

                Console.WriteLine("Incorrect matrix");

            else

            {

                var ii = 0;

                for (var i = 0; i < RowCount; i++)

                {

                    for (var j = 0; j < ColumCount; j++, ii++)

                    {

                        Matrix[i][j] = mat[ii];

                    }

                }

            }

        }



        public override String ToString()

        {

            String S = "";

            for (int i = 0; i < RowCount; i++)

            {

                S += "\r\n|";

                for (int j = 0; j < ColumCount; j++)

                {

                    S += Matrix[i][j].ToString();

                    if (j + 1 != ColumCount)

                        S += "\t";

                }



                // S += "\t" + Answ[i].ToString("F08");

                S += " | x  =  | " + RightPart[i].ToString() + " |";

            }

            return S;

        }

    }
}
