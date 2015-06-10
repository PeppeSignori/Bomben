using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net;
using System.ComponentModel;
using System.IO;

namespace Bomben
{
    public class SvSMobileSiteImporter
    {
        //Constructor
        public SvSMobileSiteImporter()
        {
            downloadComplete = false;
        }

        public int numberOfPlays { get; set; }
        public bool downloadComplete { get; set; }
        
        /*
        public int[] getInfo( Uri url )
        {
            //new Uri(@"https://www.svenskaspel.se/bomben")
            string responseString = scrapePage( url );
            string launderedString = launderHTML( responseString );
            
            numberOfPlays = checkNumberOfPlays( launderedString );
            return getDrawIds(launderedString, numberOfPlays);
            
        }

              
        public int checkNumberOfPlays(string launderedString)
        {
            //Counter
            int counter = 0;

            //Regexstring to match hometeams
            string bombenPlayPattern = @"(?<=Bomben )\d{1}";

            //Create regexobject
            Regex regex = new Regex(bombenPlayPattern);

            //Match    
            Match playMatch = regex.Match(launderedString);

            while (playMatch.Success)
            {
                counter++;
                playMatch = playMatch.NextMatch();
            }

            return counter;
        
        }

        public int[] getDrawIds(string launderedString, int numberOfBombs)
        {
            //saveArray
            int[] drawIds = new int[numberOfBombs];
            //Counter
            int counter = 0;

            //Regexstring to match hometeams
            string bombenPlayPattern = @"(?<=drawNumber"":)\d+(?=,"")"; 

            //Create regexobject
            Regex regex = new Regex(bombenPlayPattern);

            //Match    
            Match playMatch = regex.Match(launderedString);

            while (playMatch.Success)
            {
                string id = playMatch.ToString();
                drawIds[counter++] = Convert.ToInt32( id );
                playMatch = playMatch.NextMatch();
            }

            return drawIds;
        } 


        private string launderHTML(string htmlString)
        {
            //Matchningssträng och en tom sträng                     
            string pattern = "[<].+?[>]";
            string emptyString = "";

            //Ersätt alla <HTML> med tom sträng
            return Regex.Replace(htmlString, pattern, emptyString);
        }


        private string scrapePage(Uri url)
        {

            //Skapa objekt som hämtar websida
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8; //Så att den klarar svenska tecken
            string downloadString;

            try //Hämta online 
            {
                downloadString = client.DownloadString(url);
            }
            catch   //Hämta offlineresurs när online inte är tillgänglig
            {
               downloadString = client.DownloadString("./Bomben2Spel/Bomben2.html");
            }

            return downloadString;
            
        }
        */    

        public void downloadFileAsync(string adress, string newFileName)
        {
            WebClient downloadClient = new WebClient();
            downloadClient.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(fileDownloadComplete);
            
            if (!Directory.Exists(@".\downloadTempFolder"))
            {
                Directory.CreateDirectory(@".\downloadTempFolder");
            }
            //Console.WriteLine("{0}", Directory.GetCreationTime(@".\downloadTempFolder"));
            string saveAdress = @".\downloadTempFolder\";
            downloadClient.DownloadFileAsync( new Uri(adress), saveAdress +newFileName );
            
        }

        
        public void fileDownloadComplete(object sender, EventArgs e)
        {
            downloadComplete = true;
        }
       

    }
}
