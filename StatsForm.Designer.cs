namespace InterfacesDidorenko
{
    partial class StatsForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart_latitude = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart_longitude = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart_altitude = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tb_statInfo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart_latitude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_longitude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_altitude)).BeginInit();
            this.SuspendLayout();
            // 
            // chart_latitude
            // 
            chartArea4.Name = "ChartArea1";
            this.chart_latitude.ChartAreas.Add(chartArea4);
            legend4.DockedToChartArea = "ChartArea1";
            legend4.Name = "Legend1";
            this.chart_latitude.Legends.Add(legend4);
            this.chart_latitude.Location = new System.Drawing.Point(13, 13);
            this.chart_latitude.Name = "chart_latitude";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series7.Legend = "Legend1";
            series7.Name = "Latitude(t)";
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series8.Legend = "Legend1";
            series8.Name = "Average";
            this.chart_latitude.Series.Add(series7);
            this.chart_latitude.Series.Add(series8);
            this.chart_latitude.Size = new System.Drawing.Size(370, 300);
            this.chart_latitude.TabIndex = 0;
            this.chart_latitude.Text = "chart1";
            // 
            // chart_longitude
            // 
            chartArea5.Name = "ChartArea1";
            this.chart_longitude.ChartAreas.Add(chartArea5);
            legend5.DockedToChartArea = "ChartArea1";
            legend5.Name = "Legend1";
            this.chart_longitude.Legends.Add(legend5);
            this.chart_longitude.Location = new System.Drawing.Point(389, 12);
            this.chart_longitude.Name = "chart_longitude";
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series9.Legend = "Legend1";
            series9.Name = "Longitude(t)";
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series10.Legend = "Legend1";
            series10.Name = "Average";
            this.chart_longitude.Series.Add(series9);
            this.chart_longitude.Series.Add(series10);
            this.chart_longitude.Size = new System.Drawing.Size(370, 300);
            this.chart_longitude.TabIndex = 1;
            this.chart_longitude.Text = "chart2";
            // 
            // chart_altitude
            // 
            chartArea6.Name = "ChartArea1";
            this.chart_altitude.ChartAreas.Add(chartArea6);
            legend6.DockedToChartArea = "ChartArea1";
            legend6.Name = "Legend1";
            this.chart_altitude.Legends.Add(legend6);
            this.chart_altitude.Location = new System.Drawing.Point(765, 12);
            this.chart_altitude.Name = "chart_altitude";
            series11.ChartArea = "ChartArea1";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series11.Legend = "Legend1";
            series11.Name = "Altitude(t)";
            series12.ChartArea = "ChartArea1";
            series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series12.Legend = "Legend1";
            series12.Name = "Average";
            this.chart_altitude.Series.Add(series11);
            this.chart_altitude.Series.Add(series12);
            this.chart_altitude.Size = new System.Drawing.Size(370, 300);
            this.chart_altitude.TabIndex = 2;
            this.chart_altitude.Text = "chart3";
            // 
            // tb_statInfo
            // 
            this.tb_statInfo.Location = new System.Drawing.Point(13, 320);
            this.tb_statInfo.Multiline = true;
            this.tb_statInfo.Name = "tb_statInfo";
            this.tb_statInfo.ReadOnly = true;
            this.tb_statInfo.Size = new System.Drawing.Size(1122, 286);
            this.tb_statInfo.TabIndex = 3;
            // 
            // StatsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 619);
            this.Controls.Add(this.tb_statInfo);
            this.Controls.Add(this.chart_altitude);
            this.Controls.Add(this.chart_longitude);
            this.Controls.Add(this.chart_latitude);
            this.Name = "StatsForm";
            this.Text = "Статистические данные";
            this.Load += new System.EventHandler(this.StatsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart_latitude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_longitude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_altitude)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart_latitude;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_longitude;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_altitude;
        private System.Windows.Forms.TextBox tb_statInfo;
    }
}