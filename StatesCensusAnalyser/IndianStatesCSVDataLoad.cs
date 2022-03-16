using StatesCensusAnalyser.POCO;
using System;
using CsvHelper;
using System.Globalization;


namespace StatesCensusAnalyser
{
    public class IndianStatesCSVDataLoad
    {
        List<IndianStateCensusData> indianStateCensusDatas;

        public int LoadStateCensusDataIntoList(string filepath)
        {
            try
            {
                using (StreamReader sr = File.OpenText(filepath))
                using (var csvReader = new CsvReader(sr, CultureInfo.InvariantCulture))
                {
                    indianStateCensusDatas = csvReader.GetRecords<IndianStateCensusData>().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new CustomStateCensusException(CustomStateCensusException.ExceptionType.FILE_NOT_FOUND, "File is not found at specified location");
            }
            return indianStateCensusDatas.Count;
        }
    }
}
