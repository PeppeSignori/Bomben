using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;


namespace Bomben
{
    class Matris
    {

        public double[,] allaKombinationer = new double[1771561, 11];
        public double[] matrisUtanOddsKolumn1 = new double[1771561];
        public double[] matrisUtanOddsKolumn2 = new double[1771561];
        public double[] matrisUtanOddsKolumn3 = new double[1771561];
        public double[] matrisUtanOddsKolumn4 = new double[1771561];
        public double[] matrisUtanOddsKolumn5 = new double[1771561];
        public double[] matrisUtanOddsKolumn6 = new double[1771561];
        private double[] buffer7 = new double[1771561];
        private double[] buffer8 = new double[1771561];
        private double[] buffer9 = new double[1771561];
        private double[] buffer10 = new double[1771561];
        private int läggTillPlusRäknare = 0;
        private const int MAX = 1771561;

        private void skapaMatrisUtanOddskolumn1()
        {
            int a = 0;
            int h = 0;
            for (int g = 0; g < 1771561; g = g + 1)
            {
                if (g % 161051 == 0 && g != 0)
                {
                    a++;
                }
                this.matrisUtanOddsKolumn1[h++] = a;
            }
        }

        private void skapaMatrisUtanOddskolumn2()
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

        private void skapaMatrisUtanOddskolumn3()
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

        private void skapaMatrisUtanOddskolumn4()
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

        private void skapaMatrisUtanOddskolumn5()
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

        private void skapaMatrisUtanOddskolumn6()
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
            addColumn( matrisUtanOddsKolumn1, allaKombinationer, 0 );
            addColumn( matrisUtanOddsKolumn2, allaKombinationer, 1 );
            addColumn( matrisUtanOddsKolumn3, allaKombinationer, 2 );
            addColumn( matrisUtanOddsKolumn4, allaKombinationer, 3 );
            addColumn( matrisUtanOddsKolumn5, allaKombinationer, 4 );
            addColumn( matrisUtanOddsKolumn6, allaKombinationer, 5 );            
            

        }
        
        //Hjälper till att skriva värden från en matris till en annan.
        public void addColumn( double[] source1DMatrix, double[,] target2DMatrix, int targetColumn )
        {

            for( int row = 0;row < MAX;row = row + 1 )
            {
                target2DMatrix[row, targetColumn] = source1DMatrix[row];    
            }
        }
            
        //Lägg till Poissonkolumnen
        public void läggTillPoissonKolumn(double[] poissonColumn, int targetColumn)
        {
            addColumn( poissonColumn, allaKombinationer, 6 );
            
        }

        //Räkna om oddsen från Sv Spel med nytt radantal och ny omsättning. Skapar två Plus- och ROI-kolumner
        public void läggTillPlusOchROI(double[,] svSpelOdds, int bombenStatsSize, int antalPlus, int omsättning)
        {
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

            for ( int i = 0; i < MAX; i++)
            {
                for(int j = 0;j < bombenStatsSize;j++ )
                {
                    allaKombinationer[i, sparKolumn] = ((0.6 * (Convert.ToDouble( omsättning ) + Convert.ToDouble( antalPlus ))) / Convert.ToDouble( antalPlus ));
                    allaKombinationer[i, (sparKolumn + 1)] = allaKombinationer[i, sparKolumn] / allaKombinationer[i, 6];

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
                                            double firstTemp = ((0.6 * (Convert.ToDouble( omsättning ) + Convert.ToDouble( antalPlus ))) / ((0.6 * Convert.ToDouble( omsättning ) / svSpelOdds[j, 0]) + Convert.ToDouble( antalPlus )));
                                            allaKombinationer[i, sparKolumn] = firstTemp;
                                            double secondTemp = allaKombinationer[i, sparKolumn] / allaKombinationer[i, 6];
                                            allaKombinationer[i, (sparKolumn + 1)] = secondTemp;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            

        }

        //Räkna om oddsen från Sv Spel med nytt radantal och ny omsättning. Skapar två Plus- och ROI-kolumner
        public void läggTillPlus( double[,] svSpelOdds, int bombenStatsSize, int antalPlus, int omsättning, int sparKolumn, int bufferNumber)
        {
            double ROI = ((0.6 * (Convert.ToDouble( omsättning ) + Convert.ToDouble( antalPlus ))) / Convert.ToDouble( antalPlus ));
            
                                                
            for( int i = 0;i < MAX;i++ )
            {
                for( int j = 0;j < bombenStatsSize;j++ )
                {
                    allaKombinationer[i, sparKolumn] = ROI;
                    //allaKombinationer[i, (sparKolumn + 1)] = allaKombinationer[i, sparKolumn] / allaKombinationer[i, 6];

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
                                            allaKombinationer[i, (sparKolumn )] = allaKombinationer[i, sparKolumn] / allaKombinationer[i, 6];
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        //Räkna om oddsen från Sv Spel med nytt radantal och ny omsättning. Skapar två Plus- och ROI-kolumner
        public void läggTillROI( double[,] svSpelOdds, int bombenStatsSize, int antalPlus, int omsättning, int sparKolumn )
        {
            double ROI = ((0.6 * (Convert.ToDouble( omsättning ) + Convert.ToDouble( antalPlus ))) / Convert.ToDouble( antalPlus ));

            for( int i = 0;i < MAX;i++ )
            {
                for( int j = 0;j < bombenStatsSize;j++ )
                {
                    //allaKombinationer[i, sparKolumn] = ROI;
                    allaKombinationer[i, sparKolumn] = allaKombinationer[i, sparKolumn] / allaKombinationer[i, 6];

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
                                            allaKombinationer[i, sparKolumn] = ((0.6 * (Convert.ToDouble( omsättning ) + Convert.ToDouble( antalPlus ))) / ((0.6 * Convert.ToDouble( omsättning ) / svSpelOdds[j, 0]) + Convert.ToDouble( antalPlus )));
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public void writeToFile()
        {
            
            StreamWriter sw = new StreamWriter("VinnandeRader.txt");

            sw.WriteLine("HM1,BM1,HM2,BM2,HM3,BM3,Poisson,+1,+1ROI,+3,+3ROI");
            
            for (int rad = 0; rad < 1771561; rad++)
            {
                if (allaKombinationer[rad, 10] > 14 && allaKombinationer[rad, 0] < 7 && allaKombinationer[rad, 1] < 7 && allaKombinationer[rad, 2] < 7 && allaKombinationer[rad, 3] < 7 && allaKombinationer[rad, 4] < 7 && allaKombinationer[rad, 5] < 7)
                {
                    for (int kol = 0; kol < 11; kol++)
                    {
                        sw.Write(allaKombinationer[rad, kol]);
                        sw.Write(", ");
                    }
                    sw.Write("\r\n");
                }
                
            }
            
            sw.Close();
        }

        
    }
}
