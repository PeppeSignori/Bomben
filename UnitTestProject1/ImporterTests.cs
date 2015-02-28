using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bomben.Test
{
    [TestClass]
    public class ImporterTests
    {
        [TestMethod]
        public void turnOverTest()
        {
            //Arrange
            Importer import = new Importer();
            //Act
            int turnOver = import.getTurnOver("PC_P7_D8385");
            //Assert
            //Förväntat 25019
            Assert.AreEqual(25019, turnOver);

        }

        [TestMethod]
        public void countLinesTest()
        {
            //Arrange 
            Importer import = new Importer();
            //Act
            int lineCount = import.countLines("PC_P7_D8385");
            //Assert
            //Förväntat är 6315, filen är 6317 rader men ska ta bort första och sista
            Assert.AreEqual(6315, lineCount);
        
        }

        [TestMethod]
        public void ImportBombenFirstRowTest()
        {
            //Arrange
            Importer import = new Importer();
            //Act
            double[,] stats = import.importBomben("PC_P7_D8385");
            //Assert

            //Första kolumnen = 15011,40
            Assert.AreEqual(15011.40, stats[0,0]);
            //Resten av kolumnerna 0,3,2,4,2,2
            Assert.AreEqual(0, stats[0, 1]);
            Assert.AreEqual(3, stats[0, 2]);
            Assert.AreEqual(2, stats[0, 3]);
            Assert.AreEqual(4, stats[0, 4]);
            Assert.AreEqual(2, stats[0, 5]);
            Assert.AreEqual(2, stats[0, 6]);

        }

        [TestMethod]
        public void ImportBombenLastRowTest()
        {
            //Arrange
            Importer import = new Importer();
            //Act
            double[,] stats = import.importBomben("PC_P7_D8385");
            //Assert
            //Första kolumnen = 277.99 
            Assert.AreEqual( 277.99, stats[ 6314, 0]);
            //Resten av kolumnerna 1,4,1,3,2,2
            Assert.AreEqual(1, stats[6314, 1]);
            Assert.AreEqual(4, stats[6314, 2]);
            Assert.AreEqual(1, stats[6314, 3]);
            Assert.AreEqual(3, stats[6314, 4]);
            Assert.AreEqual(2, stats[6314, 5]);
            Assert.AreEqual(2, stats[6314, 6]);



        }
    }
}
