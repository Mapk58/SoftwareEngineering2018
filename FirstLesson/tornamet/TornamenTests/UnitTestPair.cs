using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tornament;

namespace TornamentTests
{
    [TestClass]
    public class PairParticipantsTest
    {
        [TestMethod]
        public void PairParticipants_FourPeople_ListStrListReturned()
        {
            //arrange
            string[] peopleStr = { "Ростислав Осипенко", "Иван Калабин", "Денис Титаев", "Маша Артемова" };
            string[,] Pairs = {{ "Ростислав Осипенко", "Иван Калабин" },{"Денис Титаев", "Маша Артемова"}} ;
            //atc
            string[,] returned = Tornament.Tornament.Pair(peopleStr);
            //assert
            CollectionAssert.AreEquivalent(Pairs, returned);
        }

        [TestMethod]
        public void PairParticipants_ThreePeople_Exception()
        {
            //arrange
            string[] peopleStr = { "Ростислав Осипенко", "Иван Калабин", "Денис Титаев" };
            //atc
            //assert
            Assert.ThrowsException<System.ArgumentException>(() => Tornament.Tornament.Pair(peopleStr), "hello");
        }
    }
}
