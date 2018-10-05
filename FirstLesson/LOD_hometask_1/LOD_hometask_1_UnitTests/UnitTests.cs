using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LOD_hometask_1;
using System.IO;
using System.Linq;

namespace LOD_hometask_1_UnitTests
{
    [TestClass]
    public class UnitTests
    {
        string projectPath = "C:/Users/Давид/source/repos/LOD_hometask_1/";

        [TestMethod]
        public void getFileTest_giveDifferentPaths_getTrueAnswerOrErrorMassage()
        {

            string nonexistentDirectory = "Wrong directory";
            string correctDirectory = projectPath + "LOD_hometask_1_UnitTests/filesForTests/default.csv";

            var NEDResult = Program.getFile(nonexistentDirectory);
            var CDResult = Program.getFile(correctDirectory);
            var CDExpectedResult = typeof(string[]);

            Assert.IsNull(NEDResult);
            Assert.IsInstanceOfType(CDResult, CDExpectedResult);
        }
        [TestMethod]
        public void profilesCounterTest_giveDifferentFiles_getTrueAnswer()
        {
            string directoryWithCorrectFile = projectPath + "LOD_hometask_1_UnitTests/filesForTests/default.csv";
            string directoryWithFileWithoutProfiles = projectPath + "LOD_hometask_1_UnitTests/filesForTests/withoutProfiles.csv";
            string[] correctFile = File.ReadAllLines(directoryWithCorrectFile).Skip(1).ToArray();
            string[] emptyFile = File.ReadAllLines(directoryWithFileWithoutProfiles).Skip(1).ToArray();

            int CFResult = Program.profilesCounter(correctFile);
            int EFResult = Program.profilesCounter(emptyFile);
            int CFExpectedResult = 15;
            int EFExpectedResult = 0;

            Assert.AreEqual(CFExpectedResult, CFResult);
            Assert.AreEqual(EFExpectedResult, EFResult);
        }
        [TestMethod]
        public void liveInDormTest_giveDifferentFiles_getTrueAnswer()
        {
            string directoryWithCorrectFile = projectPath + "LOD_hometask_1_UnitTests/filesForTests/default.csv";
            string directoryWithFileWithoutProfiles = projectPath + "LOD_hometask_1_UnitTests/filesForTests/withoutProfiles.csv";
            string directoryWithFileWithoutDormResidents = projectPath + "LOD_hometask_1_UnitTests/filesForTests/withoutDormResidents.csv";
            string[] correctFile = File.ReadAllLines(directoryWithCorrectFile).Skip(1).ToArray();
            string[] emptyFile = File.ReadAllLines(directoryWithFileWithoutProfiles).Skip(1).ToArray();
            string[] withoutDormResidentsFile = File.ReadAllLines(directoryWithFileWithoutDormResidents).Skip(1).ToArray();

            var CFResult = Program.liveInDorm(correctFile);
            var EFResult = Program.liveInDorm(emptyFile);
            var WDRFResult = Program.liveInDorm(withoutDormResidentsFile);
            var CFExpectedResult = 12;
            var EFExpectedResult = 0;
            var WDRFExpectedResult = 0;

            Assert.AreEqual(CFExpectedResult, CFResult.Count);
            Assert.AreEqual(EFExpectedResult, EFResult.Count);
            Assert.AreEqual(WDRFExpectedResult, WDRFResult.Count);
        }
        [TestMethod]
        public void courseStatisticsTest_giveDifferentFiles_getTrueAnswer()
        {
            string directoryWithCorrectFile = projectPath + "LOD_hometask_1_UnitTests/filesForTests/default.csv";
            string directoryWithFileWithoutProfiles = projectPath + "LOD_hometask_1_UnitTests/filesForTests/withoutProfiles.csv";
            string[] correctFile = File.ReadAllLines(directoryWithCorrectFile).Skip(1).ToArray();
            string[] emptyFile = File.ReadAllLines(directoryWithFileWithoutProfiles).Skip(1).ToArray();

            var CFResult = Program.courseStatistics(correctFile);
            var EFResult = Program.courseStatistics(emptyFile);
            int[] CFExpectedResult = new int[] { 3, 10, 2, 0 };
            int[] EFExpectedResult = new int[] { 0, 0, 0, 0 };

            CollectionAssert.AreEqual(CFResult, CFExpectedResult);
            CollectionAssert.AreEqual(EFResult, EFExpectedResult);
        }
    }
}
