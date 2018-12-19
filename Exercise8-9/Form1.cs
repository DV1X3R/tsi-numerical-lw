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

            euler.Analytical(0, 10, 0.05);
            euler.EulerCauchy(0, 10, 0.05, 1);

            chart1.Series[0].Points.Clear();
            double maxErrorEuler = 0;
            for (int i = 0; i < euler.ResultEuler.Count; i++)
            {
                chart1.Series[0].Points.AddXY(euler.ResultEuler[i][0], euler.ResultAnalytical[i][1] - euler.ResultEuler[i][1]);
                if (maxErrorEuler < Math.Abs(euler.ResultAnalytical[i][1] - euler.ResultEuler[i][1]))
                    maxErrorEuler = Math.Abs(euler.ResultAnalytical[i][1] - euler.ResultEuler[i][1]);
            }
            label1.Text = maxErrorEuler.ToString();

            chart1.Series[1].Points.Clear();

            maxErrorEuler = 0;
            for (int i = 0; i < euler.ResultEulerCauchy.Count; i++)
            {
                chart1.Series[1].Points.AddXY(euler.ResultEulerCauchy[i][0], euler.ResultAnalytical[i][1] - euler.ResultEulerCauchy[i][1]);
                if (maxErrorEuler < Math.Abs(euler.ResultAnalytical[i][1] - euler.ResultEulerCauchy[i][1]))
                    maxErrorEuler = Math.Abs(euler.ResultAnalytical[i][1] - euler.ResultEulerCauchy[i][1]);

            }
            label2.Text = maxErrorEuler.ToString();
            //label3.Text = chart1.Series[1].Points.FindMinByValue("Y").YValues.ToString();
            euler.Analytical(0, 10, 0.01);
            euler.EulerCauchy(0, 10, 0.01, 1);
            
            chart1.Series[2].Points.Clear();
            maxErrorEuler = 0;
            for (int i = 0; i < euler.ResultEuler.Count; i++)
            {
                chart1.Series[2].Points.AddXY(euler.ResultEuler[i][0], euler.ResultAnalytical[i][1] - euler.ResultEuler[i][1]);
                if (maxErrorEuler < Math.Abs(euler.ResultAnalytical[i][1] - euler.ResultEuler[i][1]))
                    maxErrorEuler = Math.Abs(euler.ResultAnalytical[i][1] - euler.ResultEuler[i][1]);
            }
            label3.Text = maxErrorEuler.ToString();

            chart1.Series[3].Points.Clear();
            maxErrorEuler = 0;
            for (int i = 0; i < euler.ResultEulerCauchy.Count; i++)
            {
                chart1.Series[3].Points.AddXY(euler.ResultEulerCauchy[i][0], euler.ResultAnalytical[i][1] - euler.ResultEulerCauchy[i][1]);
                if (maxErrorEuler < Math.Abs(euler.ResultAnalytical[i][1] - euler.ResultEulerCauchy[i][1]))
                    maxErrorEuler = Math.Abs(euler.ResultAnalytical[i][1] - euler.ResultEulerCauchy[i][1]);
            }
            label4.Text = maxErrorEuler.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var euler = new Euler();

            euler.EulerCauchy(0, 10, 0.05, 1);

            chart1.Series[0].Points.Clear();
            for (int i = 0; i < euler.ResultEuler.Count; i++)
            {
                chart1.Series[0].Points.AddXY(euler.ResultEuler[i][0], euler.ResultEuler[i][1]);
            }
            chart1.Series[1].Points.Clear();
            for (int i = 0; i < euler.ResultEulerCauchy.Count; i++)
            {
                chart1.Series[1].Points.AddXY(euler.ResultEulerCauchy[i][0], euler.ResultEulerCauchy[i][1]);
            }

            euler.EulerCauchy(0, 10, 0.01, 1);

            chart1.Series[2].Points.Clear();
            for (int i = 0; i < euler.ResultEuler.Count; i++)
            {
                chart1.Series[2].Points.AddXY(euler.ResultEuler[i][0], euler.ResultEuler[i][1]);
            }

            chart1.Series[3].Points.Clear();
            for (int i = 0; i < euler.ResultEulerCauchy.Count; i++)
            {
                chart1.Series[3].Points.AddXY(euler.ResultEulerCauchy[i][0], euler.ResultEulerCauchy[i][1]);
            }

            chart1.Series[4].Points.Clear();
            for (int i = 0; i < euler.ResultAnalytical.Count; i++)
            {
                chart1.Series[4].Points.AddXY(euler.ResultAnalytical[i][0], euler.ResultAnalytical[i][1]);
            }

        }
    }
}
