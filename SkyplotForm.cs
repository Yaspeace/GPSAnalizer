using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace InterfacesDidorenko
{
    public partial class SkyplotForm : Form
    {
        ProtocolHandler ph;
        public SkyplotForm(ProtocolHandler protocolHandler)
        {
            InitializeComponent();
            this.ph = protocolHandler;
        }

        private bool InList(List<KeyValuePair<int, int>> list, int id)
        {
            foreach (var kvpair in list)
                if (kvpair.Key == id)
                    return true;
            return false;
        }

        private int GetSeriesNum(List<KeyValuePair<int, int>> list, int id)
        {
            foreach(var kvp in list)
                if(kvp.Key == id)
                    return kvp.Value;
            return -1;
        }

        private void SkyplotForm_Load(object sender, EventArgs e)
        {
            if (ph.MessagesGSV.Count == 0)
                return;

            //Key - id of satelline, value - number of serie for its visualising
            List<KeyValuePair<int, int>> satsID = new List<KeyValuePair<int, int>>();
            int seriesCounter = 0;

            foreach(var gsv in ph.MessagesGSV)
            {
                int satsNum = gsv.Sats.Length;
                for(int i = 0; i < satsNum; i++)
                {
                    if(InList(satsID, gsv.Sats[i].SatID))
                    {
                        int serNum = GetSeriesNum(satsID, gsv.Sats[i].SatID);
                        spchart.Series["Series" + serNum.ToString()].Points.AddXY(gsv.Sats[i].Azimuth, gsv.Sats[i].Elevation);
                    }
                    else
                    {
                        spchart.Series.Add("Series" + seriesCounter.ToString());
                        spchart.Series["Series" + seriesCounter.ToString()].ChartType = SeriesChartType.Polar;
                        spchart.Series["Series" + seriesCounter.ToString()].ChartArea = "ChartArea1";
                        spchart.Legends.Add("Legend" + seriesCounter.ToString());
                        spchart.Legends["Legend" + seriesCounter.ToString()].DockedToChartArea = "ChartArea1";
                        spchart.Series["Series" + seriesCounter.ToString()].Legend = "Legend" + seriesCounter.ToString();
                        spchart.Series["Series" + seriesCounter.ToString()].LegendText = gsv.Sats[i].SatID.ToString();
                        satsID.Add(new KeyValuePair<int, int>(gsv.Sats[i].SatID, seriesCounter));
                        spchart.Series["Series" + seriesCounter.ToString()].Points.AddXY(gsv.Sats[i].Azimuth, gsv.Sats[i].Elevation);
                        seriesCounter++;
                    }
                }
            }
        }
    }
}
