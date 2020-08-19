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
            this.cbPaperLinks = new System.Windows.Forms.CheckBox();
            this.cbNewsPubdate = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbAchteraan = new System.Windows.Forms.RadioButton();
            this.rbAgendaVooraan = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rb12pt = new System.Windows.Forms.RadioButton();
            this.rb10pt = new System.Windows.Forms.RadioButton();
            this.MaxPosts = new System.Windows.Forms.NumericUpDown();
            this.cbIncludeNewsContent = new System.Windows.Forms.CheckBox();
            this.cbIncludeNewsSummary = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxPosts)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(30, 329);
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
            this.label2.Size = new System.Drawing.Size(202, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Maximum aantal berichten per organisatie";
            // 
            // DocPathValue
            // 
            this.DocPathValue.AutoSize = true;
            this.DocPathValue.Location = new System.Drawing.Point(30, 359);
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
            this.groupBox1.Location = new System.Drawing.Point(471, 142);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(164, 97);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Genereer voor";
            // 
            // rbpaper
            // 
            this.rbpaper.AutoSize = true;
            this.rbpaper.Location = new System.Drawing.Point(19, 48);
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
            this.rbdigital.Location = new System.Drawing.Point(19, 25);
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
            this.cbAgenda.Checked = true;
            this.cbAgenda.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAgenda.Location = new System.Drawing.Point(6, 19);
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
            // cbPaperLinks
            // 
            this.cbPaperLinks.AutoSize = true;
            this.cbPaperLinks.Location = new System.Drawing.Point(6, 119);
            this.cbPaperLinks.Name = "cbPaperLinks";
            this.cbPaperLinks.Size = new System.Drawing.Size(168, 17);
            this.cbPaperLinks.TabIndex = 38;
            this.cbPaperLinks.Text = "Links in papieren nieuwsbrief?";
            this.cbPaperLinks.UseVisualStyleBackColor = true;
            // 
            // cbNewsPubdate
            // 
            this.cbNewsPubdate.AutoSize = true;
            this.cbNewsPubdate.Location = new System.Drawing.Point(6, 44);
            this.cbNewsPubdate.Name = "cbNewsPubdate";
            this.cbNewsPubdate.Size = new System.Drawing.Size(184, 17);
            this.cbNewsPubdate.TabIndex = 39;
            this.cbNewsPubdate.Text = "Publicatiedatum nieuws opnemen";
            this.cbNewsPubdate.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbIncludeNewsSummary);
            this.groupBox2.Controls.Add(this.cbIncludeNewsContent);
            this.groupBox2.Controls.Add(this.cbAgenda);
            this.groupBox2.Controls.Add(this.cbPaperLinks);
            this.groupBox2.Controls.Add(this.cbNewsPubdate);
            this.groupBox2.Location = new System.Drawing.Point(30, 139);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(210, 143);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Inhoud";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbAchteraan);
            this.groupBox3.Controls.Add(this.rbAgendaVooraan);
            this.groupBox3.Location = new System.Drawing.Point(351, 142);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(110, 97);
            this.groupBox3.TabIndex = 41;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Agenda positie";
            // 
            // rbAchteraan
            // 
            this.rbAchteraan.AutoSize = true;
            this.rbAchteraan.Location = new System.Drawing.Point(18, 49);
            this.rbAchteraan.Name = "rbAchteraan";
            this.rbAchteraan.Size = new System.Drawing.Size(74, 17);
            this.rbAchteraan.TabIndex = 1;
            this.rbAchteraan.TabStop = true;
            this.rbAchteraan.Text = "Achteraan";
            this.rbAchteraan.UseVisualStyleBackColor = true;
            // 
            // rbAgendaVooraan
            // 
            this.rbAgendaVooraan.AutoSize = true;
            this.rbAgendaVooraan.Checked = true;
            this.rbAgendaVooraan.Location = new System.Drawing.Point(18, 25);
            this.rbAgendaVooraan.Name = "rbAgendaVooraan";
            this.rbAgendaVooraan.Size = new System.Drawing.Size(65, 17);
            this.rbAgendaVooraan.TabIndex = 0;
            this.rbAgendaVooraan.TabStop = true;
            this.rbAgendaVooraan.Text = "Vooraan";
            this.rbAgendaVooraan.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rb12pt);
            this.groupBox4.Controls.Add(this.rb10pt);
            this.groupBox4.Location = new System.Drawing.Point(247, 139);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(98, 100);
            this.groupBox4.TabIndex = 42;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Lettergrootte";
            // 
            // rb12pt
            // 
            this.rb12pt.AutoSize = true;
            this.rb12pt.Location = new System.Drawing.Point(16, 52);
            this.rb12pt.Name = "rb12pt";
            this.rb12pt.Size = new System.Drawing.Size(46, 17);
            this.rb12pt.TabIndex = 1;
            this.rb12pt.TabStop = true;
            this.rb12pt.Text = "12pt";
            this.rb12pt.UseVisualStyleBackColor = true;
            // 
            // rb10pt
            // 
            this.rb10pt.AutoSize = true;
            this.rb10pt.Checked = true;
            this.rb10pt.Location = new System.Drawing.Point(16, 28);
            this.rb10pt.Name = "rb10pt";
            this.rb10pt.Size = new System.Drawing.Size(55, 17);
            this.rb10pt.TabIndex = 0;
            this.rb10pt.TabStop = true;
            this.rb10pt.Text = "10,5pt";
            this.rb10pt.UseVisualStyleBackColor = true;
            // 
            // MaxPosts
            // 
            this.MaxPosts.Location = new System.Drawing.Point(30, 102);
            this.MaxPosts.Name = "MaxPosts";
            this.MaxPosts.Size = new System.Drawing.Size(72, 20);
            this.MaxPosts.TabIndex = 43;
            this.MaxPosts.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // cbIncludeNewsContent
            // 
            this.cbIncludeNewsContent.AutoSize = true;
            this.cbIncludeNewsContent.Checked = true;
            this.cbIncludeNewsContent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIncludeNewsContent.Location = new System.Drawing.Point(6, 69);
            this.cbIncludeNewsContent.Name = "cbIncludeNewsContent";
            this.cbIncludeNewsContent.Size = new System.Drawing.Size(142, 17);
            this.cbIncludeNewsContent.TabIndex = 40;
            this.cbIncludeNewsContent.Text = "Inhoud nieuws opnemen";
            this.cbIncludeNewsContent.UseVisualStyleBackColor = true;
            // 
            // cbIncludeNewsSummary
            // 
            this.cbIncludeNewsSummary.AutoSize = true;
            this.cbIncludeNewsSummary.Location = new System.Drawing.Point(6, 94);
            this.cbIncludeNewsSummary.Name = "cbIncludeNewsSummary";
            this.cbIncludeNewsSummary.Size = new System.Drawing.Size(174, 17);
            this.cbIncludeNewsSummary.TabIndex = 41;
            this.cbIncludeNewsSummary.Text = "Samenvatting nieuws opnemen";
            this.cbIncludeNewsSummary.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 418);
            this.Controls.Add(this.MaxPosts);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dpAgendaVanaf);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dpAgendaTot);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DateFromPicker);
            this.Controls.Add(this.DocPathValue);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Van Dam Huis nieuwsbrief generator ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxPosts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
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
        private System.Windows.Forms.CheckBox cbPaperLinks;
        private System.Windows.Forms.CheckBox cbNewsPubdate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbAchteraan;
        private System.Windows.Forms.RadioButton rbAgendaVooraan;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rb12pt;
        private System.Windows.Forms.RadioButton rb10pt;
        private System.Windows.Forms.NumericUpDown MaxPosts;
        private System.Windows.Forms.CheckBox cbIncludeNewsSummary;
        private System.Windows.Forms.CheckBox cbIncludeNewsContent;
    }
}

