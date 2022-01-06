
namespace InterfacesDidorenko
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.fileChooser = new System.Windows.Forms.OpenFileDialog();
            this.tbChosenFile = new System.Windows.Forms.TextBox();
            this.btnChooseFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbMessages = new System.Windows.Forms.ListBox();
            this.brn_More = new System.Windows.Forms.Button();
            this.btn_SkyPlot = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.rb_gga = new System.Windows.Forms.RadioButton();
            this.rb_rmc = new System.Windows.Forms.RadioButton();
            this.rb_vtg = new System.Windows.Forms.RadioButton();
            this.rb_report = new System.Windows.Forms.RadioButton();
            this.btn_stats = new System.Windows.Forms.Button();
            this.rb_stats = new System.Windows.Forms.RadioButton();
            this.rb_ETK = new System.Windows.Forms.RadioButton();
            this.lbl_Process = new System.Windows.Forms.Label();
            this.pb_import = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // tbChosenFile
            // 
            this.tbChosenFile.Location = new System.Drawing.Point(116, 6);
            this.tbChosenFile.Name = "tbChosenFile";
            this.tbChosenFile.Size = new System.Drawing.Size(215, 20);
            this.tbChosenFile.TabIndex = 0;
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.Location = new System.Drawing.Point(331, 6);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(31, 20);
            this.btnChooseFile.TabIndex = 1;
            this.btnChooseFile.Text = "...";
            this.btnChooseFile.UseVisualStyleBackColor = true;
            this.btnChooseFile.Click += new System.EventHandler(this.btnChooseFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выбранный файл:";
            // 
            // lbMessages
            // 
            this.lbMessages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbMessages.FormattingEnabled = true;
            this.lbMessages.HorizontalScrollbar = true;
            this.lbMessages.ItemHeight = 18;
            this.lbMessages.Location = new System.Drawing.Point(13, 39);
            this.lbMessages.Name = "lbMessages";
            this.lbMessages.Size = new System.Drawing.Size(349, 488);
            this.lbMessages.TabIndex = 3;
            // 
            // brn_More
            // 
            this.brn_More.Location = new System.Drawing.Point(386, 39);
            this.brn_More.Name = "brn_More";
            this.brn_More.Size = new System.Drawing.Size(274, 23);
            this.brn_More.TabIndex = 6;
            this.brn_More.Text = "Построить график...";
            this.brn_More.UseVisualStyleBackColor = true;
            this.brn_More.Click += new System.EventHandler(this.brn_More_Click);
            // 
            // btn_SkyPlot
            // 
            this.btn_SkyPlot.Location = new System.Drawing.Point(386, 69);
            this.btn_SkyPlot.Name = "btn_SkyPlot";
            this.btn_SkyPlot.Size = new System.Drawing.Size(274, 23);
            this.btn_SkyPlot.TabIndex = 7;
            this.btn_SkyPlot.Text = "Построить SkyPlot...";
            this.btn_SkyPlot.UseVisualStyleBackColor = true;
            this.btn_SkyPlot.Click += new System.EventHandler(this.btn_SkyPlot_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(386, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Протокол:";
            // 
            // rb_gga
            // 
            this.rb_gga.AutoSize = true;
            this.rb_gga.Location = new System.Drawing.Point(389, 161);
            this.rb_gga.Name = "rb_gga";
            this.rb_gga.Size = new System.Drawing.Size(48, 17);
            this.rb_gga.TabIndex = 9;
            this.rb_gga.Text = "GGA";
            this.rb_gga.UseVisualStyleBackColor = true;
            // 
            // rb_rmc
            // 
            this.rb_rmc.AutoSize = true;
            this.rb_rmc.Location = new System.Drawing.Point(389, 184);
            this.rb_rmc.Name = "rb_rmc";
            this.rb_rmc.Size = new System.Drawing.Size(49, 17);
            this.rb_rmc.TabIndex = 10;
            this.rb_rmc.Text = "RMC";
            this.rb_rmc.UseVisualStyleBackColor = true;
            // 
            // rb_vtg
            // 
            this.rb_vtg.AutoSize = true;
            this.rb_vtg.Location = new System.Drawing.Point(389, 207);
            this.rb_vtg.Name = "rb_vtg";
            this.rb_vtg.Size = new System.Drawing.Size(47, 17);
            this.rb_vtg.TabIndex = 11;
            this.rb_vtg.Text = "VTG";
            this.rb_vtg.UseVisualStyleBackColor = true;
            // 
            // rb_report
            // 
            this.rb_report.AutoSize = true;
            this.rb_report.Checked = true;
            this.rb_report.Location = new System.Drawing.Point(389, 138);
            this.rb_report.Name = "rb_report";
            this.rb_report.Size = new System.Drawing.Size(70, 17);
            this.rb_report.TabIndex = 12;
            this.rb_report.TabStop = true;
            this.rb_report.Text = "REPORT";
            this.rb_report.UseVisualStyleBackColor = true;
            // 
            // btn_stats
            // 
            this.btn_stats.Location = new System.Drawing.Point(389, 288);
            this.btn_stats.Name = "btn_stats";
            this.btn_stats.Size = new System.Drawing.Size(271, 23);
            this.btn_stats.TabIndex = 13;
            this.btn_stats.Text = "Статистика...";
            this.btn_stats.UseVisualStyleBackColor = true;
            this.btn_stats.Click += new System.EventHandler(this.btn_stats_Click);
            // 
            // rb_stats
            // 
            this.rb_stats.AutoSize = true;
            this.rb_stats.Location = new System.Drawing.Point(389, 231);
            this.rb_stats.Name = "rb_stats";
            this.rb_stats.Size = new System.Drawing.Size(83, 17);
            this.rb_stats.TabIndex = 14;
            this.rb_stats.TabStop = true;
            this.rb_stats.Text = "Статистика";
            this.rb_stats.UseVisualStyleBackColor = true;
            // 
            // rb_ETK
            // 
            this.rb_ETK.AutoSize = true;
            this.rb_ETK.Location = new System.Drawing.Point(389, 255);
            this.rb_ETK.Name = "rb_ETK";
            this.rb_ETK.Size = new System.Drawing.Size(46, 17);
            this.rb_ETK.TabIndex = 15;
            this.rb_ETK.TabStop = true;
            this.rb_ETK.Text = "ETK";
            this.rb_ETK.UseVisualStyleBackColor = true;
            // 
            // lbl_Process
            // 
            this.lbl_Process.AutoSize = true;
            this.lbl_Process.Location = new System.Drawing.Point(10, 542);
            this.lbl_Process.Name = "lbl_Process";
            this.lbl_Process.Size = new System.Drawing.Size(156, 13);
            this.lbl_Process.TabIndex = 16;
            this.lbl_Process.Text = "Добавление строк... 1000000";
            this.lbl_Process.Visible = false;
            // 
            // pb_import
            // 
            this.pb_import.Location = new System.Drawing.Point(172, 538);
            this.pb_import.Name = "pb_import";
            this.pb_import.Size = new System.Drawing.Size(190, 17);
            this.pb_import.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pb_import.TabIndex = 17;
            this.pb_import.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 564);
            this.Controls.Add(this.pb_import);
            this.Controls.Add(this.lbl_Process);
            this.Controls.Add(this.rb_ETK);
            this.Controls.Add(this.rb_stats);
            this.Controls.Add(this.btn_stats);
            this.Controls.Add(this.rb_report);
            this.Controls.Add(this.rb_vtg);
            this.Controls.Add(this.rb_rmc);
            this.Controls.Add(this.rb_gga);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_SkyPlot);
            this.Controls.Add(this.brn_More);
            this.Controls.Add(this.lbMessages);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnChooseFile);
            this.Controls.Add(this.tbChosenFile);
            this.Name = "Form1";
            this.Text = "BusReview";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog fileChooser;
        private System.Windows.Forms.TextBox tbChosenFile;
        private System.Windows.Forms.Button btnChooseFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbMessages;
        private System.Windows.Forms.Button brn_More;
        private System.Windows.Forms.Button btn_SkyPlot;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rb_gga;
        private System.Windows.Forms.RadioButton rb_rmc;
        private System.Windows.Forms.RadioButton rb_vtg;
        private System.Windows.Forms.RadioButton rb_report;
        private System.Windows.Forms.Button btn_stats;
        private System.Windows.Forms.RadioButton rb_stats;
        private System.Windows.Forms.RadioButton rb_ETK;
        private System.Windows.Forms.Label lbl_Process;
        private System.Windows.Forms.ProgressBar pb_import;
    }
}

