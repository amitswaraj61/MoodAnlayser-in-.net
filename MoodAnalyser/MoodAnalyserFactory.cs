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
        public static void CreateMoodAnalyser(String classname, String method)
        {
            bool checkValidClass = IsValidClassName(classname);
            bool checkValidMethod = IsValidMethodName(method);
            if (!checkValidClass)
            {
                throw new MoodAnalyserException("Class not found", MoodAnalyserException.ExceptionType.NO_SUCH_CLASS);
            }
            else if (checkValidMethod)
            {
                throw new MoodAnalyserException("Method not found", MoodAnalyserException.ExceptionType.NO_SUCH_METHOD);
            }
        }
        public static bool IsValidClassName(String classname)
        {
            if (classname.Equals("MoodAnalyserMain"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsValidMethodName(String method)
        {
            if (method.Equals(("AnalyseMood")))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}











    