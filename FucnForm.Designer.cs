
namespace InterfacesDidorenko
{
    partial class FucnForm
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
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button1 = new System.Windows.Forms.Button();
            this.cbox_YAxisFunc = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbox_XAxisFunc = new System.Windows.Forms.ComboBox();
            this.tb_begin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_end = new System.Windows.Forms.TextBox();
            this.panel_chooseTime = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel_chooseTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 12);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(834, 555);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(852, 534);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 33);
            this.button1.TabIndex = 1;
            this.button1.Text = "Построить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbox_YAxisFunc
            // 
            this.cbox_YAxisFunc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_YAxisFunc.FormattingEnabled = true;
            this.cbox_YAxisFunc.Items.AddRange(new object[] {
            "Широта",
            "Долгота",
            "Скорость",
            "Направление",
            "Кол-во спутников"});
            this.cbox_YAxisFunc.Location = new System.Drawing.Point(852, 34);
            this.cbox_YAxisFunc.Name = "cbox_YAxisFunc";
            this.cbox_YAxisFunc.Size = new System.Drawing.Size(121, 21);
            this.cbox_YAxisFunc.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(849, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "По оси Y:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(849, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "По оси X:";
            // 
            // cbox_XAxisFunc
            // 
            this.cbox_XAxisFunc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_XAxisFunc.FormattingEnabled = true;
            this.cbox_XAxisFunc.Items.AddRange(new object[] {
            "Широта",
            "Долгота",
            "Время"});
            this.cbox_XAxisFunc.Location = new System.Drawing.Point(852, 74);
            this.cbox_XAxisFunc.Name = "cbox_XAxisFunc";
            this.cbox_XAxisFunc.Size = new System.Drawing.Size(121, 21);
            this.cbox_XAxisFunc.TabIndex = 5;
            // 
            // tb_begin
            // 
            this.tb_begin.Location = new System.Drawing.Point(6, 24);
            this.tb_begin.Name = "tb_begin";
            this.tb_begin.Size = new System.Drawing.Size(120, 20);
            this.tb_begin.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Начало:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Конец:";
            // 
            // tb_end
            // 
            this.tb_end.Location = new System.Drawing.Point(6, 67);
            this.tb_end.Name = "tb_end";
            this.tb_end.Size = new System.Drawing.Size(120, 20);
            this.tb_end.TabIndex = 9;
            // 
            // panel_chooseTime
            // 
            this.panel_chooseTime.Controls.Add(this.label3);
            this.panel_chooseTime.Controls.Add(this.tb_end);
            this.panel_chooseTime.Controls.Add(this.tb_begin);
            this.panel_chooseTime.Controls.Add(this.label4);
            this.panel_chooseTime.Location = new System.Drawing.Point(852, 118);
            this.panel_chooseTime.Name = "panel_chooseTime";
            this.panel_chooseTime.Size = new System.Drawing.Size(133, 104);
            this.panel_chooseTime.TabIndex = 10;
            this.panel_chooseTime.Visible = false;
            // 
            // FucnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 579);
            this.Controls.Add(this.panel_chooseTime);
            this.Controls.Add(this.cbox_XAxisFunc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbox_YAxisFunc);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chart1);
            this.Name = "FucnForm";
            this.Text = "Function Building";
            this.Load += new System.EventHandler(this.FucnForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel_chooseTime.ResumeLayout(false);
            this.panel_chooseTime.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbox_YAxisFunc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbox_XAxisFunc;
        private System.Windows.Forms.TextBox tb_begin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_end;
        private System.Windows.Forms.Panel panel_chooseTime;
    }
}