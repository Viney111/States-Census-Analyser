using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatesCensusAnalyser
{
    public class StatesDataChecking
    {
        public static string[] StatesDataFilesChecking(string filepath)
        {
            string[] censusData = null;
            string[] headers = { "State,Population,AreaInSqKm,DensityPerSqKm", "SrNo,StateName,TIN,StateCode" , "StateId,State,Population,Housingunits,Totalarea,Waterarea,Landarea,PopulationDensity,HousingDensity" };
            if (File.Exists(filepath))
            {
                censusData = File.ReadAllLines(filepath);
                if (CheckForDelimiter(censusData) == false)
                {
                    throw new CustomStateCensusAndCodeException(CustomStateCensusAndCodeException.ExceptionType.INCORRECT_DELIMITER, "File has incorrect delimiter");
                }
                else if (!headers.Contains(censusData[0]))
                {
                    throw new CustomStateCensusAndCodeException(CustomStateCensusAndCodeException.ExceptionType.INCORRECT_HEADER, "File has incorrect header");
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
            return censusData;
        }
        private static bool CheckForDelimiter(string[] datas)
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
