using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatesCensusAnalyser
{
    public class CustomStateCensusException : Exception
    {
        public enum ExceptionType
        {
            FILE_NOT_FOUND, FILE_TYPE_INCORRECT, INCORRECT_DELIMITER, INCORRECT_HEADER
        }
        public ExceptionType Type;

        public CustomStateCensusException(ExceptionType type,string message) : base(message)
        {
            Type = type;
        }
    }
}
