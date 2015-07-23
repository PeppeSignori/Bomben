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

        
        
        private void populateGridView()
        {
            
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;


            dataGridView1.Columns.Add( "ColumnName1", "H1" );
            dataGridView1.Columns.Add( "ColumnName2", "B1" );
            dataGridView1.Columns.Add( "ColumnName3", "H2" );
            dataGridView1.Columns.Add( "ColumnName4", "B2" );
            dataGridView1.Columns.Add( "ColumnName5", "H3" );
            dataGridView1.Columns.Add( "ColumnName6", "B3" );
            dataGridView1.Columns.Add( "ColumnName7", "Poisson" );
            dataGridView1.Columns.Add( "ColumnName8", "+1" );
            dataGridView1.Columns.Add( "ColumnName9", "+1ROI" );
            dataGridView1.Columns.Add( "ColumnName10", "+3" );
            dataGridView1.Columns.Add( "ColumnName11", "+3ROI" );
            dataGridView1.Columns[0].Width = 25;
            dataGridView1.Columns[1].Width = 25;
            dataGridView1.Columns[2].Width = 25;
            dataGridView1.Columns[3].Width = 25;
            dataGridView1.Columns[4].Width = 25;
            dataGridView1.Columns[5].Width = 25;
            
            
            dataGridView1.Rows.Add("0", "0", "0", "0", "0", "1", "1369,71", "2353,83706124461", "1,71849301037782", "2226,6349160511", "1,62562507103774" );
            dataGridView1.Rows.Add( "1", "2", "3", "4", "5", "6", "1369,71", "2353,83706124461", "1,71849301037782", "2226,6349160511", "1,62562507103774" );

            AntalRaderTextLabel.Text = (dataGridView1.RowCount - 1).ToString();
        }


        public Form1()
        {
            InitializeComponent();
            
            string result = JsonInfo.getJsonString(new Uri(@"https://www.svenskaspel.se/bomben"));
            info = JsonConvert.DeserializeObject<SvSInfo>(result);
            populateBombenTBs(0);
            populateGridView();

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
            turnOverLabel.Text = "Omsättning: " +info.draws[draw].currentNetSales;
            extraPengarLabel.Text = "Extrapengar: " + info.draws[draw].fund.extraMoney;
            rullPottLabel.Text = "Rullpott: " + info.draws[draw].fund.rolloverIn;
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
            match2.förväntatAntalmål = Convert.ToDouble(Match2FörväntadMålantal);
        }

        private void Match3FörväntadMålantal_TextChanged(object sender, EventArgs e)
        {
            match3.förväntatAntalmål = Convert.ToDouble(Match3FörväntadMålantal);
        }

        private void Match4FörväntadMålantal_TextChanged(object sender, EventArgs e)
        {
            match4.förväntatAntalmål = Convert.ToDouble(Match4FörväntadMålantal);
        }


        

        
        
    }
}

