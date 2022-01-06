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
    public partial class FucnForm : Form
    {
        public ProtocolHandler protocolHandler { get; set; }
        public ProtocolHandlerStats stats { get; set; }

        private int ZoomCounter = 0;
        double xAxisDefaultInterval;
        double yAxisDefaultInterval;

        public string protocol { get; set; }

        DateTime minTime = new DateTime(1,1,1);
        DateTime maxTime = new DateTime(1, 1, 1);
        DateTime beginTime = new DateTime(1, 1, 1);
        DateTime endTime = new DateTime(1, 1, 1);

        public FucnForm(ProtocolHandler protocolHandler, string protocol)
        {
            InitializeComponent();
            this.protocolHandler = protocolHandler;
            chart1.MouseWheel += new MouseEventHandler(chart1_MouseWheel);
            chart1.Legends.Clear();
            this.protocol = protocol;
            this.stats = new ProtocolHandlerStats(protocolHandler);
        }

        private void chart1_MouseWheel(object sender, MouseEventArgs e)
        {
            var chart = (Chart)sender;
            var xAxis = chart.ChartAreas[0].AxisX;
            var yAxis = chart.ChartAreas[0].AxisY;

            try
            {
                if (e.Delta < 0 && ZoomCounter < 0) // Scrolled down.
                {
                    var xMin = xAxis.ScaleView.ViewMinimum;
                    var xMax = xAxis.ScaleView.ViewMaximum;
                    var yMin = yAxis.ScaleView.ViewMinimum;
                    var yMax = yAxis.ScaleView.ViewMaximum;

                    var intervalX = xMax - xMin;
                    var intervalY = yMax - yMin;

                    var posXStart = xAxis.PixelPositionToValue(e.Location.X) - intervalX;
                    var posXFinish = xAxis.PixelPositionToValue(e.Location.X) + intervalX;
                    var posYStart = yAxis.PixelPositionToValue(e.Location.Y) - intervalY;
                    var posYFinish = yAxis.PixelPositionToValue(e.Location.Y) + intervalY;

                    xAxis.ScaleView.Zoom(posXStart, posXFinish);
                    yAxis.ScaleView.Zoom(posYStart, posYFinish);

                    xAxis.Interval *= 2;
                    yAxis.Interval *= 2;
                    ZoomCounter++;
                    if (ZoomCounter == 0)
                    {
                        xAxis.Interval = xAxisDefaultInterval;
                        yAxis.Interval = yAxisDefaultInterval;
                    }
                }
                else if (e.Delta > 0) // Scrolled up.
                {
                    var xMin = xAxis.ScaleView.ViewMinimum;
                    var xMax = xAxis.ScaleView.ViewMaximum;
                    var yMin = yAxis.ScaleView.ViewMinimum;
                    var yMax = yAxis.ScaleView.ViewMaximum;

                    var posXStart = xAxis.PixelPositionToValue(e.Location.X) - (xMax - xMin) / 4;
                    var posXFinish = xAxis.PixelPositionToValue(e.Location.X) + (xMax - xMin) / 4;
                    var posYStart = yAxis.PixelPositionToValue(e.Location.Y) - (yMax - yMin) / 4;
                    var posYFinish = yAxis.PixelPositionToValue(e.Location.Y) + (yMax - yMin) / 4;

                    xAxis.ScaleView.Zoom(posXStart, posXFinish);
                    yAxis.ScaleView.Zoom(posYStart, posYFinish);

                    xAxis.Interval /= 2;
                    yAxis.Interval /= 2;

                    ZoomCounter--;
                    if (ZoomCounter == 0)
                    {
                        xAxis.Interval = xAxisDefaultInterval;
                        yAxis.Interval = yAxisDefaultInterval;
                    }
                }
            }
            catch
            { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                beginTime = Convert.ToDateTime(tb_begin.Text);
            }
            catch(Exception exc)
            {
                beginTime = minTime;
            }
            if (beginTime < minTime)
                beginTime = minTime;
            if (beginTime > endTime)
                beginTime = endTime;
            try
            {
                endTime = Convert.ToDateTime(tb_end.Text);
            }
            catch(Exception exc)
            {
                endTime = maxTime;
            }
            if (endTime > maxTime)
                endTime = maxTime;
            if (endTime < beginTime)
                endTime = beginTime;
            tb_begin.Text = beginTime.ToString();
            tb_end.Text = endTime.ToString();

            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.ChartAreas.Add("ChartArea1");
            chart1.Series.Add("Series1");
            chart1.Series[0].ChartType = SeriesChartType.Line;
            chart1.Series[0].Color = Color.Blue;

            string xAxisType = cbox_XAxisFunc.Text;
            string yAxisType = cbox_YAxisFunc.Text;

            chart1.ChartAreas[0].AxisX.IsStartedFromZero = false;
            chart1.ChartAreas[0].AxisX.Minimum = double.NaN;
            chart1.ChartAreas[0].AxisX.Maximum = double.NaN;


            chart1.Series[0].YValueType = ChartValueType.String;
            //chart1.ChartAreas[0].AxisX.LabelStyle.Format = "0.00";
            chart1.ChartAreas[0].AxisY.IsStartedFromZero = false;
            chart1.ChartAreas[0].AxisY.Minimum = double.NaN;
            chart1.ChartAreas[0].AxisY.Maximum = double.NaN;

            /*Вывод графиков напрямую по считанным данным*/
            switch(protocol)
            {
                case ("REPORT"):
                    foreach (var report in protocolHandler.MessagesREPORT)
                        if(xAxisType != "Время" || (report.DateAndTime >= beginTime && report.DateAndTime <= endTime))
                            chart1.Series[0].Points.AddXY(report.GetField(xAxisType), report.GetField(yAxisType));
                    break;
                case ("GGA"):
                    foreach (var gga in protocolHandler.MessagesGGA)
                    {
                        if(gga.positionFix > 0)
                            if (xAxisType != "Время" || (gga.time >= beginTime && gga.time <= endTime))
                                chart1.Series[0].Points.AddXY(gga.GetField(xAxisType), gga.GetField(yAxisType));
                    }
                    break;
                case ("RMC"):
                    foreach (var rmc in protocolHandler.MessagesRMC)
                        if (xAxisType != "Время" || (rmc.DateAndTime >= beginTime && rmc.DateAndTime <= endTime))
                            chart1.Series[0].Points.AddXY(rmc.GetField(xAxisType), rmc.GetField(yAxisType));
                    break;
                case ("VTG"):
                    foreach (var vtg in protocolHandler.MessagesVTG)
                        chart1.Series[0].Points.AddXY(vtg.GetField(xAxisType), vtg.GetField(yAxisType));
                    break;
                case "ETK":
                    foreach (var etk in protocolHandler.MessagesETK)
                        if (xAxisType != "Время" || (etk.Time >= beginTime && etk.Time <= endTime))
                            chart1.Series[0].Points.AddXY(etk.GetField(xAxisType), etk.GetField(yAxisType));
                    break;
                /*Вывод других графиков*/
                case ("Stats"):
                    int Xselect = 0;
                    int Yselect = 0;
                    if (xAxisType == "Время")
                        Xselect = 3;
                    else
                        Xselect = 1;
                    if (yAxisType == "Отклонение по широте")
                        Yselect = 0;
                    else if (yAxisType == "Отклонение по долготе")
                        Yselect = 1;
                    else
                        Yselect = 2;
                    foreach (var disp in stats.Dispertions)
                        chart1.Series[0].Points.AddXY(disp[Xselect], disp[Yselect]);
                    break;
                /*дальнейшее выполнение функции вывода*/
            }



            if (xAxisType == "Время")
                panel_chooseTime.Visible = true;
            else
                panel_chooseTime.Visible = false;

            chart1.ChartAreas[0].AxisX.IsStartedFromZero = false;
            chart1.ChartAreas[0].AxisY.IsStartedFromZero = false;

            xAxisDefaultInterval = chart1.ChartAreas[0].AxisX.Interval;
            yAxisDefaultInterval = chart1.ChartAreas[0].AxisY.Interval;
        }

        private void FucnForm_Load(object sender, EventArgs e)
        {
            switch(protocol)
            {
                case ("REPORT"):
                    cbox_XAxisFunc.Items.Clear();
                    cbox_XAxisFunc.Items.AddRange(new string[] { "Широта", "Долгота", "Время" });
                    cbox_YAxisFunc.Items.Clear();
                    cbox_YAxisFunc.Items.AddRange(new string[] { "Широта", "Долгота", "Скорость", "Направление", "Кол-во спутников" });
                    minTime = protocolHandler.MessagesREPORT.First().DateAndTime;
                    maxTime = protocolHandler.MessagesREPORT.Last().DateAndTime;
                    beginTime = minTime;
                    endTime = maxTime;
                    tb_begin.Text = beginTime.ToString();
                    tb_end.Text = endTime.ToString();
                    break;
                case ("GGA"):
                    cbox_XAxisFunc.Items.Clear();
                    cbox_XAxisFunc.Items.AddRange(new string[] { "Широта", "Долгота", "Время", "Кол-во спутников" });
                    cbox_YAxisFunc.Items.Clear();
                    cbox_YAxisFunc.Items.AddRange(new string[] { "Широта", "Долгота", "Высота", "Флаг фиксации позиции", "HDOP", "Кол-во спутников" });
                    minTime = protocolHandler.MessagesGGA.Min(gga => gga.time);
                    maxTime = protocolHandler.MessagesGGA.Max(gga => gga.time);
                    beginTime = minTime;
                    endTime = maxTime;
                    tb_begin.Text = beginTime.ToString();
                    tb_end.Text = endTime.ToString();
                    break;
                case ("RMC"):
                    cbox_XAxisFunc.Items.Clear();
                    cbox_XAxisFunc.Items.AddRange(new string[] { "Широта", "Долгота", "Время" });
                    cbox_YAxisFunc.Items.Clear();
                    cbox_YAxisFunc.Items.AddRange(new string[] { "Широта", "Долгота", "Скорость", "Направление" });
                    minTime = protocolHandler.MessagesRMC.Min(rmc => rmc.DateAndTime);
                    maxTime = protocolHandler.MessagesRMC.Max(rmc => rmc.DateAndTime);
                    beginTime = minTime;
                    endTime = maxTime;
                    tb_begin.Text = beginTime.ToString();
                    tb_end.Text = endTime.ToString();
                    break;
                case ("VTG"):
                    cbox_XAxisFunc.Items.Clear();
                    cbox_XAxisFunc.Items.AddRange(new string[] { "Курс на истинный север", "Курс на магнитный север" });
                    cbox_YAxisFunc.Items.Clear();
                    cbox_YAxisFunc.Items.AddRange(new string[] { "Скорость в узлах", "Скорость в км/ч" });
                    break;
                case ("ETK"):
                    cbox_XAxisFunc.Items.Clear();
                    cbox_XAxisFunc.Items.AddRange(new string[] { "Широта", "Долгота", "Время"});
                    cbox_YAxisFunc.Items.Clear();
                    cbox_YAxisFunc.Items.AddRange(new string[] { "Широта", "Долгота", "Скорость" });
                    minTime = protocolHandler.MessagesETK.Min(etk => etk.Time);
                    maxTime = protocolHandler.MessagesETK.Max(etk => etk.Time);
                    beginTime = minTime;
                    endTime = maxTime;
                    tb_begin.Text = beginTime.ToString();
                    tb_end.Text = endTime.ToString();
                    break;
                case ("Stats"):
                    cbox_XAxisFunc.Items.Clear();
                    cbox_XAxisFunc.Items.AddRange(new string[] { "Время", "Отклонение по долготе" });
                    cbox_YAxisFunc.Items.Clear();
                    cbox_YAxisFunc.Items.AddRange(new string[] { "Отклонение по широте", "Отклонение по долготе", "Отклонение по высоте" });
                    break;
            }
        }
    }
}
