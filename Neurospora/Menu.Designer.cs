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
            this.buttonSolve = new System.Windows.Forms.Button();
            this.buttonPlot = new System.Windows.Forms.Button();
            this.labelError = new System.Windows.Forms.Label();
            this.buttonAbout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // propertyGrid
            // 
            this.propertyGrid.Location = new System.Drawing.Point(8, 8);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(167, 385);
            this.propertyGrid.TabIndex = 1;
            this.propertyGrid.SelectedGridItemChanged += new System.Windows.Forms.SelectedGridItemChangedEventHandler(this.propertyGrid_SelectedGridItemChanged);
            // 
            // buttonSolve
            // 
            this.buttonSolve.Location = new System.Drawing.Point(12, 438);
            this.buttonSolve.Name = "buttonSolve";
            this.buttonSolve.Size = new System.Drawing.Size(163, 38);
            this.buttonSolve.TabIndex = 2;
            this.buttonSolve.Text = "Решить систему";
            this.buttonSolve.UseVisualStyleBackColor = true;
            this.buttonSolve.Click += new System.EventHandler(this.buttonSolve_Click);
            // 
            // buttonPlot
            // 
            this.buttonPlot.Location = new System.Drawing.Point(12, 482);
            this.buttonPlot.Name = "buttonPlot";
            this.buttonPlot.Size = new System.Drawing.Size(163, 38);
            this.buttonPlot.TabIndex = 3;
            this.buttonPlot.Text = "Нарисовать график";
            this.buttonPlot.UseVisualStyleBackColor = true;
            this.buttonPlot.Click += new System.EventHandler(this.buttonPlot_Click);
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelError.ForeColor = System.Drawing.Color.Maroon;
            this.labelError.Location = new System.Drawing.Point(12, 491);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(169, 18);
            this.labelError.TabIndex = 4;
            this.labelError.Text = "Ошибка вычислений";
            this.labelError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelError.Visible = false;
            // 
            // buttonAbout
            // 
            this.buttonAbout.Location = new System.Drawing.Point(12, 409);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(163, 23);
            this.buttonAbout.TabIndex = 5;
            this.buttonAbout.Text = "О системе уравнений";
            this.buttonAbout.UseVisualStyleBackColor = true;
            this.buttonAbout.Click += new System.EventHandler(this.buttonAbout_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(184, 531);
            this.Controls.Add(this.buttonAbout);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.buttonPlot);
            this.Controls.Add(this.buttonSolve);
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
        private System.Windows.Forms.Button buttonSolve;
        private System.Windows.Forms.Button buttonPlot;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Button buttonAbout;
    }
}

