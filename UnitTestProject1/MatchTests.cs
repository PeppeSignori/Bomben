using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bomben.Tests
{
    [TestClass]
    public class MatchTests
    {
        [TestMethod]
        public void poissonTest()
        {
            //Arrange
            Match match = new Match();
            double lambda1 = 1.9434180138568129;
            double lambda2 = 1.0565819861431871;
            
            //Act
            match.poisson(lambda1, "hemma");
            match.poisson(lambda2, "borta");

            double expectedHome0 = 
            double expectedAway0 =
                //Assert
            Assert.AreEqual(, match.hemmaMålSannolikhet);
        }
    }
}
