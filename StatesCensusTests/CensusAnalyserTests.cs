using NUnit.Framework;
using StatesCensusAnalyser;
using System;

namespace StatesCensusTests
{
    public class Tests
    {
        IndianStatesCensusAndCodeCSVDataLoad indianStatesCSVDataLoad;

        public readonly string INDIAN_STATE_CENSUS_DATA_FILEPATH = @"C:\Users\Kashish Manchanda\source\repos\Census Analyser Problem\StatesCensusTests\Resources\IndiaStateCensusData.csv";
        public readonly string INDIAN_STATE_CENSUS_DATA_WRONG_FILEPATH = @"C:\Users\Kashish Manchanda\source\repos\Census Analyser Problem\StatesCensusTests\Resource\IndiaStateCensusData.csv";
        public readonly string INDIAN_STATE_CENSUS_DATA_INCORRECT_EXTENSION_FILEPATH = @"C:\Users\Kashish Manchanda\source\repos\Census Analyser Problem\StatesCensusTests\Resource\IndiaStateCensusData.xls";
        public readonly string INDIAN_STATE_CENSUS_DATA_WRONG_DELIMITER_FILEPATH = @"C:\Users\Kashish Manchanda\source\repos\Census Analyser Problem\StatesCensusTests\Resources\IndianStateCensusWrongDelimiter.csv";
        public readonly string INDIAN_STATE_CENSUS_DATA_WRONG_HEADER_FILEPATH = @"C:\Users\Kashish Manchanda\source\repos\Census Analyser Problem\StatesCensusTests\Resources\IndianStateCensusWrongHeader.csv";
        public readonly string[] headerForStatesCensusData = { "State,Population,AreaInSqKm,DensityPerSqKm" };
        public readonly string INDIAN_STATE_CODE_DATA_FILEPATH = @"C:\Users\Kashish Manchanda\source\repos\Census Analyser Problem\StatesCensusTests\Resources\IndiaStateCode.csv";
        public readonly string INDIAN_STATE_CODE_DATA_WRONG_FILEPATH = @"C:\Users\Kashish Manchanda\source\repos\Census Analyser Problem\StatesCensusTests\Resouces\IndiaStateCode.csv";
        public readonly string INDIAN_STATE_CODE_DATA_INCORRECT_EXTENSION_FILEPATH = @"C:\Users\Kashish Manchanda\source\repos\Census Analyser Problem\StatesCensusTests\Resources\IndiaStateCode.xls";
        public readonly string INDIAN_STATE_CODE_DATA_WRONG_DELIMITER_FILEPATH = @"C:\Users\Kashish Manchanda\source\repos\Census Analyser Problem\StatesCensusTests\Resources\IndiaStateCodeWrongDelimiter.csv";
        public readonly string INDIAN_STATE_CODE_DATA_WRONG_HEADER_FILEPATH = @"C:\Users\Kashish Manchanda\source\repos\Census Analyser Problem\StatesCensusTests\Resources\IndiaStateCodeWrongHeader.csv";
        public readonly string[] headerForStatesCodeData = { "SrNo,StateName,TIN,StateCode" };

        [SetUp]
        public void Setup()
        {
            indianStatesCSVDataLoad = new IndianStatesCensusAndCodeCSVDataLoad();          
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
        [Test]
        public void GivenStateCensusDataRightFilePath_ButWrongExtension_InLoadCensusData_ThrowCustomException()
        {
            try
            {
                int expectedRecords = 29;
                int result = indianStatesCSVDataLoad.LoadStateCensusDataIntoList(INDIAN_STATE_CENSUS_DATA_INCORRECT_EXTENSION_FILEPATH);
                Assert.AreEqual(expectedRecords, result);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("File Type is incorrect", ex.Message);
            }
        }
        [Test]
        public void GivenStateCensusDataRightFilePath_ButWrongDelimiter_InLoadCensusData_ThrowCustomException()
        {
            try
            {
                int expectedRecords = 29;
                int result = indianStatesCSVDataLoad.LoadStateCensusDataIntoList(INDIAN_STATE_CENSUS_DATA_WRONG_DELIMITER_FILEPATH);
                Assert.AreEqual(expectedRecords, result);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("File has incorrect delimiter", ex.Message);
            }
        }
        [Test]
        public void GivenStateCensusDataRightFilePath_ButWrongHeader_InLoadCensusData_ThrowCustomException()
        {
            try
            {
                int expectedRecords = 29;
                int result = indianStatesCSVDataLoad.LoadStateCensusDataIntoList(INDIAN_STATE_CENSUS_DATA_WRONG_HEADER_FILEPATH,headerForStatesCensusData);
                Assert.AreEqual(expectedRecords, result);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("File has incorrect header", ex.Message);
            }
        }
        [Test]
        public void GivenStateCodeDataRightFilePath_InLoadCensusData_ReturnNumberOfRecords()
        {
            int expectedRecords = 36;
            int result = indianStatesCSVDataLoad.LoadStateCensusDataIntoList(INDIAN_STATE_CODE_DATA_FILEPATH);
            Assert.AreEqual(expectedRecords, result);
        }
        [Test]
        public void GivenStateCodeDataWrongFilePath_InLoadCensusData_ThrowCustomException()
        {
            try
            {
                int expectedRecords = 29;
                int result = indianStatesCSVDataLoad.LoadStateCensusDataIntoList(INDIAN_STATE_CODE_DATA_WRONG_FILEPATH);
                Assert.AreEqual(expectedRecords, result);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("File is not found at specified location", ex.Message);
            }
        }
        [Test]
        public void GivenStateCodeDataRightFilePath_ButWrongExtension_InLoadCensusData_ThrowCustomException()
        {
            try
            {
                int expectedRecords = 29;
                int result = indianStatesCSVDataLoad.LoadStateCensusDataIntoList(INDIAN_STATE_CODE_DATA_INCORRECT_EXTENSION_FILEPATH);
                Assert.AreEqual(expectedRecords, result);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("File Type is incorrect", ex.Message);
            }
        }
        [Test]
        public void GivenStateCodeDataRightFilePath_ButWrongDelimiter_InLoadCensusData_ThrowCustomException()
        {
            try
            {
                int expectedRecords = 29;
                int result = indianStatesCSVDataLoad.LoadStateCensusDataIntoList(INDIAN_STATE_CODE_DATA_WRONG_DELIMITER_FILEPATH);
                Assert.AreEqual(expectedRecords, result);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("File has incorrect delimiter", ex.Message);
            }
        }
        [Test]
        public void GivenStateCensusCodeRightFilePath_ButWrongHeader_InLoadCensusData_ThrowCustomException()
        {
            try
            {
                int expectedRecords = 29;
                int result = indianStatesCSVDataLoad.LoadStateCensusDataIntoList(INDIAN_STATE_CODE_DATA_WRONG_HEADER_FILEPATH, headerForStatesCodeData);
                Assert.AreEqual(expectedRecords, result);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("File has incorrect header", ex.Message);
            }
        }
    }
}