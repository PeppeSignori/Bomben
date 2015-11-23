using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Bomben
{
    public partial class Form1 : Form
    {
        CultureInfo culture = new CultureInfo( "sv-SE" );
        
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

            string result = JsonInfo.getJsonString( new Uri( @"https://www.svenskaspel.se/bomben" ) );
            info = JsonConvert.DeserializeObject<SvSInfo>( result );
            populateBombenTBs( currentDraw );
            dataGridViewController1.setDeafaultHeadersAndWidth( tbAntalPlus1, tbAntalPlus2 );


        }


        private void populateBombenTBs( int draw )
        {
            //Vilken bomb - skriver ut veckodag och "Bomben 1"
            Dictionary<string, string> weekDays = new Dictionary<string, string>();
            weekDays.Add( "Monday", "Mån" );
            weekDays.Add( "Tuesday", "Tis" );
            weekDays.Add( "Wednesday", "Ons" );
            weekDays.Add( "Thursday", "Tor" );
            weekDays.Add( "Friday", "Fre" );
            weekDays.Add( "Saturday", "Lör" );
            weekDays.Add( "Sunday", "Sön" );

            //Sortera ut de som inte är öppna för spel
            while( info.draws[draw].enabled != true && draw < info.draws.Length )
            {
                draw++;
            }

            //Skriv bara ut om det finns ett öppet spel
            if( draw < info.draws.Length )
            {

                try
                {
                    bombNrTB.Text = weekDays[info.draws[draw].cancelCloseTime.DayOfWeek.ToString()] +" " +info.draws[draw].description +"\t" +info.draws[draw].drawNumber.ToString();
                }
                catch
                {
                    bombNrTB.Text = info.draws[draw].cancelCloseTime.DayOfWeek + " " + info.draws[draw].description;
                }

                //Hemmalag och bortalag textboxar
                TextBox[] textBoxes = new TextBox[] { textBox16, textBox17, textBox19, textBox20, textBox28, textBox29, textBox37, textBox38 };

                //nollställ textboxar
                for( int i = 0; i <8; i++ )
                {
                    textBoxes[i].Text = "";
                }

                //Skriv ut lagnamn
                for( int i = 0, j=0; i < info.draws[draw].events.GetLength( 0 ); i++, j=j+2 )
                {
                    textBoxes[j].Text = info.draws[draw].events[i].match.participants[0].name;
                    textBoxes[j+1].Text = info.draws[draw].events[i].match.participants[1].name;
                }


                CultureInfo culture = new CultureInfo( "sv-SE" );
                //Skriver ut omsättning
                decimal myDec = Convert.ToDecimal( info.draws[draw].currentNetSales, culture );
                turnOverLabel.Text = myDec != 0 ? "Omsättning: " + myDec.ToString( "# #,##", culture )  +" kr" : "Omsättning: " + "0 kr";

                //extrapengar
                myDec = Convert.ToDecimal( info.draws[draw].fund.extraMoney, culture );
                extraPengarLabel.Text = myDec != 0 ? "Extrapengar: " + myDec.ToString( "# #,##", culture ) + " kr" : "Extrapengar: " + "0 kr";

                //Rullpott
                myDec = Convert.ToDecimal( info.draws[draw].fund.rolloverIn, culture );
                rullPottLabel.Text = myDec != 0 ? "Rullpott: " + myDec.ToString( "# #,##", culture ) + " kr" : "Rullpott: " + "0 kr";


                //Skriver ut spelstopp
                try
                {
                    spelStoppLabel.Text = "Spelstopp: " + weekDays[info.draws[draw].cancelCloseTime.DayOfWeek.ToString()]+ " " + info.draws[draw].cancelCloseTime.TimeOfDay;
                }
                catch
                {
                    spelStoppLabel.Text = "Spelstopp: " + info.draws[draw].cancelCloseTime.DayOfWeek + " " + info.draws[draw].cancelCloseTime.TimeOfDay;
                }


            }

        }

        //Skriver ut n'sta bomb
        private void previousButton_Click( object sender, EventArgs e )
        {
            currentDraw = (currentDraw -1) < 0 ? info.draws.GetLength( 0 )-1 : (currentDraw -1);
            populateBombenTBs( currentDraw );
        }
        //Skriver ut f;reg[ende bomb
        private void nextButton_Click( object sender, EventArgs e )
        {
            currentDraw = (currentDraw + 1) > info.draws.GetLength( 0 )-1 ? 0 : (currentDraw + 1);
            populateBombenTBs( currentDraw );
        }


        private void calculateBtn_Click( object sender, EventArgs e )
        {

            int chosenDrawId;
            if( olderGameChkbox.Checked )
            {
                chosenDrawId = Convert.ToInt32( olderGameTb.Text );
            }
            else
            {
                chosenDrawId = info.draws[currentDraw].drawNumber;
            }

            SvSMobileSiteImporter bomb = new SvSMobileSiteImporter();
            //webadress
            string link = "https://svenskaspel.se/cas/getfile.aspx?file=playedcombinations&productid=7&drawid=" + chosenDrawId;
            //filnamn
            //string fileName = "PC_P7_D" + info.draws[draw].drawNumber.ToString() + ".zip";
            string fileName = "PC_P7_D" + chosenDrawId + ".zip";
            //Ladda ner filen
            bomb.downloadFileAsync( link, fileName );

            //Vänta på nerladdningen ska bli klar
            while( !bomb.downloadComplete ) ;

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
                poissonSannolikheter.beräknaAllaResultat( match1, match2, match3 );
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
            double extraPott = Convert.ToDouble( info.draws[currentDraw].fund.extraMoney ) + Convert.ToDouble( info.draws[currentDraw].fund.rolloverIn );
            matris3.läggTillPlusOchROI( bombenStats, counter, Convert.ToDouble( tbAntalPlus1.Text ), Convert.ToDouble( turnOver ), Convert.ToDouble( extraPott ) );
            matris3.läggTillPlusOchROI( bombenStats, counter, Convert.ToDouble( tbAntalPlus2.Text ), Convert.ToDouble( turnOver ), Convert.ToDouble( extraPott ) );



            //Stämpla starttid sluttid skrivs ut i matris.writeToFile
            string stopTime = DateTime.Now.ToString( "HH:mm:ss tt" );

            MessageBox.Show( "Start: " + startTime.ToString() + "\n" + "Stopp: " + stopTime.ToString() );


            int[] maxMål = new int[] { Convert.ToInt32( MaxMålHemmalagMatch1.Text ), Convert.ToInt32( MaxMålBortalagMatch1.Text ), Convert.ToInt32( MaxMålHemmalagMatch2.Text ), Convert.ToInt32( MaxMålBortalagMatch2.Text ), Convert.ToInt32( MaxMålHemmalagMatch3.Text ), Convert.ToInt32( MaxMålBortalagMatch3.Text ), Convert.ToInt32( MaxMålHemmalagMatch4.Text ), Convert.ToInt32( MaxMålBortalagMatch4.Text ) };
            dataGridViewController1.addCalculatedRows( matris3, maxMål );
            AntalRaderTextLabel.Text = (dataGridViewController1.RowCount - 1).ToString();
            setFilterStartValues( maxMål );

            //Prompta om att ta bort gamla tempFiler
            Dialogboxes DB = new Dialogboxes();
            DB.deleteTempFiles( currentDraw );

        }
        

        private void setFilterStartValues( int[] maxMål )
        {
            
            List<ComboBox> filterBoxes = new List<ComboBox>() { cbH1, cbB1, cbH2, cbB2, cbH3, cbB3, cbH4, cbB4 };
            int maxAntal = 0;
            foreach (var box in filterBoxes)
	        {
                for(int i=0; i<=maxMål[maxAntal]; i++)
                {
                    box.Items.Add(i);
                }
                maxAntal++;
	        }
            
        }

        private void filterDataGridView()
        {
            List<ComboBox> filterBoxes = new List<ComboBox>() { cbH1, cbB1, cbH2, cbB2, cbH3, cbB3, cbH4, cbB4 };
            int[] max = new int[]
            { 
                Convert.ToInt32( MaxMålHemmalagMatch1.Text ),
                Convert.ToInt32( MaxMålBortalagMatch1.Text ),
                Convert.ToInt32( MaxMålHemmalagMatch2.Text ),
                Convert.ToInt32( MaxMålBortalagMatch2.Text ),
                Convert.ToInt32( MaxMålHemmalagMatch3.Text ),
                Convert.ToInt32( MaxMålBortalagMatch3.Text ),
                Convert.ToInt32( MaxMålHemmalagMatch4.Text ),
                Convert.ToInt32( MaxMålBortalagMatch4.Text )
            };

            int[] filterConstraints = new int[filterBoxes.Count];

            for( int i = 0; i < filterBoxes.Count; i++ )
            {
                filterConstraints[i] = filterBoxes[i].SelectedItem == null ? max[i] : (int)filterBoxes[i].SelectedItem;
            }

            dataGridViewController1.filter( matris3, filterConstraints );
            lbFiltreradeRader.Text = "Efter filtrering: " +(dataGridViewController1.RowCount - 1).ToString();
            
        }

        

        private void SkrivUtTextFilBtn_Click( object sender, EventArgs e )
        {
            
            List<double> maxGoals = new List<double>()
            {
                Convert.ToDouble( MaxMålHemmalagMatch1.Text ),
                Convert.ToDouble( MaxMålBortalagMatch1.Text ),
                Convert.ToDouble( MaxMålHemmalagMatch2.Text ),
                Convert.ToDouble( MaxMålBortalagMatch2.Text ),
                Convert.ToDouble( MaxMålHemmalagMatch3.Text ),
                Convert.ToDouble( MaxMålBortalagMatch3.Text ),
                Convert.ToDouble( MaxMålHemmalagMatch4.Text ),
                Convert.ToDouble( MaxMålBortalagMatch4.Text )
            };

            matris3.writeToFile( tbAntalPlus1.Text, tbAntalPlus2.Text, maxGoals );
            dataGridViewController1.printGridRowes();

        }

        private void updateInfoBtn_Click( object sender, EventArgs e )
        {
            string result = JsonInfo.getJsonString( new Uri( @"https://www.svenskaspel.se/bomben" ) );
            info = JsonConvert.DeserializeObject<SvSInfo>( result );
            populateBombenTBs( currentDraw );
        }

        private void BeräknaFörväntatMålAntalBtn_Click( object sender, EventArgs e )
        {

            Game[] matches = new Game[] { match1, match2, match3, match4 };
            TextBox[] oddsUnder = new TextBox[] { Match1Under, Match2Under, Match3Under, Match4Under };
            TextBox[] oddsÖver = new TextBox[] { Match1Över, Match2Över, Match3Över, Match4Över };
            int antalmatcher = info.draws[currentDraw].eventCount;

            switch( antalmatcher )
            {
                case 4:
                match4.odds1 = Convert.ToDouble( Match4Odds1.Text );
                match4.oddsX = Convert.ToDouble( Match4OddsX.Text );
                match4.odds2 = Convert.ToDouble( Match4Odds2.Text );
                goto case 3;
                case 3:
                match3.odds1 = Convert.ToDouble( Match3Odds1.Text );
                match3.oddsX = Convert.ToDouble( Match3OddsX.Text );
                match3.odds2 = Convert.ToDouble( Match3Odds2.Text );
                goto case 2;
                case 2:
                match2.odds1 = Convert.ToDouble( Match2Odds1.Text );
                match2.oddsX = Convert.ToDouble( Match2OddsX.Text );
                match2.odds2 = Convert.ToDouble( Match2Odds2.Text );

                match1.odds1 = Convert.ToDouble( Match1Odds1.Text );
                match1.oddsX = Convert.ToDouble( Match1OddsX.Text );
                match1.odds2 = Convert.ToDouble( Match1Odds2.Text );
                break;

            }

            for( int i = 0; i < antalmatcher; i++ )
            {
                matches[i].sättOddsTill100Procent();
                //Spara värdet från textbox 
                matches[i].under = Convert.ToDouble( oddsUnder[i].Text );
                matches[i].över = Convert.ToDouble( oddsÖver[i].Text );
                //Sätt till 100% om det finns ett värde i match1.över
                if( matches[i].över > 1 )
                {
                    matches[i].sättÖverUnderTill100Procent();
                }
            }


            //Kolla om alla rutor är ifyllda i så fall börja beräkna!
            switch( antalmatcher )
            {
                case 4:
                if( Match4Odds1.Text != null && Match4OddsX.Text != null && Match4Odds2.Text != null )
                {
                    match4.förväntatAntalmål = Convert.ToDouble( Match4FörväntadMålantal.Text );
                    match4.beräknaFörväntadMålantal();
                    Match4UträknatMålAntal.Text = match4.förväntatAntalmål.ToString( "0.###" );
                }
                goto case 3;
                case 3:
                if( Match3Odds1.Text != null && Match3OddsX.Text != null && Match3Odds2.Text != null )
                {
                    match3.förväntatAntalmål = Convert.ToDouble( Match3FörväntadMålantal.Text );
                    match3.beräknaFörväntadMålantal();
                    Match3UträknatMålAntal.Text = match3.förväntatAntalmål.ToString( "0.###" );
                }
                goto case 2;
                case 2:

                if( Match1Odds1.Text != null && Match1OddsX.Text != null && Match1Odds2.Text != null )
                {
                    match1.förväntatAntalmål = Convert.ToDouble( Match1FörväntadMålantal.Text );
                    match1.beräknaFörväntadMålantal();
                    Match1UträknatMålAntal.Text = match1.förväntatAntalmål.ToString( "0.###" );
                }

                if( Match2Odds1.Text != null && Match2OddsX.Text != null && Match2Odds2.Text != null )
                {
                    match2.förväntatAntalmål = Convert.ToDouble( Match2FörväntadMålantal.Text );
                    match2.beräknaFörväntadMålantal();
                    Match2UträknatMålAntal.Text = match2.förväntatAntalmål.ToString( "0.###" );
                }
                break;


            }
        }

        private void olderGameChkbox_CheckedChanged( object sender, EventArgs e )
        {
            //Inaktivera textboxar
            bool disableTeamTextboxes = olderGameChkbox.Checked ? false : true;

            bombNrTB.Enabled = disableTeamTextboxes;
            textBox16.Enabled = disableTeamTextboxes;
            textBox19.Enabled = disableTeamTextboxes;
            textBox28.Enabled = disableTeamTextboxes;
            textBox37.Enabled = disableTeamTextboxes;
            textBox17.Enabled = disableTeamTextboxes;
            textBox20.Enabled = disableTeamTextboxes;
            textBox29.Enabled = disableTeamTextboxes;
            textBox38.Enabled = disableTeamTextboxes;

            olderGameTb.Enabled = !disableTeamTextboxes;

        }

        private void tbAntalPlus1_TextChanged( object sender, EventArgs e )
        {
            dataGridViewController1.removeAllRows();
            dataGridViewController1.setDeafaultHeadersAndWidth( tbAntalPlus1, tbAntalPlus2 );
        }

        private void tbAntalPlus2_TextChanged( object sender, EventArgs e )
        {
            dataGridViewController1.removeAllRows();
            dataGridViewController1.setDeafaultHeadersAndWidth( tbAntalPlus1, tbAntalPlus2 );
        }

        //Meny
        private void testOddsToolStripMenuItem_Click( object sender, EventArgs e )
        {
            if( MenuTestOddsItem.Checked )
            {
                DialogResult dr = MessageBox.Show( "Vill du skriva över oddsfälten?", "Ta bort?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning );
                if( dr == DialogResult.Yes )
                {
                    Match1Odds1.Text = "1,42";
                    Match1Odds2.Text = "9,8";
                    Match1OddsX.Text = "5,1";
                    Match1Under.Text = "2,18";
                    Match1Över.Text  = "1,83";
                                         
                    Match2Odds1.Text = "2,48";
                    Match2Odds2.Text = "3,3";
                    Match2OddsX.Text = "3,35";
                    Match2Under.Text = "1,74";
                    Match2Över.Text  = "2,3";
                                         
                    Match3Odds1.Text = "2,28";
                    Match3Odds2.Text = "3,35";
                    Match3OddsX.Text = "3,55";
                    Match3Under.Text = "1,98";
                    Match3Över.Text = "2,00";
                }
                else
                {
                    MenuTestOddsItem.Checked = false;
                }

            }
            else
            {
                DialogResult dr = MessageBox.Show( "Nollställ oddsfälten?", "Nollställ?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning );
                if( dr == DialogResult.Yes )
                {
                    Match1Odds1.Text = "";
                    Match1Odds2.Text = "";
                    Match1OddsX.Text = "";
                    Match1Under.Text = "";
                    Match1Över.Text  = "";

                    Match2Odds1.Text = "";
                    Match2Odds2.Text = "";
                    Match2OddsX.Text = "";
                    Match2Under.Text = "";
                    Match2Över.Text  = "";

                    Match3Odds1.Text = "";
                    Match3Odds2.Text = "";
                    Match3OddsX.Text = "";
                    Match3Under.Text = "";
                    Match3Över.Text  = "";

                }
                else
                {
                    MenuTestOddsItem.Checked = true;
                }
            }
        }

        private void avslutaToolStripMenuItem_Click( object sender, EventArgs e )
        {
            Application.Exit();
        }

        //Filterboxes
        #region
        private void cbH1_SelectedIndexChanged( object sender, EventArgs e )
        {
            filterDataGridView();            
        }

        private void cbB1_SelectedIndexChanged( object sender, EventArgs e )
        {
            filterDataGridView();
        }

        private void cbH2_SelectedIndexChanged( object sender, EventArgs e )
        {
            filterDataGridView();
        }

        private void cbB2_SelectedIndexChanged( object sender, EventArgs e )
        {
            filterDataGridView();
        }

        private void cbH3_SelectedIndexChanged( object sender, EventArgs e )
        {
            filterDataGridView();
        }

        private void cbB3_SelectedIndexChanged( object sender, EventArgs e )
        {
            filterDataGridView();
        }

        private void cbH4_SelectedIndexChanged( object sender, EventArgs e )
        {
            filterDataGridView();
        }

        private void cbB4_SelectedIndexChanged( object sender, EventArgs e )
        {
            filterDataGridView();
        }
        #endregion


    }






}


