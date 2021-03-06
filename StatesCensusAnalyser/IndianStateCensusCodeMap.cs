using System;
using StatesCensusAnalyser.POCO;
using StatesCensusAnalyser.DTO;
using CsvHelper;
using System.Globalization;
using Newtonsoft.Json;

namespace StatesCensusAnalyser
{
    public class IndianStateCensusCodeMap : ILoadIndianStatesDataInMap
    {
        Dictionary<string, IndiaUSStateDTO> mapIndiaStateCensusCode = new Dictionary<string, IndiaUSStateDTO>();
        public Dictionary<string, IndiaUSStateDTO> MappingStatesData(params string[] filePath)
        {
            List<IndianStateCensusData> indianStateCensusDatasList = new List<IndianStateCensusData>();
            List<IndianStateCode> indianStateCodesList = new List<IndianStateCode>();
            if (filePath[0] != null)
            {
                StatesDataChecking.StatesDataFilesChecking(filePath[0]);
                using (StreamReader reader = File.OpenText(filePath[0]))
                using (CsvReader csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    indianStateCensusDatasList = csvReader.GetRecords<IndianStateCensusData>().ToList();
                }
                foreach (var fields in indianStateCensusDatasList)
                {
                    IndiaUSStateDTO indiaUSStateDTO = new IndiaUSStateDTO();
                    var indianStateCensusObject = new IndianStateCensusData
                    {
                        State = fields.State,
                        DensityPerSqKm = fields.DensityPerSqKm,
                        Population = fields.Population,
                        AreaInSqKm = fields.AreaInSqKm,
                    };
                    indiaUSStateDTO.StateCensusInitializer(indianStateCensusObject);
                    mapIndiaStateCensusCode.Add(fields.State, indiaUSStateDTO);
                }
            }
            if (filePath[1] != null)
            {
                StatesDataChecking.StatesDataFilesChecking(filePath[1]);
                using (StreamReader reader = File.OpenText(filePath[1]))
                using (CsvReader csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    indianStateCodesList = csvReader.GetRecords<IndianStateCode>().ToList();
                }
                IndianStateCode indianStateCodeDistinctstates = new IndianStateCode();
                foreach (var kvp in mapIndiaStateCensusCode)
                {
                    var indianStateCodeObject = indianStateCodesList.Find(x => x.StateName == kvp.Key);
                    indianStateCodesList.Remove(indianStateCodeObject);
                    kvp.Value.StateCodeInitializer(indianStateCodeObject);
                }
                foreach(var fields in indianStateCodesList)
                {
                    IndiaUSStateDTO indiaUSStateDTO = new IndiaUSStateDTO();
                    var distinctStateCodeObject = new IndianStateCode
                    {
                        StateName = fields.StateName,
                        SrNo = fields.SrNo,
                        StateCode = fields.StateCode,
                        TIN = fields.TIN,
                    };
                    indiaUSStateDTO.StateCodeInitializer(distinctStateCodeObject);
                    mapIndiaStateCensusCode.Add(fields.StateName, indiaUSStateDTO);
                }
            }
            return mapIndiaStateCensusCode;
        }
    }
}
