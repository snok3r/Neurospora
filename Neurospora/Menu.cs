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

            textBoxVsDarkOrNon.Text = odes[0].getVs(true).ToString();
            textBoxVsLight.Text = odes[0].getVs(false).ToString();
        }

        private void propertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            // при изменении параметров уравнений,
            // запрещаем рисовать решение
            if (e.OldValue == e.ChangedItem.Value) // параметры не изменились
                return;

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

        private void checkBoxVs_CheckedChanged(object sender, EventArgs e)
        {
            disablePlotButton();

            odes[0].changeVsVariability();

            labelVsLight.Visible = !labelVsLight.Visible;
            textBoxVsLight.Visible = !textBoxVsLight.Visible;

            if (checkBoxVs.Checked)
                labelVsDarkOrNon.Text = "Vs dark";
            else
                labelVsDarkOrNon.Text = "Vs";
        }

        private void textBoxVsDarkOrNon_TextChanged(object sender, EventArgs e)
        {
            disablePlotButton();
        }

        private void textBoxVsDarkOrNon_Validated(object sender, EventArgs e)
        {
            try
            {
                odes[0].setVs(0, Double.Parse(textBoxVsDarkOrNon.Text));
                textBoxVsDarkOrNon.Text = odes[0].getVs(true).ToString();
            }
            catch (Exception)
            {
                textBoxVsDarkOrNon.Text = odes[0].getVs(true).ToString();
            }
        }

        private void textBoxVsLight_TextChanged(object sender, EventArgs e)
        {
            disablePlotButton();
        }

        private void textBoxVsLight_Validated(object sender, EventArgs e)
        {
            try
            {
                odes[0].setVs(1, Double.Parse(textBoxVsLight.Text));
                textBoxVsLight.Text = odes[0].getVs(false).ToString();
            }
            catch (Exception)
            {
                textBoxVsLight.Text = odes[0].getVs(false).ToString();
            }
        }

        private void buttonSolve_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < NUM_OF_EQ; i++)
                odes[i].load();

            for (int i = 0; i < NUM_OF_EQ; i++)
                odes[i].initials();

            for (int i = 0; i < NUM_OF_EQ; i++)
                if (odes[i].solve() != 0)
                    labelError.Visible = true;

            enablePlotButton();
        }

        private void buttonPlot_Click(object sender, EventArgs e)
        {
            if (!plot.Created)
                openPlot();
            plot.buttonPlot_Click(odes);
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
