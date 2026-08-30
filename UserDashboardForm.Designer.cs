namespace EcoCommuteTracker
{
    partial class UserDashboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnLogCommute = new System.Windows.Forms.Button();
            this.btnLeaderboard = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnHistory = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTotalSavings = new System.Windows.Forms.Label();
            this.chartSavings = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblChartTitle = new System.Windows.Forms.Label();
            this.lblEcoEquivalents = new System.Windows.Forms.Label();
            this.lblTreesEquivalent = new System.Windows.Forms.Label();
            this.lblFuelEquivalent = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSavings)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.BackColor = System.Drawing.Color.LightSteelBlue;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(167, 9);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(121, 31);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome!";
            // 
            // btnLogCommute
            // 
            this.btnLogCommute.Location = new System.Drawing.Point(30, 127);
            this.btnLogCommute.Name = "btnLogCommute";
            this.btnLogCommute.Size = new System.Drawing.Size(190, 37);
            this.btnLogCommute.TabIndex = 2;
            this.btnLogCommute.Text = "Log Daily Commute";
            this.btnLogCommute.UseVisualStyleBackColor = true;
            this.btnLogCommute.Click += new System.EventHandler(this.btnLogCommute_Click);
            // 
            // btnLeaderboard
            // 
            this.btnLeaderboard.Location = new System.Drawing.Point(30, 193);
            this.btnLeaderboard.Name = "btnLeaderboard";
            this.btnLeaderboard.Size = new System.Drawing.Size(190, 37);
            this.btnLeaderboard.TabIndex = 3;
            this.btnLeaderboard.Text = "Leaderboard";
            this.btnLeaderboard.UseVisualStyleBackColor = true;
            this.btnLeaderboard.Click += new System.EventHandler(this.btnLeaderboard_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(30, 331);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(190, 37);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnHistory
            // 
            this.btnHistory.Location = new System.Drawing.Point(30, 253);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(190, 37);
            this.btnHistory.TabIndex = 5;
            this.btnHistory.Text = "View History";
            this.btnHistory.UseVisualStyleBackColor = true;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.lblTotalSavings);
            this.panel1.Controls.Add(this.lblWelcome);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(820, 100);
            this.panel1.TabIndex = 6;
            // 
            // lblTotalSavings
            // 
            this.lblTotalSavings.AutoSize = true;
            this.lblTotalSavings.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSavings.Location = new System.Drawing.Point(150, 60);
            this.lblTotalSavings.Name = "lblTotalSavings";
            this.lblTotalSavings.Size = new System.Drawing.Size(166, 31);
            this.lblTotalSavings.TabIndex = 1;
            this.lblTotalSavings.Text = "Saved : 0.0 kg ";
            // 
            // lblChartTitle
            // 
            this.lblChartTitle.AutoSize = true;
            this.lblChartTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChartTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.lblChartTitle.Location = new System.Drawing.Point(246, 118);
            this.lblChartTitle.Name = "lblChartTitle";
            this.lblChartTitle.Size = new System.Drawing.Size(220, 20);
            this.lblChartTitle.TabIndex = 7;
            this.lblChartTitle.Text = "CO2 Saved by Transport Mode";
            // 
            // chartSavings
            // 
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisY.Title = "kg CO2 Saved";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Segoe UI", 8.5F);
            chartArea1.BackColor = System.Drawing.Color.White;
            chartArea1.Name = "ChartArea1";
            this.chartSavings.ChartAreas.Add(chartArea1);
            this.chartSavings.BackColor = System.Drawing.Color.White;
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chartSavings.Legends.Add(legend1);
            this.chartSavings.Location = new System.Drawing.Point(246, 141);
            this.chartSavings.Name = "chartSavings";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            series1.IsValueShownAsLabel = true;
            series1.LabelFormat = "0.0";
            series1.Legend = "Legend1";
            series1.Name = "CO2Series";
            this.chartSavings.Series.Add(series1);
            this.chartSavings.Size = new System.Drawing.Size(544, 232);
            this.chartSavings.TabIndex = 8;
            this.chartSavings.Text = "chartSavings";
            // 
            // lblEcoEquivalents
            // 
            this.lblEcoEquivalents.AutoSize = true;
            this.lblEcoEquivalents.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEcoEquivalents.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.lblEcoEquivalents.Location = new System.Drawing.Point(246, 386);
            this.lblEcoEquivalents.Name = "lblEcoEquivalents";
            this.lblEcoEquivalents.Size = new System.Drawing.Size(140, 20);
            this.lblEcoEquivalents.TabIndex = 9;
            this.lblEcoEquivalents.Text = "What that means:";
            // 
            // lblTreesEquivalent
            // 
            this.lblTreesEquivalent.AutoSize = true;
            this.lblTreesEquivalent.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTreesEquivalent.Location = new System.Drawing.Point(248, 414);
            this.lblTreesEquivalent.Name = "lblTreesEquivalent";
            this.lblTreesEquivalent.Size = new System.Drawing.Size(220, 19);
            this.lblTreesEquivalent.TabIndex = 10;
            this.lblTreesEquivalent.Text = "🌳 Equivalent to 0.0 tree-years";
            // 
            // lblFuelEquivalent
            // 
            this.lblFuelEquivalent.AutoSize = true;
            this.lblFuelEquivalent.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFuelEquivalent.Location = new System.Drawing.Point(248, 442);
            this.lblFuelEquivalent.Name = "lblFuelEquivalent";
            this.lblFuelEquivalent.Size = new System.Drawing.Size(220, 19);
            this.lblFuelEquivalent.TabIndex = 11;
            this.lblFuelEquivalent.Text = "⛽ Equivalent to 0.0 L of gasoline";
            // 
            // UserDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(820, 500);
            this.Controls.Add(this.lblFuelEquivalent);
            this.Controls.Add(this.lblTreesEquivalent);
            this.Controls.Add(this.lblEcoEquivalents);
            this.Controls.Add(this.chartSavings);
            this.Controls.Add(this.lblChartTitle);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnHistory);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnLeaderboard);
            this.Controls.Add(this.btnLogCommute);
            this.MinimumSize = new System.Drawing.Size(750, 500);
            this.Name = "UserDashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserDashboardForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSavings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnLogCommute;
        private System.Windows.Forms.Button btnLeaderboard;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTotalSavings;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSavings;
        private System.Windows.Forms.Label lblChartTitle;
        private System.Windows.Forms.Label lblEcoEquivalents;
        private System.Windows.Forms.Label lblTreesEquivalent;
        private System.Windows.Forms.Label lblFuelEquivalent;
    }
}
