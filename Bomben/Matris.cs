using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
//using Microsoft.Office.Interop.Excel;
using Cudafy;
using Cudafy.Host;
using Cudafy.Translator;
using System.Diagnostics;



namespace Bomben
{
    class Matris
    {

        /*private static Microsoft.Office.Interop.Excel.Workbook mWorkBook;
        private static Microsoft.Office.Interop.Excel.Sheets mWorkSheets;
        private static Microsoft.Office.Interop.Excel.Worksheet Blad1;
        private static Microsoft.Office.Interop.Excel.Application oXL;
        

        public void writeToExistingExcelDocument()
        {
            //Skapa workbook object 
            string path = @"C:\Users\Erik\Desktop\Bomben\bomben.xlsx";
            oXL = new Microsoft.Office.Interop.Excel.Application();
            oXL.Visible = true;
            oXL.DisplayAlerts = false;
            mWorkBook = oXL.Workbooks.Open(path, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
            //Get all the sheets in the workbook
            mWorkSheets = mWorkBook.Worksheets;
            //Get the allready exists sheet
            Blad1 = (Microsoft.Office.Interop.Excel.Worksheet)mWorkSheets.get_Item("Blad1");
            Blad1.Cells[2, 1] = "Fungerar detta?";
            
            mWorkBook.SaveAs(path, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            mWorkBook.Close(false, false, false);
            Blad1 = null;
            mWorkBook = null;
            oXL.Quit();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
        */


        public double[,] allaKombinationer = new double[1771561, 11];
        public double[] matrisUtanOddsKolumn1 = new double[1771561];
        public double[] matrisUtanOddsKolumn2 = new double[1771561];
        public double[] matrisUtanOddsKolumn3 = new double[1771561];
        public double[] matrisUtanOddsKolumn4 = new double[1771561];
        public double[] matrisUtanOddsKolumn5 = new double[1771561];
        public double[] matrisUtanOddsKolumn6 = new double[1771561];
        private int läggTillPlusRäknare = 0;
        private const int MAX = 1771561;
        
        
        public void skapaMatrisUtanOddskolumn1()
        {
            int a = 0;
            int h = 0;
            for (int g = 0; g < 1771561; g = g + 1)
            {
                if (g % 161051 == 0 && g != 0)
                {
                    a++;
                }
                this.matrisUtanOddsKolumn1[h++] = a;
            }
        }

        public void skapaMatrisUtanOddskolumn2()
        {
            int b = 0;
            int h = 0;
            for (int g = 0; g < MAX; g = g + 1)
            {
                if (g % 14641 == 0 && g != 0)
                {
                    b++;
                }
                if (g % 161051 == 0 && g != 0)
                {
                    b = 0;
                }
                this.matrisUtanOddsKolumn2[h++] = b;
            }
        }

        public void skapaMatrisUtanOddskolumn3()
        {
            int c = 0;
            int h = 0;
            for( int g = 0;g < MAX;g = g + 1 )
            {
                if (g % 1331 == 0 && g != 0)
                {
                    c++;
                }
                if (g % 14641 == 0 && g != 0)
                {
                    c = 0;
                }
                this.matrisUtanOddsKolumn3[h++] = c;
            }
        }

        public void skapaMatrisUtanOddskolumn4()
        {
            int d = 0;
            int h = 0;
            for( int g = 0;g < MAX;g = g + 1 )
            {
                if (g % 121 == 0 && g != 0)
                {
                    d++;
                }
                if (g % 1331 == 0 && g != 0)
                {
                    d = 0;
                }
                this.matrisUtanOddsKolumn4[h++] = d;
            }
        }

        public void skapaMatrisUtanOddskolumn5()
        {
            int e = 0;
            int h = 0;
            for( int g = 0;g < MAX;g = g + 1 )
            {
                if (g % 11 == 0 && g != 0)
                {
                    e++;
                }
                if (g % 121 == 0 && g != 0)
                {
                    e = 0;
                }
                this.matrisUtanOddsKolumn5[h++] = e;
            }
        }

        public void skapaMatrisUtanOddskolumn6()
        {
            int f = 0;
            int h = 0;
            for( int g = 0;g < MAX;g = g + 1 )
            {
                if (g % 11 == 0 && g != 0)
                {
                    f = 0;
                }
                this.matrisUtanOddsKolumn6[h++] = f++;

            }
        }
        
        public void skapaAllaResultatKombinationer()
        {
            
            //Skapa startvärden för kolumner
            skapaMatrisUtanOddskolumn1();
            skapaMatrisUtanOddskolumn2();
            skapaMatrisUtanOddskolumn3();
            skapaMatrisUtanOddskolumn4();
            skapaMatrisUtanOddskolumn5();
            skapaMatrisUtanOddskolumn6();
            
            
            //Lägg till enskilda matrisers kolumner i matrisUtanOdds.
            addColumn( 0, matrisUtanOddsKolumn1 );
            addColumn( 1, matrisUtanOddsKolumn2 );
            addColumn( 2, matrisUtanOddsKolumn3 );
            addColumn( 3, matrisUtanOddsKolumn4 );
            addColumn( 4, matrisUtanOddsKolumn5 );
            addColumn( 5, matrisUtanOddsKolumn6 );            
            
        }
        
        //intern metod som bara kan användas inuti klassen. Hjälper till att skriva värden från en matris till en annan.
        public void addColumn( int targetColumn, double[] sourceMatrix )
        {

            for( int row = 0;row < MAX;row = row + 1 )
            {
                allaKombinationer[row, targetColumn] = sourceMatrix[row];
            }
        }

        public void addColumn(double[] sourceMatrix, double[,] targetMatrix, int targetColumn)
        {
            for (int row = 0; row < MAX; row = row + 1)
            {
                targetMatrix[row, targetColumn] = sourceMatrix[row];
            }
        }
            
        //Lägg till Poissonkolumnen
        public void läggTillPoissonKolumn(double[] poissonKolumn)
        {
            addColumn(6, poissonKolumn);
        }

        //Räkna om oddsen från Sv Spel med nytt radantal och ny omsättning. Skapar två Plus- och ROI-kolumner
        public void läggTillPlusOchROI(double[,] svSpelOdds, int bombenStatsSize, int antalPlus, int omsättning)
        {
            
            int sparKolumn;
            if (läggTillPlusRäknare == 0)
            {
                sparKolumn = 7;
                läggTillPlusRäknare++;
            }
            else
            {
                sparKolumn = 9;
                läggTillPlusRäknare++;
            }
            

            double ROI = ((0.6 * (Convert.ToDouble( omsättning ) + Convert.ToDouble( antalPlus ))) / Convert.ToDouble( antalPlus ));
            
            Parallel.For( 0, MAX, ii =>
                {
                    allaKombinationer[ii, sparKolumn] = ROI;
                    allaKombinationer[ii, (sparKolumn + 1)] = allaKombinationer[ii, sparKolumn] / allaKombinationer[ii, 6];
                });

            double firstTemp;
            double secondTemp;
            Parallel.For( 0, MAX, i =>
            {
                for( int j = 0; j < bombenStatsSize; j++ )
                {


                    if( allaKombinationer[i, 0] == svSpelOdds[j, 1] )
                    {
                        if( allaKombinationer[i, 1] == svSpelOdds[j, 2] )
                        {
                            if( allaKombinationer[i, 2] == svSpelOdds[j, 3] )
                            {
                                if( allaKombinationer[i, 3] == svSpelOdds[j, 4] )
                                {
                                    if( allaKombinationer[i, 4] == svSpelOdds[j, 5] )
                                    {
                                        if( allaKombinationer[i, 5] == svSpelOdds[j, 6] )
                                        {
                                            firstTemp = ((0.6 * (Convert.ToDouble( omsättning ) + Convert.ToDouble( antalPlus ))) / ((0.6 * Convert.ToDouble( omsättning ) / svSpelOdds[j, 0]) + Convert.ToDouble( antalPlus )));
                                            allaKombinationer[i, sparKolumn] = firstTemp;
                                            secondTemp = allaKombinationer[i, sparKolumn] / allaKombinationer[i, 6];
                                            allaKombinationer[i, (sparKolumn + 1)] = secondTemp;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            } );
   

        }

        public void Execute( double[] poissonColumn, int sparKolumn, int antalPlus, int omsättning, double[,] sVsOdds, double extraPott )
        {
            Stopwatch sw1 = new Stopwatch();
            sw1.Start();
            Console.WriteLine("     Execute: {0} seconds {1} milliSeconds", sw1.Elapsed.Seconds.ToString(), sw1.Elapsed.Milliseconds.ToString());
            //cudaAddPlusAndROI

            //Temp Column to save results in
            double[] CPUsparResultat = new double[poissonColumn.Length];
            double[] CPUsparResultatPlus = new double[poissonColumn.Length];
            
            //Fill CPUROI
            double doubleAntalPlus = Convert.ToDouble(antalPlus);
            double doubleTurnOver = Convert.ToDouble(omsättning);
            double doubleExtraPott = Convert.ToDouble(extraPott);
            double[] CPUROI = new double[] { doubleAntalPlus, doubleTurnOver, doubleExtraPott};
            
            //cudaAddAvailableOdds
            int[] allCombo = new int[MAX];
            int[] availableOdds = new int[sVsOdds.GetLength(0)];
            double[] svenskaSpelOdds = new double[sVsOdds.GetLength(0)];
            int zero, one, two, three, four, five;

            //Slå ihop kolumner till ett värde som ska vara snabbt och enkelt att jämföra.
            for (int i = 0; i < MAX; i++)
            {

                zero    = (int)allaKombinationer[i, 0] * 100000;
                one     = (int)allaKombinationer[i, 1] * 10000;
                two     = (int)allaKombinationer[i, 2] * 1000;
                three   = (int)allaKombinationer[i, 3] * 100;
                four    = (int)allaKombinationer[i, 4] * 10;
                five    = (int)allaKombinationer[i, 5];

                allCombo[i] = zero + one+ two + three + four + five;

                if (i < sVsOdds.GetLength(0))
                {
                    zero    = (int)sVsOdds[i, 1] * 100000;
                    one     = (int)sVsOdds[i, 2] * 10000;
                    two     = (int)sVsOdds[i, 3] * 1000;
                    three   = (int)sVsOdds[i, 4] * 100;
                    four    = (int)sVsOdds[i, 5] * 10;
                    five    = (int)sVsOdds[i, 6];
                
                    //skapa en j'mf;relsestr'ng
                    availableOdds[i] = zero + one + two + three + four + five;
                    //skapa en array med befintlinga odds
                    svenskaSpelOdds[i] = sVsOdds[i, 0];
                
                }


            }
            Console.WriteLine("     Adding columns complete: {0} seconds {1} milliSeconds", sw1.Elapsed.Seconds.ToString(), sw1.Elapsed.Milliseconds.ToString());
            
            //Adding length of available odds
            int availableOddsLength = availableOdds.GetLength(0);

            //Setup 
            CudafyModule km = CudafyTranslator.Cudafy();

            GPGPU gpu = CudafyHost.GetDevice(CudafyModes.Target, CudafyModes.DeviceId);
            gpu.LoadModule(km);
            Console.WriteLine("     Setup complete: {0} seconds {1} milliSeconds", sw1.Elapsed.Seconds.ToString(), sw1.Elapsed.Milliseconds.ToString());

            // allocate the memory on the GPU for results // allocate memory for empty arrays
            double[] gpuSparResultat = gpu.Allocate<double>(CPUsparResultat);       //ROI
            double[] gpuSparResultatPlus = gpu.Allocate<double>(CPUsparResultatPlus);   //ROI plus 1
            Console.WriteLine("     GPU memory allocation complete: {0} seconds {1} milliSeconds", sw1.Elapsed.Seconds.ToString(), sw1.Elapsed.Milliseconds.ToString());

            //Copy to GPU // copy filled arrays
            double[] gpuPoissonColumn = gpu.CopyToDevice(poissonColumn);
            double[] gpuROI = gpu.CopyToDevice(CPUROI);
            int[] gpuAllCombo = gpu.CopyToDevice(allCombo);                     //Dessa m[ste kollas s[ att det fungerar som t'nkt
            int[] gpuAvailableOdds = gpu.CopyToDevice(availableOdds);           //Dessa m[ste kollas s[ att det fungerar som t'nkt
            double[] gpuSvenskaSpelOdds = gpu.CopyToDevice(svenskaSpelOdds);
            int gpuAvailableOddsLength = availableOddsLength;
            Console.WriteLine("     Copy to GPU complete: {0} seconds {1} milliSeconds", sw1.Elapsed.Seconds.ToString(), sw1.Elapsed.Milliseconds.ToString());

            //Launch cudaLäggTillPlusOchROI - Do Calculations
            gpu.Launch(768, 128).cudaAddPlusAndROI(gpuPoissonColumn, gpuSparResultat, gpuSparResultatPlus, gpuROI, gpuAllCombo, gpuAvailableOdds, gpuSvenskaSpelOdds, gpuAvailableOddsLength);
            Console.WriteLine("     Launch complete: {0} seconds {1} milliSeconds", sw1.Elapsed.Seconds.ToString(), sw1.Elapsed.Milliseconds.ToString());

            //Copy results back from GPU
            gpu.CopyFromDevice(gpuSparResultat, CPUsparResultat);
            gpu.CopyFromDevice(gpuSparResultatPlus, CPUsparResultatPlus);
            Console.WriteLine("     Copy results to CPU complete: {0} seconds {1} milliSeconds", sw1.Elapsed.Seconds.ToString(), sw1.Elapsed.Milliseconds.ToString());

            //Lägg till CPUResultat till allaKombinationer
            addColumn( sparKolumn, CPUsparResultat );
            addColumn( (sparKolumn +1), CPUsparResultatPlus );
            Console.WriteLine("     Copy results to object complete: {0} seconds {1} milliSeconds", sw1.Elapsed.Seconds.ToString(), sw1.Elapsed.Milliseconds.ToString());

            //Free Memory on GPU
            gpu.FreeAll();

            Console.WriteLine("     Done Calculating: {0} seconds {1} milliSeconds", sw1.Elapsed.Seconds.ToString(), sw1.Elapsed.Milliseconds.ToString());
            
            
        }

        [Cudafy]
        public static void cudaAddPlusAndROI(GThread thread, double[] gpuPoissonColumn, double[] gpuSparResultat, double[] gpuSparResultatPlus, double[] gpuROI, string[] gpuAllCombo, string[] gpuAvailableOdds, double[] gpuSvenskaSpelOdds, int gpuAvailableOddsLength)
        {
            //cudaAddPlusAndROI
            double ROI = (gpuROI[2] + ((0.6 * gpuROI[1] + gpuROI[0]) / gpuROI[0]));
            //double ROI = (extrapott + ((0.6 * (Convert.ToDouble(omsättning) + Convert.ToDouble(antalPlus)))) / Convert.ToDouble(antalPlus));

            int tid = thread.threadIdx.x + thread.blockIdx.x * thread.blockDim.x;

            double firstTemp, secondTemp;
            while (tid < MAX)
            {
                //CountROI 
                gpuSparResultat[tid] = ROI;
                gpuSparResultatPlus[tid] = gpuSparResultat[tid] / gpuPoissonColumn[tid];

                for (int i = 0; i < gpuAvailableOddsLength; i++)
                {

                    if (gpuAllCombo[tid] == gpuAvailableOdds[i])
                    {
                        
                        //gpuROI = { doubleAntalPlus, doubleTurnOver};
                        firstTemp = (0.6 * (gpuROI[1] + gpuROI[0])) / ((0.6 * gpuROI[1] / gpuSvenskaSpelOdds[i]) + gpuROI[0]);  
                        gpuSparResultat[tid] = firstTemp;
                        secondTemp = gpuSparResultat[tid] / gpuPoissonColumn[tid]; 
                        gpuSparResultatPlus[tid] = secondTemp;
                    }
                }

                tid += thread.blockDim.x * thread.gridDim.x;
            }
                  
        }

        /*
        public void cudaLäggTillTillgängligaOdds(int sparKolumn, double[,] svSpelOdds, int bombenStatsSize, int antalPlus, int omsättning)
        {
            double firstTemp;
            double secondTemp;
            Parallel.For(0, MAX, i =>
            {
                for (int j = 0; j < bombenStatsSize; j++)
                {


                    if (allaKombinationer[i, 0] == svSpelOdds[j, 1])
                    {
                        if (allaKombinationer[i, 1] == svSpelOdds[j, 2])
                        {
                            if (allaKombinationer[i, 2] == svSpelOdds[j, 3])
                            {
                                if (allaKombinationer[i, 3] == svSpelOdds[j, 4])
                                {
                                    if (allaKombinationer[i, 4] == svSpelOdds[j, 5])
                                    {
                                        if (allaKombinationer[i, 5] == svSpelOdds[j, 6])
                                        {
                                            //firstTemp = ((0.6 * (Convert.ToDouble(omsättning) + Convert.ToDouble(antalPlus))) / ((0.6 * Convert.ToDouble(omsättning) / svSpelOdds[j, 0]) + Convert.ToDouble(antalPlus)));
                                            allaKombinationer[i, sparKolumn] = firstTemp;
                                            //secondTemp = allaKombinationer[i, sparKolumn] / allaKombinationer[i, 6];
                                            allaKombinationer[i, (sparKolumn + 1)] = secondTemp;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            });

        }
        
        [Cudafy]
        public static void cudaAddAvailableOdds(double[,] svSpelOdds, int bombenStatsSize)
        {

            double firstTemp;
            double secondTemp;
            
            for (int i = 0; i < bombenStatsSize; i++)
            {

                if (allaKombinationer[i, 0] == svSpelOdds[j, 1])
                {
                    if (allaKombinationer[i, 1] == svSpelOdds[j, 2])
                    {
                        if (allaKombinationer[i, 2] == svSpelOdds[j, 3])
                        {
                            if (allaKombinationer[i, 3] == svSpelOdds[j, 4])
                            {
                                if (allaKombinationer[i, 4] == svSpelOdds[j, 5])
                                {
                                    if (allaKombinationer[i, 5] == svSpelOdds[j, 6])
                                    {
                                        firstTemp = ((0.6 * (Convert.ToDouble(omsättning) + Convert.ToDouble(antalPlus))) / ((0.6 * Convert.ToDouble(omsättning) / svSpelOdds[j, 0]) + Convert.ToDouble(antalPlus)));
                                        allaKombinationer[i, sparKolumn] = firstTemp;
                                        secondTemp = allaKombinationer[i, sparKolumn] / allaKombinationer[i, 6];
                                        allaKombinationer[i, (sparKolumn + 1)] = secondTemp;
                                    }
                                }
                            }
                        }
                    }
                }
 
            }
        }
        */
        
        
        public void writeToFile()
        {
            
            StreamWriter sw = new StreamWriter("VinnandeRader.txt");

            sw.WriteLine("HM1,BM1,HM2,BM2,HM3,BM3,Poisson,+1,+1ROI,+3,+3ROI");
            
            for (int rad = 0; rad < 1771561; rad++)
            {

                if (allaKombinationer[rad, 10] > 1 && allaKombinationer[rad, 0] < 7 && allaKombinationer[rad, 1] < 9 && allaKombinationer[rad, 2] < 9 && allaKombinationer[rad, 3] < 7 && allaKombinationer[rad, 4] < 9 && allaKombinationer[rad, 5] < 7)
                {
                    for (int kol = 0; kol < 11; kol++)
                    {
                        sw.Write(allaKombinationer[rad, kol]);
                        sw.Write("; ");
                    }
                    sw.Write("\r\n");
                }
                
            }
            
            sw.Close();

                       
        }

     

        
    }
}
