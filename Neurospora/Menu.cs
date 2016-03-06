using System;
using System.Windows.Forms;

namespace Neurospora
{
    public partial class Menu : Form
    {
        Plot plot;
        ODEs[] odes;
        private const int NUM_OF_EQ = 1;

        public Menu()
        {
            InitializeComponent();

            openPlot();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            odes = new ODEs[NUM_OF_EQ];

            for (int i = 0; i < NUM_OF_EQ; i++)
                odes[i] = new ODEs();

            propertyGrid.SelectedObject = odes[0];
        }

        private void propertyGrid_SelectedGridItemChanged(object sender, SelectedGridItemChangedEventArgs e)
        {
            // при изменении параметров уравнений,
            // запрещаем рисовать решение
            disablePlotButton();
        }

        private void disablePlotButton()
        {
            // выключает кнопку "Нарисовать" и 
            // включает кнопку "Решить"
            if (buttonPlot.Enabled)
            {
                buttonPlot.Enabled = false;
                buttonSolve.Enabled = true;
            }

            labelError.Visible = false;
        }

        private void enablePlotButton()
        {
            // если система решена успешно,
            // то включаем кнопку "Нарисовать"
            if (!labelError.Visible)
            {
                buttonSolve.Enabled = false;
                buttonPlot.Enabled = true;
            }
        }

        private void buttonSolve_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < NUM_OF_EQ; i++)
                odes[i].load();

            for (int i = 0; i < NUM_OF_EQ; i++)
                odes[i].initials();

            for (int i = 0; i < NUM_OF_EQ; i++)
            {
                if (odes[i].solve() != 0)
                    labelError.Visible = true;
            }

            enablePlotButton();
        }

        private void buttonPlot_Click(object sender, EventArgs e)
        {
            if (!plot.Created)
                openPlot();
            plot.buttonPlot_Click(odes, NUM_OF_EQ);
        }

        private void openPlot()
        {
            plot = new Plot();
            plot.Show();
            plot.SetDesktopLocation(this.Location.X + this.Size.Width, this.Location.Y);
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
            about.SetDesktopLocation(this.Location.X + this.Size.Width, this.Location.Y);
        }
    }
}
