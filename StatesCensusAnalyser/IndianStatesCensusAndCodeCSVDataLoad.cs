﻿using StatesCensusAnalyser.POCO;
using System;
using CsvHelper;
using System.Globalization;
using Newtonsoft.Json;


namespace StatesCensusAnalyser
{
    public class IndianStatesCensusAndCodeCSVDataLoad : ILoadIndianStatesData
    {
        List<IndianStateCensusData> indianStateCensusDatas;
        List<IndianStateCode> indianStateCodes;

        public int LoadStateCensusDataIntoList(string filepath, string[] header = null)
        {
            int recordCounts = 0;
            if (File.Exists(filepath))
            {
                string[] censusData = File.ReadAllLines(filepath);
                if (CheckForDelimiter(censusData) == false)
                {
                    throw new CustomStateCensusAndCodeException(CustomStateCensusAndCodeException.ExceptionType.INCORRECT_DELIMITER, "File has incorrect delimiter");
                }
                else if (header != null && censusData[0] != header[0])
                {
                    throw new CustomStateCensusAndCodeException(CustomStateCensusAndCodeException.ExceptionType.INCORRECT_HEADER, "File has incorrect header");
                }
                else
                {
                    using (StreamReader sr = File.OpenText(filepath))
                    using (var csvReader = new CsvReader(sr, CultureInfo.InvariantCulture))
                    {
                        if (filepath.Contains("StateCode"))
                        {
                            indianStateCodes = csvReader.GetRecords<IndianStateCode>().ToList();
                            recordCounts = indianStateCodes.Count;
                        }
                        if (filepath.Contains("StateCensus"))
                        {   
                            indianStateCensusDatas = csvReader.GetRecords<IndianStateCensusData>().ToList();
                            recordCounts = indianStateCensusDatas.Count;
                        }                           
                    }
                }
            }
            else if (Path.GetExtension(filepath) != ".csv")
            {
                throw new CustomStateCensusAndCodeException(CustomStateCensusAndCodeException.ExceptionType.FILE_TYPE_INCORRECT, "File Type is incorrect");
            }
            else if (!File.Exists(filepath))
            {
                throw new CustomStateCensusAndCodeException(CustomStateCensusAndCodeException.ExceptionType.FILE_NOT_FOUND, "File is not found at specified location");
            }
            return recordCounts;
        }
        public bool CheckForDelimiter(string[] datas)
        {
            bool delimiterCheck = false;
            foreach (string data in datas.Skip(1))
            {
                if (data.Contains(","))
                {
                    delimiterCheck = true;
                }
                else
                {
                    delimiterCheck = false;
                    break;
                }
            }
            return delimiterCheck;
        }
        public string SortingStateCensusDataByState(string filePath)
        {
            try
            {
                int recordsCount = LoadStateCensusDataIntoList(filePath);
                List<IndianStateCensusData> stateCensusSortedList = indianStateCensusDatas;
                stateCensusSortedList.Sort((s1, s2) => s1.State.CompareTo(s2.State));
                var jsonString = JsonConvert.SerializeObject(stateCensusSortedList);
                return jsonString;
            }
            catch(NullReferenceException)
            {
                return "The file Path You mentioned is for StateCode File";
            }
        }
        public string SortingStateCodeDataByStateCode(string filePath)
        {
            try
            {
                int recordsCount = LoadStateCensusDataIntoList(filePath);
                List<IndianStateCode> stateCodeSortedList = indianStateCodes;
                stateCodeSortedList.Sort((s1, s2) => s1.StateCode.CompareTo(s2.StateCode));
                var jsonString = JsonConvert.SerializeObject(stateCodeSortedList);
                return jsonString;
            }
            catch (NullReferenceException)
            {
                return "The file Path You mentioned is for StateCensus File";
            }
        }
    }
}
