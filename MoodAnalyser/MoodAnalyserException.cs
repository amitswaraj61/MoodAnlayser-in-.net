using System;
using System.Collections.Generic;
using System.Text;
using Mood_Analyser;

namespace Mood_Analyser
{
    public class MoodAnalyserException : Exception
    {
       public String message;
       public ExceptionType type;

        public enum ExceptionType
        {
            NULL_EXCEPTION, EMPTY_EXCEPTION
        }

    public MoodAnalyserException(String message,ExceptionType type) : base(message)
        {
            this.message = message;
            this.type = type;
        }
    }
}
   
