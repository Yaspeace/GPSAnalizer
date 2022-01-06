using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesDidorenko
{
    public static class Matrix
    {
        public static double[,] Transpose(double[,] matr)
        {
            int m = matr.GetLength(0); //строк
            int n = matr.GetLength(1); //столбцов
            double[,] res = new double[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    res[i, j] = matr[j, i];
            return res;
        }
        public static double[,] Summ(double[,] matr1, double[,] matr2)
        {
            if (matr1.GetLength(0) != matr2.GetLength(0) || matr1.GetLength(1) != matr2.GetLength(1))
                return null;
            int m = matr1.GetLength(0);
            int n = matr1.GetLength(1);
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    matr1[i, j] += matr2[i, j];
            return matr1;
        }
        public static double[,] Multiply(double[,] matr1, double[,] matr2)
        {
            int m1 = matr1.GetLength(0); //строк первой
            int n1 = matr1.GetLength(1); //столбцов первой
            int m2 = matr2.GetLength(0);
            int n2 = matr2.GetLength(1);

            if (n1 != m2) //перемножать можем только матрицы, если кол-во столбцов первой == кол-ву строк второй
                return null;
            double[,] res = new double[m1, n2];
            for(int i = 0; i < m1; i++)
            {
                for(int j = 0; j < n2; j++)
                {
                    res[i, j] = 0;
                    for (int k = 0; k < m2; k++)
                        res[i,j] += matr1[i, k] * matr2[k, j];
                }
            }
            return res;
        }
    }
}
