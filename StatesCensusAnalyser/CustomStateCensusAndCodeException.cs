using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatesCensusAnalyser
{
    public class CustomStateCensusAndCodeException : Exception
    {
        public enum ExceptionType
        {
            FILE_NOT_FOUND, FILE_TYPE_INCORRECT, INCORRECT_DELIMITER, INCORRECT_HEADER
        }
        public ExceptionType Type;

        public CustomStateCensusAndCodeException(ExceptionType type,string message) : base(message)
        {
            Type = type;
        }
    }
}
