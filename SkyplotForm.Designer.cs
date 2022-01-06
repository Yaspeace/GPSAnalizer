namespace InterfacesDidorenko
{
    partial class SkyplotForm
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
            this.spchart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.spchart)).BeginInit();
            this.SuspendLayout();
            // 
            // spchart
            // 
            chartArea1.Name = "ChartArea1";
            this.spchart.ChartAreas.Add(chartArea1);
            this.spchart.Location = new System.Drawing.Point(12, 12);
            this.spchart.Name = "spchart";
            this.spchart.Size = new System.Drawing.Size(952, 622);
            this.spchart.TabIndex = 0;
            this.spchart.Text = "chart1";
            // 
            // SkyplotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 646);
            this.Controls.Add(this.spchart);
            this.Name = "SkyplotForm";
            this.Text = "SkyplotForm";
            this.Load += new System.EventHandler(this.SkyplotForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spchart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart spchart;
    }
}