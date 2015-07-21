using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        int drawLength=0;
        
        Game match1 = new Game();
        Game match2 = new Game();
        Game match4 = new Game();
        Game match3 = new Game();
        
        public Form1()
        {
            InitializeComponent();
            
            string result = JsonInfo.getJsonString(new Uri(@"https://www.svenskaspel.se/bomben"));
            info = JsonConvert.DeserializeObject<SvSInfo>(result);
            populateBombenTBs(0);

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
            //Spara värdet från textbox
            match1.under = Convert.ToDouble(Match1Under.Text);
            //Sätt till 100% om det finns ett värde i match1.över
            if (match1.över > 1)
            {
                match1.sättÖverUnderTill100Procent();
            }
            
            //Kolla om alla rutor är ifyllda i så fall börja beräkna! 
            if (Match1Odds1.Text != null && Match1OddsX.Text != null)
            {
                Match1FörväntadMålantal.Text = "Testar";
            }
            
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
            //Spara värdet från textbox
            match2.under = Convert.ToDouble(Match2Under.Text);
            //Sätt till 100% om det finns ett värde i match1.över
            if (match2.över > 1)
            {
                match2.sättÖverUnderTill100Procent();
            }
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
            //Spara värdet från textbox
            match3.under = Convert.ToDouble(Match3Under.Text);
            //Sätt till 100% om det finns ett värde i match1.över
            if (match3.över > 1)
            {
                match3.sättÖverUnderTill100Procent();
            }
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
            //Spara värdet från textbox
            match4.under = Convert.ToDouble(Match4Under.Text);
            //Sätt till 100% om det finns ett värde i match1.över
            if (match4.över > 1)
            {
                match4.sättÖverUnderTill100Procent();
            }
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

            try
            {
                bombNrTB.Text = weekDays[ info.draws[draw].cancelCloseTime.DayOfWeek.ToString() ] +" " +info.draws[draw].description;
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

            //Skriver ut omsättning, extrapengar och rullpott
            string temp = info.draws[draw].currentNetSales;
            turnOverLabel.Text = "Omsättning: " + temp;

            temp = info.draws[draw].fund.extraMoney;
            extraPengarLabel.Text = "Extrapengar: " + temp;

            temp = info.draws[draw].fund.rolloverIn;
            rullPottLabel.Text = "Rullpott: " + temp;
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

        //Skriver ut n'sta bomb
        private void previousButton_Click(object sender, EventArgs e)
        {
            drawLength = (drawLength -1) < 0 ? info.draws.GetLength(0)-1 : (drawLength -1);
            populateBombenTBs(drawLength);
        }
        //Skriver ut f;reg[ende bomb
        private void nextButton_Click(object sender, EventArgs e)
        {
            drawLength = (drawLength + 1) > info.draws.GetLength(0)-1 ? 0 : (drawLength + 1);
            populateBombenTBs(drawLength);
        }


        
        
    }
}

