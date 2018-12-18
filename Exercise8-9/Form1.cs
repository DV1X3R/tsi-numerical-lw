using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise8_9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var euler = new Euler();

            euler.EulerSimple(0, 10, 0.05, 1);
            chart1.Series[0].Points.Clear();
            for (int i = 0; i < euler.Result.Count; i++)
            {
                chart1.Series[0].Points.AddXY(euler.Result[i][0], euler.Result[i][1]);
            }

            euler.EulerCauchy(0, 10, 0.05, 1);
            chart1.Series[1].Points.Clear();
            for (int i = 0; i < euler.Result.Count; i++)
            {
                chart1.Series[1].Points.AddXY(euler.Result[i][0], euler.Result[i][1]);
            }

            euler.EulerSimple(0, 10, 0.01, 1);
            chart1.Series[2].Points.Clear();
            for (int i = 0; i < euler.Result.Count; i++)
            {
                chart1.Series[2].Points.AddXY(euler.Result[i][0], euler.Result[i][1]);
            }

            euler.EulerCauchy(0, 10, 0.01, 1);
            chart1.Series[3].Points.Clear();
            for (int i = 0; i < euler.Result.Count; i++)
            {
                chart1.Series[3].Points.AddXY(euler.Result[i][0], euler.Result[i][1]);
            }

        }
    }
}
