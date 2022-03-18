using NUnit.Framework;
using StatesCensusAnalyser;
using System;
using Newtonsoft.Json;
using StatesCensusAnalyser.POCO;

namespace StatesCensusTests
{
    public class Tests
    {
        CensusAnalyserFactory censusAnalyserFactory;

        public readonly string INDIAN_STATE_CENSUS_DATA_FILEPATH = @"C:\Users\Kashish Manchanda\source\repos\Census Analyser Problem\StatesCensusTests\Resources\IndiaStateCensusData.csv";
        public readonly string INDIAN_STATE_CENSUS_DATA_WRONG_FILEPATH = @"C:\Users\Kashish Manchanda\source\repos\Census Analyser Problem\StatesCensusTests\Resource\IndiaStateCensusData.csv";
        public readonly string INDIAN_STATE_CENSUS_DATA_INCORRECT_EXTENSION_FILEPATH = @"C:\Users\Kashish Manchanda\source\repos\Census Analyser Problem\StatesCensusTests\Resource\IndiaStateCensusData.xls";
        public readonly string INDIAN_STATE_CENSUS_DATA_WRONG_DELIMITER_FILEPATH = @"C:\Users\Kashish Manchanda\source\repos\Census Analyser Problem\StatesCensusTests\Resources\IndianStateCensusWrongDelimiter.csv";
        public readonly string INDIAN_STATE_CENSUS_DATA_WRONG_HEADER_FILEPATH = @"C:\Users\Kashish Manchanda\source\repos\Census Analyser Problem\StatesCensusTests\Resources\IndianStateCensusWrongHeader.csv";
        public readonly string INDIAN_STATE_CODE_DATA_FILEPATH = @"C:\Users\Kashish Manchanda\source\repos\Census Analyser Problem\StatesCensusTests\Resources\IndiaStateCode.csv";
        public readonly string INDIAN_STATE_CODE_DATA_WRONG_FILEPATH = @"C:\Users\Kashish Manchanda\source\repos\Census Analyser Problem\StatesCensusTests\Resouces\IndiaStateCode.csv";
        public readonly string INDIAN_STATE_CODE_DATA_INCORRECT_EXTENSION_FILEPATH = @"C:\Users\Kashish Manchanda\source\repos\Census Analyser Problem\StatesCensusTests\Resources\IndiaStateCode.xls";
        public readonly string INDIAN_STATE_CODE_DATA_WRONG_DELIMITER_FILEPATH = @"C:\Users\Kashish Manchanda\source\repos\Census Analyser Problem\StatesCensusTests\Resources\IndiaStateCodeWrongDelimiter.csv";
        public readonly string INDIAN_STATE_CODE_DATA_WRONG_HEADER_FILEPATH = @"C:\Users\Kashish Manchanda\source\repos\Census Analyser Problem\StatesCensusTests\Resources\IndiaStateCodeWrongHeader.csv";
        public readonly string US_STATE_CENSUS_DATA_FILEPATH = @"C:\Users\Kashish Manchanda\source\repos\Census Analyser Problem\StatesCensusTests\Resources\USCensusData.csv";
        public readonly string US_STATE_CENSUS_DATA_WRONG_FILEPATH = @"C:\Users\Kashish Manchanda\source\repos\Census Analser Problem\StatesCensusTests\Resources\USCensusData.csv";

        [SetUp]
        public void Setup()
        {
            censusAnalyserFactory = new CensusAnalyserFactory();
        }
        [Test]
        public void GivenUSCensusDataRightFilePath_InLoadCensusData_ReturnNumberOfRecords()
        {
            int expectedRecords = 51;
            int result = censusAnalyserFactory.LoadIndianStatesData(CountryType.US, US_STATE_CENSUS_DATA_FILEPATH);
            Assert.AreEqual(expectedRecords, result);
        }
        [Test]
        public void GivenUSCensusDataWrongFilePath_InLoadCensusData_ThrowCustomException()
        {
            try
            {
                int expectedRecords = 51;
                int result = censusAnalyserFactory.LoadIndianStatesData(CountryType.US, US_STATE_CENSUS_DATA_WRONG_FILEPATH);
                Assert.AreEqual(expectedRecords, result);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("File is not found at specified location", ex.Message);
            }
        }

        [Test]
        public void GivenStateCensusDataRightFilePath_InLoadCensusData_ReturnNumberOfRecords()
        {
            int expectedRecords = 29;
            int result = censusAnalyserFactory.LoadIndianStatesData(CountryType.INDIA,INDIAN_STATE_CENSUS_DATA_FILEPATH,null);
            Assert.AreEqual(expectedRecords, result);
        }
        [Test]
        public void GivenStateCensusDataWrongFilePath_InLoadCensusData_ThrowCustomException()
        {
            try
            {
                int expectedRecords = 29;
                int result = censusAnalyserFactory.LoadIndianStatesData(CountryType.INDIA,INDIAN_STATE_CENSUS_DATA_WRONG_FILEPATH,null);
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
                int result = censusAnalyserFactory.LoadIndianStatesData(CountryType.INDIA,INDIAN_STATE_CENSUS_DATA_INCORRECT_EXTENSION_FILEPATH,null);
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
                int result = censusAnalyserFactory.LoadIndianStatesData(CountryType.INDIA,INDIAN_STATE_CENSUS_DATA_WRONG_DELIMITER_FILEPATH,null);
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
                int result = censusAnalyserFactory.LoadIndianStatesData(CountryType.INDIA,INDIAN_STATE_CENSUS_DATA_WRONG_HEADER_FILEPATH);
                Assert.AreEqual(expectedRecords, result);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("File has incorrect header", ex.Message);
            }
        }
        [Test]
        public void GivenStateCodeDataWrongFilePath_InLoadCensusData_ThrowCustomException()
        {
            try
            {
                int expectedRecords = 36;
                int result = censusAnalyserFactory.LoadIndianStatesData(CountryType.INDIA,null,INDIAN_STATE_CODE_DATA_WRONG_FILEPATH);
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
                int expectedRecords = 36;
                int result = censusAnalyserFactory.LoadIndianStatesData(CountryType.INDIA,null,INDIAN_STATE_CODE_DATA_INCORRECT_EXTENSION_FILEPATH);
                Assert.AreEqual(expectedRecords, result);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("File Type is incorrect", ex.Message);
            }
        }
        [Test]
        public void GivenStateCensusCodeRightFilePath_ButWrongDelimiter_InLoadCensusData_ThrowCustomException()
        {
            try
            {
                int expectedRecords = 36;
                int result = censusAnalyserFactory.LoadIndianStatesData(CountryType.INDIA,null,INDIAN_STATE_CODE_DATA_WRONG_DELIMITER_FILEPATH);
                Assert.AreEqual(expectedRecords, result);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("File has incorrect delimiter", ex.Message);
            }
        }
        [Test]
        public void GivenStateCodeDataRightFilePath_ButWrongHeader_InLoadCensusData_ThrowCustomException()
        {
            try
            {
                int expectedRecords = 36;
                int result = censusAnalyserFactory.LoadIndianStatesData(CountryType.INDIA,null,INDIAN_STATE_CODE_DATA_WRONG_HEADER_FILEPATH);
                Assert.AreEqual(expectedRecords, result);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("File has incorrect header", ex.Message);
            }
        }

        [Test]
        public void GivenStateCensusDataRightFilePath_InLoadCensusData_GetsMeSortedListByStateName()
        {
            var jsonString = censusAnalyserFactory.SortingIndianStateData(CountryType.INDIA,ComparerFields.SortingType.STATE, INDIAN_STATE_CENSUS_DATA_FILEPATH, INDIAN_STATE_CODE_DATA_FILEPATH);
            var arraySortedByState = JsonConvert.DeserializeObject<IndianStateCensusData[]>(jsonString);
            Assert.AreEqual(arraySortedByState[0].State, "Andhra Pradesh");
            Array.Reverse(arraySortedByState);
            Assert.AreEqual(arraySortedByState[0].State, "West Bengal");
        }
        [Test]
        public void GivenStateCodeRightFilePath_InLoadCensusData_GetsMeSortedListByStateCode()
        {
            var jsonString = censusAnalyserFactory.SortingIndianStateData(CountryType.INDIA,ComparerFields.SortingType.STATE_CODE, INDIAN_STATE_CENSUS_DATA_FILEPATH, INDIAN_STATE_CODE_DATA_FILEPATH);
            var arraySortedByStateCode = JsonConvert.DeserializeObject<IndianStateCode[]>(jsonString);
            Assert.AreEqual(arraySortedByStateCode[0].StateName, "Andhra Pradesh");
            Array.Reverse(arraySortedByStateCode);
            Assert.AreEqual(arraySortedByStateCode[0].StateName, "West Bengal");
        }
    }
}