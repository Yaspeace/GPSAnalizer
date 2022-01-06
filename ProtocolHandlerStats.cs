using System;
using System.Collections.Generic;

namespace InterfacesDidorenko
{
    public class ProtocolHandlerStats
    {
        private ProtocolHandler _ph;
        private bool avStatsCached;
        private bool dispCached;
        private bool cov_matrCached;
        /// <summary>
        /// 0-долгота, 1-широта, 2-высота.
        /// </summary>
        private double[] avStats;
        public double[] AverageStats
        {
            get
            {
                if (avStatsCached)
                    return avStats;
                avStats = new double[3];
                for (int i = 0; i < avStats.Length; i++)
                    avStats[i] = 0;
                int N = 0;
                foreach (var gga in _ph.MessagesGGA)
                {
                    if (gga.positionFix > 0)
                    {
                        N++;
                        avStats[0] += gga.Latitude;
                        avStats[1] += gga.Longitude;
                        avStats[2] += gga.Altitude;
                    }
                }
                avStats[0] /= N;
                avStats[1] /= N;
                avStats[2] /= N;
                avStatsCached = true;
                return avStats;
            }
        }
        private List<double[]> dispertions;
        public List<double[]> Dispertions
        {
            get
            {
                if (dispCached)
                    return dispertions;
                dispertions = new List<double[]>();
                foreach(var gga in _ph.MessagesGGA)
                {
                    double[] disp_vector = new double[4];
                    disp_vector[0] = gga.Latitude - AverageStats[0];
                    disp_vector[1] = gga.Longitude - AverageStats[1];
                    disp_vector[2] = gga.Altitude - AverageStats[2];
                    disp_vector[3] = gga.GetField("Time");
                    dispertions.Add(disp_vector);
                }
                dispCached = true;
                return dispertions;
            }
        }
        private double[,] covMatr;
        public double[,] CovariationMatr
        {
            get
            {
                if (cov_matrCached)
                    return covMatr;
                covMatr = new double[3, 3];
                int N = 0;
                foreach(var disp_vec in Dispertions)
                {
                    double[,] disp_matr = new double[3, 1];
                    for (int i = 0; i < 3; i++)
                        disp_matr[i, 0] = disp_vec[i];
                    double[,] disp_matr_T = Matrix.Transpose(disp_matr);
                    covMatr = Matrix.Summ(covMatr, Matrix.Multiply(disp_matr, disp_matr_T));
                    N++;
                }
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                        covMatr[i, j] /= N;
                cov_matrCached = true;
                return covMatr;
            }
        }
        private double[] sko;
        public double[] SKO
        {
            get
            {
                sko = new double[3];
                sko[0] = Math.Sqrt(CovariationMatr[0, 0]);
                sko[1] = Math.Sqrt(CovariationMatr[1, 1]);
                sko[2] = Math.Sqrt(CovariationMatr[2, 2]);
                return sko;
            }
        }
        private double[,] corMatr;
        public double[,] CorellationMatr
        {
            get
            {
                double[,] idk = new double[3, 3];
                idk[0, 0] = 1 / SKO[0];
                idk[1, 1] = 1 / SKO[1];
                idk[2, 2] = 1 / SKO[2];
                corMatr = Matrix.Multiply(idk, Matrix.Multiply(CovariationMatr, idk));
                return corMatr;
            }
        }
        private double[] anomals;
        public double[] AnomalDispersionNum
        {
            get
            {
                anomals = new double[3];
                foreach(var disp in Dispertions)
                {
                    if (disp[0] > 3 * SKO[0])
                        anomals[0]++;
                    if (disp[1] > 3 * SKO[1])
                        anomals[1]++;
                    if(disp[2] > 3 * SKO[2])
                        anomals[2]++;
                }
                return anomals;
            }
        }
        public ProtocolHandlerStats(ProtocolHandler protocolHandler)
        {
            _ph = protocolHandler;
            avStatsCached = false;
            dispCached = false;
            cov_matrCached = false;
        }
    }
}
