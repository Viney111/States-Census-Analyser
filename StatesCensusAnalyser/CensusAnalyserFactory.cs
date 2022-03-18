using Newtonsoft.Json;
using StatesCensusAnalyser.DTO;
using System.Linq;

namespace StatesCensusAnalyser
{
    public class CensusAnalyserFactory
    {
        Dictionary<string,IndiaUSStateDTO> distinctCountryData = new Dictionary<string, IndiaUSStateDTO>();
        public int LoadIndianStatesData(CountryType country, params string[] filePath)
        {
            if (country == CountryType.INDIA)
            {
                ILoadIndianStatesDataInMap indianStatesDataInMap = new IndianStateCensusCodeMap();
                distinctCountryData = indianStatesDataInMap.MappingStatesData(filePath);
            }
            if(country == CountryType.US)
            {
                ILoadIndianStatesDataInMap usStatesDataInMap = new USStateMap();
                distinctCountryData = usStatesDataInMap.MappingStatesData(filePath);
            }
            return distinctCountryData.Count;
        }
        public string SortingIndiaUSStateData(CountryType country,ComparerFields.SortingType fieldtoBesorted, params string[] filePath)
        {
            if (country == CountryType.INDIA)
            {
                ILoadIndianStatesDataInMap indianStatesDataInMap = new IndianStateCensusCodeMap();
                distinctCountryData = indianStatesDataInMap.MappingStatesData(filePath);
                var sortedList = distinctCountryData.Select(x => x.Value).ToList();
                ComparerFields comparer = new ComparerFields(fieldtoBesorted);
                sortedList.Sort(comparer);
                return JsonConvert.SerializeObject(sortedList);
            }
            if (country == CountryType.US)
            {
                ILoadIndianStatesDataInMap uSStatesDataInMap = new USStateMap();
                distinctCountryData = uSStatesDataInMap.MappingStatesData(filePath);
                var sortedList = distinctCountryData.Select(x => x.Value).ToList();
                ComparerFields comparer = new ComparerFields(fieldtoBesorted);
                sortedList.Sort(comparer);
                return JsonConvert.SerializeObject(sortedList);
            }
            else
            {
                return "Please select Country";
            }
        }
    }
}
