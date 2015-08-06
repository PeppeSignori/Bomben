using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bomben
{
    class DataGridViewController : DataGridView 
    {
        public void setDeafaultHeadersAndWidth( TextBox antalPlus1, TextBox antalPlus2)
        {
                                  
            this.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            
            this.Columns.Add( "ColumnName1", "H1" );
            this.Columns.Add( "ColumnName2", "B1" );
            this.Columns.Add( "ColumnName3", "H2" );
            this.Columns.Add( "ColumnName4", "B2" );
            this.Columns.Add( "ColumnName5", "H3" );
            this.Columns.Add( "ColumnName6", "B3" );
            this.Columns.Add( "ColumnName7", "Poisson" );
            this.Columns.Add( "ColumnName8",  "+" +antalPlus1.Text.ToString() );
            this.Columns.Add( "ColumnName9",  "+" +antalPlus1.Text.ToString() +"ROI");
            this.Columns.Add( "ColumnName10", "+" +antalPlus2.Text.ToString() );
            this.Columns.Add( "ColumnName11", "+" +antalPlus2.Text.ToString() +"ROI" );
            this.Columns[0].Width = 25;
            this.Columns[1].Width = 25;
            this.Columns[2].Width = 25;
            this.Columns[3].Width = 25;
            this.Columns[4].Width = 25;
            this.Columns[5].Width = 25;
            this.Columns[6].Width = 60;
            this.Columns[7].Width = 60;
            this.Columns[8].Width = 60;
            this.Columns[9].Width = 60;
            this.Columns[10].Width = 60;

            //For testing purposes
            //this.Rows.Add("0", "0", "0", "0", "0", "1", "1369,71", "2353,83706124461", "1,71849301037782", "2226,6349160511", "1,62562507103774" );
            //this.Rows.Add( "3", "2", "3", "6", "5", "10", "1369,71", "2353,83706124461", "1,71849301037782", "2226,6349160511", "1,62562507103774" );
            //this.Rows.Add( "2", "2", "3", "4", "5", "6", "1369,71", "2353,83706124461", "1,71849301037782", "2226,6349160511", "1,62562507103774" );
        }

        public void addCalculatedRows( Matris3 matrix, int[] maxConstraints )
        {

            for( int rad = 0; rad < 1771561; rad++ )
            {
                if (matrix.allaKombinationer[rad, 10] > 1 && matrix.allaKombinationer[rad, 0] < maxConstraints[0] && matrix.allaKombinationer[rad, 1] < maxConstraints[1] && matrix.allaKombinationer[rad, 2] < maxConstraints[2] && matrix.allaKombinationer[rad, 3] < maxConstraints[3] && matrix.allaKombinationer[rad, 4] < maxConstraints[4] && matrix.allaKombinationer[rad, 5] < maxConstraints[5])
                {
                      this.Rows.Add( matrix.allaKombinationer[rad, 0], matrix.allaKombinationer[rad, 1], matrix.allaKombinationer[rad, 2], matrix.allaKombinationer[rad, 3], matrix.allaKombinationer[rad, 4], matrix.allaKombinationer[rad, 5], Math.Round(matrix.allaKombinationer[rad, 6],0), Math.Round(matrix.allaKombinationer[rad, 7],0), Math.Round(matrix.allaKombinationer[rad, 8],2), Math.Round(matrix.allaKombinationer[rad, 9],0), Math.Round(matrix.allaKombinationer[rad, 10],2) );                 
                }
            }
            var me = Convert.ToInt32(this.Rows[0].Cells[8].Value);
        }

        public void removeAllRows()
        {
            for(int i=0; i<11; i++)
            {
                this.Columns.RemoveAt( 0 );
            }
        }


        public void printGridRowes()
        {
            
            StreamWriter sw = new StreamWriter("EgnaRader.txt");
            sw.WriteLine("Bomben,Bombennummer=X,Insats=1");
            
            for (int i = 0; i<(this.RowCount-1); i++ )
            {   
                //För varje ny rad
                sw.Write("E");
                
                for(int ii = 0; ii<6; ii=ii+2)
                {
                    sw.Write(",");

                    sw.Write( this.Rows[i].Cells[ii].Value.ToString() +"-" + this.Rows[i].Cells[(ii+1)].Value.ToString() );
                }
                sw.Write("\r\n");
            }
                        
            sw.Close();
                      
        
        }



        
    }
}
