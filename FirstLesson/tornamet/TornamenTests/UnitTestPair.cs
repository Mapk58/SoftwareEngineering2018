using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tornament;
using System;
using System.Collections.Generic;

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

    [TestClass]
    public class CheckPersonTests
    {
        [TestMethod]
        public void CheckPerson_PersonInside_True()
        {
            string person = "a";
            string[] participants = { "a", "b", "c", "d" };
            Tornament.Tornament t;

            t = new Tornament.Tornament("test", participants);
            bool inside = t.CheckPerson(person);

            Assert.IsTrue(inside);
        }

        [TestMethod]
        public void CheckPerson_PersonNotInside_False()
        {
            string person = "z";
            string[] participants = { "a", "b", "c", "d" };
            Tornament.Tornament t;

            t = new Tornament.Tornament("test", participants);
            bool inside = t.CheckPerson(person);

            Assert.IsFalse(inside);
        }
    }

    [TestClass]
    public class GetPersonIndexTests
    {
        [TestMethod]
        public void GetPersonIndex_PersonInside_IntArray2D()
        {
            string person = "a";
            string[] participants = { "a", "b", "c", "d" };
            Tornament.Tornament t;
            int[] expected = { 0, 0 };

            t = new Tornament.Tornament("test", participants);
            int[] index = t.GetPersonIndex(person);

            CollectionAssert.AreEqual(expected, index);
        }

        [TestMethod]
        public void GetPersonIndex_PersonNotInside_IntArray2D()
        {
            string person = "z";
            string[] participants = { "a", "b", "c", "d" };
            Tornament.Tornament t;
            int[] expected = { -1, -1 };

            t = new Tornament.Tornament("test", participants);
            int[] index = t.GetPersonIndex(person);

            CollectionAssert.AreEqual(expected, index);
        }
    }

    [TestClass]
    public class AddPairWinner
    {
        [TestMethod]
        public void AddPairWinner_PersonInsideAvailable_WinnersAppended()
        {
            string person = "a";
            string[] participants = { "a", "b", "c", "d" };
            List<String> winners;
            List<String> expected = new List<String>() { person };
            Tornament.Tornament t;

            t = new Tornament.Tornament("test", participants);
            t.AddPairWinner(person);
            winners = t.CurrentLevelWinners;

            CollectionAssert.AreEqual(expected, winners);
        }

        [TestMethod]
        public void AddPairWinner_PersonNotInside_EmptyWinners()
        {
            string person = "z";
            string[] participants = { "a", "b", "c", "d" };
            Tornament.Tornament t;
            string[] winners;
            string[] expected = {};

            t = new Tornament.Tornament("test", participants);
            t.AddPairWinner(person);
            winners = t.CurrentLevelWinners.ToArray();

            CollectionAssert.AreEquivalent(expected, winners);
        }
    }
}
