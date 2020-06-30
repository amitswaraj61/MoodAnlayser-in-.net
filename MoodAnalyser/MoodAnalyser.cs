using System;
using System.Collections.Generic;
using System.Text;

namespace Mood_Analyser
{
    public class MoodAnalyser
    {
        String message;

        public MoodAnalyser()
        {

        }


        public MoodAnalyser(String message)
        {
            this.message = message;
        }

        public String AnalyseMood()
        {
            try
            {
                if (message.Length == 0)
                    throw new MoodAnalyserException("mood cant be empty", MoodAnalyserException.ExceptionType.EMPTY_EXCEPTION);
                else if (message.Contains("sad"))
                    return "sad";
                else
                    return "happy";
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserException("mood cant be null", MoodAnalyserException.ExceptionType.NULL_EXCEPTION);
            }
        }
    }
    }
                    
    


  