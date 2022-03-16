﻿using StatesCensusAnalyser.POCO;
using System;
using CsvHelper;
using System.Globalization;


namespace StatesCensusAnalyser
{
    public class IndianStatesCSVDataLoad
    {
        List<IndianStateCensusData> indianStateCensusDatas;

        public int LoadStateCensusDataIntoList(string filepath)
        {
            if (File.Exists(filepath))
            {
                using (StreamReader sr = File.OpenText(filepath))
                using (var csvReader = new CsvReader(sr, CultureInfo.InvariantCulture))
                {
                    indianStateCensusDatas = csvReader.GetRecords<IndianStateCensusData>().ToList();
                }
            }
            else if (Path.GetExtension(filepath) != ".csv")
            {
                throw new CustomStateCensusException(CustomStateCensusException.ExceptionType.FILE_TYPE_INCORRECT, "File Type is incorrect");
            }
            else if (!File.Exists(filepath))
            {
                throw new CustomStateCensusException(CustomStateCensusException.ExceptionType.FILE_NOT_FOUND, "File is not found at specified location");
            }
            return indianStateCensusDatas.Count;
        }
    }
}
