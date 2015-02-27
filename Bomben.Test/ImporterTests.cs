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
    }
}
