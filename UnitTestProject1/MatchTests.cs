using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bomben;


namespace UnitTestProject1
{
    [TestClass]
    public class MatchTests
    {
        [TestMethod]
        public void FörväntatAntalMålTest()
        {
            //Arrange 
            var match = new Match();
            //Act
            double resultat = match.beräknaFörväntadMålantal(2.5, 0.01, 1.80, 1.80, 1.75, 1.85);
            //Assert
            double förväntatSvar = 3;
            Assert.AreEqual(förväntatSvar, resultat);
        }
    }
}

