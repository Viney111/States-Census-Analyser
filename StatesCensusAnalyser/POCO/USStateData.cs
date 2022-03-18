using System;
using System.Collections.Generic;

namespace StatesCensusAnalyser.POCO
{
    public class USStateData
    {
        public string State { get; set; }
        public string StateId { get; set; }
        public long Population { get; set; }
        public long Housingunits { get; set; }
        public double Totalarea { get; set; }
        public double Waterarea { get; set; }
        public double Landarea { get; set; }
        public double PopulationDensity { get; set; }
        public double HousingDensity { get; set; }
    }
}
