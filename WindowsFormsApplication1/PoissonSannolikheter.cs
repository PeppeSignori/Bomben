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

        public void beräknaAllaResultat(Game Match1, Game Match2)
        {
            int j = 0;
            int k = 0;
            int l = 0;

            for (int m = 0; m < 121; m = m + 1)
            {
                if (m % 11 == 0 && m != 0)
                {
                    j++;
                    k = 0;
                }

                //this.resultat[l++] = this.hemmaMålSannolikhet[j] * this.bortaMålSannolikhet[k++];
            }
        }

        public void beräknaAllaResultat(Game Match1, Game Match2, Game Match3)
        {
            Match1.beräknaFörväntadMålantal();
            int i = 0;
            int j = 0;
            int k = 0;
            int l = 0;

            for (int m = 0; m < 1771561; m = m + 1)
            {

                if (m % 121 == 0 && m != 0)
                {
                    j++;
                    k = 0;
                }
                if (m % 14641 == 0 && m != 0)
                {
                    i++;
                    j = 0;
                    k = 0;
                }
                allaResultat[l++] = Math.Round(1 / (Match1.resultat[i] * Match2.resultat[j] * Match3.resultat[k++]), 2);
            }
        }

        public void beräknaAllaResultat(Game Match1, Game Match2, Game Match3, Game Match4)
        {

        }
    }
}
