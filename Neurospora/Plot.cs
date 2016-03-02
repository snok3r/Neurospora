using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neurospora
{
    public partial class Plot : Form
    {
        public Plot()
        {
            InitializeComponent();
        }

        public void btnPlot_Click(ODEs[] obj, int NUM_OF_EQ)
        {
            clearPlot();
            setPlot(obj[0].T);

            for (int i = 0; i < NUM_OF_EQ; i++)
                for (int j = 0; j < obj[i].N; j++)
                    plot(j, obj[i]);
        }

        private void plot(int j, ODEs obj)
        {
            double t = obj.getT(j);
            double fn = obj.getFn(j);

            chart.Series[0].Points.AddXY(t, obj.getM(j));
            chart.Series[1].Points.AddXY(t, obj.getFc(j) + fn);
            chart.Series[2].Points.AddXY(t, fn);
            chart.Series[3].Points.AddXY(t, obj.Vs);
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

            chart.ChartAreas[0].AxisX.Interval = Convert.ToInt32((chart.ChartAreas[0].AxisX.Maximum + chart.ChartAreas[0].AxisX.Minimum) / 6.0);
        }
    }
}
