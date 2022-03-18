using StatesCensusAnalyser.DTO;
using StatesCensusAnalyser.POCO;
using CsvHelper;
using System.Globalization;

namespace StatesCensusAnalyser
{
    public class USStateMap : ILoadIndianStatesDataInMap
    {
        Dictionary<string, IndiaUSStateDTO> mapUSStateData = new Dictionary<string, IndiaUSStateDTO>();
        public Dictionary<string, IndiaUSStateDTO> MappingStatesData(params string[] filePath)
        {
            List<USStateData> uSStateDataList = new List<USStateData>();
            if (filePath[0] != null)
            {
                StatesDataChecking.StatesDataFilesChecking(filePath[0]);
            }
            using(StreamReader streamReader = File.OpenText(filePath[0]))
            using(CsvReader csvReader = new CsvReader(streamReader,CultureInfo.CurrentCulture))
            {
                uSStateDataList = csvReader.GetRecords<USStateData>().ToList();
            }
            foreach(var field in uSStateDataList)
            {
                IndiaUSStateDTO indiaUSStateDTO = new IndiaUSStateDTO();
                var uSStateData = new USStateData
                {
                    StateId = field.StateId,
                    State = field.State,
                    Population = field.Population,
                    HousingDensity = field.HousingDensity,
                    Landarea = field.Landarea,
                    Waterarea = field.Waterarea,
                    Housingunits = field.Housingunits,
                    PopulationDensity = field.PopulationDensity,
                    Totalarea = field.Totalarea,
                };
                indiaUSStateDTO.USDataInitializer(uSStateData);
                mapUSStateData.Add(field.State, indiaUSStateDTO);
            }
            return mapUSStateData;
        }
    }
}
