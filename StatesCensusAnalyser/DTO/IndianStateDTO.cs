using System;
using StatesCensusAnalyser.POCO;

namespace StatesCensusAnalyser.DTO
{
    public class IndianStateDTO
    {
        public string State { get; set; }
        public long Population { get; set; }
        public long AreaInSqKm { get; set; }
        public long DensityPerSqKm { get; set; }
        public int SrNo { get; set; }
        public string StateName { get; set; }
        public int TIN { get; set; }
        public string StateCode { get; set; }

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
    }
}
