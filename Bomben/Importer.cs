using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Text.RegularExpressions;

namespace Bomben
{


    public class Importer
    {
        //static string _pathFile;
        static string user { get; set; }
        static string extractPath { get; set; }


        //Constructor
        public Importer()
        {
            extractPath = @"C:\Bomben\";
        }

        /// <summary>
        /// Check user
        /// </summary>
        private void checkUser()
        {
            if (Directory.Exists(@"C:\Users\Erik"))
            {
                user = "Erik";
            }
            else if (Directory.Exists(@"C:\Users\Christer"))
            {
                user = "Christer";
            }
            else
            {
                user = "Unknown";
            }

        }


        /// <summary>
        /// Räknar antalet rader i en textfil -1
        /// </summary>
        /// <returns>Returnerar en int med antalet rader</returns>
        public int countLines(string ZipFileName)
        {
            //Hämta filnamn
            //Console.WriteLine( "Skriv in namnet på textfil (utan ändelse): " );
            //_currentFileName = Console.ReadLine().ToUpper();

            //_currentFileName = ZipFileName;


            //Kontrollera vem som är användare
            checkUser();
            string txt = ".txt";
            string zip = ".zip";
            string zipPath = @"C:\Users\" + user + @"\Downloads\" + ZipFileName + zip;

            //Kolla om filen finns extrahera om den inte finns.
            if (!File.Exists(extractPath + ZipFileName + txt))
            {
                ZipFile.ExtractToDirectory(zipPath, extractPath);
            }

            //Vänta på att filen extraherats
            while (!File.Exists(@"C:\Bomben\" + ZipFileName + txt)) ;

            //Skapa nytt streamReader objekt
            System.IO.StreamReader bombenFile = new System.IO.StreamReader(@"C:\Bomben\" + ZipFileName + txt);

            //Gå igenom filen för att se antal rader
            string line;
            int counter = 0;
            while ((line = bombenFile.ReadLine()) != null)
            {
                counter++;
            }

            //Stäng filen så andra kan använda den
            bombenFile.Close();

            return counter - 1;

        }

        ///Metod som läser in textfiler med odds för Bomben, returnerar en int[,] array
        public double[,] importBomben(string ZipFileName)
        {
            double[,] bombendoubleStats;

            try
            {
                //Nytt streamReader objekt
                System.IO.StreamReader bombenFile = new System.IO.StreamReader(extractPath + ZipFileName + ".txt");

                //Gå igenom filen för att se antal rader
                string line;
                int counter = 0;
                while ((line = bombenFile.ReadLine()) != null)
                {
                    counter++;
                }

                //Flytta tillbaka till filens början
                bombenFile.BaseStream.Seek(0, SeekOrigin.Begin);
                bombenFile.DiscardBufferedData();


                string delimiterstring = ";,"; //delare
                char[] delimiters = delimiterstring.ToArray(); //Omständigt sätt att skapa en charArray initialiserad
                string[] tempString = null;
                string[,] bombenStats = new string[counter, 7];

                int rad = 0;
                int kolumn = 0;
                //Läs in filen, skippa första raden. 
                while ((line = bombenFile.ReadLine()) != null)
                {
                    //Skippa första raden
                    if (rad > 0)
                    {
                        //separera saker i raden
                        tempString = line.Split(delimiters);
                        foreach (string str in tempString)
                        {
                            bombenStats[rad - 1, kolumn++] = str;
                        }

                    }
                    rad++;
                    kolumn = 0;
                }

                //Stäng filen så andra kan använda den
                bombenFile.Close();

                int newCounter = counter - 1;
                bombendoubleStats = new double[newCounter, 7];
                //Gör om alla till int
                for (int nyaRader = 0; nyaRader < newCounter; nyaRader++)
                {
                    for (int nyaKolumner = 0; nyaKolumner < 7; nyaKolumner++)
                    {
                        bombendoubleStats[nyaRader, nyaKolumner] = Convert.ToDouble(bombenStats[nyaRader, nyaKolumner]);
                    }

                    //Dela oddsen med 100 för att få riktiga odds. 
                    bombendoubleStats[nyaRader, 0] /= 100;


                }

                

            }
            catch
            {
                Console.WriteLine("Något gick fel vid inläsningen av textfilen!");
                //fullösning för att få ett returvärde
                bombendoubleStats = new double[1, 7];
                
            }

            return bombendoubleStats;

        }

        /// <summary>
        /// Hämta Omsättning ur textfil
        /// </summary>
        /// <returns>Returnerar en int med omsättning</returns>
        public int getTurnOver(string ZipFileName)
        {

            try
            {
                System.IO.StreamReader bombenFile = new System.IO.StreamReader(extractPath + ZipFileName + ".txt");

                string delimiterstring = ";"; //delare
                char[] delimiters = delimiterstring.ToArray(); //Omständigt sätt att skapa en charArray initialiserad
                string[] tempString = null;
                string[,] bombenStats = new string[1, 6];

                //Läs in filen
                string line = bombenFile.ReadLine();

                //separera saker i raden
                tempString = line.Split(delimiters);
                string turnOver = tempString[4];

                string numberString = Regex.Match(turnOver, @"\d+").Value;

                //Returnera omsättning
                return Int32.Parse(numberString);

            }
            catch
            {
                Console.WriteLine("Kunde inte läsa in filen i metoden getTurnOver");
                return -1;
            }

        }



    }
}
