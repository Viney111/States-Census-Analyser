using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatesCensusAnalyser
{
    public enum CountryType
    {
        INDIA, US
    }
    public class CountryDataHandler
    {
        public CountryType country;
        public CountryDataHandler(CountryType country)
        {
            this.country = country;
        }
    }
}
