using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;


namespace Bomben
{
    class Matris3
    {
        

        public double[,] allaKombinationer = new double[1771561, 11];
        public double[] matrisUtanOddsKolumn1 = new double[1771561];
        public double[] matrisUtanOddsKolumn2 = new double[1771561];
        public double[] matrisUtanOddsKolumn3 = new double[1771561];
        public double[] matrisUtanOddsKolumn4 = new double[1771561];
        public double[] matrisUtanOddsKolumn5 = new double[1771561];
        public double[] matrisUtanOddsKolumn6 = new double[1771561];
        private int läggTillPlusRäknare = 0;
        private int MAX = 1771561;
               
        
        public void skapaMatrisUtanOddskolumn1()
        {
            int a = 0;
            int h = 0;
            for (int g = 0; g < MAX; g = g + 1)
            {
                if (g % 161051 == 0 && g != 0)
                {
                    a++;
                }
                this.matrisUtanOddsKolumn1[h++] = a;
            }
        }

        public void skapaMatrisUtanOddskolumn2()
        {
            int b = 0;
            int h = 0;
            for (int g = 0; g < MAX; g = g + 1)
            {
                if (g % 14641 == 0 && g != 0)
                {
                    b++;
                }
                if (g % 161051 == 0 && g != 0)
                {
                    b = 0;
                }
                this.matrisUtanOddsKolumn2[h++] = b;
            }
        }

        public void skapaMatrisUtanOddskolumn3()
        {
            int c = 0;
            int h = 0;
            for( int g = 0;g < MAX;g = g + 1 )
            {
                if (g % 1331 == 0 && g != 0)
                {
                    c++;
                }
                if (g % 14641 == 0 && g != 0)
                {
                    c = 0;
                }
                this.matrisUtanOddsKolumn3[h++] = c;
            }
        }

        public void skapaMatrisUtanOddskolumn4()
        {
            int d = 0;
            int h = 0;
            for( int g = 0;g < MAX;g = g + 1 )
            {
                if (g % 121 == 0 && g != 0)
                {
                    d++;
                }
                if (g % 1331 == 0 && g != 0)
                {
                    d = 0;
                }
                this.matrisUtanOddsKolumn4[h++] = d;
            }
        }

        public void skapaMatrisUtanOddskolumn5()
        {
            int e = 0;
            int h = 0;
            for( int g = 0;g < MAX;g = g + 1 )
            {
                if (g % 11 == 0 && g != 0)
                {
                    e++;
                }
                if (g % 121 == 0 && g != 0)
                {
                    e = 0;
                }
                this.matrisUtanOddsKolumn5[h++] = e;
            }
        }

        public void skapaMatrisUtanOddskolumn6()
        {
            int f = 0;
            int h = 0;
            for( int g = 0;g < MAX;g = g + 1 )
            {
                if (g % 11 == 0 && g != 0)
                {
                    f = 0;
                }
                this.matrisUtanOddsKolumn6[h++] = f++;

            }
        }
        
        public void skapaAllaResultatKombinationer()
        {
            
            //Skapa startvärden för kolumner
            skapaMatrisUtanOddskolumn1();
            skapaMatrisUtanOddskolumn2();
            skapaMatrisUtanOddskolumn3();
            skapaMatrisUtanOddskolumn4();
            skapaMatrisUtanOddskolumn5();
            skapaMatrisUtanOddskolumn6();
            
            
            //Lägg till enskilda matrisers kolumner i matrisUtanOdds.
            addColumn( 0, matrisUtanOddsKolumn1 );
            addColumn( 1, matrisUtanOddsKolumn2 );
            addColumn( 2, matrisUtanOddsKolumn3 );
            addColumn( 3, matrisUtanOddsKolumn4 );
            addColumn( 4, matrisUtanOddsKolumn5 );
            addColumn( 5, matrisUtanOddsKolumn6 );            
            
        }
        
        //intern metod som bara kan användas inuti klassen. Hjälper till att skriva värden från en matris till en annan.
        public void addColumn( int targetColumn, double[] sourceMatrix )
        {

            for( int row = 0;row < MAX;row = row + 1 )
            {
                allaKombinationer[row, targetColumn] = sourceMatrix[row];
            }
        }
            
        //Lägg till Poissonkolumnen
        public void läggTillPoissonKolumn(double[] poissonKolumn)
        {
            addColumn(6, poissonKolumn);
        }

        //Räkna om oddsen från Sv Spel med nytt radantal och ny omsättning. Skapar två Plus- och ROI-kolumner
        public void läggTillPlusOchROI(double[,] svSpelOdds, int bombenStatsSize, int antalPlus, int omsättning, double extrapott)
        {
            //float[,] floatSvSOdds =  svSpelOdds; //En tanke om att float blir snabbare än double.
            int sparKolumn;
            if (läggTillPlusRäknare == 0)
            {
                sparKolumn = 7;
                läggTillPlusRäknare++;
            }
            else
            {
                sparKolumn = 9;
                läggTillPlusRäknare++;
            }
            

            double ROI = ((0.6 * (Convert.ToDouble( omsättning ) + Convert.ToDouble( antalPlus ))) / Convert.ToDouble( antalPlus ));
            
            Parallel.For( 0, MAX, ii =>
                {
                    allaKombinationer[ii, sparKolumn] = ROI;
                    allaKombinationer[ii, (sparKolumn + 1)] = allaKombinationer[ii, sparKolumn] / allaKombinationer[ii, 6];
                });

            double firstTemp;
            double secondTemp;
            Parallel.For( 0, MAX, i =>
            {
                for( int j = 0; j < bombenStatsSize; j++ )
                {


                    if( allaKombinationer[i, 0] == svSpelOdds[j, 1] )
                    {
                        if( allaKombinationer[i, 1] == svSpelOdds[j, 2] )
                        {
                            if( allaKombinationer[i, 2] == svSpelOdds[j, 3] )
                            {
                                if( allaKombinationer[i, 3] == svSpelOdds[j, 4] )
                                {
                                    if( allaKombinationer[i, 4] == svSpelOdds[j, 5] )
                                    {
                                        if( allaKombinationer[i, 5] == svSpelOdds[j, 6] )
                                        {
                                            
                                            firstTemp = ((0.6 * (Convert.ToDouble(omsättning) + Convert.ToDouble(antalPlus))) + extrapott) /
                                                ((((0.6 * (Convert.ToDouble(omsättning))) + extrapott) / svSpelOdds[j, 0]) + Convert.ToDouble(antalPlus));
                                            allaKombinationer[i, sparKolumn] = firstTemp;
                                            secondTemp = allaKombinationer[i, sparKolumn] / allaKombinationer[i, 6];
                                            allaKombinationer[i, (sparKolumn + 1)] = secondTemp;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            } );
   

        }

        
        public void writeToFile()
        {
            
            StreamWriter sw = new StreamWriter("VinnandeRader.txt");

            sw.WriteLine("HM1,BM1,HM2,BM2,HM3,BM3,Poisson,+1,+1ROI,+3,+3ROI");
            
            for (int rad = 0; rad < 1771561; rad++)
            {
                if (allaKombinationer[rad, 10] > 1 && allaKombinationer[rad, 0] < 7 && allaKombinationer[rad, 1] < 7 && allaKombinationer[rad, 2] < 7 && allaKombinationer[rad, 3] < 7 && allaKombinationer[rad, 4] < 7 && allaKombinationer[rad, 5] < 7)
                {
                    for (int kol = 0; kol < 11; kol++)
                    {
                        sw.Write(allaKombinationer[rad, kol]);
                        sw.Write("; ");
                    }
                    sw.Write("\r\n");
                }
                
            }
            
            sw.Close();

                       
        }

     

        
    }
}
