using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows;
using System.Net;


namespace Bomben
{
    class SvSJsonGetter
    {
        
        public string getJsonString( Uri url )
        {
           
            //Skapa objekt som hämtar websida
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8; //Så att den klarar svenska tecken
            
            string downloadString = "";
            
            try
            {
                downloadString = client.DownloadString(url);
                      
                //Regexstring to match hometeams
                //string matchStringPattern = @"(?s)(?<=_svs.bomben.data.bombendraws\s\=\s\{).*?(?=window.svs.core.data.selectedUrlMappings)";
                string matchStringPattern = @"(?s)(?<=_svs\.bomben\.data\.bombendraws\=\{).*?(?=_core\.data\.selectedUrlMappings={)";
                


                //Create regexobject
                Regex regex = new Regex(matchStringPattern);

                //Match    
                System.Text.RegularExpressions.Match myMatch = regex.Match(downloadString);

                string matchString ="";
                if ( myMatch.Success )
                {
                    matchString = myMatch.Value;
                }

                matchString = "{" + matchString;
                char[] trimmingChars = { '\r', '\n', ';' };
                matchString = matchString.TrimEnd( trimmingChars );
                downloadString = matchString;

            }
            catch
            {
                downloadString = null;
            }
            
            
            return downloadString;
            
        }

        

    }
}



