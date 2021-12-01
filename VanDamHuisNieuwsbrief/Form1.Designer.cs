namespace VanDamHuisNieuwsbriefGenerator
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
            this.btnGenerate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DocPathValue = new System.Windows.Forms.Label();
            this.DateFromPicker = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbpaper = new System.Windows.Forms.RadioButton();
            this.rbdigital = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.dpAgendaTot = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dpAgendaVanaf = new System.Windows.Forms.DateTimePicker();
            this.MaxPosts = new System.Windows.Forms.NumericUpDown();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.dpPublicatieDatum = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.ToonSamenvattingActiviteit = new System.Windows.Forms.CheckBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.Preview = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Edition = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DocSizeLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.HideCanceledEvents = new System.Windows.Forms.CheckBox();
            this.ExterneMedia = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Thema = new System.Windows.Forms.TextBox();
            this.Uitklapbaar = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxPosts)).BeginInit();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(6, 19);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(105, 23);
            this.btnGenerate.TabIndex = 28;
            this.btnGenerate.Text = "&Genereren";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.GenerateHtml);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Vanaf";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Max berichten per organisatie";
            // 
            // DocPathValue
            // 
            this.DocPathValue.AutoSize = true;
            this.DocPathValue.Location = new System.Drawing.Point(6, 49);
            this.DocPathValue.Name = "DocPathValue";
            this.DocPathValue.Size = new System.Drawing.Size(42, 13);
            this.DocPathValue.TabIndex = 29;
            this.DocPathValue.Text = "Locatie";
            // 
            // DateFromPicker
            // 
            this.DateFromPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateFromPicker.Location = new System.Drawing.Point(9, 42);
            this.DateFromPicker.Name = "DateFromPicker";
            this.DateFromPicker.Size = new System.Drawing.Size(102, 20);
            this.DateFromPicker.TabIndex = 30;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbpaper);
            this.groupBox1.Controls.Add(this.rbdigital);
            this.groupBox1.Location = new System.Drawing.Point(349, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(195, 58);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nieuwsbrief media";
            // 
            // rbpaper
            // 
            this.rbpaper.AutoSize = true;
            this.rbpaper.Location = new System.Drawing.Point(97, 25);
            this.rbpaper.Name = "rbpaper";
            this.rbpaper.Size = new System.Drawing.Size(54, 17);
            this.rbpaper.TabIndex = 1;
            this.rbpaper.Text = "papier";
            this.rbpaper.UseVisualStyleBackColor = true;
            // 
            // rbdigital
            // 
            this.rbdigital.AutoSize = true;
            this.rbdigital.Checked = true;
            this.rbdigital.Location = new System.Drawing.Point(19, 25);
            this.rbdigital.Name = "rbdigital";
            this.rbdigital.Size = new System.Drawing.Size(58, 17);
            this.rbdigital.TabIndex = 0;
            this.rbdigital.TabStop = true;
            this.rbdigital.Text = "digitaal";
            this.rbdigital.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Tot";
            // 
            // dpAgendaTot
            // 
            this.dpAgendaTot.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpAgendaTot.Location = new System.Drawing.Point(11, 93);
            this.dpAgendaTot.Name = "dpAgendaTot";
            this.dpAgendaTot.Size = new System.Drawing.Size(101, 20);
            this.dpAgendaTot.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Vanaf";
            // 
            // dpAgendaVanaf
            // 
            this.dpAgendaVanaf.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpAgendaVanaf.Location = new System.Drawing.Point(11, 42);
            this.dpAgendaVanaf.Name = "dpAgendaVanaf";
            this.dpAgendaVanaf.Size = new System.Drawing.Size(101, 20);
            this.dpAgendaVanaf.TabIndex = 37;
            // 
            // MaxPosts
            // 
            this.MaxPosts.Location = new System.Drawing.Point(9, 93);
            this.MaxPosts.Name = "MaxPosts";
            this.MaxPosts.Size = new System.Drawing.Size(72, 20);
            this.MaxPosts.TabIndex = 43;
            this.MaxPosts.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.dpPublicatieDatum);
            this.groupBox8.Controls.Add(this.label7);
            this.groupBox8.Controls.Add(this.label1);
            this.groupBox8.Controls.Add(this.label2);
            this.groupBox8.Controls.Add(this.DateFromPicker);
            this.groupBox8.Controls.Add(this.MaxPosts);
            this.groupBox8.Location = new System.Drawing.Point(30, 23);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(171, 182);
            this.groupBox8.TabIndex = 47;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Nieuwsbrief";
            // 
            // dpPublicatieDatum
            // 
            this.dpPublicatieDatum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpPublicatieDatum.Location = new System.Drawing.Point(9, 143);
            this.dpPublicatieDatum.Name = "dpPublicatieDatum";
            this.dpPublicatieDatum.Size = new System.Drawing.Size(102, 20);
            this.dpPublicatieDatum.TabIndex = 47;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 46;
            this.label7.Text = "Publicatiedatum";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.ToonSamenvattingActiviteit);
            this.groupBox9.Controls.Add(this.label4);
            this.groupBox9.Controls.Add(this.label3);
            this.groupBox9.Controls.Add(this.dpAgendaTot);
            this.groupBox9.Controls.Add(this.dpAgendaVanaf);
            this.groupBox9.Location = new System.Drawing.Point(207, 23);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(136, 182);
            this.groupBox9.TabIndex = 48;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Agenda";
            // 
            // ToonSamenvattingActiviteit
            // 
            this.ToonSamenvattingActiviteit.AutoSize = true;
            this.ToonSamenvattingActiviteit.Location = new System.Drawing.Point(11, 127);
            this.ToonSamenvattingActiviteit.Name = "ToonSamenvattingActiviteit";
            this.ToonSamenvattingActiviteit.Size = new System.Drawing.Size(117, 17);
            this.ToonSamenvattingActiviteit.TabIndex = 38;
            this.ToonSamenvattingActiviteit.Text = "Toon samenvatting";
            this.ToonSamenvattingActiviteit.UseVisualStyleBackColor = true;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.Preview);
            this.groupBox10.Controls.Add(this.label6);
            this.groupBox10.Controls.Add(this.Edition);
            this.groupBox10.Controls.Add(this.label5);
            this.groupBox10.Controls.Add(this.DocSizeLabel);
            this.groupBox10.Controls.Add(this.btnGenerate);
            this.groupBox10.Controls.Add(this.DocPathValue);
            this.groupBox10.Location = new System.Drawing.Point(30, 310);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(514, 106);
            this.groupBox10.TabIndex = 49;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Rapport";
            // 
            // Preview
            // 
            this.Preview.Location = new System.Drawing.Point(415, 21);
            this.Preview.Name = "Preview";
            this.Preview.Size = new System.Drawing.Size(89, 20);
            this.Preview.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(363, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Preview";
            // 
            // Edition
            // 
            this.Edition.Location = new System.Drawing.Point(156, 21);
            this.Edition.Name = "Edition";
            this.Edition.Size = new System.Drawing.Size(200, 20);
            this.Edition.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(117, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Editie";
            // 
            // DocSizeLabel
            // 
            this.DocSizeLabel.AutoSize = true;
            this.DocSizeLabel.Location = new System.Drawing.Point(6, 75);
            this.DocSizeLabel.Name = "DocSizeLabel";
            this.DocSizeLabel.Size = new System.Drawing.Size(42, 13);
            this.DocSizeLabel.TabIndex = 30;
            this.DocSizeLabel.Text = "Grootte";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Uitklapbaar);
            this.groupBox2.Controls.Add(this.HideCanceledEvents);
            this.groupBox2.Controls.Add(this.ExterneMedia);
            this.groupBox2.Location = new System.Drawing.Point(350, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(194, 117);
            this.groupBox2.TabIndex = 50;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Opties";
            // 
            // HideCanceledEvents
            // 
            this.HideCanceledEvents.AutoSize = true;
            this.HideCanceledEvents.Checked = true;
            this.HideCanceledEvents.CheckState = System.Windows.Forms.CheckState.Checked;
            this.HideCanceledEvents.Location = new System.Drawing.Point(7, 52);
            this.HideCanceledEvents.Name = "HideCanceledEvents";
            this.HideCanceledEvents.Size = new System.Drawing.Size(177, 17);
            this.HideCanceledEvents.TabIndex = 1;
            this.HideCanceledEvents.Text = "Verberg afgelaste evenementen";
            this.HideCanceledEvents.UseVisualStyleBackColor = true;
            // 
            // ExterneMedia
            // 
            this.ExterneMedia.AutoSize = true;
            this.ExterneMedia.Location = new System.Drawing.Point(7, 28);
            this.ExterneMedia.Name = "ExterneMedia";
            this.ExterneMedia.Size = new System.Drawing.Size(117, 17);
            this.ExterneMedia.TabIndex = 0;
            this.ExterneMedia.Text = "Voor externe media";
            this.ExterneMedia.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Thema);
            this.groupBox3.Location = new System.Drawing.Point(30, 212);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(514, 92);
            this.groupBox3.TabIndex = 51;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thema";
            // 
            // Thema
            // 
            this.Thema.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Thema.Location = new System.Drawing.Point(3, 16);
            this.Thema.Multiline = true;
            this.Thema.Name = "Thema";
            this.Thema.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Thema.Size = new System.Drawing.Size(508, 73);
            this.Thema.TabIndex = 0;
            // 
            // Uitklapbaar
            // 
            this.Uitklapbaar.AutoSize = true;
            this.Uitklapbaar.Location = new System.Drawing.Point(7, 76);
            this.Uitklapbaar.Name = "Uitklapbaar";
            this.Uitklapbaar.Size = new System.Drawing.Size(80, 17);
            this.Uitklapbaar.TabIndex = 2;
            this.Uitklapbaar.Text = "Uitklapbaar";
            this.Uitklapbaar.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 455);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Van Dam Huis nieuwsbrief generator ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxPosts)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label DocPathValue;
        private System.Windows.Forms.DateTimePicker DateFromPicker;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbpaper;
        private System.Windows.Forms.RadioButton rbdigital;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dpAgendaTot;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dpAgendaVanaf;
        private System.Windows.Forms.NumericUpDown MaxPosts;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.DateTimePicker dpPublicatieDatum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label DocSizeLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox ExterneMedia;
        private System.Windows.Forms.CheckBox HideCanceledEvents;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox Thema;
        private System.Windows.Forms.CheckBox ToonSamenvattingActiviteit;
        private System.Windows.Forms.TextBox Preview;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Edition;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox Uitklapbaar;
    }
}

