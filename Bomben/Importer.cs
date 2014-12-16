using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Bomben
{
    

    static class Importer
    {
        static string _pathFile;
        
        ///Metod som räknar antalet rader i en fil
        public static int countLines()
        {
            //Hämta filnamn
            Console.WriteLine( "Skriv in namnet på textfil: " );
            string fileName = Console.ReadLine().ToUpper();


            //Nytt objekt som läser in filen
            //string pathFile = @"C:\Users\Christer\Desktop\Bomben\" +fileName;
            //string pathFile = @"C:\Users\Erik\Desktop\Bomben\" +fileName;
            string pathFile = @"C:\Bomben\" +fileName;
            System.IO.StreamReader bombenFile =  new System.IO.StreamReader( pathFile );


            string line;
            int counter = 0;
            //Gå igenom filen för att se antal rader
            while( ( line = bombenFile.ReadLine() )  != null )
            {
                counter++;
            }
            
            _pathFile = pathFile;

            //Stäng filen så andra kan använda den
            bombenFile.Close();

            return counter;
 
        }

        ///Metod som läser in textfiler med odds för Bomben, returnerar en int[,] array
        public static double[,] importBomben( )
        {
            double[,] bombenDoubleStats;

            try
            {
            
                //Hämta filnamn
                //Console.WriteLine("Skriv in namnet på textfil: ");
                //string fileName = Console.ReadLine().ToUpper();


                //Nytt objekt som läser in filen
                //string pathFile = @"C:\Users\Christer\Desktop\Bomben\" +fileName;
                //string pathFile = @"C:\Users\Erik\Desktop\Bomben\" +fileName;
                System.IO.StreamReader bombenFile =  new System.IO.StreamReader( _pathFile );
            
            
                string line;
                int counter = 0;
                //Gå igenom filen för att se antal rader
                while( ( line = bombenFile.ReadLine() )  != null )
                {
                    counter++;
                }
            
                //Flytta tillbaka till filens början
                bombenFile.BaseStream.Seek(0, SeekOrigin.Begin );
                bombenFile.DiscardBufferedData();
            

                int kolumn = 0;
                int rad = 0;
                string delimiterstring = ";,"; //delare
                char[] delimiters = delimiterstring.ToArray(); //Omständigt sätt att skapa en charArray initialiserad
                string[] tempString = null; 
                string[,] bombenStats = new string[counter, 7];
            
                //Läs in filen, skippa första raden. 
                while( ( line = bombenFile.ReadLine() ) != null )
                {
                    //Skippa första raden
                    if(rad > 0)
                    {
                        //separera saker i raden
                        tempString = line.Split(delimiters);
                        foreach( string str in tempString )
                        {
                            bombenStats[rad-1,kolumn++] = str;
                        }
                                        
                    }
                    rad++;
                    kolumn=0;
                }
            
                //Stäng filen så andra kan använda den
                bombenFile.Close();

                int newCounter = counter -1;
                bombenDoubleStats = new double[newCounter, 7];
                //Gör om alla till int
                for( int nyaRader=0 ; nyaRader < newCounter ; nyaRader++ )
                {
                    for( int nyaKolumner=0 ; nyaKolumner < 7 ; nyaKolumner++ )
                    {
                        bombenDoubleStats[ nyaRader, nyaKolumner ] = Convert.ToDouble( bombenStats[ nyaRader, nyaKolumner ] );
                        
                        //DebugPrint
                        /*if( nyaRader < 10 )
                        {
                            Console.WriteLine( bombenIntStats[ nyaRader, nyaKolumner ] );
                        }
                        */
                    }
                    //Dela oddsen med 100 för att få riktiga odds. 
                    bombenDoubleStats[ nyaRader, 0 ] /= 100;
                
                }

                return bombenDoubleStats;
                
            }
            catch 
            {
                Console.WriteLine("Något gick fel vid inläsningen av textfilen!");
                //fullösning för att få ett returvärde
                bombenDoubleStats = new double[ 1, 7 ];
                return bombenDoubleStats;
            }
            
            
        }


    }
}
