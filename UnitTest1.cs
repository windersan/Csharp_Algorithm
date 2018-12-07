using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Kiran;

namespace KiranUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void StringGeneratorTest()
        {
            LetterService svc2 = new LetterService();
            List<int> test2 = new List<int>() { 1 };
            List<int>[] markerSets2 = svc2.GenerateMarkerSets(test2);
            List<string> test2_strings = svc2.GenerateLetterStrings(test2, markerSets2);
            Assert.AreEqual("A", test2_strings[0]);

            LetterService svc3 = new LetterService();
            List<int> test3 = new List<int>() { 1,1,1 };
            List<int>[] markerSets3 = svc3.GenerateMarkerSets(test3);
            List<string> test3_strings = svc3.GenerateLetterStrings(test3, markerSets3);
            Assert.AreEqual("AAA", test3_strings[0]);
        }

        [TestMethod]
        public void MarkerGeneratorTest()
        {
            LetterService svc = new LetterService();

            List<int> test = new List<int>() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            List<int>[] testResult = svc.GenerateMarkerSets(test);
            List<int> expected = new List<int>() { 0, 2, 4, 6, 8 };

            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual(expected[i], testResult[88][i]);
            }
            
            Assert.AreEqual(8, svc.Fibonacci(6));           
        }


        [TestMethod]
        public void Test5()
        {
            LetterService svc = new LetterService();

            svc.DB();
        }


    }
}
