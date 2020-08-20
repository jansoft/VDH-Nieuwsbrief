﻿namespace VanDamHuisNieuwsbriefGenerator
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
            this.cbIncludeLogos = new System.Windows.Forms.CheckBox();
            this.cbIncludeNewsSummary = new System.Windows.Forms.CheckBox();
            this.cbIncludeNewsContent = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbAchteraan = new System.Windows.Forms.RadioButton();
            this.rbAgendaVooraan = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rb12pt = new System.Windows.Forms.RadioButton();
            this.rb10pt = new System.Windows.Forms.RadioButton();
            this.MaxPosts = new System.Windows.Forms.NumericUpDown();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.udLogoHeight = new System.Windows.Forms.NumericUpDown();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rbLogoNaKop = new System.Windows.Forms.RadioButton();
            this.rbLogoVoorKop = new System.Windows.Forms.RadioButton();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.cbEeventTitleBold = new System.Windows.Forms.CheckBox();
            this.cbNewsTitleBold = new System.Windows.Forms.CheckBox();
            this.cbOrganizationTitleBold = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxPosts)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udLogoHeight)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
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
            this.groupBox1.Location = new System.Drawing.Point(467, 139);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(112, 79);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nieuwsbrief media";
            // 
            // rbpaper
            // 
            this.rbpaper.AutoSize = true;
            this.rbpaper.Location = new System.Drawing.Point(19, 48);
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
            this.groupBox2.Controls.Add(this.cbIncludeLogos);
            this.groupBox2.Controls.Add(this.cbIncludeNewsSummary);
            this.groupBox2.Controls.Add(this.cbIncludeNewsContent);
            this.groupBox2.Controls.Add(this.cbAgenda);
            this.groupBox2.Controls.Add(this.cbPaperLinks);
            this.groupBox2.Controls.Add(this.cbNewsPubdate);
            this.groupBox2.Location = new System.Drawing.Point(30, 139);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(210, 181);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Inhoud";
            // 
            // cbIncludeLogos
            // 
            this.cbIncludeLogos.AutoSize = true;
            this.cbIncludeLogos.Checked = true;
            this.cbIncludeLogos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIncludeLogos.Location = new System.Drawing.Point(7, 143);
            this.cbIncludeLogos.Name = "cbIncludeLogos";
            this.cbIncludeLogos.Size = new System.Drawing.Size(104, 17);
            this.cbIncludeLogos.TabIndex = 42;
            this.cbIncludeLogos.Text = "Logo\'s opnemen";
            this.cbIncludeLogos.UseVisualStyleBackColor = true;
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbAchteraan);
            this.groupBox3.Controls.Add(this.rbAgendaVooraan);
            this.groupBox3.Location = new System.Drawing.Point(351, 139);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(110, 79);
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
            this.groupBox4.Size = new System.Drawing.Size(98, 79);
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
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.udLogoHeight);
            this.groupBox5.Location = new System.Drawing.Point(247, 224);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(98, 96);
            this.groupBox5.TabIndex = 44;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Logo hoogte";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(68, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "px";
            // 
            // udLogoHeight
            // 
            this.udLogoHeight.Location = new System.Drawing.Point(16, 20);
            this.udLogoHeight.Name = "udLogoHeight";
            this.udLogoHeight.Size = new System.Drawing.Size(46, 20);
            this.udLogoHeight.TabIndex = 0;
            this.udLogoHeight.Value = new decimal(new int[] {
            75,
            0,
            0,
            0});
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rbLogoNaKop);
            this.groupBox6.Controls.Add(this.rbLogoVoorKop);
            this.groupBox6.Location = new System.Drawing.Point(351, 224);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(110, 96);
            this.groupBox6.TabIndex = 45;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Logo positie";
            // 
            // rbLogoNaKop
            // 
            this.rbLogoNaKop.AutoSize = true;
            this.rbLogoNaKop.Checked = true;
            this.rbLogoNaKop.Location = new System.Drawing.Point(18, 41);
            this.rbLogoNaKop.Name = "rbLogoNaKop";
            this.rbLogoNaKop.Size = new System.Drawing.Size(60, 17);
            this.rbLogoNaKop.TabIndex = 1;
            this.rbLogoNaKop.TabStop = true;
            this.rbLogoNaKop.Text = "Na kop";
            this.rbLogoNaKop.UseVisualStyleBackColor = true;
            // 
            // rbLogoVoorKop
            // 
            this.rbLogoVoorKop.AutoSize = true;
            this.rbLogoVoorKop.Location = new System.Drawing.Point(18, 18);
            this.rbLogoVoorKop.Name = "rbLogoVoorKop";
            this.rbLogoVoorKop.Size = new System.Drawing.Size(68, 17);
            this.rbLogoVoorKop.TabIndex = 0;
            this.rbLogoVoorKop.Text = "Voor kop";
            this.rbLogoVoorKop.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.cbOrganizationTitleBold);
            this.groupBox7.Controls.Add(this.cbNewsTitleBold);
            this.groupBox7.Controls.Add(this.cbEeventTitleBold);
            this.groupBox7.Location = new System.Drawing.Point(471, 224);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(108, 96);
            this.groupBox7.TabIndex = 46;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Titels vet maken";
            // 
            // cbEeventTitleBold
            // 
            this.cbEeventTitleBold.AutoSize = true;
            this.cbEeventTitleBold.Location = new System.Drawing.Point(15, 17);
            this.cbEeventTitleBold.Name = "cbEeventTitleBold";
            this.cbEeventTitleBold.Size = new System.Drawing.Size(80, 17);
            this.cbEeventTitleBold.TabIndex = 0;
            this.cbEeventTitleBold.Text = "Evenement";
            this.cbEeventTitleBold.UseVisualStyleBackColor = true;
            // 
            // cbNewsTitleBold
            // 
            this.cbNewsTitleBold.AutoSize = true;
            this.cbNewsTitleBold.Location = new System.Drawing.Point(15, 41);
            this.cbNewsTitleBold.Name = "cbNewsTitleBold";
            this.cbNewsTitleBold.Size = new System.Drawing.Size(61, 17);
            this.cbNewsTitleBold.TabIndex = 1;
            this.cbNewsTitleBold.Text = "Nieuws";
            this.cbNewsTitleBold.UseVisualStyleBackColor = true;
            // 
            // cbOrganizationTitleBold
            // 
            this.cbOrganizationTitleBold.AutoSize = true;
            this.cbOrganizationTitleBold.Location = new System.Drawing.Point(15, 65);
            this.cbOrganizationTitleBold.Name = "cbOrganizationTitleBold";
            this.cbOrganizationTitleBold.Size = new System.Drawing.Size(79, 17);
            this.cbOrganizationTitleBold.TabIndex = 2;
            this.cbOrganizationTitleBold.Text = "Organisatie";
            this.cbOrganizationTitleBold.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 418);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
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
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udLogoHeight)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
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
        private System.Windows.Forms.CheckBox cbIncludeLogos;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown udLogoHeight;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton rbLogoNaKop;
        private System.Windows.Forms.RadioButton rbLogoVoorKop;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.CheckBox cbOrganizationTitleBold;
        private System.Windows.Forms.CheckBox cbNewsTitleBold;
        private System.Windows.Forms.CheckBox cbEeventTitleBold;
    }
}

