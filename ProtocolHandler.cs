using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace InterfacesDidorenko
{
    public class ProtocolHandler
    {
        public string CurMessage { get; set; }
        public List<string> Messages { get; set; }
        //public List<Report> MessagesREPORT { get; set; }
        public ConcurrentBag<Report> MessagesREPORT { get; set; }
        /*public List<GGA> MessagesGGA { get; set; }
        public List<GSA> MessagesGSA { get; set; }
        public List<GSV> MessagesGSV { get; set; }
        public List<RMC> MessagesRMC { get; set; }
        public List<VTG> MessagesVTG { get; set; }
        public List<ETK> MessagesETK { get; set; }*/
        public ConcurrentBag<GGA> MessagesGGA { get; set; }
        public ConcurrentBag<GSA> MessagesGSA { get; set; }
        public ConcurrentBag<GSV> MessagesGSV { get; set; }
        public ConcurrentBag<RMC> MessagesRMC { get; set; }
        public ConcurrentBag<VTG> MessagesVTG { get; set; }
        public ConcurrentBag<ETK> MessagesETK { get; set; }


        public event EventHandler DataReaded;
        public bool HasData { get; private set; }

        public ProtocolHandler()
        {
            Messages = new List<string>();
            MessagesREPORT = new ConcurrentBag<Report>();

            MessagesGGA = new ConcurrentBag<GGA>();
            MessagesGSA = new ConcurrentBag<GSA>();
            MessagesGSV = new ConcurrentBag<GSV>();
            MessagesRMC = new ConcurrentBag<RMC>();
            MessagesVTG = new ConcurrentBag<VTG>();
            MessagesETK = new ConcurrentBag<ETK>();

            CurMessage = String.Empty;
            HasData = false;
        }

        private async void AddMessagesAsync(List<string> messages)
        {
            await Task.Run(() =>
            {
                foreach(var msg in messages)
                {
                    if (msg.Split(',')[0] == "$GPGGA")
                        MessagesGGA.Add(GetGGAData(msg));
                    if (msg.Split(',')[0] == "$GPGSV")
                        MessagesGSV.Add(GetGSVData(msg));
                    if (msg.Split(',')[0] == "$GPGSA")
                        MessagesGSA.Add(GetGSAData(msg));
                    if (msg.Split(',')[0] == "$GPRMC")
                        MessagesRMC.Add(GetRMCData(msg));
                    if (msg.Split(',')[0] == "$GPVTG")
                        MessagesVTG.Add(GetVTGData(msg));
                    if (msg.Split(',')[0] == "&REPORT")
                        MessagesREPORT.Add(_getReportData(msg));
                    if (msg[0] == '"')
                    {
                        ETK? etk = GetETKData(msg);
                        if (etk != null)
                            MessagesETK.Add((ETK)etk);
                    }
                }
            });
        }

        public async void _ReadFromFileAsync(string filePath)
        {
            await Task.Run(() =>
            {
                List<string> localList = new List<string>();
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line = sr.ReadLine();
                    localList.Add(line);
                    while (line != null)
                    {
                        if (localList.Count == 40000)
                        {
                            AddMessagesAsync(localList);
                            localList = new List<string>();
                        }
                        localList.Add(line);
                        Messages.Add(line);
                        line = sr.ReadLine();
                    }
                    if (localList.Count > 0)
                        AddMessagesAsync(localList);
                }
                if (MessagesREPORT.Count > 0 || MessagesGGA.Count > 0 || MessagesGSA.Count > 0 || MessagesGSV.Count > 0 || MessagesRMC.Count > 0 || MessagesVTG.Count > 0 || MessagesETK.Count > 0)
                    HasData = true;
                DataReaded.Invoke(this, new EventArgs());
            });
        }

        public void _ReadFromFile(string filePath)
        {
            try
            {
                List<string> localList = new List<string>();
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line = sr.ReadLine();
                    localList.Add(line);
                    while (line != null)
                    {
                        if (localList.Count == 10000)
                        {
                            AddMessagesAsync(localList);
                            localList = new List<string>();
                        }
                        localList.Add(line);
                        Messages.Add(line);
                        line = sr.ReadLine();
                    }
                    if (localList.Count > 0)
                        AddMessagesAsync(localList);
                }
                if (MessagesREPORT.Count > 0 || MessagesGGA.Count > 0 || MessagesGSA.Count > 0 || MessagesGSV.Count > 0 || MessagesRMC.Count > 0 || MessagesVTG.Count > 0 || MessagesETK.Count > 0)
                    HasData = true;
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Возникла ошибка при чтении из файла!");
                if (MessagesREPORT.Count > 0 || MessagesGGA.Count > 0 || MessagesGSA.Count > 0 || MessagesGSV.Count > 0 || MessagesRMC.Count > 0 || MessagesVTG.Count > 0 || MessagesETK.Count > 0)
                    HasData = true;
                return;
            }
        }

        public void ReadFromFile(string filePath)
        {
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line = sr.ReadLine();
                    while (line != null)
                    {
                        Messages.Add(line);
                        if (line.Split(',')[0] == "$GPGGA")
                            MessagesGGA.Add(GetGGAData(line));
                        if (line.Split(',')[0] == "$GPGSV")
                            MessagesGSV.Add(GetGSVData(line));
                        if (line.Split(',')[0] == "$GPGSA")
                            MessagesGSA.Add(GetGSAData(line));
                        if (line.Split(',')[0] == "$GPRMC")
                            MessagesRMC.Add(GetRMCData(line));
                        if (line.Split(',')[0] == "$GPVTG")
                            MessagesVTG.Add(GetVTGData(line));
                        if (line.Split(',')[0] == "&REPORT")
                            MessagesREPORT.Add(_getReportData(line));
                        if (line[0] == '"')
                        {
                            ETK? etk = GetETKData(line);
                            if (etk != null)
                                MessagesETK.Add((ETK)etk);
                        }
                        line = sr.ReadLine();
                    }
                }
                if (MessagesREPORT.Count > 0 || MessagesGGA.Count > 0 || MessagesGSA.Count > 0 || MessagesGSV.Count > 0 || MessagesRMC.Count > 0 || MessagesVTG.Count > 0 || MessagesETK.Count > 0)
                    HasData = true;
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Возникла ошибка при чтении из файла!");
                if (MessagesREPORT.Count > 0 || MessagesGGA.Count > 0 || MessagesGSA.Count > 0 || MessagesGSV.Count > 0 || MessagesRMC.Count > 0 || MessagesVTG.Count > 0 || MessagesETK.Count > 0)
                    HasData = true;
                return;
            }
        }
        public Report getReportData(string report)
        {
            string[] dataStr = report.Split(',');
            if (dataStr[0] != "&REPORT")
                return new Report();
            
            uint id = Convert.ToUInt32(dataStr[1]);
            
            int day = Convert.ToInt32(new String(new char[] { dataStr[2][0], dataStr[2][1] }));
            int month = Convert.ToInt32(new String(new char[] { dataStr[2][2], dataStr[2][3] }));
            int year = Convert.ToInt32(new String(new char[] { '2', '0', dataStr[2][4], dataStr[2][5] }));
            int hh = Convert.ToInt32(new String(new char[] { dataStr[3][0], dataStr[3][1] }));
            int mm = Convert.ToInt32(new String(new char[] { dataStr[3][2], dataStr[3][3] }));
            int ss = Convert.ToInt32(new String(new char[] { dataStr[3][4], dataStr[3][5] }));
            DateTime dt = new DateTime(year, month, day, hh, mm, ss);


            double grad = Convert.ToDouble(new String(new char[] { dataStr[4][0], dataStr[4][1], dataStr[4][2] }));
            double minutes = Convert.ToDouble(new String(new char[] { dataStr[4][3], dataStr[4][4], ',', dataStr[4][6], dataStr[4][7], dataStr[4][8], dataStr[4][9] }));
            grad += minutes / 60;
            double Latitude = grad;

            char NS = dataStr[5][0];

            grad = Convert.ToDouble(new String(new char[] { dataStr[6][0], dataStr[6][1], dataStr[6][2] }));
            minutes = Convert.ToDouble(new String(new char[] { dataStr[6][3], dataStr[6][4], ',', dataStr[6][6], dataStr[6][7], dataStr[6][8], dataStr[6][9] }));
            grad += minutes / 60;
            double Longitude = grad;

            char WE = dataStr[7][0];

            double Speed = Convert.ToDouble(dataStr[8]);

            double Dir = Convert.ToDouble(dataStr[9]);

            int GLONASS_SAT_NO = Convert.ToInt32(dataStr[16]);
            int GPS_SAT_NO = Convert.ToInt32(dataStr[17]);

            if (NS == 'S')
                Latitude *= -1;
            if (WE == 'W')
                Longitude *= -1;

            return new Report(id, dt, Latitude, NS, Longitude, WE, Speed, Dir, GLONASS_SAT_NO, GPS_SAT_NO);
        }

        public Report _getReportData(string report)
        {
            string[] dataStr = report.Split(',');
            if (dataStr[0] != "&REPORT")
                return new Report();

            uint id = Convert.ToUInt32(dataStr[1]);

            int day = Convert.ToInt32(new String(new char[] { dataStr[2][0], dataStr[2][1] }));
            int month = Convert.ToInt32(new String(new char[] { dataStr[2][2], dataStr[2][3] }));
            int year = Convert.ToInt32(new String(new char[] { '2', '0', dataStr[2][4], dataStr[2][5] }));
            int hh = Convert.ToInt32(new String(new char[] { dataStr[3][0], dataStr[3][1] }));
            int mm = Convert.ToInt32(new String(new char[] { dataStr[3][2], dataStr[3][3] }));
            int ss = Convert.ToInt32(new String(new char[] { dataStr[3][4], dataStr[3][5] }));
            DateTime dt = new DateTime(year, month, day, hh, mm, ss);


            double grad = Convert.ToDouble(dataStr[4].Substring(0, 3));
            double minutes = Convert.ToDouble(dataStr[4].Substring(3, 2) + "," + dataStr[4].Substring(6, 4));
            grad += minutes / 60;
            double Latitude = grad;

            char NS = dataStr[5][0];

            grad = Convert.ToDouble(new String(new char[] { dataStr[6][0], dataStr[6][1], dataStr[6][2] }));
            minutes = Convert.ToDouble(new String(new char[] { dataStr[6][3], dataStr[6][4], ',', dataStr[6][6], dataStr[6][7], dataStr[6][8], dataStr[6][9] }));
            grad += minutes / 60;
            double Longitude = grad;

            char WE = dataStr[7][0];

            double Speed = Convert.ToDouble(dataStr[8]);

            double Dir = Convert.ToDouble(dataStr[9]);

            int GLONASS_SAT_NO = Convert.ToInt32(dataStr[16]);
            int GPS_SAT_NO = Convert.ToInt32(dataStr[17]);

            if (NS == 'S')
                Latitude *= -1;
            if (WE == 'W')
                Longitude *= -1;

            return new Report(id, dt, Latitude, NS, Longitude, WE, Speed, Dir, GLONASS_SAT_NO, GPS_SAT_NO);
        }

        public GGA GetGGAData(string message)
        {
            GGA gga = new GGA();
            string[] data = message.Split(',');
            
            int hh = Convert.ToInt32(data[1].Substring(0,2));
            int mm = Convert.ToInt32(data[1].Substring(2,2));
            int ss = Convert.ToInt32(data[1].Substring(4,2));
            int ms = Convert.ToInt32(data[1].Substring(7,2)) * 10;
            gga.time = new DateTime(1, 1, 1, hh, mm, ss, ms);

            if (data[2].Length <= 1)
                gga.Latitude = 0;
            else
            {
                double deg = Convert.ToDouble(data[2].Substring(0, 2));
                double mins = Convert.ToDouble(data[2].Substring(2, 2) + "," + data[2].Substring(5, 4));
                deg += mins / 60;
                gga.Latitude = deg;
            }

            if (data[3].Length == 0)
                gga.NS = '?';
            else
                gga.NS = data[3][0];

            if (data[4].Length == 0)
                gga.Longitude = 0;
            else
            {
                double deg = Convert.ToDouble(data[4].Substring(0, 3));
                double mins = Convert.ToDouble(data[4].Substring(3, 2) + "," + data[4].Substring(6, 4));
                gga.Longitude = deg + (mins / 60);
            }

            if (data[5].Length == 0)
                gga.WE = '?';
            else
                gga.WE = data[5][0];

            gga.positionFix = data[6].Length > 0 ? Convert.ToInt32(data[6][0]) : 0;

            gga.SatNum = data[7].Length > 0 ? Convert.ToInt32(data[7]) : 0;

            gga.HDOP = data[8].Length > 0 ? Convert.ToDouble(data[8].Replace(".", ",")) : 0;

            gga.Altitude = data[9].Length > 0 ? Convert.ToDouble(data[9].Replace(".", ",")) : 0;


            string sum = data[14].Split('*')[1];
            gga.ControlSum = Convert.ToInt32(sum, 16);

            if (gga.NS == 'S')
                gga.Latitude *= -1;
            if (gga.WE == 'W')
                gga.Longitude *= -1;

            return gga;
        }

        public GSV GetGSVData(string message)
        {
            GSV gsv = new GSV();
            string[] data = message.Split(',');
            
            gsv.NumOfMessages = Convert.ToInt32(data[1]);

            gsv.MessageNum = Convert.ToInt32(data[2]);

            gsv.SatsInView = Convert.ToInt32(data[3]);

            int satNum = (data.Length - 4) / 4;

            gsv.Sats = new GSVSatInfo[satNum];

            for(int i = 0; i < satNum; i++)
            {
                if (data[(i * 4) + 4].Length == 0)
                    gsv.Sats[i].SatID = 0;
                else
                    gsv.Sats[i].SatID = Convert.ToInt32(data[(i * 4) + 4]);
                if (data[(i * 4) + 5].Length == 0)
                    gsv.Sats[i].Elevation = 0;
                else
                    gsv.Sats[i].Elevation = Convert.ToInt32(data[(i * 4) + 5]);
                if (data[(i * 4) + 6].Length == 0)
                    gsv.Sats[i].Azimuth = 0;
                else
                    gsv.Sats[i].Azimuth = Convert.ToInt32(data[(i * 4) + 6]);
                if(i == satNum - 1)
                    gsv.Sats[i].SignalPower = data[(i * 4) + 7].Split('*')[0].Length == 0 ? 0 : Convert.ToInt32(data[(i * 4) + 7].Split('*')[0]);
                else
                    gsv.Sats[i].SignalPower = data[(i * 4) + 7].Length == 0 ? 0 : Convert.ToInt32(data[(i * 4) + 7]);
            }

            gsv.ControlSum = Convert.ToInt32(data[data.Length - 1].Split('*')[1], 16);
            
            return gsv;
        }

        public GSA GetGSAData(string message)
        {
            GSA gsa = new GSA();
            string[] data = message.Split(',');

            gsa.Mode1 = Convert.ToChar(data[1]);

            gsa.Mode2 = Convert.ToInt32(data[2]);

            gsa.UsedSats = new int[12];

            for(int i = 0; i < 12; i++)
                gsa.UsedSats[i] = data[i + 3].Length == 0 ? 0 : Convert.ToInt32(data[i + 3]);

            gsa.PDOP = data[data.Length - 3].Length == 0 ? 0 : Convert.ToDouble(data[data.Length - 3].Replace(".", ","));

            gsa.HDOP = data[data.Length - 2].Length == 0 ? 0 : Convert.ToDouble(data[data.Length - 2].Replace(".", ","));

            gsa.VDOP = data[data.Length - 1].Split('*')[0].Length == 0 ? 0 : Convert.ToDouble(data[data.Length - 1].Split('*')[0].Replace(".", ","));

            gsa.ControlSum = Convert.ToInt32(data[data.Length - 1].Split('*')[1], 16);

            return gsa;
        }

        public RMC GetRMCData(string message)
        {
            RMC rmc = new RMC();
            string[] data = message.Split(',');

            if (data[1].Length == 0)
                rmc.UTCTime = new DateTime(1, 1, 1, 0, 0, 0, 0);
            else
            {
                string[] timedata = data[1].Split('.');
                int hh = Convert.ToInt32(timedata[0].Substring(0, 2));
                int mm = Convert.ToInt32(timedata[0].Substring(2, 2));
                int ss = Convert.ToInt32(timedata[0].Substring(4, 2));
                int ms = Convert.ToInt32(timedata[1]);
                rmc.UTCTime = new DateTime(1, 1, 1, hh, mm, ss, ms);
            }

            rmc.Status = Convert.ToChar(data[2]);

            if (data[3].Length == 0)
                rmc.Latitude = 0;
            else
            {
                double deg = Convert.ToDouble(data[3].Substring(0,2));
                double mins = Convert.ToDouble(data[3].Substring(2).Replace(".", ","));
                rmc.Latitude = deg + (mins / 60);
            }

            rmc.NS = data[4].Length == 0 ? '?' : data[4][0];

            if (data[5].Length == 0)
                rmc.Longitude = 0;
            else
            {
                double deg = Convert.ToDouble(data[5].Substring(0, 3));
                double mins = Convert.ToDouble(data[5].Substring(3).Replace(".", ","));
                rmc.Longitude = deg + (mins / 60);
            }

            rmc.WE = data[6].Length == 0 ? '?' : data[6][0];

            rmc.Speed = data[7].Length == 0 ? 0 : Convert.ToDouble(data[7].Replace(".", ","));

            rmc.Course = data[8].Length == 0 ? 0 : Convert.ToDouble(data[8].Replace(".", ","));

            if (data[9].Length == 0)
                rmc.Date = new DateTime(1, 1, 1);
            else
            {
                int dd = Convert.ToInt32(data[9].Substring(0, 2));
                int mm = Convert.ToInt32(data[9].Substring(2, 2));
                int yy = Convert.ToInt32(data[9].Substring(4, 2));
                rmc.Date = new DateTime(yy, mm, dd);
            }

            rmc.ControlSum = Convert.ToInt32(data[12].Split('*')[1], 16);

            rmc.DateAndTime = new DateTime(rmc.Date.Year, rmc.Date.Month, rmc.Date.Day, rmc.UTCTime.Hour, rmc.UTCTime.Minute, rmc.UTCTime.Second, rmc.UTCTime.Millisecond);

            return rmc;
        }

        public VTG GetVTGData(string message)
        {
            VTG vtg = new VTG();
            string[] data = message.Split(',');

            vtg.CourseTrueNorth = data[1].Length == 0 ? 0 : Convert.ToDouble(data[1].Replace(".", ","));
            
            vtg.ReferenceTrueNorth = data[2].Length == 0 ? '?' : Convert.ToChar(data[2]);

            vtg.CourseMagNorth = data[3].Length == 0 ? 0 : Convert.ToDouble(data[3].Replace(".", ","));

            vtg.ReferenceMagNorth = data[4].Length == 0 ? '?' : Convert.ToChar(data[4]);

            vtg.SpeedKnots = data[5].Length == 0 ? 0 : Convert.ToDouble(data[5].Replace(".", ","));

            vtg.Units = data[6].Length == 0 ? '?' : Convert.ToChar(data[6]);

            vtg.SpeedKMH = data[7].Length == 0 ? 0 : Convert.ToDouble(data[7].Replace(".", ","));

            vtg.UnitsKMH = data[8].Split('*')[0].Length == 0 ? '?' : Convert.ToChar(data[8].Split('*')[0]);

            vtg.ControlSum = Convert.ToInt32(data[9].Split('*')[1], 16);

            return vtg;
        }

        public ETK? GetETKData(string message)
        {
            ETK etk = new ETK();
            string[] data = message.Split(';');

            etk.Time = Convert.ToDateTime(data[0].Substring(1, data[0].Length - 2));
            etk.Speed = Convert.ToDouble(data[1].Split(' ')[0].Substring(1));
            try
            {
                etk.Latitude = Convert.ToDouble(data[2].Split(',')[0].Substring(1).Replace('.', ','));
                etk.Longitude = Convert.ToDouble(data[2].Split(',')[1].Substring(1, data[2].Split(',')[1].Length - 2).Replace('.', ','));
            }
            catch
            {
                return null;
            }
            return etk;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter">Парамтр, по которому ищется максимум/минимум</param>
        /// <param name="findingMax">Если true, ищется максимум, иначе - минимум</param>
        /// <returns>Возвращает максимум/минимум указанного параметра из всех репортов</returns>
        public double FindMaxMin(ReportParameters parameter, bool findingMax)
        {
            if (!HasData)
            {
                MessageBox.Show("Нет считанных данных!");
                return Double.NaN;
            }

            double[] dataValues = new double[MessagesREPORT.Count];
            foreach(var report in MessagesREPORT)
            {
                switch (parameter)
                {
                    case (ReportParameters.LATITUDE):
                        {
                            dataValues[dataValues.Length] = report.Latitude;
                            break;
                        }
                    case (ReportParameters.LONGITUDE):
                        {
                            dataValues[dataValues.Length] = report.Longitude;
                            break;
                        }
                    case (ReportParameters.SPEED):
                        {
                            dataValues[dataValues.Length] = report.Speed;
                            break;
                        }
                    case (ReportParameters.DIR):
                        {
                            dataValues[dataValues.Length] = report.Dir;
                            break;
                        }
                    case (ReportParameters.SAT_NUM):
                        {
                            dataValues[dataValues.Length] = report.GLONASS_SAT_NO + report.GPS_SAT_NO;
                            break;
                        }
                    default:
                        {
                            MessageBox.Show("ОШИБКА!");
                            return Double.NaN;
                        }
                }
            }
            if (findingMax)
                return dataValues.Max();
            else
                return dataValues.Min();
        }
    }
}
