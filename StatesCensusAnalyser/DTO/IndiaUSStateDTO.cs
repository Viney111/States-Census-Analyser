using StatesCensusAnalyser.POCO;
using System;


namespace StatesCensusAnalyser.DTO
{
    public class IndiaUSStateDTO
    {
        public string State { get; set; }
        public long Population { get; set; }
        public long AreaInSqKm { get; set; }
        public long DensityPerSqKm { get; set; }
        public int SrNo { get; set; }
        public string StateName { get; set; }
        public int TIN { get; set; }
        public string StateCode { get; set; }
        public string StateId {get; set;}
        public long Housingunits { get; set; }
        public double Totalarea { get; set; }
        public double Waterarea { get; set; }
        public double Landarea { get; set; }
        public double PopulationDensity { get; set; }
        public double HousingDensity { get; set; }
        public void StateCensusInitializer(IndianStateCensusData indianStateCensusData)
        {
            this.State = indianStateCensusData.State;
            this.Population = indianStateCensusData.Population;
            this.AreaInSqKm = indianStateCensusData.AreaInSqKm;
            this.DensityPerSqKm = indianStateCensusData.DensityPerSqKm;
        }
        public void StateCodeInitializer(IndianStateCode indianStateCode)
        {
            this.StateName = indianStateCode.StateName;
            this.SrNo = indianStateCode.SrNo;
            this.TIN = indianStateCode.TIN;
            this.StateCode = indianStateCode.StateCode;
        }
        public void USDataInitializer(USStateData uSStateData)
        {
            this.StateId = uSStateData.StateId;
            this.State = uSStateData.State;
            this.Population = uSStateData.Population;
            this.HousingDensity = uSStateData.HousingDensity;
            this.Housingunits = uSStateData.Housingunits;
            this.Landarea = uSStateData.Landarea;
            this.Totalarea = uSStateData.Totalarea;
            this.Waterarea = uSStateData.Waterarea;
            this.PopulationDensity = uSStateData.PopulationDensity;
        }
    }
}
