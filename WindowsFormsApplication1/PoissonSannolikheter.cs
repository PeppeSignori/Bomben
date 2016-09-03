using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomben
{
    class PoissonSannolikheter
    {
        public double[] allaResultat = new double[1771561];

        public void beräknaAllaResultat( Game Match1, Game Match2 )
        {
            int i = 0;
            int j = 0;
            int m = 0;

            for( int n = 0; n < 121; n = n + 1 )
            {
                if( n % 11 == 0 && n != 0 )
                {
                    i++;
                    j = 0;
                }

                allaResultat[m++] = Math.Round( 1 / (Match1.resultat[i] * Match2.resultat[j++]), 2 );
            }
        }

        public void beräknaAllaResultat( Game Match1, Game Match2, Game Match3 )
        {

            int i = 0;
            int j = 0;
            int k = 0;
            int m = 0;

            for( int n = 0; n < 1771561; n = n + 1 )
            {

                if( n % 121 == 0 && n != 0 )
                {
                    j++;
                    k = 0;
                }
                if( n % 14641 == 0 && n != 0 )
                {
                    i++;
                    j = 0;
                    k = 0;
                }
                allaResultat[m++] = Math.Round( 1 / (Match1.resultat[i] * Match2.resultat[j] * Match3.resultat[k++]), 2 );
            }
        }

        public void beräknaAllaResultat( Game Match1, Game Match2, Game Match3, Game Match4 )
        {

            int i = 0;
            int j = 0;
            int k = 0;
            int l = 0;
            int m = 0;

            for( int n = 0; n < 214358881; n = n + 1 )
            {

                if( n % 121 == 0 && n != 0 )
                {
                    k++;
                    l = 0;
                }
                if( n % 14641 == 0 && n != 0 )
                {
                    j++;
                    k = 0;
                    l = 0;
                }
                if( n % 1771561 == 0 && n != 0 )
                {
                    i++;
                    j = 0;
                    k = 0;
                    l = 0;
                }
                allaResultat[m++] = Math.Round( 1 / (Match1.resultat[i] * Match2.resultat[j] * Match3.resultat[k] * Match4.resultat[l++]), 2 );
            }
        }
    }
}
