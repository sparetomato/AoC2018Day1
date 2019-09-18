using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestPlatform;
using System;
using System.IO;

namespace Day1Calibration
{
    [TestClass]
    public class UnitTest1
    {

        //Requirements

        //You notice that the device repeats the same frequency change list over and over.
        //To calibrate the device, you need to find the first frequency it reaches twice.
        //I may need to restart reading the list from the beginning in order to find a duplicate.

            //+1, -1 first reaches 0 twice.
            //+3, +3, +4, -2, -4 first reaches 10 twice.
            //-6, +3, +8, +5, -6 first reaches 5 twice.
            //+7, +7, -2, -7, -4 first reaches 14 twice.

        [TestMethod]
        public void ProgramCanLoadCalibrationFile()
        {
            Program.Calibrate(new string[] { "Day1Input.txt" });
        }

        [TestMethod]
        public void ProgramCanHandleCalibrationFileWithoutExtension()
        {
            Program.Calibrate(new string[] { "Day1Input" });
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void ProgramWillThrowExceptionIfCalibrationFileCannotBeFound()
        {
            Program.Calibrate(new string[] { "Day2Input.txt" });
        }

        [TestMethod]
        public void ProgramCanProcessAdditions()
        {
            int expected = 1;
            int actual = Program.transformCalibration(0, "+1");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProgramCanProcessSubtractions()
        {
            int expected = -1;
            int actual = Program.transformCalibration(0, "-1");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ProgramWillErrorIfCalibrationDoesNotStartAsExpected()
        {
            int actual = Program.transformCalibration(0, "*");
        }

        [TestMethod]
        public void ProgramWillReturnCalibrationCodeAsAnInt()
        {
            var result = Program.Calibrate(new string[] { "Day1Input" });
            Assert.AreEqual(typeof(int), result.GetType());
        }

        [TestMethod]
        public void ProgramCanFindDuplicatesInList()
        {
            int[] freqs = new int[4] { 1, 2, 3, 4 };
                Program.frequencies.AddRange(freqs);
            bool expected = true;
            Assert.AreEqual(expected, Program.isRepeatFrequency(4));
        }
        [TestMethod]
        public void ProgramCanFindNonDuplicatesInList()
        {
            int[] freqs = new int[4] { 1, 2, 3, 4 };
            Program.frequencies.AddRange(freqs);
            bool expected = false;
            Assert.AreEqual(expected, Program.isRepeatFrequency(5));
        }

        [TestMethod]
        public void ProgramWillLoopFromBeginningUntilADupeIsGenerated()
        {
            int expected = 10;
            int dupe = Program.Calibrate("+3, +3, +4, -2, -4");
            Assert.AreEqual(expected, dupe);
        }

        [TestMethod]
        public void ProgramWillLoopFromBeginningUntilADupeIsGenerated2()
        {
            int expected = 14;
            int dupe = Program.Calibrate("+7, +7, -2, -7, -4");
            Assert.AreEqual(expected, dupe);
        }


    }
}
