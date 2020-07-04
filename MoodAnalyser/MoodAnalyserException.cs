//-----------------------------------------------------------------------
// <copyright file="MoodAnalyzerException.cs" company="BridgeLabz">
// Copyright (c) 2012 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------
namespace MoodAnalyser
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MoodAnalyser;
    //// <summary>
    //// Create custom exception for MoodAnalyserMain
    //// </summary>
    public class MoodAnalyserException : Exception
    {
        public String message;
        public ExceptionType type;
        //// <summary>
        //// create enum class
        //// </summary>
        public enum ExceptionType
        {
            //// <summary>
            //// Create diffrent enum type
            //// </summary>
            NULL_EXCEPTION, EMPTY_EXCEPTION, NO_SUCH_CLASS, NO_SUCH_METHOD, OBJECT_CREATION_ERROR, No_such_Method, No_such_class, mood_cant_be_empty, mood_cant_be_null,NO_SUCH_FIELD
        }
        public MoodAnalyserException(String message, ExceptionType type) : base(message)
        {
            this.message = message;
            this.type = type;
        }
    }
}
