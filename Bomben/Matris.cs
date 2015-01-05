using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Bomben
{
    class Matris
    {

        public double[,] matrisUtanOdds = new double[1771561, 7];
        public double[] matrisUtanOddsKolumn1 = new double[1771561];
        public double[] matrisUtanOddsKolumn2 = new double[1771561];
        public double[] matrisUtanOddsKolumn3 = new double[1771561];
        public double[] matrisUtanOddsKolumn4 = new double[1771561];
        public double[] matrisUtanOddsKolumn5 = new double[1771561];
        public double[] matrisUtanOddsKolumn6 = new double[1771561];
        
        public void skapaMatrisUtanOddskolumn1()
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

        public void skapaMatrisUtanOddskolumn2()
        {
            int b = 0;
            int h = 0;
            for (int g = 0; g < 1771561; g = g + 1)
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
            for (int g = 0; g < 1771561; g = g + 1)
            {
                if (g % 1331 == 0 && g != 0)
                {
                    c++;
                }
                if (g % 14641 == 0 && g != 0)
                {
                    c = 0;
                }
                this.matrisUtanOddsKolumn2[h++] = c;
            }
        }

        public void skapaMatrisUtanOddskolumn4()
        {
            int d = 0;
            int h = 0;
            for (int g = 0; g < 1771561; g = g + 1)
            {
                if (g % 121 == 0 && g != 0)
                {
                    d++;
                }
                if (g % 1331 == 0 && g != 0)
                {
                    d = 0;
                }
                this.matrisUtanOddsKolumn2[h++] = d;
            }
        }

        public void skapaMatrisUtanOddskolumn5()
        {
            int e = 0;
            int h = 0;
            for (int g = 0; g < 1771561; g = g + 1)
            {
                if (g % 11 == 0 && g != 0)
                {
                    e++;
                }
                if (g % 121 == 0 && g != 0)
                {
                    e = 0;
                }
                this.matrisUtanOddsKolumn2[h++] = e;
            }
        }

        public void skapaMatrisUtanOddskolumn6()
        {
            int f = 0;
            int h = 0;
            for (int g = 0; g < 1771561; g = g + 1)
            {
                if (g % 11 == 0 && g != 0)
                {
                    f = 0;
                }
                this.matrisUtanOddsKolumn2[h++] = f;
            }
        }



        public void skapaMatrisUtanOdds()
        {
            
            //Så här skulle det se ut om matrisUtanOddsKolumnerna var private istället för public
            //Då skulle skapaMatrisUtanOdds anropa dem. "Användaren" ute i program kan inte styra 
            //men det blir snyggare tycker jag mindre text ute i Program. 

            /*
            skapaMatrisUtanOddskolumn1();
            skapaMatrisUtanOddskolumn2();
            skapaMatrisUtanOddskolumn3();
            skapaMatrisUtanOddskolumn4();
            skapaMatrisUtanOddskolumn5();
            skapaMatrisUtanOddskolumn6();
            */

            //Lägg till enskilda matrisers kolumner i matrisUtanOdds.
            addColumn( 0, matrisUtanOddsKolumn1 );
            addColumn( 1, matrisUtanOddsKolumn2 );
            addColumn( 2, matrisUtanOddsKolumn3 );
            addColumn( 3, matrisUtanOddsKolumn4 );
            addColumn( 4, matrisUtanOddsKolumn5 );
            addColumn( 5, matrisUtanOddsKolumn6 );            
            
        }
        
        //intern metod som bara kan användas inuti klassen. Hjälper till att skriva värden från en matris till en annan.
        private void addColumn( int targetColumn, double[] sourceMatrix )
        {
            
            for (int row = 0; row < 1771561; row = row + 1)
            {
                matrisUtanOdds[row, targetColumn] = sourceMatrix[row];    
            }

                        
            
        }


    }
}
