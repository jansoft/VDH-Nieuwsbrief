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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbMaxPosts = new System.Windows.Forms.TextBox();
            this.DocPathValue = new System.Windows.Forms.Label();
            this.DateFromPicker = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbpaper = new System.Windows.Forms.RadioButton();
            this.rbdigital = new System.Windows.Forms.RadioButton();
            this.cbAgenda = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dpAgendaTot = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dpAgendaVanaf = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(30, 229);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 23);
            this.button1.TabIndex = 28;
            this.button1.Text = "Rapport genereren";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.GenerateHtml);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Nieuwsbrief vanaf";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Maximum aantal (optioneel, standaard is 15)";
            // 
            // tbMaxPosts
            // 
            this.tbMaxPosts.Location = new System.Drawing.Point(30, 103);
            this.tbMaxPosts.Name = "tbMaxPosts";
            this.tbMaxPosts.Size = new System.Drawing.Size(100, 20);
            this.tbMaxPosts.TabIndex = 24;
            // 
            // DocPathValue
            // 
            this.DocPathValue.AutoSize = true;
            this.DocPathValue.Location = new System.Drawing.Point(30, 259);
            this.DocPathValue.Name = "DocPathValue";
            this.DocPathValue.Size = new System.Drawing.Size(42, 13);
            this.DocPathValue.TabIndex = 29;
            this.DocPathValue.Text = "Locatie";
            // 
            // DateFromPicker
            // 
            this.DateFromPicker.Location = new System.Drawing.Point(30, 51);
            this.DateFromPicker.Name = "DateFromPicker";
            this.DateFromPicker.Size = new System.Drawing.Size(200, 20);
            this.DateFromPicker.TabIndex = 30;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbpaper);
            this.groupBox1.Controls.Add(this.rbdigital);
            this.groupBox1.Location = new System.Drawing.Point(30, 139);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(378, 66);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Genereer voor";
            // 
            // rbpaper
            // 
            this.rbpaper.AutoSize = true;
            this.rbpaper.Location = new System.Drawing.Point(139, 29);
            this.rbpaper.Name = "rbpaper";
            this.rbpaper.Size = new System.Drawing.Size(122, 17);
            this.rbpaper.TabIndex = 1;
            this.rbpaper.Text = "papieren nieuwsbrief";
            this.rbpaper.UseVisualStyleBackColor = true;
            // 
            // rbdigital
            // 
            this.rbdigital.AutoSize = true;
            this.rbdigital.Checked = true;
            this.rbdigital.Location = new System.Drawing.Point(19, 29);
            this.rbdigital.Name = "rbdigital";
            this.rbdigital.Size = new System.Drawing.Size(114, 17);
            this.rbdigital.TabIndex = 0;
            this.rbdigital.TabStop = true;
            this.rbdigital.Text = "digitale nieuwsbrief";
            this.rbdigital.UseVisualStyleBackColor = true;
            // 
            // cbAgenda
            // 
            this.cbAgenda.AutoSize = true;
            this.cbAgenda.Location = new System.Drawing.Point(264, 103);
            this.cbAgenda.Name = "cbAgenda";
            this.cbAgenda.Size = new System.Drawing.Size(110, 17);
            this.cbAgenda.TabIndex = 33;
            this.cbAgenda.Text = "Agenda opnemen";
            this.cbAgenda.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(468, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Agenda tot";
            // 
            // dpAgendaTot
            // 
            this.dpAgendaTot.Location = new System.Drawing.Point(471, 51);
            this.dpAgendaTot.Name = "dpAgendaTot";
            this.dpAgendaTot.Size = new System.Drawing.Size(200, 20);
            this.dpAgendaTot.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(244, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Agenda vanaf";
            // 
            // dpAgendaVanaf
            // 
            this.dpAgendaVanaf.Location = new System.Drawing.Point(247, 51);
            this.dpAgendaVanaf.Name = "dpAgendaVanaf";
            this.dpAgendaVanaf.Size = new System.Drawing.Size(200, 20);
            this.dpAgendaVanaf.TabIndex = 37;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 314);
            this.Controls.Add(this.dpAgendaVanaf);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dpAgendaTot);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbAgenda);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DateFromPicker);
            this.Controls.Add(this.DocPathValue);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbMaxPosts);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Van Dam Huis nieuwsbrief generator ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbMaxPosts;
        private System.Windows.Forms.Label DocPathValue;
        private System.Windows.Forms.DateTimePicker DateFromPicker;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbpaper;
        private System.Windows.Forms.RadioButton rbdigital;
        private System.Windows.Forms.CheckBox cbAgenda;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dpAgendaTot;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dpAgendaVanaf;
    }
}

