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
            double resultat = match.beräknaFörväntadMålantal();
            //Assert
            double förväntatSvar = 3;
            Assert.AreEqual(förväntatSvar, resultat);
        }
    }
}
