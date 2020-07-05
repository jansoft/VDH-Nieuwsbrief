namespace VanDamHuisAgendaReporter
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btGenerateReport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dpFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dpUntil = new System.Windows.Forms.DateTimePicker();
            this.cbShowBackground = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LocationLabel = new System.Windows.Forms.Label();
            this.btOpenLocation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btGenerateReport
            // 
            this.btGenerateReport.Location = new System.Drawing.Point(120, 153);
            this.btGenerateReport.Name = "btGenerateReport";
            this.btGenerateReport.Size = new System.Drawing.Size(116, 23);
            this.btGenerateReport.TabIndex = 0;
            this.btGenerateReport.Text = "Maak Agenda";
            this.btGenerateReport.UseVisualStyleBackColor = true;
            this.btGenerateReport.Click += new System.EventHandler(this.btGenerateReport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Van";
            // 
            // dpFrom
            // 
            this.dpFrom.Location = new System.Drawing.Point(120, 26);
            this.dpFrom.Name = "dpFrom";
            this.dpFrom.Size = new System.Drawing.Size(200, 20);
            this.dpFrom.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tot";
            // 
            // dpUntil
            // 
            this.dpUntil.Location = new System.Drawing.Point(120, 70);
            this.dpUntil.Name = "dpUntil";
            this.dpUntil.Size = new System.Drawing.Size(200, 20);
            this.dpUntil.TabIndex = 4;
            // 
            // cbShowBackground
            // 
            this.cbShowBackground.AutoSize = true;
            this.cbShowBackground.Location = new System.Drawing.Point(120, 110);
            this.cbShowBackground.Name = "cbShowBackground";
            this.cbShowBackground.Size = new System.Drawing.Size(57, 17);
            this.cbShowBackground.TabIndex = 5;
            this.cbShowBackground.Text = "Tonen";
            this.cbShowBackground.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Achtergrond";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(69, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Locatie";
            // 
            // LocationLabel
            // 
            this.LocationLabel.AutoSize = true;
            this.LocationLabel.Location = new System.Drawing.Point(118, 199);
            this.LocationLabel.Name = "LocationLabel";
            this.LocationLabel.Size = new System.Drawing.Size(59, 13);
            this.LocationLabel.TabIndex = 8;
            this.LocationLabel.Text = "Onbepaald";
            // 
            // btOpenLocation
            // 
            this.btOpenLocation.Location = new System.Drawing.Point(120, 228);
            this.btOpenLocation.Name = "btOpenLocation";
            this.btOpenLocation.Size = new System.Drawing.Size(75, 23);
            this.btOpenLocation.TabIndex = 9;
            this.btOpenLocation.Text = "Open locatie";
            this.btOpenLocation.UseVisualStyleBackColor = true;
            this.btOpenLocation.Click += new System.EventHandler(this.btOpenLocation_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 315);
            this.Controls.Add(this.btOpenLocation);
            this.Controls.Add(this.LocationLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbShowBackground);
            this.Controls.Add(this.dpUntil);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dpFrom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btGenerateReport);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Van Dam Huis Agenda Reporter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btGenerateReport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dpFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dpUntil;
        private System.Windows.Forms.CheckBox cbShowBackground;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LocationLabel;
        private System.Windows.Forms.Button btOpenLocation;
    }
}

