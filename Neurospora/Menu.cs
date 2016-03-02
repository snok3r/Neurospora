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
    public partial class Menu : Form
    {
        Plot w;
        ODEs[] odes;
        private const int NUM_OF_EQ = 1;

        public Menu()
        {
            InitializeComponent();

            w = new Plot();
            w.Show();
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
            for (int i = 0; i < NUM_OF_EQ; i++)
                odes[i] = null;

            odes = null;

            w = null;
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
            if (!w.Created)
            {
                w = new Plot();
                w.Show();
            }
            w.btnPlot_Click(odes, NUM_OF_EQ);
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            About w = new About();
            w.Show();
        }
    }
}
