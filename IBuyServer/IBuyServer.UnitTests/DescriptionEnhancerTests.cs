using System;
using IBuyServer.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IBuyServer.UnitTests
{
    [TestClass]
    public class DescriptionEnhancerTests
    {
        [TestMethod]
        public void AddTheBestAfterEverySecondWord_SentanceWith5Words_TheBestIsAddedTwiceAfterSecondAndForthWord()
        {
            // Arrange
            string sentence = "i have excellent new computer";
            DescriptionEnhancer enhancer = new DescriptionEnhancer();

            // Act
            var resultString = enhancer.AddTheBestAfterEverySecondWord(sentence);
            var expectedResult = "i have The Best excellent new The Best computer";

            // Assert
            Assert.AreEqual<string>(expectedResult, resultString);
        }

        [TestMethod]
        public void AddTheBestAfterEverySecondWord_EmptySentance_ReturnEmptyString()
        {
            DescriptionEnhancer enhancer = new DescriptionEnhancer();

            var resultString = enhancer.AddTheBestAfterEverySecondWord("");
            var expectedResult = "";

            Assert.AreEqual<string>(expectedResult, resultString);
        }

        [TestMethod]
        public void AddTheBestAfterEverySecondWord_OneWord_ReturnSameWord()
        {
            DescriptionEnhancer enhancer = new DescriptionEnhancer();
            string word = "hello";

            var resultString = enhancer.AddTheBestAfterEverySecondWord(word);
            var expectedResult = "hello";

            Assert.AreEqual<string>(expectedResult, resultString);
        }


        [TestMethod]
        public void AddTheBestAfterEverySecondWord_TwoWords_ReturnSameStringTheBest()
        {
            DescriptionEnhancer enhancer = new DescriptionEnhancer();
            string sentence = "hello world";

            var resultString = enhancer.AddTheBestAfterEverySecondWord(sentence);
            var expectedResult = "hello world The Best";

            Assert.AreEqual<string>(expectedResult, resultString);
        }

        [TestMethod]
        public void AddTheBestAfterEverySecondWord_FourWordsSpaceAtTheEnd_ReturnSameStringTrimmedWithTheBestTwiceAdded()
        {
            DescriptionEnhancer enhancer = new DescriptionEnhancer();
            string sentence = "hello my dear world ";

            var resultString = enhancer.AddTheBestAfterEverySecondWord(sentence);
            var expectedResult = "hello my The Best dear world The Best";

            Assert.AreEqual<string>(expectedResult, resultString);
        }
    }
}  
