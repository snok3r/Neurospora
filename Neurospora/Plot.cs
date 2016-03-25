using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Neurospora
{
    public partial class Plot : Form
    {
        public Plot()
        {
            InitializeComponent();
        }

        public void buttonPlot_Click(ODEs[] odes)
        {
            clearPlot();
            setPlot(odes[0].T);

            StreamReader srT = new StreamReader("./tmp/T.ira");
            StreamReader srM = new StreamReader("./tmp/M.ira");
            StreamReader srFc = new StreamReader("./tmp/Fc.ira");
            StreamReader srFn = new StreamReader("./tmp/Fn.ira");

            string m;
            int j = 0;
            while ((m = srM.ReadLine()) != null)
            {
                plot(double.Parse(srT.ReadLine()), double.Parse(m), double.Parse(srFc.ReadLine()), double.Parse(srFn.ReadLine()), odes[0].getVs(j));
                j++;
            }

            srT.Close();
            srM.Close(); 
            srFc.Close(); 
            srFn.Close();

            makeTitle(odes[0]);
        }

        private void plot(double t, double m, double fc, double fn, double vs)
        {
            chart.Series[0].Points.AddXY(t, m);
            chart.Series[1].Points.AddXY(t, fc + fn);
            chart.Series[2].Points.AddXY(t, fn);
            chart.Series[3].Points.AddXY(t, vs);
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
            if (ode.isVsVar())
                sb.Append("Vs = " + ode.getVs(true) + " / " + ode.getVs(false) + ";  ");
            else
                sb.Append("Vs = " + ode.getVs(true) + ";  ");
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
