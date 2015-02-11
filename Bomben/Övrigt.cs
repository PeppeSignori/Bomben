using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomben
{
    class Övrigt
    {
        /*

        //Mata in mål i matcher
        double[] homeGoals = new double[3];
        double[] awayGoals = new double[3];
        
        Console.Write( "Hemmalag1 mål: " );
        homeGoals[ 0 ] = Convert.ToDouble( Console.ReadLine() );
        Console.Write( "Bortalag1 mål: " );
        awayGoals[ 0 ] = Convert.ToDouble( Console.ReadLine() );
        Console.Write( "Hemmalag2 mål: " );
        homeGoals[ 1 ] = Convert.ToDouble( Console.ReadLine() );
        Console.Write( "Bortalag2 mål: " );
        awayGoals[ 1 ] = Convert.ToDouble( Console.ReadLine() );
        Console.Write( "Hemmalag3 mål: " );
        homeGoals[ 2 ] = Convert.ToDouble( Console.ReadLine() );
        Console.Write( "Bortalag3 mål: " );
        awayGoals[ 2 ] = Convert.ToDouble( Console.ReadLine() );

        //Leta upp rätt odds för resultatet. return 0 om det inte finns
        int rattrad = getOdds( bombenStats, homeGoals, awayGoals );

        if( rattrad != 0 )
        {
            Console.WriteLine( "Odds: " +bombenStats[rattrad,0] );
        }
        else
        {
            Console.WriteLine( "Odds: " +"0");
        }    

        ///Letar upp rätt odds för en viss kombination. Returnerar int för rätt rad i BombenStats
        private static int getOdds(double[,] stats, double[] homeGoals, double[] awayGoals)
        {
            int rattrad = 0;
            int arrayEnd = stats.GetLength(0); //Dimension 0
            for (int i = 0; i < arrayEnd; i++)
            {
                //testa om hemmamål1 stämmer
                if (stats[i, 1] == homeGoals[0])
                {
                    //Testa om bortamål1 stämmer
                    if (stats[i, 2] == awayGoals[0])
                    {
                        //Testa om hemmamål2 stämmer
                        if (stats[i, 3] == homeGoals[1])
                        {
                            //Testa om bortamål2 stämmer
                            if (stats[i, 4] == awayGoals[1])
                            {
                                //Testa om hemmamål3 stämmer
                                if (stats[i, 5] == homeGoals[2])
                                {
                                    //Testa om bortamål3 stämmer
                                    if (stats[i, 6] == awayGoals[2])
                                    {
                                        rattrad = i;
                                    }
                                }
                            }
                        }
                    }
                }

            }

            return rattrad;

        }

        Console.WriteLine("Omsättning: " +turnOver);
        */

        /*
        System.IO.StreamWriter file = new System.IO.StreamWriter("C:\\Poissonodds.txt", true);
        file.WriteLine(allaResultat);
        file.Close();
        */
            
        /*
        // Testa kombination
        Console.Write("Testa en kombination? [j]: ");
        answer = Console.ReadLine();
        while (answer == "j")
        {
            Console.WriteLine();
            Console.WriteLine("Resultat match 1");
            Console.WriteLine("----------------");
            Console.Write("Hemmamål: ");
            int HM1K = Convert.ToInt32(Console.ReadLine());               
            Console.Write("Bortamål: ");
            int BM1K = Convert.ToInt32(Console.ReadLine());   

            Console.WriteLine();
            Console.WriteLine("Resultat match 2");
            Console.WriteLine("----------------");
            Console.Write("Hemmamål: ");
            int HM2K = Convert.ToInt32(Console.ReadLine());            
            Console.Write("Bortamål: ");
            int BM2K = Convert.ToInt32(Console.ReadLine()); 

            Console.WriteLine();
            Console.WriteLine("Resultat match 3");
            Console.WriteLine("----------------");
            Console.Write("Hemmamål: ");
            int HM3K = Convert.ToInt32(Console.ReadLine());             
            Console.Write("Bortamål: ");
            int BM3K = Convert.ToInt32(Console.ReadLine());

            int M1K = HM1K * 11 + BM1K;
            int M2K = HM2K * 11 + BM2K;
            int M3K = HM3K * 11 + BM3K;
            int K = M3K + M2K * 121 + M1K * 14641;

            Console.WriteLine();
            Console.WriteLine("Poissonodds: " + Math.Round(1/allaResultat[K], 2));
            Console.WriteLine();
            Console.Write( "Testa en till kombination? [j]: " );
            answer = Console.ReadLine();

        }  


    */

    }
}
