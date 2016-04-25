using System;
using System.IO;
using System.Windows.Forms;

namespace Neurospora
{
    public partial class Menu : Form
    {
        Plot plotView;
        ODEs ode;

        public Menu()
        {
            InitializeComponent();
            openPlot();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            ode = new ODEs();

            propertyGrid.SelectedObject = ode;

            textBoxVsDarkOrNon.Text = ode.getVs(true).ToString();
            textBoxVsLight.Text = ode.getVs(false).ToString();
        }

        private void checkBoxVs_CheckedChanged(object sender, EventArgs e)
        {
            ode.changeVsVariability();

            labelVsLight.Visible = !labelVsLight.Visible;
            textBoxVsLight.Visible = !textBoxVsLight.Visible;

            if (checkBoxVs.Checked)
                labelVsDarkOrNon.Text = "Vs dark";
            else
                labelVsDarkOrNon.Text = "Vs";
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

        private void textBoxVsLight_Validated(object sender, EventArgs e)
        {
            try
            {
                ode.setVs(1, Double.Parse(textBoxVsLight.Text));
            }
            catch (Exception) { }
            textBoxVsLight.Text = ode.getVs(false).ToString();
        }

        private void buttonSolveAndPlot_Click(object sender, EventArgs e)
        {
            solve();
            plot();
        }

        private void solve()
        {
            labelError.Visible = false;
            labelErrFile.Visible = false;

            try
            {
                ode.load();
                ode.initials();
                ode.solve();
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

        private void plot()
        {
            if (!labelErrFile.Visible && !labelError.Visible)
            {
                if (!plotView.Created)
                    openPlot();

                try
                {
                    plotView.plot(ode);
                }
                catch (FileNotFoundException)
                {
                    labelErrFile.Visible = true;
                }
                catch (DirectoryNotFoundException)
                {
                    Directory.CreateDirectory(Program.tmpFolder);
                    labelErrFile.Visible = true;
                }
            }
        }

        private void openPlot()
        {
            plotView = new Plot();
            plotView.Show();
            plotView.SetDesktopLocation(this.Location.X + this.Size.Width, this.Location.Y);
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
            about.SetDesktopLocation(this.Location.X + this.Size.Width, this.Location.Y);
        }
    }
}
