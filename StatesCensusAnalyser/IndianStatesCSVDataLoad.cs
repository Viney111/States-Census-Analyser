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
                if (CheckForDelimiter(filepath) == false)
                {
                    throw new CustomStateCensusException(CustomStateCensusException.ExceptionType.INCORRECT_DELIMITER, "File has incorrect delimiter");
                }
                else if (header != null)
                {
                    bool headerMatch = CheckForHeader(filepath, header);
                    if (headerMatch == false)
                    {
                        throw new CustomStateCensusException(CustomStateCensusException.ExceptionType.INCORRECT_HEADER, "File has incorrect header");
                    }
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
        public bool CheckForDelimiter(string filePath)
        {
            string[] censusData = File.ReadAllLines(filePath);
            bool delimiterCheck = false;
            foreach (string data in censusData.Skip(1))
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
        public bool CheckForHeader(string filePath,params string[] header)
        {
            string[] censusdata = File.ReadAllLines(filePath);
            bool headerCheck = censusdata[0]== header[0]? true: false;
            return headerCheck;
        }
    }
}
