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
        Dictionary<string, IndianStateDTO> mapStateCensusCode = new Dictionary<string, IndianStateDTO>();
        public Dictionary<string, IndianStateDTO> MappingStateCodeAndCensus(params string[] filePath)
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
                    IndianStateDTO indianStateDTO = new IndianStateDTO();
                    var indianStateCensusObject = new IndianStateCensusData
                    {
                        State = fields.State,
                        DensityPerSqKm = fields.DensityPerSqKm,
                        Population = fields.Population,
                        AreaInSqKm = fields.AreaInSqKm,
                    };
                    indianStateDTO.StateCensusInitializer(indianStateCensusObject);
                    mapStateCensusCode.Add(fields.State, indianStateDTO);
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
                foreach (var kvp in mapStateCensusCode)
                {
                    var indianStateCodeObject = indianStateCodesList.Find(x => x.StateName == kvp.Key);
                    kvp.Value.StateCodeInitializer(indianStateCodeObject);
                }
            }
            return mapStateCensusCode;
        }
    }
}
