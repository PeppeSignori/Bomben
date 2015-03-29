using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net;

namespace Bomben
{
    class SvSMobileSiteImporter
    {



        public int getInfo( Uri url )
        {
            //new Uri(@"https://www.svenskaspel.se/bomben")
            string responeString = scrapePage( url );
            string launderedString = launderHTML( responeString );
            
            int numberOfPlays = checkNumberOfPlays( launderedString );

            return numberOfPlays;

        }

        private int checkNumberOfPlays(string launderedString)
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
                playMatch.NextMatch();
            }

            return counter;
        
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





    }
}
