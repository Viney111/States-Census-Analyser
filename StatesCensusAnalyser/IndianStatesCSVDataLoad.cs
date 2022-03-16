using StatesCensusAnalyser.POCO;
using System;
using CsvHelper;
using System.Globalization;


namespace StatesCensusAnalyser
{
    public class IndianStatesCSVDataLoad
    {
        List<IndianStateCensusData> indianStateCensusDatas;

        public int LoadStateCensusDataIntoList(string filepath, string[] header = null)
        {

            if (File.Exists(filepath))
            {
                string[] censusData = File.ReadAllLines(filepath);
                if (CheckForDelimiter(censusData) == false)
                {
                    throw new CustomStateCensusException(CustomStateCensusException.ExceptionType.INCORRECT_DELIMITER, "File has incorrect delimiter");
                }
                else if (header != null && censusData[0] != header[0])
                {
                    throw new CustomStateCensusException(CustomStateCensusException.ExceptionType.INCORRECT_HEADER, "File has incorrect header");
                }
                else
                {
                    using (StreamReader sr = File.OpenText(filepath))
                    using (var csvReader = new CsvReader(sr, CultureInfo.InvariantCulture))
                    {
                        indianStateCensusDatas = csvReader.GetRecords<IndianStateCensusData>().ToList();
                    }
                }
            }
            else if (Path.GetExtension(filepath) != ".csv")
            {
                throw new CustomStateCensusException(CustomStateCensusException.ExceptionType.FILE_TYPE_INCORRECT, "File Type is incorrect");
            }
            else if (!File.Exists(filepath))
            {
                throw new CustomStateCensusException(CustomStateCensusException.ExceptionType.FILE_NOT_FOUND, "File is not found at specified location");
            }
            return indianStateCensusDatas.Count;
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
    }
}
