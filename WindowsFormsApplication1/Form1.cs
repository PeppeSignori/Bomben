using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bomben
{
    public partial class Form1 : Form
    {
        
        SvSJsonGetter JsonInfo = new SvSJsonGetter();
        SvSInfo info = new SvSInfo();
        int currentDraw=0;
        
        Game match1 = new Game();
        Game match2 = new Game();
        Game match3 = new Game();
        Game match4 = new Game();

        Matris3 matris3 = new Matris3();

        public Form1()
        {
            InitializeComponent();
            
            string result = JsonInfo.getJsonString(new Uri(@"https://www.svenskaspel.se/bomben"));
            info = JsonConvert.DeserializeObject<SvSInfo>(result);
            populateBombenTBs(currentDraw);
            dataGridViewController1.setDeafaultHeadersAndWidth();
            

        }
        
        private void Match1Odds1_TextChanged(object sender, EventArgs e)
        {
            //Spara värdet från textbox
            match1.odds1 = Convert.ToDouble(Match1Odds1.Text);
            //Sätt till 100% om det finns ett värde i match1.över
            if (match1.oddsX > 1 && match1.odds2 > 1)
            {
                match1.sättOddsTill100Procent();
            }  
        }

        private void Match1OddsX_TextChanged(object sender, EventArgs e)
        {
            //Spara värdet från textbox
            match1.oddsX = Convert.ToDouble(Match1OddsX.Text);
            //Sätt till 100% om det finns ett värde i match1.över
            if (match1.odds1 > 1 && match1.odds2 > 1)
            {
                match1.sättOddsTill100Procent();
            }  
        }

        private void Match1Odds2_TextChanged(object sender, EventArgs e)
        {
            //Spara värdet från textbox
            match1.odds2 = Convert.ToDouble(Match1Odds2.Text);
            //Sätt till 100% om det finns ett värde i match1.över
            if (match1.odds1 > 1 && match1.oddsX > 1)
            {
                match1.sättOddsTill100Procent();
            }  
        }

        private void Match1Över_TextChanged(object sender, EventArgs e)
        {
            //Spara värdet från textbox
            match1.över = Convert.ToDouble(Match1Över.Text);
            //Sätt till 100% om det finns ett värde i match1.över
            if (match1.under > 1)
            {
                match1.sättÖverUnderTill100Procent();   
            }      
        }
        
        private void Match1Under_TextChanged(object sender, EventArgs e)
        {
            match1.förväntatAntalmål = Convert.ToDouble(Match1FörväntadMålantal.Text);
            //Kolla så att alla boxar är ifyllda beräkna sedan
            match1.beräknaFörväntadMålantal();
            Match1UträknatMålAntal.Text = match1.förväntatAntalmål.ToString();
        }

        private void Match2Odds1_TextChanged(object sender, EventArgs e)
        {
            //Spara värdet från textbox
            match2.odds1 = Convert.ToDouble(Match2Odds1.Text);
            //Sätt till 100% om det finns ett värde i match1.över
            if (match2.oddsX > 1 && match2.odds2 > 1)
            {
                match2.sättOddsTill100Procent();
            }  
        }

        private void Match2OddsX_TextChanged(object sender, EventArgs e)
        {
            //Spara värdet från textbox
            match2.oddsX = Convert.ToDouble(Match2OddsX.Text);
            //Sätt till 100% om det finns ett värde i match1.över
            if (match2.odds1 > 1 && match2.odds2 > 1)
            {
                match2.sättOddsTill100Procent();
            }  
        }

        private void Match2Odds2_TextChanged(object sender, EventArgs e)
        {
            //Spara värdet från textbox
            match2.odds2 = Convert.ToDouble(Match2Odds2.Text);
            //Sätt till 100% om det finns ett värde i match1.över
            if (match2.odds1 > 1 && match2.oddsX > 1)
            {
                match2.sättOddsTill100Procent();
            }  
        }

        private void Match2Över_TextChanged(object sender, EventArgs e)
        {
            //Spara värdet från textbox
            match2.över = Convert.ToDouble(Match2Över.Text);
            //Sätt till 100% om det finns ett värde i match1.över
            if (match2.under > 1)
            {
                match2.sättÖverUnderTill100Procent();
            }    
        }

        private void Match2Under_TextChanged(object sender, EventArgs e)
        {

        }

        private void Match3Odds1_TextChanged(object sender, EventArgs e)
        {
            //Spara värdet från textbox
            match3.odds1 = Convert.ToDouble(Match3Odds1.Text);
            //Sätt till 100% om det finns ett värde i match1.över
            if (match3.oddsX > 1 && match3.odds2 > 1)
            {
                match3.sättOddsTill100Procent();
            }  
        }

        private void Match3OddsX_TextChanged(object sender, EventArgs e)
        {
            //Spara värdet från textbox
            match3.oddsX = Convert.ToDouble(Match3OddsX.Text);
            //Sätt till 100% om det finns ett värde i match1.över
            if (match3.odds1 > 1 && match3.odds2 > 1)
            {
                match3.sättOddsTill100Procent();
            }  
        }

        private void Match3Odds2_TextChanged(object sender, EventArgs e)
        {
            //Spara värdet från textbox
            match3.odds2 = Convert.ToDouble(Match3Odds2.Text);
            //Sätt till 100% om det finns ett värde i match1.över
            if (match3.odds1 > 1 && match3.oddsX > 1)
            {
                match3.sättOddsTill100Procent();
            }  
        }

        private void Match3Över_TextChanged(object sender, EventArgs e)
        {
            //Spara värdet från textbox
            match3.över = Convert.ToDouble(Match3Över.Text);
            //Sätt till 100% om det finns ett värde i match1.över
            if (match3.under > 1)
            {
                match3.sättÖverUnderTill100Procent();
            }    
        }

        private void Match3Under_TextChanged(object sender, EventArgs e)
        {

        }

        private void Match4Odds1_TextChanged(object sender, EventArgs e)
        {
            //Spara värdet från textbox
            match4.odds1 = Convert.ToDouble(Match4Odds1.Text);
            //Sätt till 100% om det finns ett värde i match1.över
            if (match4.oddsX > 1 && match4.odds2 > 1)
            {
                match4.sättOddsTill100Procent();
            }  
        }

        private void Match4OddsX_TextChanged(object sender, EventArgs e)
        {
            //Spara värdet från textbox
            match4.oddsX = Convert.ToDouble(Match4OddsX.Text);
            //Sätt till 100% om det finns ett värde i match1.över
            if (match4.odds1 > 1 && match4.odds2 > 1)
            {
                match4.sättOddsTill100Procent();
            }  
        }

        private void Match4Odds2_TextChanged(object sender, EventArgs e)
        {
            //Spara värdet från textbox
            match4.odds2 = Convert.ToDouble(Match4Odds2.Text);
            //Sätt till 100% om det finns ett värde i match1.över
            if (match4.odds1 > 1 && match4.oddsX > 1)
            {
                match4.sättOddsTill100Procent();
            }  
        }

        private void Match4Över_TextChanged(object sender, EventArgs e)
        {
            //Spara värdet från textbox
            match4.över = Convert.ToDouble(Match4Över.Text);
            //Sätt till 100% om det finns ett värde i match1.över
            if (match4.under > 1)
            {
                match4.sättÖverUnderTill100Procent();
            }    
        }

        private void Match4Under_TextChanged(object sender, EventArgs e)
        {

        }
        

        private void populateBombenTBs(int draw)
        {
            //Vilken bomb - skriver ut veckodag och "Bomben 1"
            Dictionary<string, string> weekDays = new Dictionary<string, string>();
            weekDays.Add("Monday", "Mån");
            weekDays.Add("Tuesday", "Tis");
            weekDays.Add("Wednesday", "Ons");
            weekDays.Add("Thursday", "Tor");
            weekDays.Add("Friday", "Fre");
            weekDays.Add("Saturday", "Lör");
            weekDays.Add("Sunday", "Sön");

            //Sortera ut de som inte är öppna för spel
            while( info.draws[draw].enabled != true && draw < info.draws.Length)
            {
                draw++;
            }

            //Skriv bara ut om det finns ett öppet spel
            if( draw < info.draws.Length )
            {

                try
                {
                    bombNrTB.Text = weekDays[ info.draws[draw].cancelCloseTime.DayOfWeek.ToString() ] +" " +info.draws[draw].description +"\t" +info.draws[draw].drawNumber.ToString();
                }
                catch
                {
                    bombNrTB.Text = info.draws[draw].cancelCloseTime.DayOfWeek + " " + info.draws[draw].description;
                }
            
                //Hemmalag och bortalag textboxar
                TextBox[] textBoxes = new TextBox[] { textBox16, textBox17, textBox19, textBox20, textBox28, textBox29, textBox37, textBox38 };
            
                //nollställ textboxar
                for (int i = 0; i <8 ; i++)
                {
                    textBoxes[i].Text = "";
                }
            
                //Skriv ut lagnamn
                for (int i = 0, j=0; i < info.draws[draw].events.GetLength(0); i++, j=j+2)
                {
                    textBoxes[j].Text = info.draws[draw].events[i].match.participants[0].name;
                    textBoxes[j+1].Text = info.draws[draw].events[i].match.participants[1].name;    
                }

                //Skriver ut omsättning

                decimal myDec = Convert.ToDecimal(info.draws[draw].currentNetSales);
                myDec = Decimal.Round(myDec);
                string myMoney = myDec.ToString("0,0");
                turnOverLabel.Text = "Omsättning: " + myMoney +" kr";

                //extrapengar
                myDec = Convert.ToDecimal(info.draws[draw].fund.extraMoney);
                myDec = Decimal.Round(myDec);
                myMoney = myDec.ToString("0,0");

                extraPengarLabel.Text = "Extrapengar: " + myMoney + " kr";

                //Rullpott
                myDec = Convert.ToDecimal(info.draws[draw].fund.rolloverIn);
                myDec = Decimal.Round(myDec);
                myMoney = myDec.ToString("0,0");

                rullPottLabel.Text = "Rullpott: " + myMoney + " kr";


                //Skriver ut spelstopp
                try
                {
                    spelStoppLabel.Text = "Spelstopp: " + weekDays[ info.draws[draw].cancelCloseTime.DayOfWeek.ToString() ]+ " " + info.draws[draw].cancelCloseTime.TimeOfDay;
                }
                catch 
                {
                    spelStoppLabel.Text = "Spelstopp: " + info.draws[draw].cancelCloseTime.DayOfWeek + " " + info.draws[draw].cancelCloseTime.TimeOfDay;
                }
            

            }

        }

        //Skriver ut n'sta bomb
        private void previousButton_Click(object sender, EventArgs e)
        {
            currentDraw = (currentDraw -1) < 0 ? info.draws.GetLength(0)-1 : (currentDraw -1);
            populateBombenTBs(currentDraw);
        }
        //Skriver ut f;reg[ende bomb
        private void nextButton_Click(object sender, EventArgs e)
        {
            currentDraw = (currentDraw + 1) > info.draws.GetLength(0)-1 ? 0 : (currentDraw + 1);
            populateBombenTBs(currentDraw);
        }

        private void Match1FörväntadMålantal_TextChanged(object sender, EventArgs e)
        {
            //Spara värdet från textbox 
            match1.under = Convert.ToDouble(Match1Under.Text);
            //Sätt till 100% om det finns ett värde i match1.över
            if (match1.över > 1)
            {
                match1.sättÖverUnderTill100Procent();
            }


            //Kolla om alla rutor är ifyllda i så fall börja beräkna!
            if (Match1Odds1.Text != null && Match1OddsX.Text != null && Match1Odds2.Text != null)
            {
                match1.förväntatAntalmål = Convert.ToDouble(Match1FörväntadMålantal.Text);
                match1.beräknaFörväntadMålantal();
                Match1UträknatMålAntal.Text = match1.förväntatAntalmål.ToString();
            }

        }

        private void Match2FörväntadMålantal_TextChanged(object sender, EventArgs e)
        {
            match2.under = Convert.ToDouble(Match2Under.Text);
            //Sätt till 100% om det finns ett värde i match1.över
            if (match2.över > 1)
            {
                match2.sättÖverUnderTill100Procent();
            }


            //Kolla om alla rutor är ifyllda i så fall börja beräkna!
            if (Match2Odds1.Text != null && Match2OddsX.Text != null && Match2Odds2.Text != null)
            {
                match2.förväntatAntalmål = Convert.ToDouble(Match2FörväntadMålantal.Text);
                match2.beräknaFörväntadMålantal();
                Match2UträknatMålAntal.Text = match2.förväntatAntalmål.ToString();
            }
        }

        private void Match3FörväntadMålantal_TextChanged(object sender, EventArgs e)
        {
            match3.under = Convert.ToDouble(Match3Under.Text);
            //Sätt till 100% om det finns ett värde i match1.över
            if (match3.över > 1)
            {
                match3.sättÖverUnderTill100Procent();
            }


            //Kolla om alla rutor är ifyllda i så fall börja beräkna!
            if (Match3Odds1.Text != null && Match3OddsX.Text != null && Match3Odds2.Text != null)
            {
                match3.förväntatAntalmål = Convert.ToDouble(Match3FörväntadMålantal.Text);
                match3.beräknaFörväntadMålantal();
                Match3UträknatMålAntal.Text = match3.förväntatAntalmål.ToString();
            }
        }

        private void Match4FörväntadMålantal_TextChanged(object sender, EventArgs e)
        {
            
            match4.under = Convert.ToDouble(Match4Under.Text);
            //Sätt till 100% om det finns ett värde i match1.över
            if (match4.över > 1)
            {
                match4.sättÖverUnderTill100Procent();
            }


            //Kolla om alla rutor är ifyllda i så fall börja beräkna!
            if (Match4Odds1.Text != null && Match4OddsX.Text != null && Match4Odds2.Text != null)
            {
                match4.förväntatAntalmål = Convert.ToDouble(Match4FörväntadMålantal.Text);
                match4.beräknaFörväntadMålantal();
                Match4UträknatMålAntal.Text = match4.förväntatAntalmål.ToString();
            }
        }

        

        private void calculateBtn_Click( object sender, EventArgs e)
        {
           
            SvSMobileSiteImporter bomb = new SvSMobileSiteImporter();
            int chosenDrawId = info.draws[currentDraw].drawNumber;
            //webadress
            string link = "https://svenskaspel.se/cas/getfile.aspx?file=playedcombinations&productid=7&drawid=" + chosenDrawId;
            //filnamn
            //string fileName = "PC_P7_D" + info.draws[draw].drawNumber.ToString() + ".zip";
            string fileName = "PC_P7_D" + chosenDrawId + ".zip";
            //Ladda ner filen
            bomb.downloadFileAsync( link, fileName );

            //Vänta på nerladdningen ska bli klar
            while( !bomb.downloadComplete );

            //Importera odds från textfil från SvS.
            int counter = FileImporter.countLines( chosenDrawId );
            double[,] bombenStats = new double[counter, 7];
            bombenStats = FileImporter.importBomben();

            //Hämta omsättning från textfil från SvS
            int turnOver = FileImporter.getTurnOver();
            
            
            //Kolumner: HemmaMålLag1, BortaMålLag1, HML2, BML2, HML3, BML3, Poisson, +1, +1ROI, +3, +3ROI 
            //Lägg till dem i matrisUtanOdds.
            matris3.skapaAllaResultatKombinationer();
            PoissonSannolikheter poissonSannolikheter = new PoissonSannolikheter();
            if( info.draws[currentDraw].eventCount == 3 )
            {
                poissonSannolikheter.beräknaAllaResultat(match1, match2, match3);
            }
            else if( info.draws[currentDraw].eventCount == 4 )
            {
                poissonSannolikheter.beräknaAllaResultat( match1, match2, match3, match4 );
            }
            else
            {
                poissonSannolikheter.beräknaAllaResultat( match1, match2 );
            }

            matris3.läggTillPoissonKolumn( poissonSannolikheter.allaResultat );
            
            //Stämpla starttid sluttid skrivs ut i matris.writeToFile
            string startTime = DateTime.Now.ToString( "HH:mm:ss tt" );
            
            //Behöver lägga till rollover i extrapott eller liknande
            double extraPott = Convert.ToDouble(info.draws[currentDraw].fund.extraMoney) + Convert.ToDouble(info.draws[currentDraw].fund.rolloverIn);
            matris3.läggTillPlusOchROI( bombenStats, counter, 1, turnOver, extraPott); 
            matris3.läggTillPlusOchROI( bombenStats, counter, 3, turnOver, extraPott );

            
            //Stämpla starttid sluttid skrivs ut i matris.writeToFile
            string stopTime = DateTime.Now.ToString( "HH:mm:ss tt" );
            
            dataGridViewController1.addCalculatedRows(matris3);
            AntalRaderTextLabel.Text = (dataGridViewController1.RowCount - 1).ToString();

            //Prompta om att ta bort gamla tempFiler
            Dialogboxes DB = new Dialogboxes();
            DB.deleteTempFiles(currentDraw);

            


        }

        private void BeräknaFörväntatMålAntalBtn_Click(object sender, EventArgs e)
        {
            Game[] matches = new Game[] { match1, match2, match3, match4 };
                        
            int antalmatcher = info.draws[currentDraw].eventCount;

            switch (antalmatcher)
            {
                case 4:
                    match4.odds1 = Convert.ToDouble(Match4Odds1.Text);
                    match4.oddsX = Convert.ToDouble(Match4OddsX.Text);
                    match4.odds2 = Convert.ToDouble(Match4Odds2.Text);
                    goto case 3;
                case 3:
                    match3.odds1 = Convert.ToDouble(Match3Odds1.Text);
                    match3.oddsX = Convert.ToDouble(Match3OddsX.Text);
                    match3.odds2 = Convert.ToDouble(Match3Odds2.Text);
                    goto case 2;
                case 2:
                    match2.odds1 = Convert.ToDouble(Match2Odds1.Text);
                    match2.oddsX = Convert.ToDouble(Match2OddsX.Text);
                    match2.odds2 = Convert.ToDouble(Match2Odds2.Text);
                    
                    match1.odds1 = Convert.ToDouble(Match1Odds1.Text);
                    match1.oddsX = Convert.ToDouble(Match1OddsX.Text);
                    match1.odds2 = Convert.ToDouble(Match1Odds2.Text);
                    break;

            } 

            for (int i = 0; i < antalmatcher; i++)
            {
                matches[i].sättOddsTill100Procent();
                //Spara värdet från textbox 
                matches[i].under = Convert.ToDouble(Match1Under.Text);
                //Sätt till 100% om det finns ett värde i match1.över
                if (matches[i].över > 1)
                {
                    matches[i].sättÖverUnderTill100Procent();
                }
            }


            //Kolla om alla rutor är ifyllda i så fall börja beräkna!
            switch (antalmatcher )
            {
                case 4:
                    if (Match4Odds1.Text != null && Match4OddsX.Text != null && Match4Odds2.Text != null)
                    {
                        match4.förväntatAntalmål = Convert.ToDouble(Match4FörväntadMålantal.Text);
                        match4.beräknaFörväntadMålantal();
                        Match4UträknatMålAntal.Text = match4.förväntatAntalmål.ToString();
                    }
                    goto case 3;   
                case 3:
                    if (Match3Odds1.Text != null && Match3OddsX.Text != null && Match3Odds2.Text != null)
                    {
                        match3.förväntatAntalmål = Convert.ToDouble(Match3FörväntadMålantal.Text);
                        match3.beräknaFörväntadMålantal();
                        Match3UträknatMålAntal.Text = match3.förväntatAntalmål.ToString();
                    }
                    goto case 2;
                case 2:
                    
                    if (Match1Odds1.Text != null && Match1OddsX.Text != null && Match1Odds2.Text != null)
                    {
                        match1.förväntatAntalmål = Convert.ToDouble(Match1FörväntadMålantal.Text);
                        match1.beräknaFörväntadMålantal();
                        Match1UträknatMålAntal.Text = match1.förväntatAntalmål.ToString();
                    }

                    if (Match2Odds1.Text != null && Match2OddsX.Text != null && Match2Odds2.Text != null)
                    {
                        match2.förväntatAntalmål = Convert.ToDouble(Match2FörväntadMålantal.Text);
                        match2.beräknaFörväntadMålantal();
                        Match2UträknatMålAntal.Text = match2.förväntatAntalmål.ToString();
                    }
                    break;
            
                    
            }

        }

        private void SkrivUtTextFilBtn_Click(object sender, EventArgs e)
        {
            //if (matris3.allaKombinationer != null)
            //{
                matris3.writeToFile();
            //}

        }

        private void updateInfoBtn_Click(object sender, EventArgs e)
        {
            string result = JsonInfo.getJsonString(new Uri(@"https://www.svenskaspel.se/bomben"));
            info = JsonConvert.DeserializeObject<SvSInfo>(result);
            populateBombenTBs(currentDraw);
        }
    }


        

        
        
}


