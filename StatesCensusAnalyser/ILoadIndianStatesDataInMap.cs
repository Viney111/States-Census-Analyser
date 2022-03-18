using System;
using System.Collections.Generic;
using StatesCensusAnalyser.DTO;

namespace StatesCensusAnalyser
{
    public interface ILoadIndianStatesDataInMap
    {
        public Dictionary<string, IndianStateDTO> MappingStateCodeAndCensus(params string[] filePath);
    }
}
