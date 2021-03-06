﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Bomben
{
    public class Game
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


        

        public double [] oddsPlus = new double [1771561];
        public void beräknaOddsPlus1(int adderadeRader, int turnOver, double[,] stats)
        {

            
            for (int m = 0; m < 1771561; m = m + 1)
            {
                if (stats[m,0] != 0)
                {
                    this.oddsPlus[m] = (0.6 * (turnOver + adderadeRader) ) / (1 + 0.6 * (turnOver + 1) / stats[m,0]);
                }
                else
                {
                    this.oddsPlus[m] = (0.6 * (turnOver + 1));
                }
            }
        }


        public double beräknaÖverUnder(double överUnderLina)
        {
            double underSannolikhet = 0;
            int antalLoopar = Convert.ToInt32(överUnderLina + 0.5);
            int yttreAntalLoopar = antalLoopar;
            for (int m = 0; m < 11*yttreAntalLoopar; m = m + 11)
            {
                antalLoopar -= 1;
                for (int n = (antalLoopar); n >= 0; n = n - 1)
                {
                    underSannolikhet = underSannolikhet + resultat[m + n]; 
                }

            }


                return underSannolikhet;
        }


        public double beräknaFörväntadMålantal(double etta, double kryss, double tvåa, double startvärde, double pöver, double punder, double böver, double bunder)
        {
            //Starta med ÖverUnderLina som startvärde
            punder = Math.Round(1 / punder, 2);
         

            //Om pöver > böver minska startvärde med 0.01 osv tills pöver=böver och/eller punder=bunder
            if (punder > bunder)
            {
                while (punder != bunder && pöver != böver)
                {
                    startvärde = startvärde - 0.01;

                }

            }




            return startvärde;
        }

        

    }
}