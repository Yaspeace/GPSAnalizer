using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace InterfacesDidorenko
{
    public enum MsgTypes { REPORT, GGA, RMC, GSV, VTG }
    public enum ReportParameters { ID, DATAANDTIME, LATITUDE, NS, LONGITUDE, WE, SPEED, DIR, SAT_NUM }
    public struct Report
    {
        public uint ID;
        public DateTime DateAndTime;
        public double Latitude;
        public char NS;
        public double Longitude;
        public char WE;
        public double Speed;
        public double Dir;
        public double GLONASS_SAT_NO;
        public double GPS_SAT_NO;
        public Report(uint ID, DateTime DateAndTime, double Latitude, char NS, double Longitude, char WE, double Speed, double Dir, double GLONASS_SAT_NO, double GPS_SAT_NO)
        {
            this.ID = ID;
            this.DateAndTime = DateAndTime;
            this.Latitude = Latitude;
            this.NS = NS;
            this.Longitude = Longitude;
            this.WE = WE;
            this.Speed = Speed;
            this.Dir = Dir;
            this.GLONASS_SAT_NO = GLONASS_SAT_NO;
            this.GPS_SAT_NO = GPS_SAT_NO;
        }
        public double GetField(string fieldName)
        {
            switch (fieldName)
            {
                case ("ID"):
                case ("id"):
                        return ID;
                case ("Time"):
                case ("Время"):
                    return DateAndTime.Hour + (DateAndTime.Minute / 60.0) + (DateAndTime.Second / 3600.0);
                case ("Latitude"):
                case ("Широта"):
                        return Latitude;
                case ("Longitude"):
                case ("Долгота"):
                    return Longitude;
                case ("Speed"):
                case ("Скорость"):
                    return Speed;
                case ("Dir"):
                case ("Direction"):
                case ("Направление"):
                    return Dir;
                case ("Sat_num"):
                case ("Кол-во спутников"):
                    return (GLONASS_SAT_NO + GPS_SAT_NO);
                default:
                    return 0;
            }
        }
    }
    public struct GGA
    {
        public DateTime time;
        public double Latitude;
        public char NS;
        public double Longitude;
        public char WE;
        public int positionFix;
        public int SatNum;
        public double HDOP;
        public double Altitude;
        public int ControlSum;

        public GGA(DateTime time, double Latitude, char NS, double Longitude, char WE, int positionFix, int SatNum, double HDOP, double Altitude, int ControlSum)
        {
            this.time = time;
            this.Latitude = Latitude;
            this.NS = NS;
            this.Longitude = Longitude;
            this.WE = WE;
            this.positionFix = positionFix;
            this.SatNum = SatNum;
            this.HDOP = HDOP;
            this.Altitude = Altitude;
            this.ControlSum = ControlSum;
        }
        public double GetField(string fieldName)
        {
            switch(fieldName)
            {
                case ("Time"):
                case ("Время"):
                    return time.Year*10e6 + time.Month*10e4 + time.Day*100 + time.Hour + (time.Minute / 60.0) + (time.Second / 3600.0);
                case ("Latitude"):
                case ("Широта"):
                    return Latitude;
                case ("Longitude"):
                case ("Долгота"):
                    return Longitude;
                case ("PositionFix"):
                case ("Флаг фиксации позиции"):
                    return positionFix;
                case ("SatNum"):
                case ("Sat_num"):
                case ("Кол-во спутников"):
                    return SatNum;
                case ("HDOP"):
                    return HDOP;
                case ("Altitude"):
                case ("Высота"):
                    return Altitude;
                case ("ControlSum"):
                case ("Контрольная сумма"):
                    return ControlSum;
                default:
                    return 0;
            }
        }
    }

    public struct GSA
    {
        public char Mode1;
        public int Mode2;
        public int[] UsedSats;
        public double PDOP;
        public double HDOP;
        public double VDOP;
        public int ControlSum;

        public GSA(char mode1, int mode2, int[] usedSats, double pDOP, double hDOP, double vDOP, int controlSum)
        {
            Mode1 = mode1;
            Mode2 = mode2;
            UsedSats = usedSats;
            PDOP = pDOP;
            HDOP = hDOP;
            VDOP = vDOP;
            ControlSum = controlSum;
        }
    }

    public struct GSVSatInfo
    {
        public int SatID;
        public int Elevation;
        public int Azimuth;
        public int SignalPower;

        public GSVSatInfo(int satID, int elevation, int azimuth, int signalPower)
        {
            SatID = satID;
            Elevation = elevation;
            Azimuth = azimuth;
            SignalPower = signalPower;
        }
    }

    public struct GSV
    {
        public int NumOfMessages;
        public int MessageNum;
        public int SatsInView;
        public GSVSatInfo[] Sats;
        public int ControlSum;

        public GSV(int numOfMessages, int messageNum, int satsInView, GSVSatInfo[] sats, int controlSum)
        {
            NumOfMessages = numOfMessages;
            MessageNum = messageNum;
            SatsInView = satsInView;
            Sats = sats;
            ControlSum = controlSum;
        }
    }

    public struct RMC
    {
        public DateTime UTCTime;
        public char Status;
        public double Latitude;
        public char NS;
        public double Longitude;
        public char WE;
        public double Speed;
        public double Course;
        public DateTime Date;
        public int ControlSum;
        public DateTime DateAndTime;

        public RMC(DateTime uTCTime, char status, double latitude, char nS, double longitude, char wE, double speed, double course, DateTime date, int controlSum)
        {
            UTCTime = uTCTime;
            Status = status;
            Latitude = latitude;
            NS = nS;
            Longitude = longitude;
            WE = wE;
            Speed = speed;
            Course = course;
            Date = date;
            ControlSum = controlSum;
            DateAndTime = new DateTime(date.Year, date.Month, date.Day, uTCTime.Hour, uTCTime.Minute, uTCTime.Second, uTCTime.Millisecond);
        }
        public double GetField(string fieldName)
        {
            switch(fieldName)
            {
                case ("Time"):
                case ("Время"):
                    return UTCTime.Hour + (UTCTime.Minute / 60.0) + (UTCTime.Second / 3600.0);
                case ("Latitude"):
                case ("Широта"):
                    return Latitude;
                case ("Longitude"):
                case ("Долгота"):
                    return Longitude;
                case ("Speed"):
                case ("Скорость"):
                    return Speed;
                case ("Course"):
                case ("Направление"):
                    return Course;
                case ("ControlSum"):
                case ("Контрольная сумма"):
                    return ControlSum;
                default:
                    return 0;
            }
        }
    }

    public struct VTG
    {
        public double CourseTrueNorth;
        public char ReferenceTrueNorth;
        public double CourseMagNorth;
        public char ReferenceMagNorth;
        public double SpeedKnots;
        public char Units;
        public double SpeedKMH;
        public char UnitsKMH;
        public int ControlSum;

        public VTG(double courseTrueNorth, char referenceTrueNorth, double courseMagNorth, char referenceMagNorth, double speedKnots, char units, double speedKMH, char unitsKMH, int controlSum)
        {
            CourseTrueNorth = courseTrueNorth;
            ReferenceTrueNorth = referenceTrueNorth;
            CourseMagNorth = courseMagNorth;
            ReferenceMagNorth = referenceMagNorth;
            SpeedKnots = speedKnots;
            Units = units;
            SpeedKMH = speedKMH;
            UnitsKMH = unitsKMH;
            ControlSum = controlSum;
        }

        public double GetField(string fieldName)
        {
            switch (fieldName)
            {
                case ("CourceTrueNorth"):
                case ("Курс на истинный север"):
                    return CourseTrueNorth;
                case ("CourseMagNorth"):
                case ("Курс на магнитный север"):
                    return CourseMagNorth;
                case ("SpeedKnots"):
                case ("Speed in knots"):
                case ("Скорость в узлах"):
                    return SpeedKnots;
                case ("SpeedKMH"):
                case ("Speed in KMH"):
                case ("Скорость в км/ч"):
                    return SpeedKMH;
                case ("ControlSum"):
                case ("Контрольная сумма"):
                    return ControlSum;
                default:
                    return 0;
            }
        }
    }

    public struct ETK
    {
        public DateTime Time;
        public double Speed;
        public double Latitude;
        public double Longitude;

        public ETK(DateTime time, double speed, double latitude, double longitude)
        {
            Time = time;
            Speed = speed;
            Latitude = latitude;
            Longitude = longitude;
        }

        public double GetField(string field)
        {
            switch (field)
            {
                case "Time":
                case "Время":
                    return Time.Year * 10e6 + Time.Month * 10e4 + Time.Day * 100 + Time.Hour + (Time.Minute / 60.0) + (Time.Second / 3600.0);
                case "Speed":
                case "Скорость":
                    return Speed;
                case "Широта":
                case "Latitude":
                    return Latitude;
                case "Долгота":
                case "Longitude":
                    return Longitude;
                default:
                    return 0;
            }
        }
    }
}