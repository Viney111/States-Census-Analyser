using System;
using System.Collections.Generic;
using System.Linq;

namespace StatesCensusAnalyser.POCO
{
    public class IndianStateCensusData
    {
        public string State { get; set; }
        public long Population { get; set; }
        public long AreaInSqKm { get; set; }
        public long DensityPerSqKm { get; set; }

    }
}
