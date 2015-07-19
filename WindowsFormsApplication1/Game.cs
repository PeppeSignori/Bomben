using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Bomben
{
    public class Game
    {
        public string hemmaLag { get; set; }
        public string bortaLag { get; set; }
        public double[] hemmaMålSannolikhet = new double[11];
        public double[] bortaMålSannolikhet = new double[11];
        public double[] resultat = new double[121];
        public double odds1 { get; set; }
        public double oddsX { get; set; }
        public double odds2 { get; set; }
        public double antalMål { get; set; }
        public double över { get; set; }
        public double under { get; set; }
        public double förväntatAntalmål { get; set; }
        public double hemma { get; set; }
        public double borta { get; set; }
        public double hemmaLambda { get; set; }
        public double bortaLambda { get; set; }
        public double underSannolikhet { get; set; }


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

        public void beräknaLambda()
        {
            this.hemmaLambda = this.hemma * this.förväntatAntalmål;
            this.bortaLambda = this.borta * this.förväntatAntalmål;
        }

        public void sättOddsTill100Procent()
        {
            this.hemma = (1 / this.odds1 + (1 / this.oddsX)/2) / (1 / this.odds1+ 1 / this.oddsX + 1 / this.odds2);
            this.borta = (1 / this.odds2 + (1 / this.oddsX)/2) / (1 / this.odds1 + 1 / this.oddsX + 1 / this.odds2);       
        }

        public void sättÖverUnderTill100Procent()
        {

            double NewÖver = (1 / this.över) / (1 / this.över + 1 / this.under);
            double NewUnder = (1 / this.under) / (1 / this.över + 1 / this.under);
            this.över = NewÖver;
            this.under = NewUnder;
        }

        public void beräknaÖverUnder(double överUnderLina)
        {
            this.underSannolikhet = 0;
            int antalLoopar = Convert.ToInt32(överUnderLina + 0.5);
            int yttreAntalLoopar = antalLoopar;
            for (int m = 0; m < 11 * yttreAntalLoopar; m = m + 11)
            {
                antalLoopar -= 1;
                for (int n = (antalLoopar); n >= 0; n = n - 1)
                {
                    this.underSannolikhet = this.underSannolikhet + resultat[m + n];
                }

            }


            
        }


        public void beräknaFörväntadMålantal()
        {
            //Räkna fram förväntat målantal. Startar med det värde som skrivs in i gui, tex 2,5. 
            double startvärde = this.förväntatAntalmål;
            double bunder = this.under;

            this.beräknaLambda();
            this.poisson(this.hemmaLambda, "hemma");
            this.poisson(this.bortaLambda, "borta");
            this.beräknaResultat();
            this.beräknaÖverUnder(startvärde);


            bool upDirection = this.underSannolikhet > bunder ? true : false;

            while( Math.Abs(this.underSannolikhet - bunder) > 0.001 )
            {
                if (upDirection)
                {
                    this.förväntatAntalmål += 0.01; 
                }
                else
                {
                    this.förväntatAntalmål -= 0.01;
                }

                //Sannolikheterna från Poisson fås mha oddsen på 1,X,2 som skrivs in i gui och startvärdet+-0,01 på förväntat målantal.
                this.beräknaLambda();
                this.poisson(this.hemmaLambda, "hemma");
                this.poisson(this.bortaLambda, "borta");
                this.beräknaResultat();
                this.beräknaÖverUnder(startvärde);

                //Sannolikheterna från bolag (gui) räknas fram genom P(över)=(1/över)/(1/över + 1/under) & P(under)=(1/under)/(1/över + 1/under). 
         
                //Om sannolikheten på över 2,5 mål från Poisson är högre än motsvarande sannolikhet från bolag så sänk startvärdet på målantal med 0,01. 
                //Om sannolikheten på över 2,5 mål från Poisson är lägre än motsvarande sannolikhet från bolag så höj startvärdet på målantal med 0,01.

            }


            

        }



    }
}