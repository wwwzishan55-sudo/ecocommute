namespace EcoCommuteTracker
{
    partial class LogCommuteForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDistance = new System.Windows.Forms.TextBox();
            this.cmbTransportMode = new System.Windows.Forms.ComboBox();
            this.btnSaveCommute = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(92, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Transport Mode :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(92, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Distance in KM :";
            // 
            // txtDistance
            // 
            this.txtDistance.Location = new System.Drawing.Point(302, 193);
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.Size = new System.Drawing.Size(149, 22);
            this.txtDistance.TabIndex = 2;
            // 
            // cmbTransportMode
            // 
            this.cmbTransportMode.FormattingEnabled = true;
            this.cmbTransportMode.Items.AddRange(new object[] {
            "Walking",
            "Bicycle",
            "Bus",
            "Train"});
            this.cmbTransportMode.Location = new System.Drawing.Point(302, 125);
            this.cmbTransportMode.Name = "cmbTransportMode";
            this.cmbTransportMode.Size = new System.Drawing.Size(149, 24);
            this.cmbTransportMode.TabIndex = 3;
            // 
            // btnSaveCommute
            // 
            this.btnSaveCommute.Location = new System.Drawing.Point(283, 283);
            this.btnSaveCommute.Name = "btnSaveCommute";
            this.btnSaveCommute.Size = new System.Drawing.Size(188, 34);
            this.btnSaveCommute.TabIndex = 4;
            this.btnSaveCommute.Text = "Save Commute";
            this.btnSaveCommute.UseVisualStyleBackColor = true;
            this.btnSaveCommute.Click += new System.EventHandler(this.btnSaveCommute_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(103, 283);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(125, 38);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(506, 100);
            this.panel1.TabIndex = 6;
            // 
            // LogCommuteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(506, 417);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnSaveCommute);
            this.Controls.Add(this.cmbTransportMode);
            this.Controls.Add(this.txtDistance);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "LogCommuteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LogCommuteForm";
            this.Load += new System.EventHandler(this.LogCommuteForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDistance;
        private System.Windows.Forms.ComboBox cmbTransportMode;
        private System.Windows.Forms.Button btnSaveCommute;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel panel1;
    }
}