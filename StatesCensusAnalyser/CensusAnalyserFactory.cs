using Newtonsoft.Json;
using StatesCensusAnalyser.DTO;
using StatesCensusAnalyser.POCO;
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
        public string SortingByPopulationDensityAmongIndiaAndUS(string filePathUS, string filePathIN)
        {
            CensusAnalyserFactory censusAnalyserFactory = new CensusAnalyserFactory();
            var jsonStringUS = censusAnalyserFactory.SortingIndiaUSStateData(CountryType.US,ComparerFields.SortingType.POPULATION_DENSITY,filePathUS);
            var arraySortedByUSState = JsonConvert.DeserializeObject<USStateData[]>(jsonStringUS);
            Array.Reverse(arraySortedByUSState);
            var jsonStringIN = censusAnalyserFactory.SortingIndiaUSStateData(CountryType.INDIA, ComparerFields.SortingType.DENSITY_SQ_KM, filePathIN,null);
            var arraySortedByIndiaState = JsonConvert.DeserializeObject<IndianStateCensusData[]>(jsonStringIN);
            Array.Reverse(arraySortedByIndiaState);
            double densityOfUSState = arraySortedByUSState[0].PopulationDensity;
            double densityOfIndiaState = arraySortedByIndiaState[0].DensityPerSqKm;
            string resultedState = densityOfIndiaState > densityOfUSState ? arraySortedByIndiaState[0].State : arraySortedByUSState[0].State;
            return resultedState;
        }
    }
}
