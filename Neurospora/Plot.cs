using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Neurospora
{
    public partial class Plot : Form
    {
        public Plot()
        {
            InitializeComponent();
        }

        public void buttonPlot_Click(ODEs[] odes, int NUM_OF_EQ)
        {
            clearPlot();
            setPlot(odes[0].T);

            for (int i = 0; i < NUM_OF_EQ; i++)
            {
                odes[i].getVs(-1);
                for (int j = 0; j < odes[i].N; j++)
                    plot(odes[i], j);
            }

            makeTitle(odes[0]);
        }

        private void plot(ODEs ode, int j)
        {
            double t = ode.getT(j);
            double fn = ode.getFn(j);

            chart.Series[0].Points.AddXY(t, ode.getM(j));
            chart.Series[1].Points.AddXY(t, ode.getFc(j) + fn);
            chart.Series[2].Points.AddXY(t, fn);
            chart.Series[3].Points.AddXY(t, ode.getVs(j));
        }

        private void clearPlot()
        {
            // удаляет все точки с графика
            for (int i = 0; i < chart.Series.Count(); i++)
                chart.Series[i].Points.Clear();
        }

        private void setPlot(double T)
        {
            // настраивает оси графика
            chart.ChartAreas[0].AxisX.Minimum = 0;
            chart.ChartAreas[0].AxisX.Maximum = T + 1;

            if (T >= 12)
                chart.ChartAreas[0].AxisX.Interval = 12;
            else
                chart.ChartAreas[0].AxisX.Interval = 3;
        }

        private void makeTitle(ODEs ode)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Ki = " + ode.Ki + ";  ");
            sb.Append("Km = " + ode.Km + ";  ");
            sb.Append("Kd = " + ode.Kd + ";  ");
            sb.Append("k1 = " + ode.k1 + ";  ");
            sb.Append("k2 = " + ode.k2 + ";  ");
            sb.Append("ks = " + ode.ks + ";  ");
            sb.Append(ode.getVsString());
            sb.Append("Vm = " + ode.Vm + ";  ");
            sb.Append("Vd = " + ode.Vd + ";  ");
            sb.Append("n = " + ode.n);
            chart.Titles[0].Text = sb.ToString();
            chart.Titles[0].Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);

            sb.Clear();
            sb.Append("M(0) = " + ode.M0 + ";  ");
            sb.Append("Fc(0) = " + ode.Fc0 + ";  ");
            sb.Append("Fn(0) = " + ode.Fn0);
            chart.Titles[1].Text = sb.ToString();
            chart.Titles[1].Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
        }
    }
}
