using NUnit.Framework;
using System;
using LigaApplies_Homework;

namespace Application
{
    [TestFixture()]
    public class NUnitTestClass
    {
        [Test()]
        public void CallEqualOnEqualStrings_ReturnTrue()
        {
            var FirstString = "string";
            var SeoocndString = "string1";

            var equal = FirstString.Equals(SeoocndString);

            Assert.IsTrue(equal);
        }

        [TestMethod]
        public void TestGetIsDormFromLine_IsStudentLivesInDorm()
        {
            string line = "9.3.2018 0:02:47;Белов Артём;3 бакалавриат;Институт информационных технологий и автоматизированных систем управления (ИТАСУ);Да;;;;;;";

            bool result = Program.GetIsDormFromLine(line);

            Assert.IsTrue(result);
        }
    }
}
