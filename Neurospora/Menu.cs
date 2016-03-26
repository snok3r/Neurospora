using System;
using System.IO;
using System.Windows.Forms;

namespace Neurospora
{
    public partial class Menu : Form
    {
        Plot plot;
        ODEs ode;

        public Menu()
        {
            InitializeComponent();
            Directory.CreateDirectory(Program.tmpFolder);
            openPlot();
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Directory.Delete(Program.tmpFolder, true);
            }
            catch (DirectoryNotFoundException) { }
            finally 
            {
                Dispose(true);
            }
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            ode = new ODEs();

            propertyGrid.SelectedObject = ode;

            textBoxVsDarkOrNon.Text = ode.getVs(true).ToString();
            textBoxVsLight.Text = ode.getVs(false).ToString();
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
            if (buttonPlot.Enabled)
            {
                buttonPlot.Enabled = false;
                buttonSolve.Enabled = true;
            }
        }

        private void enablePlotButton()
        {
            if (!buttonPlot.Enabled)
            {
                buttonPlot.Enabled = true;
                buttonSolve.Enabled = false;
            }
        }

        private void checkBoxVs_CheckedChanged(object sender, EventArgs e)
        {
            disablePlotButton();

            ode.changeVsVariability();

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
                ode.setVs(0, Double.Parse(textBoxVsDarkOrNon.Text));
            }
            catch (Exception) { }
            textBoxVsDarkOrNon.Text = ode.getVs(true).ToString();
        }

        private void textBoxVsLight_TextChanged(object sender, EventArgs e)
        {
            disablePlotButton();
        }

        private void textBoxVsLight_Validated(object sender, EventArgs e)
        {
            try
            {
                ode.setVs(1, Double.Parse(textBoxVsLight.Text));
            }
            catch (Exception) { }
            textBoxVsLight.Text = ode.getVs(false).ToString();
        }

        private void buttonSolve_Click(object sender, EventArgs e)
        {
            labelError.Visible = false;
            labelErrFile.Visible = false;

            try
            {
                ode.load();
                ode.initials();
                ode.solve();
                enablePlotButton();
            }
            catch (OverflowException)
            {
                labelError.Visible = true;
            }
            catch (DirectoryNotFoundException)
            {
                Directory.CreateDirectory(Program.tmpFolder);
                labelErrFile.Visible = true;
            }
        }

        private void buttonPlot_Click(object sender, EventArgs e)
        {
            if (!plot.Created)
                openPlot();

            try
            {
                plot.buttonPlot_Click(ode);
            }
            catch (FileNotFoundException) 
            {
                disablePlotButton();
                labelErrFile.Visible = true;
            }
            catch (DirectoryNotFoundException) 
            {
                Directory.CreateDirectory(Program.tmpFolder);
                disablePlotButton();
                labelErrFile.Visible = true;
            }
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
