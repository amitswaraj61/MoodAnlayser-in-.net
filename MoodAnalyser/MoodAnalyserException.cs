using System;
using System.Collections.Generic;
using System.Text;
using MoodAnalyser;

namespace MoodAnalyser
{
    public class MoodAnalyserException : Exception
    {
       public String message;
       public ExceptionType type;

        public enum ExceptionType
        {
            NULL_EXCEPTION, EMPTY_EXCEPTION,NO_SUCH_CLASS,NO_SUCH_METHOD,OBJECT_CREATION_ERROR
        }

    public MoodAnalyserException(String message,ExceptionType type) : base(message)
        {
            this.message = message;
            this.type = type;
        }
    }
}
   
