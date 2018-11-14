using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise4_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();   
        }

        List<double> initXs, initYs;
        Mnk mnk = new Mnk();

        private void button1_Click(object sender, EventArgs e)
        {   
            initXs = new List<double> { -2, -1.5, -1, -0.5, 0, 0.5, 1, 1.5, 2 };
            initYs = initXs.Select(x => Math.Sin(x * 5) * Math.Exp(x)).ToList();
            mnk.Recalculate(initXs, initYs, (int)numericUpDown1.Value + 1);
            ShowSource();
            ShowBezier();
            ShowMNK();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            initXs = new List<double> { -3.2, -2.1, 0.4, 0.7, 2, 2.5, 2.777 };
            initYs = new List<double> { 10, -2, 0, -7, 7, 0, 0 };
            mnk.Recalculate(initXs, initYs, (int)numericUpDown1.Value + 1);
            ShowSource();
            ShowBezier();
            ShowMNK();
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            double x;
            if (Double.TryParse(maskedTextBox1.Text, out x))
                maskedTextBox2.Text = mnk.GetY(x).ToString();
        }

        public void ShowSource()
        {
            chart1.Series[2].Points.Clear();
            for (int i = 0; i < initXs.Count; i++)
            {
                chart1.Series[2].Points.AddXY(initXs[i], initYs[i]);
            }

        }

        public void ShowBezier()
        {
            var resXs = new List<double>();
            var resYs = new List<double>();

            for (double i = 0; i <= 1; i += 0.01F)
            {
                var resX = Bezier.Approx(initXs.Count - 1, i, initXs);
                var resY = Bezier.Approx(initYs.Count - 1, i, initYs);

                resXs.Add(resX);
                resYs.Add(resY);
            }

            chart1.Series[0].Points.Clear();
            for (int i = 0; i < resXs.Count; i++)
            {
                chart1.Series[0].Points.AddXY(resXs[i], resYs[i]);
            }

        }

        public void ShowMNK()
        {
            chart1.Series[1].Points.Clear();
            for(double x = initXs.Min(); x <= initXs.Max(); x += 0.01F)
            {
                chart1.Series[1].Points.AddXY(x, mnk.GetY(x));
            }

            listBox1.Items.Clear();
            for(int i = 0; i < mnk.eq.x.Length; i++)
            {
                listBox1.Items.Add(string.Format("a{0} = {1}", i + 1, mnk.eq.x[i]));
            }
        }

    }
}
