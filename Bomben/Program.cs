using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomben
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // Match 1
            
            Match Match1 = new Match();

            Console.WriteLine("Match 1");
            Console.WriteLine("-------");
            Console.WriteLine();

            Console.Write("Odds på 1: ");
            double M11 = 1 / Convert.ToDouble(Console.ReadLine());
            Console.Write("Odds på X: ");
            double M1X = 1 / Convert.ToDouble(Console.ReadLine());
            Console.Write("Odds på 2: ");
            double M12 = 1 / Convert.ToDouble(Console.ReadLine());

            Console.WriteLine();

            Console.Write("Över/Under [2,5]/[5,5]: ");
            double M1ÖU = Convert.ToDouble(Console.ReadLine());
            while ((M1ÖU != 2.5) && (M1ÖU != 5.5))
            {
                Console.Write("Över/Under [2,5]/[5,5]: ");
                M1ÖU = Convert.ToDouble(Console.ReadLine());
            }

            Console.Write("Odds på över " + M1ÖU + ":");
            double M1Ö = 1 / Convert.ToDouble(Console.ReadLine());
            Console.Write("Odds på under " + M1ÖU + ":");
            double M1U = 1 / Convert.ToDouble(Console.ReadLine());
            double M1HÖ = (M1Ö / (M1Ö + M1U));
            double M1HU = (M1U / (M1Ö + M1U));

            Console.WriteLine();

            Console.Write("Ändra nåt? [j]: ");
            string answer1 = Console.ReadLine();

            while (answer1 == "j")
            {

                Console.WriteLine();

                Console.Write("Odds på 1: ");
                M11 = 1 / Convert.ToDouble(Console.ReadLine());
                Console.Write("Odds på X: ");
                M1X = 1 / Convert.ToDouble(Console.ReadLine());
                Console.Write("Odds på 2: ");
                M12 = 1 / Convert.ToDouble(Console.ReadLine());

                Console.WriteLine();

                Console.Write("Över/Under [2,5]/[5,5]: ");
                M1ÖU = Convert.ToDouble(Console.ReadLine());
                Console.Write("Odds på över " + M1ÖU + ":");
                M1Ö = 1 / Convert.ToDouble(Console.ReadLine());
                Console.Write("Odds på under " + M1ÖU + ":");
                M1U = 1 / Convert.ToDouble(Console.ReadLine());
                M1HÖ = (M1Ö / (M1Ö + M1U));
                M1HU = (M1U / (M1Ö + M1U));

                Console.WriteLine();

                Console.Write("Ändra nåt? [j]: ");
                answer1 = Console.ReadLine();
            }

            Console.WriteLine();

            Console.Write("100 % odds på över " + M1ÖU + ":");
            Console.WriteLine(Math.Round(1 / M1HÖ, 2));
            Console.Write("100 % odds på under " + M1ÖU + ":");
            Console.WriteLine(Math.Round(1 / M1HU, 2));

            Console.WriteLine();

            Console.Write("Förväntat målantal: ");
            double M1M = Convert.ToDouble(Console.ReadLine());

            double H1 = (M11 + M1X / 2) / (M11 + M1X + M12);
            double B1 = (M12 + M1X / 2) / (M11 + M1X + M12);
            double lambda1 = H1 * M1M;
            double lambda2 = B1 * M1M;

            Match1.poisson(lambda1, "hemma");
            Match1.poisson(lambda2, "borta");
            Match1.beräknaResultat();

            Console.WriteLine();
             
            // Match 2                                  
           
            Match Match2 = new Match();


            Console.WriteLine("Match 2");
            Console.WriteLine("-------");
            Console.WriteLine();

            Console.Write("Odds på 1: ");
            double M21 = 1 / Convert.ToDouble(Console.ReadLine());
            Console.Write("Odds på X: ");
            double M2X = 1 / Convert.ToDouble(Console.ReadLine());
            Console.Write("Odds på 2: ");
            double M22 = 1 / Convert.ToDouble(Console.ReadLine());

            Console.WriteLine();

            Console.Write("Över/Under [2,5]/[5,5]: ");
            double M2ÖU = Convert.ToDouble(Console.ReadLine());
            while ((M2ÖU != 2.5) && (M2ÖU != 5.5))
            {
                Console.Write("Över/Under [2,5]/[5,5]: ");
                M1ÖU = Convert.ToDouble(Console.ReadLine());
            }

            Console.Write("Odds på över " + M2ÖU + ":");
            double M2Ö = 1 / Convert.ToDouble(Console.ReadLine());
            Console.Write("Odds på under " + M2ÖU + ":");
            double M2U = 1 / Convert.ToDouble(Console.ReadLine());
            double M2HÖ = (M2Ö / (M2Ö + M2U));
            double M2HU = (M2U / (M2Ö + M2U));

            Console.WriteLine();

            Console.Write("Ändra nåt? [j]: ");
            string answer2 = Console.ReadLine();

            while (answer2 == "j")
            {

                Console.WriteLine();

                Console.Write("Odds på 1: ");
                M21 = 1 / Convert.ToDouble(Console.ReadLine());
                Console.Write("Odds på X: ");
                M2X = 1 / Convert.ToDouble(Console.ReadLine());
                Console.Write("Odds på 2: ");
                M22 = 1 / Convert.ToDouble(Console.ReadLine());

                Console.WriteLine();

                Console.Write("Över/Under [2,5]/[5,5]: ");
                M2ÖU = Convert.ToDouble(Console.ReadLine());
                Console.Write("Odds på över " + M2ÖU + ":");
                M2Ö = 1 / Convert.ToDouble(Console.ReadLine());
                Console.Write("Odds på under " + M2ÖU + ":");
                M2U = 1 / Convert.ToDouble(Console.ReadLine());
                M2HÖ = (M2Ö / (M2Ö + M2U));
                M2HU = (M2U / (M2Ö + M2U));

                Console.WriteLine();

                Console.Write("Ändra nåt? [j]: ");
                answer2 = Console.ReadLine();
            }

            Console.WriteLine();

            Console.Write("100 % odds på över " + M1ÖU + ":");
            Console.WriteLine(Math.Round(1 / M2HÖ, 2));
            Console.Write("100 % odds på under " + M1ÖU + ":");
            Console.WriteLine(Math.Round(1 / M2HU, 2));

            Console.WriteLine();

            Console.Write("Förväntat målantal: ");
            double M2M = Convert.ToDouble(Console.ReadLine());

            double H2 = (M21 + M2X / 2) / (M21 + M2X + M22);
            double B2 = (M22 + M2X / 2) / (M21 + M2X + M22);
            double lambda3 = H2 * M2M;
            double lambda4 = B2 * M2M;

            Match2.poisson(lambda3, "hemma");
            Match2.poisson(lambda4, "borta");
            Match2.beräknaResultat();

            Console.WriteLine();

            // Match 3

            Match Match3 = new Match();
            
            Console.WriteLine("Match 3");
            Console.WriteLine("-------");
            Console.WriteLine();

            Console.Write("Odds på 1: ");
            double M31 = 1 / Convert.ToDouble(Console.ReadLine());
            Console.Write("Odds på X: ");
            double M3X = 1 / Convert.ToDouble(Console.ReadLine());
            Console.Write("Odds på 2: ");
            double M32 = 1 / Convert.ToDouble(Console.ReadLine());

            Console.WriteLine();

            Console.Write("Över/Under [2,5]/[5,5]: ");
            double M3ÖU = Convert.ToDouble(Console.ReadLine());
            while ((M3ÖU != 2.5) && (M3ÖU != 5.5))
            {
                Console.Write("Över/Under [2,5]/[5,5]: ");
                M3ÖU = Convert.ToDouble(Console.ReadLine());
            }

            Console.Write("Odds på över " + M3ÖU + ":");
            double M3Ö = 1 / Convert.ToDouble(Console.ReadLine());
            Console.Write("Odds på under " + M3ÖU + ":");
            double M3U = 1 / Convert.ToDouble(Console.ReadLine());
            double M3HÖ = (M3Ö / (M3Ö + M3U));
            double M3HU = (M3U / (M3Ö + M3U));

            Console.WriteLine();

            Console.Write("Ändra nåt? [j]: ");
            string answer = Console.ReadLine();

            while (answer == "j")
            {

                Console.WriteLine();

                Console.Write("Odds på 1: ");
                M31 = 1 / Convert.ToDouble(Console.ReadLine());
                Console.Write("Odds på X: ");
                M3X = 1 / Convert.ToDouble(Console.ReadLine());
                Console.Write("Odds på 2: ");
                M32 = 1 / Convert.ToDouble(Console.ReadLine());

                Console.WriteLine();

                Console.Write("Över/Under [2,5]/[5,5]: ");
                M3ÖU = Convert.ToDouble(Console.ReadLine());
                Console.Write("Odds på över " + M3ÖU + ":");
                M3Ö = 1 / Convert.ToDouble(Console.ReadLine());
                Console.Write("Odds på under " + M3ÖU + ":");
                M3U = 1 / Convert.ToDouble(Console.ReadLine());
                M3HÖ = (M3Ö / (M3Ö + M3U));
                M3HU = (M3U / (M3Ö + M3U));

                Console.WriteLine();

                Console.Write("Ändra nåt? [j]: ");
                answer = Console.ReadLine();
            }

            Console.WriteLine();

            Console.Write("100 % odds på över " + M3ÖU + ":");
            Console.WriteLine(Math.Round(1 / M3HÖ, 2));
            Console.Write("100 % odds på under " + M3ÖU + ":");
            Console.WriteLine(Math.Round(1 / M3HU, 2));

            Console.WriteLine();

            Console.Write("Förväntat målantal: ");
            double M3M = Convert.ToDouble(Console.ReadLine());

            double H3 = (M31 + M3X / 2) / (M31 + M3X + M32);
            double B3 = (M32 + M3X / 2) / (M31 + M3X + M32);
            double lambda5 = H3 * M3M;
            double lambda6 = B3 * M3M;
            
            Match3.poisson(lambda5, "hemma");
            Match3.poisson(lambda6, "borta");
            Match3.beräknaResultat();
                   
            // Alla resultat

            double[] allaResultat = new double[1771561];

            int i = 0;
            int j = 0;
            int k = 0;
            int l = 0;

            for (int m = 0; m < 1771560; m = m + 1)
            {

                if (m%121 == 0 && m != 0)                
                {
                    j++;
                    k = 0;
                }
                if (m%14641 == 0 && m != 0)
                {
                    i++;
                    j = 0;
                    k = 0;
                }
                allaResultat[l++] = Match1.resultat[i] * Match2.resultat[j] * Match3.resultat[k++];
            }
            
            Console.WriteLine();
            Console.WriteLine(1 / Match1.resultat[11]);
            Console.WriteLine(1 / Match2.resultat[0]);
            Console.WriteLine(1 / Match3.resultat[0]);
            Console.WriteLine(1 / allaResultat[14651]);
            Console.ReadLine();

        






            Console.WriteLine();

            Console.WriteLine("Poissonodds på över " + M1ÖU + ":");

            Console.WriteLine("Posissonodds på under " + M1ÖU + ":");



        }
    }
}
