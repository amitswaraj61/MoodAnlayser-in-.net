using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using MoodAnalyser;

namespace MoodAnalyser
{
    public class MoodAnalyserFactory
    {
        public static MoodAnalyserMain CreateMoodAnalyser()
        {

            Type type = typeof(MoodAnalyserMain);
            ConstructorInfo[] constructorInfo = type.GetConstructors();
            Object obj = Activator.CreateInstance(type);
            return (MoodAnalyserMain)obj;
        }
       
    }
}











    