using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp47;
using System.Collections.Generic;

namespace ConsoleApp47Test
{
    [TestClass]
    public class ConsoleApp47Test
    {
        [TestMethod]
        public void callGetCount_ReturnTrue()
        {
            List<string> input = new List<string>(new string[] { "das", "as","dsa"});
            int output = 3;

            int expectedOutput = Program.GetCount(input);

            Assert.IsTrue(output.Equals(expectedOutput));
        }
        [TestMethod]
        public void callGetCours_returnTrue()
        {
            List<string> input = new List<string>(new string[]
            {
                "9.14.2018 15:33:12; Dani Danyel Aristizabal;2 бакалавриат;Институт информационных технологий и автоматизированных систем управления(ИТАСУ);Да; ; ; ; ; ;",
                "9.14.2018 8:39:25; Татьяна Кузнецова;2 бакалавриат;Институт информационных технологий и автоматизированных систем управления(ИТАСУ);Да; ; ; ; ; ;",
                "9.12.2018 0:19:01; Давид Хуриев;2 бакалавриат;Институт информационных технологий и автоматизированных систем управления(ИТАСУ);Да; ; ; ; ; ;",
                "9.4.2018 22:05:19; Леон Минасян;1 бакалавриат;Институт информационных технологий и автоматизированных систем управления(ИТАСУ);Нет; ; ; ; ; ;"

            });
            int[] expectedAnswer = new int[] {1, 3, 0, 0 };

            int[] answ = Program.GetCours(input);

            for (int i = 0; i < expectedAnswer.Length; i++)
            {
                Assert.IsTrue(expectedAnswer[i] == answ[i]);
            }
            Assert.IsTrue(answ.Length == expectedAnswer.Length);

            
        }
        [TestMethod]
        public void callGetDormPeople_returnTrue()
        {
            List<string> input = new List<string>(new string[]
            {
                "9.14.2018 15:33:12; Dani Danyel Aristizabal;2 бакалавриат;Институт информационных технологий и автоматизированных систем управления(ИТАСУ);Да; ; ; ; ; ;",
                "9.14.2018 8:39:25; Татьяна Кузнецова;2 бакалавриат;Институт информационных технологий и автоматизированных систем управления(ИТАСУ);Да; ; ; ; ; ;",
                "9.12.2018 0:19:01; Давид Хуриев;2 бакалавриат;Институт информационных технологий и автоматизированных систем управления(ИТАСУ);Да; ; ; ; ; ;",
                "9.4.2018 22:05:19; Леон Минасян;1 бакалавриат;Институт информационных технологий и автоматизированных систем управления(ИТАСУ);Нет; ; ; ; ; ;"

            });
            List<string> expectedAnswer = new List<string> (new string[] { " Dani Danyel Aristizabal", " Татьяна Кузнецова", " Давид Хуриев" });

            List<string> answ = Program.GetDormPeople(input);

            for(int i = 0; i < expectedAnswer.Count; i++)
            {
                Assert.IsTrue(answ[i] == expectedAnswer[i]);
            }
            Assert.IsTrue(answ.Count == expectedAnswer.Count);

           
        }
    }
}
