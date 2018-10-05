using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tournament_Table;


namespace TournamentTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestShufflingOfTable()
        {
            List<string> Members = new List<string>() {"Pen", "iwejdc","efjcn", "djwdni", "WhoAreYou"};
            var result = MainClass.ShufflingOfTable(Members);

            Assert.AreNotEqual(result, Members);
        }
    }
}
