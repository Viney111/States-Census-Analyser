using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatesCensusAnalyser
{
    public interface ILoadIndianStatesData
    {
        public int LoadStateCensusDataIntoList(string filepath, string[] header = null);
    }
}
