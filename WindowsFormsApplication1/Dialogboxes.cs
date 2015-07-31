using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bomben
{
    class Dialogboxes
    {
        public Tuple<bool, bool> deleteTempFiles(int currentDraw)
        {
            DialogResult dialogResult = MessageBox.Show("Ta bort tillfälliga filer?", "Ta bort Filer", MessageBoxButtons.YesNo);

            bool success1 = false;
            bool success2 = false;
            
            if (dialogResult == DialogResult.Yes)
            {
                try
                {

                    if (File.Exists(@".\downloadTempFolder\PC_P7_D" + currentDraw + ".zip"))
                    {
                        File.Delete(@".\downloadTempFolder\PC_P7_D" + currentDraw + ".zip");
                    }
                    success1 = true;                   
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    success1 = false;
                }

                try
                {
                    if (File.Exists(@".\downloadTempFolder\PC_P7_D" + currentDraw + ".txt"))
                    {
                        File.Delete(@".\downloadTempFolder\PC_P7_D" + currentDraw + ".txt");
                    }
                    success2 = true;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    success2 = false;
                }
            }

            Tuple<bool, bool> success = new Tuple<bool, bool>(success1, success2);
            return success;
        }

    }
}
