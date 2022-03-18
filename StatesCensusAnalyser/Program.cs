using System;
using CsvHelper;
using System.Globalization;


namespace StatesCensusAnalyser
{
    public class Program
    {
        public static string INDIAN_STATE_CENSUS_DATA_FILEPATH = @"C:\Users\Kashish Manchanda\source\repos\Census Analyser Problem\StatesCensusTests\Resources\IndiaStateCensusData.csv";
        public static string INDIAN_STATE_CODE_DATA_FILEPATH = @"C:\Users\Kashish Manchanda\source\repos\Census Analyser Problem\StatesCensusTests\Resources\IndiaStateCode.csv";
        public static void Main(string[] args)
        {
            IndianStateCensusCodeMap indianStateCensusCodeMap = new IndianStateCensusCodeMap();
            indianStateCensusCodeMap.MappingStateCodeAndCensus(INDIAN_STATE_CODE_DATA_FILEPATH);
        }
    }
}