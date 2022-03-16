using NUnit.Framework;
using StatesCensusAnalyser;

namespace StatesCensusTests
{
    public class Tests
    {
        IndianStatesCSVDataLoad indianStatesCSVDataLoad;
        public readonly string INDIAN_STATE_CENSUS_DATA_FILEPATH = @"C:\Users\Kashish Manchanda\source\repos\Census Analyser Problem\StatesCensusTests\Resources\IndiaStateCensusData.csv";
        [SetUp]
        public void Setup()
        {
            indianStatesCSVDataLoad = new IndianStatesCSVDataLoad();
        }

        [Test]
        public void GivenStateCensusDataFilePath_InLoadCensusData_ReturnExactNumberOfRecords()
        {
            int expectedRecords = 29;
            int result = indianStatesCSVDataLoad.LoadStateCensusDataIntoList(INDIAN_STATE_CENSUS_DATA_FILEPATH);
            Assert.AreEqual(expectedRecords, result);
        }
    }
}