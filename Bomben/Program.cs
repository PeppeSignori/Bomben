using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Bomben
{
    class Program
    {
        static void Main(string[] args)
        {

            SvSMobileSiteImporter bomb = new SvSMobileSiteImporter();
            int numberOfPlays = bomb.getInfo( new Uri(@"https://www.svenskaspel.se/bomben") );
            
            //Match object
            Game Match1 = new Game();
            Game Match2 = new Game();
            Game Match3 = new Game();
            Game Match4 = new Game();

            Console.WriteLine("Extrapott?");
            double extrapott = Convert.ToDouble(Console.ReadLine());           

            // Match 1
            Console.WriteLine("Antal Bomber: " + numberOfPlays);

            Console.WriteLine("Match 1");
            Console.WriteLine("-------");
            Console.WriteLine();

            Console.Write("Odds på 1: ");
            double M11 = 1 / Convert.ToDouble(Console.ReadLine());
            Console.Write("Odds på X: ");
            double M1X = 1 / Convert.ToDouble(Console.ReadLine());
            Console.Write("Odds på 2: ");
            double M12 = 1 / Convert.ToDouble(Console.ReadLine());

            Console.WriteLine();

            Console.Write("Över/Under [2,5]/[5,5]: ");
            double M1ÖU = Convert.ToDouble(Console.ReadLine()); 
            while ((M1ÖU != 2.5) && (M1ÖU != 5.5))
            {
                Console.Write("Över/Under [2,5]/[5,5]: ");
                M1ÖU = Convert.ToDouble(Console.ReadLine());
            }

            Console.Write("Odds på över " + M1ÖU + ":  ");
            double M1Ö = 1 / Convert.ToDouble(Console.ReadLine());
            Console.Write("Odds på under " + M1ÖU + ": ");
            double M1U = 1 / Convert.ToDouble(Console.ReadLine());
            double M1HÖ = (M1Ö / (M1Ö + M1U)); //Gör till en egen metod i game
            double M1HU = (M1U / (M1Ö + M1U)); //Gör till en egen metod i game

            Console.WriteLine();

            Console.Write("Ändra nåt? [j]: ");
            string answer = Console.ReadLine();

            while (answer == "j")
            {

                Console.WriteLine();

                Console.Write("Odds på 1: ");
                M11 = 1 / Convert.ToDouble(Console.ReadLine());
                Console.Write("Odds på X: ");
                M1X = 1 / Convert.ToDouble(Console.ReadLine());
                Console.Write("Odds på 2: ");
                M12 = 1 / Convert.ToDouble(Console.ReadLine());

                Console.WriteLine();

                Console.Write("Över/Under [2,5]/[5,5]: ");
                M1ÖU = Convert.ToDouble(Console.ReadLine());
                Console.Write("Odds på över " + M1ÖU + ":  ");
                M1Ö = 1 / Convert.ToDouble(Console.ReadLine());
                Console.Write("Odds på under " + M1ÖU + ": ");
                M1U = 1 / Convert.ToDouble(Console.ReadLine());
                M1HÖ = (M1Ö / (M1Ö + M1U));
                M1HU = (M1U / (M1Ö + M1U));

                Console.WriteLine();

                Console.Write("Ändra nåt? [j]: ");
                answer = Console.ReadLine();
            }

            Console.WriteLine();

            Console.WriteLine("100 % odds på över " + M1ÖU + ":  " + Math.Round(1 / M1HÖ, 2)); 
            Console.WriteLine("100 % odds på under " + M1ÖU + ": " + Math.Round(1 / M1HU, 2));

            Console.WriteLine();

            Console.Write("Förväntat målantal: ");
            double M1M = Convert.ToDouble(Console.ReadLine());

            double H1 = (M11 + M1X / 2) / (M11 + M1X + M12); //Gör till en egen metod i game
            double B1 = (M12 + M1X / 2) / (M11 + M1X + M12); //Gör till en egen metod i game

            double lambda1 = H1 * M1M; //Gör till en egen metod i game
            double lambda2 = B1 * M1M; //Gör till en egen metod i game

            Match1.poisson(lambda1, "hemma"); 
            Match1.poisson(lambda2, "borta");
            Match1.beräknaResultat();

            Console.WriteLine();
            double P1UB = Match1.beräknaÖverUnder(M1ÖU);
            Console.WriteLine(P1UB);
            double P1U = Match1.resultat[0] + Match1.resultat[1] + Match1.resultat[2] + Match1.resultat[11] + Match1.resultat[12] + Match1.resultat[22];
            Console.WriteLine(P1U);
            double P1Ö = 1 - P1U;

            Console.WriteLine("Poissonodds på över " + M1ÖU + ":  " + Math.Round(1 /P1Ö, 2));
            Console.WriteLine("Poissonodds på under " + M1ÖU + ": " + Math.Round(1 / P1U, 2));

            Console.WriteLine();

            Console.Write("Ändra nåt? [j]: ");
            answer = Console.ReadLine();

            while (answer == "j")
            {
                            
                Console.WriteLine();

                Console.Write("Förväntat målantal: ");
                M1M = Convert.ToDouble(Console.ReadLine());

                H1 = (M11 + M1X / 2) / (M11 + M1X + M12);
                B1 = (M12 + M1X / 2) / (M11 + M1X + M12);
                lambda1 = H1 * M1M;
                lambda2 = B1 * M1M;

                Match1.poisson(lambda1, "hemma");
                Match1.poisson(lambda2, "borta");
                Match1.beräknaResultat();

                Console.WriteLine();
                
                P1U = Match1.resultat[0] + Match1.resultat[1] + Match1.resultat[2] + Match1.resultat[11] + Match1.resultat[12] + Match1.resultat[22];
                P1Ö = 1 - P1U;

                Console.WriteLine("100 % odds på över " + M1ÖU + ":   " + Math.Round(1 / M1HÖ, 2));
                Console.WriteLine("Poissonodds på över " + M1ÖU + ":  " + Math.Round(1 /P1Ö, 2));
                Console.WriteLine();
                Console.WriteLine("100 % odds på under " + M1ÖU + ":  " + Math.Round(1 / M1HU, 2));
                Console.WriteLine("Poissonodds på under " + M1ÖU + ": " + Math.Round(1 / P1U, 2));

                Console.WriteLine();

                Console.Write("Ändra nåt? [j]: ");
                answer = Console.ReadLine();
            }

            Console.WriteLine();


            // Match 2                                  

            

            Console.WriteLine("Match 2");
            Console.WriteLine("-------");
            Console.WriteLine();

            Console.Write("Odds på 1: ");
            double M21 = 1 / Convert.ToDouble(Console.ReadLine());
            Console.Write("Odds på X: ");
            double M2X = 1 / Convert.ToDouble(Console.ReadLine());
            Console.Write("Odds på 2: ");
            double M22 = 1 / Convert.ToDouble(Console.ReadLine());

            Console.WriteLine();

            Console.Write("Över/Under [2,5]/[5,5]: ");
            double M2ÖU = Convert.ToDouble(Console.ReadLine());
            while ((M2ÖU != 2.5) && (M2ÖU != 5.5))
            {
                Console.Write("Över/Under [2,5]/[5,5]: ");
                M2ÖU = Convert.ToDouble(Console.ReadLine());
            }

            Console.Write("Odds på över " + M2ÖU + ":  ");
            double M2Ö = 1 / Convert.ToDouble(Console.ReadLine());
            Console.Write("Odds på under " + M2ÖU + ": ");
            double M2U = 1 / Convert.ToDouble(Console.ReadLine());
            double M2HÖ = (M2Ö / (M2Ö + M2U));
            double M2HU = (M2U / (M2Ö + M2U));

            Console.WriteLine();

            Console.Write("Ändra nåt? [j]: ");
            answer = Console.ReadLine();

            while (answer == "j")
            {

                Console.WriteLine();

                Console.Write("Odds på 1: ");
                M21 = 1 / Convert.ToDouble(Console.ReadLine());
                Console.Write("Odds på X: ");
                M2X = 1 / Convert.ToDouble(Console.ReadLine());
                Console.Write("Odds på 2: ");
                M22 = 1 / Convert.ToDouble(Console.ReadLine());

                Console.WriteLine();

                Console.Write("Över/Under [2,5]/[5,5]: ");
                M2ÖU = Convert.ToDouble(Console.ReadLine());
                Console.Write("Odds på över " + M2ÖU + ":  ");
                M2Ö = 1 / Convert.ToDouble(Console.ReadLine());
                Console.Write("Odds på under " + M2ÖU + ": ");
                M2U = 1 / Convert.ToDouble(Console.ReadLine());
                M2HÖ = (M2Ö / (M2Ö + M2U));
                M2HU = (M2U / (M2Ö + M2U));

                Console.WriteLine();

                Console.Write("Ändra nåt? [j]: ");
                answer = Console.ReadLine();
            }

            Console.WriteLine();

            Console.WriteLine("100 % odds på över " + M2ÖU + ":  " + Math.Round(1 / M2HÖ, 2));
            Console.WriteLine("100 % odds på under " + M2ÖU + ": " + Math.Round(1 / M2HU, 2));

            Console.WriteLine();

            Console.Write("Förväntat målantal: ");
            double M2M = Convert.ToDouble(Console.ReadLine());

            double H2 = (M21 + M2X / 2) / (M21 + M2X + M22);
            double B2 = (M22 + M2X / 2) / (M21 + M2X + M22);
            double lambda3 = H2 * M2M;
            double lambda4 = B2 * M2M;

            Match2.poisson(lambda3, "hemma");
            Match2.poisson(lambda4, "borta");
            Match2.beräknaResultat();

            Console.WriteLine();

            double P2U = Match2.resultat[0] + Match2.resultat[1] + Match2.resultat[2] + Match2.resultat[11] + Match2.resultat[12] + Match2.resultat[22];
            double P2Ö = 1 - P2U;

            Console.WriteLine("Poissonodds på över " + M2ÖU + ":  " + Math.Round(1 / P2Ö, 2));
            Console.WriteLine("Poissonodds på under " + M2ÖU + ": " + Math.Round(1 / P2U, 2));

            Console.WriteLine();

            Console.Write("Ändra nåt? [j]: ");
            answer = Console.ReadLine();

            while (answer == "j")
            {

                Console.WriteLine();

                Console.Write("Förväntat målantal: ");
                M2M = Convert.ToDouble(Console.ReadLine());

                H2 = (M21 + M2X / 2) / (M21 + M2X + M22);
                B2 = (M22 + M2X / 2) / (M21 + M2X + M22);
                lambda3 = H2 * M2M;
                lambda4 = B2 * M2M;

                Match2.poisson(lambda3, "hemma");
                Match2.poisson(lambda4, "borta");
                Match2.beräknaResultat();

                Console.WriteLine();

                P2U = Match2.resultat[0] + Match2.resultat[1] + Match2.resultat[2] + Match2.resultat[11] + Match2.resultat[12] + Match2.resultat[22];
                P2Ö = 1 - P2U;

                Console.WriteLine("100 % odds på över " + M2ÖU + ":   " + Math.Round(1 / M2HÖ, 2));
                Console.WriteLine("Poissonodds på över " + M2ÖU + ":  " + Math.Round(1 / P2Ö, 2));
                Console.WriteLine();
                Console.WriteLine("100 % odds på under " + M2ÖU + ":  " + Math.Round(1 / M2HU, 2));
                Console.WriteLine("Poissonodds på under " + M2ÖU + ": " + Math.Round(1 / P2U, 2));

                Console.WriteLine();

                Console.Write("Ändra nåt? [j]: ");
                answer = Console.ReadLine();
            }

            Console.WriteLine();

            // Match 3
            Console.WriteLine("Match 3");
            Console.WriteLine("-------");
            Console.WriteLine();

            Console.Write("Odds på 1: ");
            double M31 = 1 / Convert.ToDouble(Console.ReadLine());
            Console.Write("Odds på X: ");
            double M3X = 1 / Convert.ToDouble(Console.ReadLine());
            Console.Write("Odds på 2: ");
            double M32 = 1 / Convert.ToDouble(Console.ReadLine());

            Console.WriteLine();

            Console.Write("Över/Under [2,5]/[5,5]: ");
            double M3ÖU = Convert.ToDouble(Console.ReadLine());
            while ((M3ÖU != 2.5) && (M3ÖU != 5.5))
            {
                Console.Write("Över/Under [2,5]/[5,5]: ");
                M3ÖU = Convert.ToDouble(Console.ReadLine());
            }

            Console.Write("Odds på över " + M3ÖU + ":  ");
            double M3Ö = 1 / Convert.ToDouble(Console.ReadLine());
            Console.Write("Odds på under " + M3ÖU + ": ");
            double M3U = 1 / Convert.ToDouble(Console.ReadLine());
            double M3HÖ = (M3Ö / (M3Ö + M3U));
            double M3HU = (M3U / (M3Ö + M3U));

            Console.WriteLine();

            Console.Write("Ändra nåt? [j]: ");
            answer = Console.ReadLine();

            while (answer == "j")
            {

                Console.WriteLine();

                Console.Write("Odds på 1: ");
                M31 = 1 / Convert.ToDouble(Console.ReadLine());
                Console.Write("Odds på X: ");
                M3X = 1 / Convert.ToDouble(Console.ReadLine());
                Console.Write("Odds på 2: ");
                M32 = 1 / Convert.ToDouble(Console.ReadLine());

                Console.WriteLine();

                Console.Write("Över/Under [2,5]/[5,5]: ");
                M3ÖU = Convert.ToDouble(Console.ReadLine());
                Console.Write("Odds på över " + M3ÖU + ":  ");
                M3Ö = 1 / Convert.ToDouble(Console.ReadLine());
                Console.Write("Odds på under " + M3ÖU + ": ");
                M3U = 1 / Convert.ToDouble(Console.ReadLine());
                M3HÖ = (M3Ö / (M3Ö + M3U));
                M3HU = (M3U / (M3Ö + M3U));

                Console.WriteLine();

                Console.Write("Ändra nåt? [j]: ");
                answer = Console.ReadLine();
            }

            Console.WriteLine();

            Console.WriteLine("100 % odds på över " + M3ÖU + ":  " + Math.Round(1 / M3HÖ, 2));
            Console.WriteLine("100 % odds på under " + M3ÖU + ": " + Math.Round(1 / M3HU, 2));

            Console.WriteLine();

            Console.Write("Förväntat målantal: ");
            double M3M = Convert.ToDouble(Console.ReadLine());

            double H3 = (M31 + M3X / 2) / (M31 + M3X + M32);
            double B3 = (M32 + M3X / 2) / (M31 + M3X + M32);
            double lambda5 = H3 * M3M;
            double lambda6 = B3 * M3M;

            Match3.poisson(lambda5, "hemma");
            Match3.poisson(lambda6, "borta");
            Match3.beräknaResultat();

            Console.WriteLine();

            double P3U = Match3.resultat[0] + Match3.resultat[1] + Match3.resultat[2] + Match3.resultat[11] + Match3.resultat[12] + Match3.resultat[22];
            double P3Ö = 1 - P3U;

            Console.WriteLine("Poissonodds på över " + M3ÖU + ":  " + Math.Round(1 / P3Ö, 2));
            Console.WriteLine("Poissonodds på under " + M3ÖU + ": " + Math.Round(1 / P3U, 2));
//          Match3.beräknaFörväntadMålantal(M3M, Math.Abs(0.01), P3Ö, P3U, M3Ö, M3U);
            Console.WriteLine();

            Console.Write("Ändra nåt? [j]: ");
            answer = Console.ReadLine();

            while (answer == "j")
            {

                Console.WriteLine();

                Console.Write("Förväntat målantal: ");
                M3M = Convert.ToDouble(Console.ReadLine());

                H3 = (M31 + M3X / 2) / (M31 + M3X + M32);
                B3 = (M32 + M3X / 2) / (M31 + M3X + M32);
                lambda5 = H3 * M3M;
                lambda6 = B3 * M3M;

                Match3.poisson(lambda5, "hemma");
                Match3.poisson(lambda6, "borta");
                Match3.beräknaResultat();

                Console.WriteLine();

                P3U = Match3.resultat[0] + Match3.resultat[1] + Match3.resultat[2] + Match3.resultat[11] + Match3.resultat[12] + Match3.resultat[22];
                P3Ö = 1 - P3U;

                Console.WriteLine("100 % odds på över " + M3ÖU + ":  " + Math.Round(1 / M3HÖ, 2));
                Console.WriteLine("Poissonodds på över " + M3ÖU + ": " + Math.Round(1 / P3Ö, 2));
                Console.WriteLine();
                Console.WriteLine("100 % odds på under " + M3ÖU + ":  " + Math.Round(1 / M3HU, 2));
                Console.WriteLine("Poissonodds på under " + M3ÖU + ": " + Math.Round(1 / P3U, 2));

                Console.WriteLine();

                Console.Write("Ändra nåt? [j]: ");
                answer = Console.ReadLine();
            }

            Console.WriteLine();
            
            Match3.poisson(lambda5, "hemma");
            Match3.poisson(lambda6, "borta");
            Match3.beräknaResultat();
                   
            // Alla resultat

            double[] allaResultat = new double[1771561];

            int i = 0;
            int j = 0;
            int k = 0;
            int l = 0;

            for (int m = 0; m < 1771561; m = m + 1)
            {

                if (m%121 == 0 && m != 0)                
                {
                    j++;
                    k = 0;
                }
                if (m%14641 == 0 && m != 0)
                {
                    i++;
                    j = 0;
                    k = 0;
                }
                allaResultat[l++] = Math.Round(1 / (Match1.resultat[i] * Match2.resultat[j] * Match3.resultat[k++]), 2);
            }

  

            Console.WriteLine();
            

            //Importera odds från textfil från SvS.
            int counter = FileImporter.countLines();
            double[,] bombenStats = new double[counter, 7];
            bombenStats = FileImporter.importBomben();
           
            //Hämta omsättning från textfil från SvS
            int turnOver = FileImporter.getTurnOver();
            
           
            Console.WriteLine( "Beräknar...." );
            
            //Skapa nytt matris-objekt
            Matris matris = new Matris();
            //Kolumner: HemmaMålLag1, BortaMålLag1, HML2, BML2, HML3, BML3, Poisson, +1, +1ROI, +3, +3ROI 


            //Lägg till dem i matrisUtanOdds.
            matris.skapaAllaResultatKombinationer();
            matris.läggTillPoissonKolumn(allaResultat);

            //Stämpla starttid sluttid skrivs ut i matris.writeToFile
            string time = DateTime.Now.ToString( "HH:mm:ss tt" );
            Console.WriteLine(time);
            
            //Skapa nya tasks för läggTillPlusOchROI - Det är dessa som tar lång tid att bearbeta
            //Task firstTask = Task.Factory.StartNew( () => matris.läggTillPlusOchROI( bombenStats, counter, 1, turnOver ) );
            //firstTask.ContinueWith( ( t ) => taskTime("TaskA") );
            //Task secondTask = Task.Factory.StartNew( () => matris.läggTillPlusOchROI( bombenStats, counter, 3, turnOver ) );
            //secondTask.ContinueWith( (t) => matris.writeToFile() );


            matris.läggTillPlusOchROI(bombenStats, counter, 1, turnOver, extrapott);
            matris.läggTillPlusOchROI(bombenStats, counter, 3, turnOver, extrapott);
            //Stämpla starttid sluttid skrivs ut i matris.writeToFile
            time = DateTime.Now.ToString( "HH:mm:ss tt" );
            Console.WriteLine( time );
            matris.writeToFile();
      //    matris.writeToExistingExcelDocument();
            Console.WriteLine( "Skriv till fil klart." );
                        
            //Räkna om alla odds och lägg till odds på icke spelade kombinationer
            //finalMatrix.reCalculateOdds();

            //Lägg in poissonOdds i matrisen
            //finalMatrix.addPoissonOdds();

            //Skriv ut i listview(matris i consolFönstret)
            
            Console.ReadLine();


        }


        static private void taskTime( string taskName )
        {
            string Atime = DateTime.Now.ToString( "HH:mm:ss tt" );
            Console.WriteLine( taskName +": " +Atime );
        }


    }
}
