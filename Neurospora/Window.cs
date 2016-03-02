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
        private const int NUM_OF_EQ = 1;

        public Window()
        {
            InitializeComponent();
        }

        private void Window_Load(object sender, EventArgs e)
        {
            odes = new ODEs[NUM_OF_EQ];

            for (int i = 0; i < NUM_OF_EQ; i++)
                odes[i] = new ODEs();

            propertyGrid.SelectedObject = odes[0];
        }

        private void Window_FormClosing(object sender, FormClosingEventArgs e)
        {
            chart.Series.Clear();

            for (int i = 0; i < NUM_OF_EQ; i++)
                odes[i] = null;

            odes = null;
        }

        private void propertyGrid_SelectedGridItemChanged(object sender, SelectedGridItemChangedEventArgs e)
        {
            // при изменении параметров уравнений,
            // запрещаем рисовать решение
            disablePlotBtn();
        }

        private void disablePlotBtn()
        {
            // выключает кнопку "Нарисовать" и 
            // включает кнопку "Решить"
            if (btnPlot.Enabled)
            {
                btnPlot.Enabled = false;
                btnSolve.Enabled = true;
            }

            labelError.Visible = false;
        }

        private void enablePlotBtn()
        {
            // если система решена успешно,
            // то включаем кнопку "Нарисовать"
            if (!labelError.Visible)
            {
                btnSolve.Enabled = false;
                btnPlot.Enabled = true;
            }
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            progressBar.Value = 0;

            for (int i = 0; i < NUM_OF_EQ; i++)
                odes[i].load();
            progressBar.Value++;

            for (int i = 0; i < NUM_OF_EQ; i++)
                odes[i].initials();
            progressBar.Value++;

            for (int i = 0; i < NUM_OF_EQ; i++)
            {
                int extCode = odes[i].solve();
                if (extCode != 0)
                    labelError.Visible = true;
            }
            progressBar.Value++;

            enablePlotBtn();
        }

        private void btnPlot_Click(object sender, EventArgs e)
        {
            clearPlot();
            setPlot();

            for (int i = 0; i < NUM_OF_EQ; i++)
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
            // удаляет все точки с графика
            for (int i = 0; i < chart.Series.Count(); i++)
                chart.Series[i].Points.Clear();
        }

        private void setPlot()
        {
            // настраивает оси графика
            chart.ChartAreas[0].AxisX.Minimum = 0;
            chart.ChartAreas[0].AxisX.Maximum = odes[0].T + 1;

            chart.ChartAreas[0].AxisX.Interval = Convert.ToInt32((chart.ChartAreas[0].AxisX.Maximum + chart.ChartAreas[0].AxisX.Minimum) / 6.0);
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            About w = new About();
            w.Show();
        }
    }
}
