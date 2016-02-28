using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neurospora
{
    public partial class Window : Form
    {
        ODEs[] odes;
        const int NUM_OF_EQ = 1;

        public Window()
        {
            InitializeComponent();
        }

        private void Window_Load(object sender, EventArgs e)
        {
            odes = new ODEs[NUM_OF_EQ];

            for (int i = 0; i < odes.Length; i++)
                odes[i] = new ODEs();

            propertyGrid.SelectedObject = odes[0];
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            progressBar.Value = 0;
            progressBar.Maximum = 3;

            for (int i = 0; i < odes.Length; i++)
                odes[i].load();
            progressBar.Value++;

            for (int i = 0; i < odes.Length; i++)
                odes[i].initials();
            progressBar.Value++;

            for (int i = 0; i < odes.Length; i++)
            {
                int extCode = odes[i].solve();
                if (extCode != 0)
                    labelError.Visible = true;
            }
            progressBar.Value++;
        }

        private void btnPlot_Click(object sender, EventArgs e)
        {
            clearPlot();
            setPlot();

            for (int i = 0; i < odes.Length; i++)
                for (int j = 0; j < odes[i].N; j++)
                    plot(j, odes[i]);
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
            for (int i = 0; i < chart.Series.Count(); i++)
                chart.Series[i].Points.Clear();
        }

        private void setPlot()
        {
            chart.ChartAreas[0].AxisX.Minimum = 0;
            chart.ChartAreas[0].AxisX.Maximum = odes[0].T + 1;

            //chart.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(txtBoxMaxUVT.Text);
            //chart.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(txtBoxMinUVT.Text);

            chart.ChartAreas[0].AxisX.Interval = Convert.ToInt32((chart.ChartAreas[0].AxisX.Maximum + chart.ChartAreas[0].AxisX.Minimum) / 6.0);
            //chart.ChartAreas[0].AxisY.Interval = Convert.ToInt32((chart.ChartAreas[0].AxisY.Maximum + chart.ChartAreas[0].AxisY.Minimum) / 4.0);
        }
    }
}
