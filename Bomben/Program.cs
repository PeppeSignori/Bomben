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
            int[] drawIds = bomb.getInfo( new Uri(@"https://www.svenskaspel.se/bomben") );
            

            //Match object
            Game Match1 = new Game();
            Game Match2 = new Game();
            Game Match3 = new Game();
            Game Match4 = new Game();

            Console.WriteLine("Extrapott?");
            double extrapott = Convert.ToDouble(Console.ReadLine());           

            // Match 1
            
            Console.WriteLine("Match 1");
            Console.WriteLine("-------");
            Console.WriteLine();

            Console.Write("Odds på 1: ");
            double match1Etta = 1 / Convert.ToDouble(Console.ReadLine());
            Console.Write("Odds på X: ");
            double match1Kryss = 1 / Convert.ToDouble(Console.ReadLine());
            Console.Write("Odds på 2: ");
            double match1Tvåa = 1 / Convert.ToDouble(Console.ReadLine());

            Console.WriteLine();

            Console.Write("Goal Line: ");
            double match1ÖverUnderLina = Convert.ToDouble(Console.ReadLine());
            while ((match1ÖverUnderLina != 0.5) && (match1ÖverUnderLina != 1.5) && (match1ÖverUnderLina != 2.5) && (match1ÖverUnderLina != 3.5) && (match1ÖverUnderLina != 4.5) && (match1ÖverUnderLina != 5.5)
                 && (match1ÖverUnderLina != 6.5) && (match1ÖverUnderLina != 7.5) && (match1ÖverUnderLina != 8.5) && (match1ÖverUnderLina != 9.5))
            {
                Console.Write("Goal Line: ");
                match1ÖverUnderLina = Convert.ToDouble(Console.ReadLine());
            }

            Console.Write("Odds på över " + match1ÖverUnderLina + ":  ");
            double match1ÖverSannolikhetBolag = 1 / Convert.ToDouble(Console.ReadLine());
            Console.Write("Odds på under " + match1ÖverUnderLina + ": ");
            double match1UnderSannolikhetBolag = 1 / Convert.ToDouble(Console.ReadLine());
            double match1ÖverSannolikhetBolag100procent = (match1ÖverSannolikhetBolag / (match1ÖverSannolikhetBolag + match1UnderSannolikhetBolag)); //Gör till en egen metod i game
            double match1UnderSannolikhetBolag100procent = (match1UnderSannolikhetBolag / (match1ÖverSannolikhetBolag + match1UnderSannolikhetBolag)); //Gör till en egen metod i game

            Console.WriteLine();

            Console.Write("Ändra nåt? [j]: ");
            string answer = Console.ReadLine();

            while (answer == "j")
            {

                Console.WriteLine();

                Console.Write("Odds på 1: ");
                match1Etta = 1 / Convert.ToDouble(Console.ReadLine());
                Console.Write("Odds på X: ");
                match1Kryss = 1 / Convert.ToDouble(Console.ReadLine());
                Console.Write("Odds på 2: ");
                match1Tvåa = 1 / Convert.ToDouble(Console.ReadLine());

                Console.WriteLine();

                Console.Write("Goal Line: ");
                match1ÖverUnderLina = Convert.ToDouble(Console.ReadLine());
                Console.Write("Odds på över " + match1ÖverUnderLina + ":  ");
                match1ÖverSannolikhetBolag = 1 / Convert.ToDouble(Console.ReadLine());
                Console.Write("Odds på under " + match1ÖverUnderLina + ": ");
                match1UnderSannolikhetBolag = 1 / Convert.ToDouble(Console.ReadLine());
                match1ÖverSannolikhetBolag100procent = (match1ÖverSannolikhetBolag / (match1ÖverSannolikhetBolag + match1UnderSannolikhetBolag));
                match1UnderSannolikhetBolag100procent = (match1UnderSannolikhetBolag / (match1ÖverSannolikhetBolag + match1UnderSannolikhetBolag));

                Console.WriteLine();

                Console.Write("Ändra nåt? [j]: ");
                answer = Console.ReadLine();
            }

            Console.WriteLine();

            Console.WriteLine("100 % odds på över " + match1ÖverUnderLina + ":  " + Math.Round(1 / match1ÖverSannolikhetBolag100procent, 2)); 
            Console.WriteLine("100 % odds på under " + match1ÖverUnderLina + ": " + Math.Round(1 / match1UnderSannolikhetBolag100procent, 2));

            Console.WriteLine();

            Console.Write("Förväntat målantal: ");
            double match1FörväntatMålantal = Convert.ToDouble(Console.ReadLine());

            double match1Hemmastyrka = (match1Etta + match1Kryss / 2) / (match1Etta + match1Kryss + match1Tvåa); //Gör till en egen metod i game
            double match1Bortastyrka = (match1Tvåa + match1Kryss / 2) / (match1Etta + match1Kryss + match1Tvåa); //Gör till en egen metod i game

            double lambda1 = match1Hemmastyrka * match1FörväntatMålantal; //Gör till en egen metod i game
            double lambda2 = match1Bortastyrka * match1FörväntatMålantal; //Gör till en egen metod i game

            Match1.poisson(lambda1, "hemma"); 
            Match1.poisson(lambda2, "borta");
            Match1.beräknaResultat();

            Console.WriteLine();

            double match1UnderSannolikhetPoisson = Match1.beräknaÖverUnder(match1ÖverUnderLina);
            double match1ÖverSannolikhetPoisson = 1 - match1UnderSannolikhetPoisson;

            Console.WriteLine("Poissonodds på över " + match1ÖverUnderLina + ":  " + Math.Round(1 / match1ÖverSannolikhetPoisson, 2));
            Console.WriteLine("Poissonodds på under " + match1ÖverUnderLina + ": " + Math.Round(1 / match1UnderSannolikhetPoisson, 2));

            Console.WriteLine();

            Console.Write("Ändra nåt? [j]: ");
            answer = Console.ReadLine();

            while (answer == "j")
            {
                            
                Console.WriteLine();

                Console.Write("Förväntat målantal: ");
                match1FörväntatMålantal = Convert.ToDouble(Console.ReadLine());

                match1Hemmastyrka = (match1Etta + match1Kryss / 2) / (match1Etta + match1Kryss + match1Tvåa);
                match1Bortastyrka = (match1Tvåa + match1Kryss / 2) / (match1Etta + match1Kryss + match1Tvåa);
                lambda1 = match1Hemmastyrka * match1FörväntatMålantal;
                lambda2 = match1Bortastyrka * match1FörväntatMålantal;

                Match1.poisson(lambda1, "hemma");
                Match1.poisson(lambda2, "borta");
                Match1.beräknaResultat();

                Console.WriteLine();

                match1UnderSannolikhetPoisson = Match1.beräknaÖverUnder(match1ÖverUnderLina);
                match1ÖverSannolikhetPoisson = 1 - match1UnderSannolikhetPoisson;

                Console.WriteLine("100 % odds på över " + match1ÖverUnderLina + ":   " + Math.Round(1 / match1ÖverSannolikhetBolag100procent, 2));
                Console.WriteLine("Poissonodds på över " + match1ÖverUnderLina + ":  " + Math.Round(1 /match1ÖverSannolikhetPoisson, 2));
                Console.WriteLine();
                Console.WriteLine("100 % odds på under " + match1ÖverUnderLina + ":  " + Math.Round(1 / match1UnderSannolikhetBolag100procent, 2));
                Console.WriteLine("Poissonodds på under " + match1ÖverUnderLina + ": " + Math.Round(1 / match1UnderSannolikhetPoisson, 2));

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
            double match2Etta = 1 / Convert.ToDouble(Console.ReadLine());
            Console.Write("Odds på X: ");
            double match2Kryss = 1 / Convert.ToDouble(Console.ReadLine());
            Console.Write("Odds på 2: ");
            double match2Tvåa = 1 / Convert.ToDouble(Console.ReadLine());

            Console.WriteLine();

            Console.Write("Goal Line: ");
            double match2ÖverUnderLina = Convert.ToDouble(Console.ReadLine());
            while ((match2ÖverUnderLina != 0.5) && (match2ÖverUnderLina != 1.5) && (match2ÖverUnderLina != 2.5) && (match2ÖverUnderLina != 3.5) && (match2ÖverUnderLina != 4.5) && (match2ÖverUnderLina != 5.5)
                 && (match2ÖverUnderLina != 6.5) && (match2ÖverUnderLina != 7.5) && (match2ÖverUnderLina != 8.5) && (match2ÖverUnderLina != 9.5))
            {
                Console.Write("Goal Line: ");
                match2ÖverUnderLina = Convert.ToDouble(Console.ReadLine());
            }

            Console.Write("Odds på över " + match2ÖverUnderLina + ":  ");
            double match2ÖverSannolikhetBolag = 1 / Convert.ToDouble(Console.ReadLine());
            Console.Write("Odds på under " + match2ÖverUnderLina + ": ");
            double match2UnderSannolikhetBolag = 1 / Convert.ToDouble(Console.ReadLine());
            double match2ÖverSannolikhetBolag100procent = (match2ÖverSannolikhetBolag / (match2ÖverSannolikhetBolag + match2UnderSannolikhetBolag));
            double match2UnderSannolikhetBolag100procent = (match2UnderSannolikhetBolag / (match2ÖverSannolikhetBolag + match2UnderSannolikhetBolag));

            Console.WriteLine();

            Console.Write("Ändra nåt? [j]: ");
            answer = Console.ReadLine();

            while (answer == "j")
            {

                Console.WriteLine();

                Console.Write("Odds på 1: ");
                match2Etta = 1 / Convert.ToDouble(Console.ReadLine());
                Console.Write("Odds på X: ");
                match2Kryss = 1 / Convert.ToDouble(Console.ReadLine());
                Console.Write("Odds på 2: ");
                match2Tvåa = 1 / Convert.ToDouble(Console.ReadLine());

                Console.WriteLine();

                Console.Write("Goal Line: ");
                match2ÖverUnderLina = Convert.ToDouble(Console.ReadLine());
                Console.Write("Odds på över " + match2ÖverUnderLina + ":  ");
                match2ÖverSannolikhetBolag = 1 / Convert.ToDouble(Console.ReadLine());
                Console.Write("Odds på under " + match2ÖverUnderLina + ": ");
                match2UnderSannolikhetBolag = 1 / Convert.ToDouble(Console.ReadLine());
                match2ÖverSannolikhetBolag100procent = (match2ÖverSannolikhetBolag / (match2ÖverSannolikhetBolag + match2UnderSannolikhetBolag));
                match2UnderSannolikhetBolag100procent = (match2UnderSannolikhetBolag / (match2ÖverSannolikhetBolag + match2UnderSannolikhetBolag));

                Console.WriteLine();

                Console.Write("Ändra nåt? [j]: ");
                answer = Console.ReadLine();
            }

            Console.WriteLine();

            Console.WriteLine("100 % odds på över " + match2ÖverUnderLina + ":  " + Math.Round(1 / match2ÖverSannolikhetBolag100procent, 2));
            Console.WriteLine("100 % odds på under " + match2ÖverUnderLina + ": " + Math.Round(1 / match2UnderSannolikhetBolag100procent, 2));

            Console.WriteLine();

            Console.Write("Förväntat målantal: ");
            double match2FörväntatMålantal = Convert.ToDouble(Console.ReadLine());

            double match2Hemmastyrka = (match2Etta + match2Kryss / 2) / (match2Etta + match2Kryss + match2Tvåa);
            double match2Bortastyrka = (match2Tvåa + match2Kryss / 2) / (match2Etta + match2Kryss + match2Tvåa);
            double lambda3 = match2Hemmastyrka * match2FörväntatMålantal;
            double lambda4 = match2Bortastyrka * match2FörväntatMålantal;

            Match2.poisson(lambda3, "hemma");
            Match2.poisson(lambda4, "borta");
            Match2.beräknaResultat();

            Console.WriteLine();

            double match2UnderSannolikhetPoisson = Match2.beräknaÖverUnder(match2ÖverUnderLina);
            double match2ÖverSannolikhetPoisson = 1 - match2UnderSannolikhetPoisson;

            Console.WriteLine("Poissonodds på över " + match2ÖverUnderLina + ":  " + Math.Round(1 / match2ÖverSannolikhetPoisson, 2));
            Console.WriteLine("Poissonodds på under " + match2ÖverUnderLina + ": " + Math.Round(1 / match2UnderSannolikhetPoisson, 2));

            Console.WriteLine();

            Console.Write("Ändra nåt? [j]: ");
            answer = Console.ReadLine();

            while (answer == "j")
            {

                Console.WriteLine();

                Console.Write("Förväntat målantal: ");
                match2FörväntatMålantal = Convert.ToDouble(Console.ReadLine());

                match2Hemmastyrka = (match2Etta + match2Kryss / 2) / (match2Etta + match2Kryss + match2Tvåa);
                match2Bortastyrka = (match2Tvåa + match2Kryss / 2) / (match2Etta + match2Kryss + match2Tvåa);
                lambda3 = match2Hemmastyrka * match2FörväntatMålantal;
                lambda4 = match2Bortastyrka * match2FörväntatMålantal;

                Match2.poisson(lambda3, "hemma");
                Match2.poisson(lambda4, "borta");
                Match2.beräknaResultat();

                Console.WriteLine();

                match2UnderSannolikhetPoisson = Match2.beräknaÖverUnder(match2ÖverUnderLina);
                match2ÖverSannolikhetPoisson = 1 - match2UnderSannolikhetPoisson;

                Console.WriteLine("100 % odds på över " + match2ÖverUnderLina + ":   " + Math.Round(1 / match2ÖverSannolikhetBolag100procent, 2));
                Console.WriteLine("Poissonodds på över " + match2ÖverUnderLina + ":  " + Math.Round(1 / match2ÖverSannolikhetPoisson, 2));
                Console.WriteLine();
                Console.WriteLine("100 % odds på under " + match2ÖverUnderLina + ":  " + Math.Round(1 / match2UnderSannolikhetBolag100procent, 2));
                Console.WriteLine("Poissonodds på under " + match2ÖverUnderLina + ": " + Math.Round(1 / match2UnderSannolikhetPoisson, 2));

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
            double match3Etta = 1 / Convert.ToDouble(Console.ReadLine());
            Console.Write("Odds på X: ");
            double match3Kryss = 1 / Convert.ToDouble(Console.ReadLine());
            Console.Write("Odds på 2: ");
            double match3Tvåa = 1 / Convert.ToDouble(Console.ReadLine());

            Console.WriteLine();

            Console.Write("Goal Line: ");
            double match3ÖverUnderLina = Convert.ToDouble(Console.ReadLine());
            while ((match2ÖverUnderLina != 0.5) && (match2ÖverUnderLina != 1.5) && (match2ÖverUnderLina != 2.5) && (match2ÖverUnderLina != 3.5) && (match2ÖverUnderLina != 4.5) && (match2ÖverUnderLina != 5.5)
                 && (match2ÖverUnderLina != 6.5) && (match2ÖverUnderLina != 7.5) && (match2ÖverUnderLina != 8.5) && (match2ÖverUnderLina != 9.5))
            {
                Console.Write("Goal Line: ");
                match3ÖverUnderLina = Convert.ToDouble(Console.ReadLine());
            }

            Console.Write("Odds på över " + match3ÖverUnderLina + ":  ");
            double match3ÖverSannolikhetBolag = 1 / Convert.ToDouble(Console.ReadLine());
            Console.Write("Odds på under " + match3ÖverUnderLina + ": ");
            double match3UnderSannolikhetBolag = 1 / Convert.ToDouble(Console.ReadLine());
            double match3ÖverSannolikhetBolag100procent = (match3ÖverSannolikhetBolag / (match3ÖverSannolikhetBolag + match3UnderSannolikhetBolag));
            double match3UnderSannolikhetBolag100procent = (match3UnderSannolikhetBolag / (match3ÖverSannolikhetBolag + match3UnderSannolikhetBolag));

            Console.WriteLine();

            Console.Write("Ändra nåt? [j]: ");
            answer = Console.ReadLine();

            while (answer == "j")
            {

                Console.WriteLine();

                Console.Write("Odds på 1: ");
                match3Etta = 1 / Convert.ToDouble(Console.ReadLine());
                Console.Write("Odds på X: ");
                match3Kryss = 1 / Convert.ToDouble(Console.ReadLine());
                Console.Write("Odds på 2: ");
                match3Tvåa = 1 / Convert.ToDouble(Console.ReadLine());

                Console.WriteLine();

                Console.Write("Goal Line: ");
                match3ÖverUnderLina = Convert.ToDouble(Console.ReadLine());
                Console.Write("Odds på över " + match3ÖverUnderLina + ":  ");
                match3ÖverSannolikhetBolag = 1 / Convert.ToDouble(Console.ReadLine());
                Console.Write("Odds på under " + match3ÖverUnderLina + ": ");
                match3UnderSannolikhetBolag = 1 / Convert.ToDouble(Console.ReadLine());
                match3ÖverSannolikhetBolag100procent = (match3ÖverSannolikhetBolag / (match3ÖverSannolikhetBolag + match3UnderSannolikhetBolag));
                match3UnderSannolikhetBolag100procent = (match3UnderSannolikhetBolag / (match3ÖverSannolikhetBolag + match3UnderSannolikhetBolag));

                Console.WriteLine();

                Console.Write("Ändra nåt? [j]: ");
                answer = Console.ReadLine();
            }

            Console.WriteLine();

            Console.WriteLine("100 % odds på över " + match3ÖverUnderLina + ":  " + Math.Round(1 / match3ÖverSannolikhetBolag100procent, 2));
            Console.WriteLine("100 % odds på under " + match3ÖverUnderLina + ": " + Math.Round(1 / match3UnderSannolikhetBolag100procent, 2));

            Console.WriteLine();

            Console.Write("Förväntat målantal: ");
            double match3FörväntatMålantal = Convert.ToDouble(Console.ReadLine());

            double match3Hemmastyrka = (match3Etta + match3Kryss / 2) / (match3Etta + match3Kryss + match3Tvåa);
            double match3Bortastyrka = (match3Tvåa + match3Kryss / 2) / (match3Etta + match3Kryss + match3Tvåa);
            double lambda5 = match3Hemmastyrka * match3FörväntatMålantal;
            double lambda6 = match3Bortastyrka * match3FörväntatMålantal;

            Match3.poisson(lambda5, "hemma");
            Match3.poisson(lambda6, "borta");
            Match3.beräknaResultat();

            Console.WriteLine();

            double match3UnderSannolikhetPoisson = Match3.beräknaÖverUnder(match3ÖverUnderLina);
            double match3ÖverSannolikhetPoisson = 1 - match3UnderSannolikhetPoisson;

            Console.WriteLine("Poissonodds på över " + match3ÖverUnderLina + ":  " + Math.Round(1 / match3ÖverSannolikhetPoisson, 2));
            Console.WriteLine("Poissonodds på under " + match3ÖverUnderLina + ": " + Math.Round(1 / match3UnderSannolikhetPoisson, 2));

            Console.WriteLine();

            Console.Write("Ändra nåt? [j]: ");
            answer = Console.ReadLine();

            while (answer == "j")
            {

                Console.WriteLine();

                Console.Write("Förväntat målantal: ");
                match3FörväntatMålantal = Convert.ToDouble(Console.ReadLine());

                match3Hemmastyrka = (match3Etta + match3Kryss / 2) / (match3Etta + match3Kryss + match3Tvåa);
                match3Bortastyrka = (match3Tvåa + match3Kryss / 2) / (match3Etta + match3Kryss + match3Tvåa);
                lambda5 = match3Hemmastyrka * match3FörväntatMålantal;
                lambda6 = match3Bortastyrka * match3FörväntatMålantal;

                Match3.poisson(lambda5, "hemma");
                Match3.poisson(lambda6, "borta");
                Match3.beräknaResultat();

                Console.WriteLine();

                match3UnderSannolikhetPoisson = Match3.beräknaÖverUnder(match3ÖverUnderLina);
                match3ÖverSannolikhetPoisson = 1 - match3UnderSannolikhetPoisson;

                Console.WriteLine("100 % odds på över " + match3ÖverUnderLina + ":  " + Math.Round(1 / match3ÖverSannolikhetBolag100procent, 2));
                Console.WriteLine("Poissonodds på över " + match3ÖverUnderLina + ": " + Math.Round(1 / match3ÖverSannolikhetPoisson, 2));
                Console.WriteLine();
                Console.WriteLine("100 % odds på under " + match3ÖverUnderLina + ":  " + Math.Round(1 / match3UnderSannolikhetBolag100procent, 2));
                Console.WriteLine("Poissonodds på under " + match3ÖverUnderLina + ": " + Math.Round(1 / match3UnderSannolikhetPoisson, 2));

                Console.WriteLine();

                Console.Write("Ändra nåt? [j]: ");
                answer = Console.ReadLine();
            }

            Console.WriteLine();
            
 
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

  

            Console.WriteLine("Bomber, i kronologisk ordning: ");

            foreach (int drawId in drawIds)
            {
                Console.WriteLine(drawId);
            }

            //Mata in bombenNr
            Console.WriteLine("\nSkriv in spelnr för bomben (t.ex 8372): ");
            //drawId = bombenNr
            int chosenDrawId = Convert.ToInt32(Console.ReadLine());
            //webadress
            string link = "https://svenskaspel.se/cas/getfile.aspx?file=playedcombinations&productid=7&drawid=" + chosenDrawId;
            //filnamn
            string fileName = "PC_P7_D" + chosenDrawId + ".zip";
            //Ladda ner filen
            bomb.downloadFileAsync(link, fileName);

            //Vänta på nerladdningen ska bli klar
            while (!bomb.downloadComplete) ;

            //Importera odds från textfil från SvS.
            int counter = FileImporter.countLines(chosenDrawId);
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
            Console.WriteLine("Ta bort tillfälliga filer? (J/N) ");
            string delete = Console.ReadLine();
            if (delete == "j" || delete == "J")
            {
                File.Delete(@".\downloadTempFolder\PC_P7_D" + chosenDrawId + ".zip");
                File.Delete(@".\downloadTempFolder\PC_P7_D" + chosenDrawId + ".txt");
            }

            Console.ReadLine();


        }


        static private void taskTime( string taskName )
        {
            string Atime = DateTime.Now.ToString( "HH:mm:ss tt" );
            Console.WriteLine( taskName +": " +Atime );
        }


    }
}
