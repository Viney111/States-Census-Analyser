using NUnit.Framework;
using StatesCensusAnalyser;
using System;

namespace StatesCensusTests
{
    public class Tests
    {
        IndianStatesCSVDataLoad indianStatesCSVDataLoad;

        public readonly static string INDIAN_STATE_CENSUS_DATA_FILEPATH = @"C:\Users\Kashish Manchanda\source\repos\Census Analyser Problem\StatesCensusTests\Resources\IndiaStateCensusData.csv";
        public readonly static string INDIAN_STATE_CENSUS_DATA_WRONG_FILEPATH = @"C:\Users\Kashish Manchanda\source\repos\Census Analyser Problem\StatesCensusTests\Resource\IndiaStateCensusData.csv";
        
        [SetUp]
        public void Setup()
        {
            indianStatesCSVDataLoad = new IndianStatesCSVDataLoad();
        }

        [Test]
        public void GivenStateCensusDataRightFilePath_InLoadCensusData_ReturnNumberOfRecords()
        {
            int expectedRecords = 29;
            int result = indianStatesCSVDataLoad.LoadStateCensusDataIntoList(INDIAN_STATE_CENSUS_DATA_FILEPATH);
            Assert.AreEqual(expectedRecords, result);
        }
        [Test]
        public void GivenStateCensusDataWrongFilePath_InLoadCensusData_ThrowCustomException()
        {
            try
            {
                int expectedRecords = 29;
                int result = indianStatesCSVDataLoad.LoadStateCensusDataIntoList(INDIAN_STATE_CENSUS_DATA_WRONG_FILEPATH);
                Assert.AreEqual(expectedRecords, result);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("File is not found at specified location", ex.Message);
            }
        }
    }
}