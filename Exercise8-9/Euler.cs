using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise8_9
{
    class Euler
    {
        public List<double[]> ResultEuler = new List<double[]>();
        public List<double[]> ResultEulerCauchy = new List<double[]>();
        public List<double[]> ResultAnalytical = new List<double[]>();

        public double Function(double x) => 0.8 * x - 0.15 * Math.Pow(x, 2);
        public double FunctionA(double x) => 0.8 * 1 * Math.Exp(0.8 * x) / (0.8 + 0.15 * 1 * (Math.Exp(0.8 * x) - 1));

        public void EulerCauchy(double minT, double maxT, double h, double y0)
        {
            ResultEuler.Clear();
            ResultEulerCauchy.Clear();

            double yEuler = y0;
            double yEulerCauchy = y0;
            double t = minT;

            ResultEuler.Add(new double[] { 0, y0 });
            ResultEulerCauchy.Add(new double[] { 0, y0 });

            do
            {
                t += h;

                // Euler
                yEuler = yEuler + (h * Function(yEuler));
                ResultEuler.Add(new double[] { t, yEuler });

                // EulerCauchy
                var yLocal = yEulerCauchy;
                var EulerStart = yLocal + (h * Function(yEulerCauchy));

                for (int i = 0; i < 1; i++)
                {  
                    yEulerCauchy = yLocal + (h / 2) * (Function(yLocal) + Function(EulerStart));
                    EulerStart = yEulerCauchy;
                }
                ResultEulerCauchy.Add(new double[] { t, yEulerCauchy });

            } while (t <= maxT);

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
