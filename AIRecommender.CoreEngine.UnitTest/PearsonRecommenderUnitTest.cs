using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AIRecommender.CoreEngine.UnitTest
{
    [TestClass]
    public class PearsonRecommenderUnitTest
    {
        PersonRecommender pearsonRecommender = null;   
        [TestInitialize]
      
        public void Init()
        {
            pearsonRecommender= new PersonRecommender();
        }

        [TestCleanup]
        public void Cleanup()
        {
            pearsonRecommender = null;
        }


        [TestMethod]
        public void CoreEngine_WithCorrectInput_CorrectResult()
        {
            int[] baseData ={ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            int[] otherData = { 5, 6, 7, 8, 1, 2, 3, 4, 5, 6, 7 };
            double expeced = -0.0273;
            double actual=Math.Round( pearsonRecommender.GetCorrelation(baseData,otherData),4) ;
           // Console.WriteLine(actual);
            Assert.AreEqual(expeced, actual);
            
        }
        [TestMethod]
        public void CoreEngine_ShorterBaseArray_ShouldTrimOtherArray()
        {
            int[] baseData = { 1, 2, 3, 4, 5 };
            int[] otherData = {1, 2,  3, 4 ,5 ,6 ,7  };
            double expected = 1; 
            double actutal=pearsonRecommender.GetCorrelation(baseData,otherData);
            Assert.AreEqual(expected, actutal);

        }
        [TestMethod]
        public void CoreEngine_ShortOtherArray_ShouldExtendOtherArray()
        {
            int[] baseData = { 1, 2, 3, 0, 0,0 };
            int[] otherData = { 1, 2, 3 };
            double expected = 1;
            double actual= pearsonRecommender.GetCorrelation(baseData, otherData);
            Assert.AreEqual (expected, actual);
            
        }
        [TestMethod]
        public void CoreEngine_EmptyArray_ShouldReturnNaN()
        {
            int[] baseData = {1,2,3 };
            int[] otherData = { };
            double expected = double.NaN;
            double actual=pearsonRecommender.GetCorrelation (baseData,otherData);
            Assert.AreEqual ( expected, actual);
        }
        [TestMethod]
        public void test()
        {
            int[] basearray = new int[] {1,2,3,1,0};
            int[] otherarray = new int[] { 1, 2,0};
           
            double actual=pearsonRecommender.GetCorrelation(basearray,otherarray);
            Assert.AreEqual(basearray[2], 4);
        }
    }
}
