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

            labelVsLight.Enabled = !labelVsLight.Enabled;
            textBoxVsLight.Enabled = !textBoxVsLight.Enabled;

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
            try
            {
                solve();
                plot();
            }
            catch (OverflowException)
            {
                MessageBox.Show(
                    "Ошибка при вычислении (попробуйте уменьшить шаг ht)",
                    "Computation error",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (DirectoryNotFoundException)
            {
                Directory.CreateDirectory(Program.tmpFolder);
                if (sender is String)
                {
                    String message = (String)sender;
                    if (message.Equals("directory not found"))
                    {
                        MessageBox.Show(
                            "Ошибка при считывании с файла. Проверьте права доступа.",
                            "Directory not found",
                            MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                    buttonSolveAndPlot_Click("directory not found", e);

            }
            catch (FileNotFoundException)
            {
                if (sender is String)
                {
                    String message = (String)sender;
                    if (message.Equals("file not found"))
                    {
                        MessageBox.Show(
                            "Ошибка при считывании с файла. Проверьте права доступа.",
                            "File not found",
                             MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                    buttonSolveAndPlot_Click("file not found", e);
            }
        }

        /// <exception cref="System.OverflowException">если решение расходится</exception>
        /// <exception cref="System.DirectoryNotFoundException">если что-то не так с файлами</exception>
        private void solve()
        {
            ode.load();
            ode.initials();
            ode.solve();
        }

        /// <exception cref="System.FileNotFoundException">если что-то не так с файлами</exception>
        /// <exception cref="System.DirectoryNotFoundException">если что-то не так с файлами</exception>
        private void plot()
        {
            if (!plotView.Created)
                openPlot();

            plotView.plot(ode);
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
