//-----------------------------------------------------------------------
// <copyright file="MoodAnalyzerMain.cs" company="BridgeLabz">
// Copyright (c) 2012 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyser
{
    public class MoodAnalyserMain
    {
      public  String message;

        public MoodAnalyserMain()
        {
            message = "";
        }

        public MoodAnalyserMain(String message)
        {
            this.message = message;
        }
        public String AnalyseMood()
        {
            return AnalyseMood(this.message);
        }

      
            public String AnalyseMood(String message)
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
        override
        public bool Equals(Object obj)
        {
            MoodAnalyserMain moodAnalyser = (MoodAnalyserMain)obj;
            if (this.message.Equals(moodAnalyser.message))
            {
                return true;
            }
            return false;
        }
    }
}