using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bomben;

namespace Bomben.Test
{
    [TestClass]
    public class SvsMobileSiteImporterTest
    {
        [TestMethod]
        public void downloadBombenStatsTest()
        {
            //Arrange
            var bomb = new SvSMobileSiteImporter();
            int drawId = 8534;
            string link = "https://svenskaspel.se/cas/getfile.aspx?file=playedcombinations&productid=7&drawid=" + drawId;
            string saveTo = "./downloads/";
            string fileName = "PC_P7_D" + drawId + ".zip";
            //Act
            bomb.downloadFileAsync( link, saveTo, fileName);
            //Assert
            while (!bomb.downloadComplete) ;
            bool exists = File.Exists("./downloads/PC_P7_D" +drawId +".zip");
            Assert.AreEqual(true, exists);
        }
    }
}
