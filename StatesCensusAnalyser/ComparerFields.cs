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
            STATE,STATE_CODE
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
                default:
                    break;
            }
            return 0;
        }
    }
}
