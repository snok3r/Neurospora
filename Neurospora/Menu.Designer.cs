namespace Neurospora
{
    partial class Menu
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.buttonSolveAndPlot = new System.Windows.Forms.Button();
            this.labelError = new System.Windows.Forms.Label();
            this.buttonAbout = new System.Windows.Forms.Button();
            this.checkBoxVs = new System.Windows.Forms.CheckBox();
            this.labelVsDarkOrNon = new System.Windows.Forms.Label();
            this.labelVsLight = new System.Windows.Forms.Label();
            this.textBoxVsDarkOrNon = new System.Windows.Forms.TextBox();
            this.textBoxVsLight = new System.Windows.Forms.TextBox();
            this.labelErrFile = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // propertyGrid
            // 
            this.propertyGrid.Location = new System.Drawing.Point(8, 8);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(167, 363);
            this.propertyGrid.TabIndex = 1;
            // 
            // buttonSolveAndPlot
            // 
            this.buttonSolveAndPlot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSolveAndPlot.Location = new System.Drawing.Point(12, 467);
            this.buttonSolveAndPlot.Name = "buttonSolveAndPlot";
            this.buttonSolveAndPlot.Size = new System.Drawing.Size(163, 64);
            this.buttonSolveAndPlot.TabIndex = 2;
            this.buttonSolveAndPlot.Text = "Нарисовать решение";
            this.buttonSolveAndPlot.UseVisualStyleBackColor = true;
            this.buttonSolveAndPlot.Click += new System.EventHandler(this.buttonSolveAndPlot_Click);
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelError.ForeColor = System.Drawing.Color.Maroon;
            this.labelError.Location = new System.Drawing.Point(12, 534);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(169, 18);
            this.labelError.TabIndex = 4;
            this.labelError.Text = "Ошибка вычислений";
            this.labelError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelError.Visible = false;
            // 
            // buttonAbout
            // 
            this.buttonAbout.Location = new System.Drawing.Point(12, 438);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(163, 23);
            this.buttonAbout.TabIndex = 5;
            this.buttonAbout.Text = "О системе уравнений";
            this.buttonAbout.UseVisualStyleBackColor = true;
            this.buttonAbout.Click += new System.EventHandler(this.buttonAbout_Click);
            // 
            // checkBoxVs
            // 
            this.checkBoxVs.AutoSize = true;
            this.checkBoxVs.Location = new System.Drawing.Point(12, 377);
            this.checkBoxVs.Name = "checkBoxVs";
            this.checkBoxVs.Size = new System.Drawing.Size(107, 17);
            this.checkBoxVs.TabIndex = 6;
            this.checkBoxVs.Text = "Переменный Vs";
            this.checkBoxVs.UseVisualStyleBackColor = true;
            this.checkBoxVs.CheckedChanged += new System.EventHandler(this.checkBoxVs_CheckedChanged);
            // 
            // labelVsDarkOrNon
            // 
            this.labelVsDarkOrNon.AutoSize = true;
            this.labelVsDarkOrNon.Location = new System.Drawing.Point(12, 396);
            this.labelVsDarkOrNon.Name = "labelVsDarkOrNon";
            this.labelVsDarkOrNon.Size = new System.Drawing.Size(19, 13);
            this.labelVsDarkOrNon.TabIndex = 7;
            this.labelVsDarkOrNon.Text = "Vs";
            // 
            // labelVsLight
            // 
            this.labelVsLight.AutoSize = true;
            this.labelVsLight.Location = new System.Drawing.Point(108, 396);
            this.labelVsLight.Name = "labelVsLight";
            this.labelVsLight.Size = new System.Drawing.Size(41, 13);
            this.labelVsLight.TabIndex = 8;
            this.labelVsLight.Text = "Vs light";
            this.labelVsLight.Visible = false;
            // 
            // textBoxVsDarkOrNon
            // 
            this.textBoxVsDarkOrNon.Location = new System.Drawing.Point(12, 412);
            this.textBoxVsDarkOrNon.Name = "textBoxVsDarkOrNon";
            this.textBoxVsDarkOrNon.Size = new System.Drawing.Size(55, 20);
            this.textBoxVsDarkOrNon.TabIndex = 9;
            this.textBoxVsDarkOrNon.Validated += new System.EventHandler(this.textBoxVsDarkOrNon_Validated);
            // 
            // textBoxVsLight
            // 
            this.textBoxVsLight.Location = new System.Drawing.Point(111, 412);
            this.textBoxVsLight.Name = "textBoxVsLight";
            this.textBoxVsLight.Size = new System.Drawing.Size(61, 20);
            this.textBoxVsLight.TabIndex = 10;
            this.textBoxVsLight.Visible = false;
            this.textBoxVsLight.Validated += new System.EventHandler(this.textBoxVsLight_Validated);
            // 
            // labelErrFile
            // 
            this.labelErrFile.AutoSize = true;
            this.labelErrFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelErrFile.ForeColor = System.Drawing.Color.Maroon;
            this.labelErrFile.Location = new System.Drawing.Point(32, 534);
            this.labelErrFile.Name = "labelErrFile";
            this.labelErrFile.Size = new System.Drawing.Size(127, 18);
            this.labelErrFile.TabIndex = 11;
            this.labelErrFile.Text = "File Load Failed";
            this.labelErrFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelErrFile.Visible = false;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(184, 561);
            this.Controls.Add(this.labelErrFile);
            this.Controls.Add(this.textBoxVsLight);
            this.Controls.Add(this.textBoxVsDarkOrNon);
            this.Controls.Add(this.labelVsLight);
            this.Controls.Add(this.labelVsDarkOrNon);
            this.Controls.Add(this.checkBoxVs);
            this.Controls.Add(this.buttonAbout);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.buttonSolveAndPlot);
            this.Controls.Add(this.propertyGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Location = new System.Drawing.Point(50, 100);
            this.MaximizeBox = false;
            this.Name = "Menu";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PropertyGrid propertyGrid;
        private System.Windows.Forms.Button buttonSolveAndPlot;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Button buttonAbout;
        private System.Windows.Forms.CheckBox checkBoxVs;
        private System.Windows.Forms.Label labelVsDarkOrNon;
        private System.Windows.Forms.Label labelVsLight;
        private System.Windows.Forms.TextBox textBoxVsDarkOrNon;
        private System.Windows.Forms.TextBox textBoxVsLight;
        private System.Windows.Forms.Label labelErrFile;
    }
}

