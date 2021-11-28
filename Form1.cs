using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Method_of_calculation_6
{
    public partial class Main_Form : Form
    {
        public Main_Form()
        {
            InitializeComponent();
        }

        static int end = 20;
        static int y0 = 1;
        static double a = 0;
        static double b = Math.PI / 2;
        static double[] start_section = new double[end];
        static double[] mid_section = new double[end];
        static double[] end_section = new double[end];

        // 
        static double Func(double x, double y)
        {
            return y * Math.Sin(x);
        }

        // 
        static double Ex_sol(double x)
        {
            return Math.Exp(1 - Math.Cos(x));
        }

        static double[] Eulers_method(int n)
        {
            double[] yj = new double[n + 1];
            yj[0] = y0;
            double h = (a + b) / n;

            for (int i = 1; i < n; ++i)
            {
                double xj = a + i * h;
                yj[i] = yj[i - 1] + h * Func(xj, yj[i - 1]);
            }
            return yj;
        }

        private void Result_btn_Click(object sender, EventArgs e)
        {
            int n = 1;
            double mid = (a + b) / 2;

            for (int i = 0; i < end; ++i)
            {
                n *= 2;
                double[] yj = Eulers_method(n);

                start_section[i] = Ex_sol(0) - yj[0];
                mid_section[i] = Ex_sol(mid) - yj[(n-1) / 2];
                end_section[i] = Ex_sol(b) - yj[n - 1];
                dataGridView.Rows.Add(n, start_section[i], mid_section[i], end_section[i]);
            }
        }
    }
}