using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfacesDidorenko
{
    public partial class StatsForm : Form
    {
        ProtocolHandler ph;
        ProtocolHandlerStats stats;
        public StatsForm(ProtocolHandler ph)
        {
            InitializeComponent();
            this.ph = ph;
            stats = new ProtocolHandlerStats(ph);
        }

        void InitLatChart()
        {
            chart_latitude.Series[0].Points.Clear();
            chart_latitude.Series[1].Points.Clear();

            foreach(var gga in ph.MessagesGGA)
            {
                chart_latitude.Series[0].Points.AddXY(gga.GetField("Time"), gga.GetField("Latitude"));
                chart_latitude.Series[1].Points.AddXY(gga.GetField("Time"), stats.AverageStats[0]);
            }
        }

        void InitLongChart()
        {
            chart_longitude.Series[0].Points.Clear();
            chart_longitude.Series[1].Points.Clear();

            foreach (var gga in ph.MessagesGGA)
            {
                chart_longitude.Series[0].Points.AddXY(gga.GetField("Time"), gga.GetField("Longitude"));
                chart_longitude.Series[1].Points.AddXY(gga.GetField("Time"), stats.AverageStats[1]);
            }
        }

        void InitAltChart()
        {
            chart_altitude.Series[0].Points.Clear();
            chart_altitude.Series[1].Points.Clear();

            foreach (var gga in ph.MessagesGGA)
            {
                chart_altitude.Series[0].Points.AddXY(gga.GetField("Time"), gga.GetField("Altitude"));
                chart_altitude.Series[1].Points.AddXY(gga.GetField("Time"), stats.AverageStats[2]);
            }
        }

        private void StatsForm_Load(object sender, EventArgs e)
        {
            InitLatChart();
            InitLongChart();
            InitAltChart();

            tb_statInfo.Text += "Средние значения:" + Environment.NewLine + $"Широта: {stats.AverageStats[0]}" + Environment.NewLine + $"Долгота: {stats.AverageStats[1]}" + Environment.NewLine + $"Высота: { stats.AverageStats[2]}" + Environment.NewLine;
            tb_statInfo.Text += "Ковариационная матрица:" + Environment.NewLine;
            for (int i = 0; i < stats.CovariationMatr.GetLength(0); i++)
            {
                tb_statInfo.Text += "[";
                for (int j = 0; j < stats.CovariationMatr.GetLength(1); j++)
                {
                    tb_statInfo.Text += $" {stats.CovariationMatr[i,j]} ";
                }
                tb_statInfo.Text += "]" + Environment.NewLine;
            }
            tb_statInfo.Text += "Среднеквадратичные отколнения:" + Environment.NewLine;
            tb_statInfo.Text += $"Широта: {stats.SKO[0]}" + Environment.NewLine;
            tb_statInfo.Text += $"Долгота: {stats.SKO[1]}" + Environment.NewLine;
            tb_statInfo.Text += $"Высота: {stats.SKO[2]}" + Environment.NewLine;
            tb_statInfo.Text += "Корелляционная матрица:" + Environment.NewLine;
            for (int i = 0; i < stats.CorellationMatr.GetLength(0); i++)
            {
                tb_statInfo.Text += "[";
                for (int j = 0; j < stats.CorellationMatr.GetLength(1); j++)
                {
                    tb_statInfo.Text += $" {stats.CorellationMatr[i, j]} ";
                }
                tb_statInfo.Text += "]" + Environment.NewLine;
            }
            tb_statInfo.Text += "Количество аномальных отклонений:" + Environment.NewLine;
            tb_statInfo.Text += $"По широте: {stats.AnomalDispersionNum[0]}" + Environment.NewLine;
            tb_statInfo.Text += $"По долготе: {stats.AnomalDispersionNum[1]}" + Environment.NewLine;
            tb_statInfo.Text += $"По высоте: {stats.AnomalDispersionNum[2]}" + Environment.NewLine;
        }
    }
}
