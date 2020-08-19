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
            this.label4 = new System.Windows.Forms.Label();
            this.LocationLabel = new System.Windows.Forms.Label();
            this.btOpenLocation = new System.Windows.Forms.Button();
            this.cbPrivate = new System.Windows.Forms.CheckBox();
            this.cbPublic = new System.Windows.Forms.CheckBox();
            this.udMaxEvents = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.cbAllEvents = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.udMaxEvents)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btGenerateReport
            // 
            this.btGenerateReport.Location = new System.Drawing.Point(22, 150);
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
            this.label1.Location = new System.Drawing.Point(9, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Van";
            // 
            // dpFrom
            // 
            this.dpFrom.Location = new System.Drawing.Point(41, 19);
            this.dpFrom.Name = "dpFrom";
            this.dpFrom.Size = new System.Drawing.Size(200, 20);
            this.dpFrom.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tot";
            // 
            // dpUntil
            // 
            this.dpUntil.Location = new System.Drawing.Point(41, 63);
            this.dpUntil.Name = "dpUntil";
            this.dpUntil.Size = new System.Drawing.Size(200, 20);
            this.dpUntil.TabIndex = 4;
            // 
            // cbShowBackground
            // 
            this.cbShowBackground.AutoSize = true;
            this.cbShowBackground.Location = new System.Drawing.Point(10, 21);
            this.cbShowBackground.Name = "cbShowBackground";
            this.cbShowBackground.Size = new System.Drawing.Size(161, 17);
            this.cbShowBackground.TabIndex = 5;
            this.cbShowBackground.Text = "Achtergrond tonen in rapport";
            this.cbShowBackground.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Locatie";
            // 
            // LocationLabel
            // 
            this.LocationLabel.AutoSize = true;
            this.LocationLabel.Location = new System.Drawing.Point(68, 192);
            this.LocationLabel.Name = "LocationLabel";
            this.LocationLabel.Size = new System.Drawing.Size(59, 13);
            this.LocationLabel.TabIndex = 8;
            this.LocationLabel.Text = "Onbepaald";
            // 
            // btOpenLocation
            // 
            this.btOpenLocation.Location = new System.Drawing.Point(22, 220);
            this.btOpenLocation.Name = "btOpenLocation";
            this.btOpenLocation.Size = new System.Drawing.Size(75, 23);
            this.btOpenLocation.TabIndex = 9;
            this.btOpenLocation.Text = "Open locatie";
            this.btOpenLocation.UseVisualStyleBackColor = true;
            this.btOpenLocation.Click += new System.EventHandler(this.btOpenLocation_Click);
            // 
            // cbPrivate
            // 
            this.cbPrivate.AutoSize = true;
            this.cbPrivate.Location = new System.Drawing.Point(10, 45);
            this.cbPrivate.Name = "cbPrivate";
            this.cbPrivate.Size = new System.Drawing.Size(165, 17);
            this.cbPrivate.TabIndex = 10;
            this.cbPrivate.Text = "Privé evenementen opnemen";
            this.cbPrivate.UseVisualStyleBackColor = true;
            // 
            // cbPublic
            // 
            this.cbPublic.AutoSize = true;
            this.cbPublic.Checked = true;
            this.cbPublic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPublic.Location = new System.Drawing.Point(10, 67);
            this.cbPublic.Name = "cbPublic";
            this.cbPublic.Size = new System.Drawing.Size(188, 17);
            this.cbPublic.TabIndex = 13;
            this.cbPublic.Text = "Openbare evenementen opnemen";
            this.cbPublic.UseVisualStyleBackColor = true;
            // 
            // udMaxEvents
            // 
            this.udMaxEvents.Location = new System.Drawing.Point(63, 23);
            this.udMaxEvents.Name = "udMaxEvents";
            this.udMaxEvents.Size = new System.Drawing.Size(70, 20);
            this.udMaxEvents.TabIndex = 14;
            this.udMaxEvents.Value = new decimal(new int[] {
            13,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Maximum";
            // 
            // cbAllEvents
            // 
            this.cbAllEvents.AutoSize = true;
            this.cbAllEvents.Location = new System.Drawing.Point(9, 45);
            this.cbAllEvents.Name = "cbAllEvents";
            this.cbAllEvents.Size = new System.Drawing.Size(48, 17);
            this.cbAllEvents.TabIndex = 16;
            this.cbAllEvents.Text = "Alles";
            this.cbAllEvents.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbAllEvents);
            this.groupBox1.Controls.Add(this.udMaxEvents);
            this.groupBox1.Location = new System.Drawing.Point(506, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(153, 98);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Aantal evenementen";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbShowBackground);
            this.groupBox2.Controls.Add(this.cbPrivate);
            this.groupBox2.Controls.Add(this.cbPublic);
            this.groupBox2.Location = new System.Drawing.Point(287, 30);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(213, 98);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Opties";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dpFrom);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.dpUntil);
            this.groupBox3.Location = new System.Drawing.Point(22, 30);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(259, 98);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Periode";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 301);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btOpenLocation);
            this.Controls.Add(this.LocationLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btGenerateReport);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Van Dam Huis Agenda Reporter";
            ((System.ComponentModel.ISupportInitialize)(this.udMaxEvents)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LocationLabel;
        private System.Windows.Forms.Button btOpenLocation;
        private System.Windows.Forms.CheckBox cbPrivate;
        private System.Windows.Forms.CheckBox cbPublic;
        private System.Windows.Forms.NumericUpDown udMaxEvents;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbAllEvents;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

