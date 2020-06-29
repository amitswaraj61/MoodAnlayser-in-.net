using System;
using System.Collections.Generic;
using System.Text;

namespace Mood_Analyser
{
  public  class MoodAnalyser
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
            if (message.Contains("sad"))
                return "sad";
            return "happy";
        }
    }
}
