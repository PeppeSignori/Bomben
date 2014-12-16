﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Bomben
{
    class Match
    {
        public double[] hemmaMålSannolikhet = new double[11];
        public double[] bortaMålSannolikhet = new double[11];
        public double[] resultat = new double[121];


        public void poisson(double lambda, string hemmaborta)
        {
            double[] målsannolikhet = new double[11];

            målsannolikhet[0] = Math.Pow((double)lambda, (double)0) * Math.Pow(Math.E, (double)-lambda) / 1;
            målsannolikhet[1] = Math.Pow((double)lambda, (double)1) * Math.Pow(Math.E, (double)-lambda) / 1;
            målsannolikhet[2] = Math.Pow((double)lambda, (double)2) * Math.Pow(Math.E, (double)-lambda) / (1 * 2);
            målsannolikhet[3] = Math.Pow((double)lambda, (double)3) * Math.Pow(Math.E, (double)-lambda) / (1 * 2 * 3);
            målsannolikhet[4] = Math.Pow((double)lambda, (double)4) * Math.Pow(Math.E, (double)-lambda) / (1 * 2 * 3 * 4);
            målsannolikhet[5] = Math.Pow((double)lambda, (double)5) * Math.Pow(Math.E, (double)-lambda) / (1 * 2 * 3 * 4 * 5);
            målsannolikhet[6] = Math.Pow((double)lambda, (double)6) * Math.Pow(Math.E, (double)-lambda) / (1 * 2 * 3 * 4 * 5 * 6);
            målsannolikhet[7] = Math.Pow((double)lambda, (double)7) * Math.Pow(Math.E, (double)-lambda) / (1 * 2 * 3 * 4 * 5 * 6 * 7);
            målsannolikhet[8] = Math.Pow((double)lambda, (double)8) * Math.Pow(Math.E, (double)-lambda) / (1 * 2 * 3 * 4 * 5 * 6 * 7 * 8);
            målsannolikhet[9] = Math.Pow((double)lambda, (double)9) * Math.Pow(Math.E, (double)-lambda) / (1 * 2 * 3 * 4 * 5 * 6 * 7 * 8 * 9);
            målsannolikhet[10] = Math.Pow((double)lambda, (double)10) * Math.Pow(Math.E, (double)-lambda) / (1 * 2 * 3 * 4 * 5 * 6 * 7 * 8 * 9 * 10);

            if (hemmaborta == "hemma")
            {
                hemmaMålSannolikhet = målsannolikhet;
            }
            else
            {
                bortaMålSannolikhet = målsannolikhet;
            }

        }

        public void beräknaResultat()
        {
            int j = 0;
            int k = 0;
            int l = 0;

            for (int m = 0; m < 121; m = m + 1)
            {           
                if (m%11 == 0 && m != 0)
                {
                    j++;
                    k = 0;
                }

                this.resultat[l++] = this.hemmaMålSannolikhet[j] * this.bortaMålSannolikhet[k++];
            }
        }



    }
}