using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bomben
{
    class DataGridViewController : DataGridView 
    {
        public void setDeafaultHeadersAndWidth( )
        {
                       
            this.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            
            this.Columns.Add( "ColumnName1", "H1" );
            this.Columns.Add( "ColumnName2", "B1" );
            this.Columns.Add( "ColumnName3", "H2" );
            this.Columns.Add( "ColumnName4", "B2" );
            this.Columns.Add( "ColumnName5", "H3" );
            this.Columns.Add( "ColumnName6", "B3" );
            this.Columns.Add( "ColumnName7", "Poisson" );
            this.Columns.Add( "ColumnName8", "+1" );
            this.Columns.Add( "ColumnName9", "+1ROI" );
            this.Columns.Add( "ColumnName10", "+3" );
            this.Columns.Add( "ColumnName11", "+3ROI" );
            this.Columns[0].Width = 25;
            this.Columns[1].Width = 25;
            this.Columns[2].Width = 25;
            this.Columns[3].Width = 25;
            this.Columns[4].Width = 25;
            this.Columns[5].Width = 25;
            

            //For testing purposes
            /*
            this.Rows.Add("0", "0", "0", "0", "0", "1", "1369,71", "2353,83706124461", "1,71849301037782", "2226,6349160511", "1,62562507103774" );
            this.Rows.Add( "3", "2", "3", "6", "5", "10", "1369,71", "2353,83706124461", "1,71849301037782", "2226,6349160511", "1,62562507103774" );
            this.Rows.Add( "2", "2", "3", "4", "5", "6", "1369,71", "2353,83706124461", "1,71849301037782", "2226,6349160511", "1,62562507103774" );
            */
       
        }

        public void addCalculatedRows( Matris3 matrix )
        {
            for( int rad = 0; rad < 1771561; rad++ )
            {
                if( matrix.allaKombinationer[rad, 10] > 1 && matrix.allaKombinationer[rad, 0] < 7 && matrix.allaKombinationer[rad, 1] < 7 && matrix.allaKombinationer[rad, 2] < 7 && matrix.allaKombinationer[rad, 3] < 7 && matrix.allaKombinationer[rad, 4] < 7 && matrix.allaKombinationer[rad, 5] < 7 )
                {
                    this.Rows.Add( matrix.allaKombinationer[rad, 0], matrix.allaKombinationer[rad, 1], matrix.allaKombinationer[rad, 2], matrix.allaKombinationer[rad, 3], matrix.allaKombinationer[rad, 4], matrix.allaKombinationer[rad, 5], matrix.allaKombinationer[rad, 6], matrix.allaKombinationer[rad, 7], matrix.allaKombinationer[rad, 8], matrix.allaKombinationer[rad, 9], matrix.allaKombinationer[rad, 10], matrix.allaKombinationer[rad, 10] );                 
                }
            }
        }



        
    }
}
