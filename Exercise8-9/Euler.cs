using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise8_9
{
    class Euler
    {
        public List<double[]> Result = new List<double[]>();
        public List<double[]> ResultAnalytical = new List<double[]>();

        public double Function(double x) => 0.8 * x - 0.15 * Math.Pow(x, 2);
        public double FunctionA(double x) => 0.8 * 1 * Math.Exp(0.8 * x) / (0.8 + 0.15 * 1 * (Math.Exp(0.8 * x) - 1));

        public double EulerSimple(double minT, double maxT, double h, double y0, double? reqT = null)
        {
            double y = y0;
            double t = minT;
            //double n = maxT / h;
            var result = new List<double[]>() { new double[] { 0, y0 } };

            do
            {
                t += h; // Calculate
                y = y + h * Function(y);
                result.Add(new double[] { t, y });
                if (reqT != null && reqT == t)
                    return y; // EulerCauchy shortcut
            } while (t <= maxT);

            Result = result;
            return 0;
        }

        public void EulerCauchy(double minT, double maxT, double h, double y0)
        {
            double y = y0;
            double t = minT;
            //double n = maxT / h;
            var result = new List<double[]>() { new double[] { 0, y0 } };

            do
            {
                t += h; // Calculate
                if (t <= maxT)
                {
                    y = y + ((h / 2) * (Function(y) + EulerSimple(minT, maxT, h, y0, (t + h))));
                }
                result.Add(new double[] { t, y });
            } while (t <= maxT);

            Result = result;
        }

        public void Analytical(double minT, double maxT, double h)
        {
            double t = minT;
            var result = new List<double[]>() { new double[] { 0, FunctionA(0) } }; ;

            do
            {
                t += h; // Calculate
                var y = FunctionA(t);
                result.Add(new double[] { t, y });
            } while (t <= maxT);

            ResultAnalytical = result;
        }
    }
}
