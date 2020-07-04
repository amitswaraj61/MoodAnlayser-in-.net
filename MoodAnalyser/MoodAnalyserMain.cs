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
    //// <summary>
    //// MoodAnalyserClass 
    //// </summary>
    public class MoodAnalyserMain
    {
        //// <summary>
        //// delclare globally message
        //// </summary>
        public string message;
        //// <summary>
        //// MoodAnalyserMain deafult constructor
        //// </summary>
        public MoodAnalyserMain()
        {
            message = "";
        }
        //// <summary>
        //// MoodAnalyserMain parameter constructor
        //// </summary>
        public MoodAnalyserMain(string message)
        {
            this.message = message;
        }
        //// <summary>
        ////Default AnalyseMood
        //// </summary>
        public string AnalyseMood()
        {
            return AnalyseMood(this.message);
        }
        //// <summary>
        //// AnalyseMood method
        //// </summary>
       public string AnalyseMood(string message)
        {
            try
            {
                if (message.Length == 0)
                {
                    throw new MoodAnalyserException("mood cant be empty", MoodAnalyserException.ExceptionType.EMPTY_EXCEPTION);
                }
                else if (message.Contains("sad"))
                {
                    return "sad";
                }
                else
                {
                    return "happy";
                }
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserException("mood cant be null", MoodAnalyserException.ExceptionType.NULL_EXCEPTION);
            }
        }
        //// <summary>
        ////Equal method to comapare two objects 
        //// </summary>
        override
        public bool Equals(object obj)
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