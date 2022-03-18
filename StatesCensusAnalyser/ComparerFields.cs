using System;
using System.Collections.Generic;
using StatesCensusAnalyser.DTO;
using StatesCensusAnalyser.POCO;

namespace StatesCensusAnalyser
{
    public class ComparerFields : IComparer<IndiaUSStateDTO>
    {
        public enum SortingType
        {
            STATE,STATE_CODE,POPULATION_DENSITY,POPULATION,LAND_AREA
        }
        public SortingType comparebyDataHeader;
        public ComparerFields(SortingType comparebyDataHeader)
        {
            this.comparebyDataHeader = comparebyDataHeader;
        }
        public int Compare(IndiaUSStateDTO x, IndiaUSStateDTO y)
        {
            switch (comparebyDataHeader)
            {
                case SortingType.STATE:
                    return x.State.CompareTo(y.State);
                case SortingType.STATE_CODE:
                    return x.StateCode.CompareTo(y.StateCode);
                case SortingType.POPULATION_DENSITY:
                    return x.PopulationDensity.CompareTo(y.PopulationDensity);
                case SortingType.POPULATION:
                    return x.Population.CompareTo(y.Population);
                case SortingType.LAND_AREA:
                    return x.Landarea.CompareTo(y.Landarea);
                default:
                    break;
            }
            return 0;
        }
    }
}
