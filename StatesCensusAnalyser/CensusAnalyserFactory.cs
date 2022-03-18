using Newtonsoft.Json;
using StatesCensusAnalyser.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatesCensusAnalyser
{
    public class CensusAnalyserFactory
    {
        Dictionary<string,IndianStateDTO> indianStateData = new Dictionary<string,IndianStateDTO>();
        public int LoadIndianStatesData(params string[] filePath)
        {
            ILoadIndianStatesDataInMap indianStatesDataInMap = new IndianStateCensusCodeMap();
            indianStateData = indianStatesDataInMap.MappingStateCodeAndCensus(filePath);
            return indianStateData.Count();
        }
        public string SortingIndianStateData(ComparerFields.SortingType fieldtoBesorted, params string[] filePath)
        {
            ILoadIndianStatesDataInMap indianStatesDataInMap = new IndianStateCensusCodeMap();
            indianStateData = indianStatesDataInMap.MappingStateCodeAndCensus(filePath);
            var sortedList = indianStateData.Select(x => x.Value).ToList();
            ComparerFields comparer = new ComparerFields(fieldtoBesorted);
            sortedList.Sort(comparer);
            return JsonConvert.SerializeObject(sortedList);
        }
    }
}
