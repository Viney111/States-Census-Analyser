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
            using (StreamReader sr = File.OpenText(filepath))
            using (var csvReader = new CsvReader(sr, CultureInfo.InvariantCulture))
            {
                indianStateCensusDatas = csvReader.GetRecords<IndianStateCensusData>().ToList();
            }
            return indianStateCensusDatas.Count;
        }
    }
}
