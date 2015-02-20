using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bomben;

namespace Bomben.Test
{
    [TestClass]
    public class ImporterTests
    {
        [TestMethod]
        public void CountLinesTest()
        {
            //Arrange 
            string zipFileName = "PC_P7_D8385";
            var import = new Importer();
            
            //Act
            int numberOfLinesMinusOne = import.countLines(zipFileName);
            
            //Assert
            //6315 är rätt svar. Filen är 6317 rader men första och sista ska inte räknas
            Assert.AreEqual(6315, numberOfLinesMinusOne);
        }

        [TestMethod]
        public void getTurnOverTest()
        {
            //Arrange
            var import = new Importer();
            string zipFileName = "PC_P7_D8385";
            //Act
            int turnOver = import.getTurnOver(zipFileName);

            //Assert
            //Förväntat = 25019
            Assert.AreEqual(25019, turnOver);
        }

        

    }
}
