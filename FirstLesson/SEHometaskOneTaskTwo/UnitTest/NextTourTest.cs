using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SEHometaskOneTaskTwo;
namespace UnitTest
{
    [TestClass]
    public class NextTourTest
    {
        [TestMethod]
        public void promotePlayerTest_giveDifferentWinnerNames_getTrueResultOrNull()
        {
            var listWithPairs = new List<List<string>>();
            var firstPair = new List<string>();
            var secondPair = new List<string>();
            firstPair.Add("Victor");
            firstPair.Add("Anton");
            secondPair.Add("David");
            secondPair.Add("Alex");
            listWithPairs.Add(firstPair);
            listWithPairs.Add(secondPair);
            var existingName = "Victor";
            var unExistingName = "Tanya";

            var ENResult = NextTour.promotePlayer(existingName, listWithPairs);
            var UENResult = NextTour.promotePlayer(unExistingName, listWithPairs);

            Assert.AreEqual(3, ENResult[0].Count + ENResult[1].Count);
            Assert.IsNull(UENResult);
        }
        [TestMethod]
        public void tryToPromoteWinnersToNextTourTest_giveDifferentLists_getTrueResult()
        {
            var listWithWinners = new List<List<string>>();
            var firstWinner = new List<string>();
            var secondWinner = new List<string>();
            firstWinner.Add("Victor");
            secondWinner.Add("David");
            listWithWinners.Add(firstWinner);
            listWithWinners.Add(secondWinner);
            var listWithPairs = new List<List<string>>();
            var firstPair = new List<string>();
            var secondPair = new List<string>();
            firstPair.Add("Vova");
            firstPair.Add("Anton");
            secondPair.Add("Vlad");
            listWithPairs.Add(firstPair);
            listWithPairs.Add(secondPair);

            var LWWResult = NextTour.tryToPromoteWinnersToNextTour(listWithWinners);
            var LWPResult = NextTour.tryToPromoteWinnersToNextTour(listWithPairs);

            Assert.AreEqual(1, LWWResult.Count);
            Assert.AreEqual(3, LWPResult[0].Count + LWPResult[1].Count);
        }
    }
}
