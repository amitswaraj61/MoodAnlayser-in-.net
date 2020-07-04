//-----------------------------------------------------------------------
// <copyright file="MoodAnalyzerFactory.cs" company="BridgeLabz">
// Copyright (c) 2012 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using MoodAnalyser;

namespace MoodAnalyser
{
    //// <summary>
    //// MoodAnlayserReflectorclass
    //// </summary>
    public class MoodAnalyserReflector<GenType>
    {
        //// <summary>
        //// Declare type to access MoodAnalyserMain class
        //// </summary>
        Type type = typeof(GenType);
        //// <summary>
        //// Method create for defualt and parameterized Constructor
        //// </summary>
        public ConstructorInfo GetDefaultConstructor(int numParameters = 0)

        {
            try
            {
                 ConstructorInfo[] constructor = type.GetConstructors();
                //// sending defalut constructor => parameters are 0
                foreach (var info in constructor)
                {
                    if (info.GetParameters().Length == numParameters)
                        return info;
                }
              return constructor[0];
            }
            catch (Exception)
            {
                throw new MoodAnalyserException("please enter valid class", MoodAnalyserException.ExceptionType.NO_SUCH_CLASS);
            }
        }
        //// <summary>
        //// Method create to get instance of default constructor
        //// </summary>
        public object GetInstance(string className, ConstructorInfo constructor)
        { 
            Type type = typeof(GenType);
            if (className != type.Name)
            {
                throw new MoodAnalyserException("No such class", MoodAnalyserException.ExceptionType.NO_SUCH_CLASS);
            }
            if (constructor != type.GetConstructors()[0])
            {
                throw new MoodAnalyserException("No such Method Found", MoodAnalyserException.ExceptionType.NO_SUCH_METHOD);
            }
            GenType ObjReturn = Activator.CreateInstance<GenType>();
            return ObjReturn;
        }
        //// <summary>
        //// Method create to get instance of parameterized constructor
        //// </summary>
        public object GetParameterizedInsatance(string className, ConstructorInfo constructor, string parameterValue)
        {
            Type type = typeof(GenType);
            if (className != type.Name)
            {
                throw new MoodAnalyserException("No_such_class", MoodAnalyserException.ExceptionType.NO_SUCH_CLASS);
            }
            if (constructor != type.GetConstructors()[1])
            {
                throw new MoodAnalyserException("No_such_Method", MoodAnalyserException.ExceptionType.NO_SUCH_METHOD);
            }
           object ObjReturn = Activator.CreateInstance(type, parameterValue);
            return ObjReturn;
        }
        //// <summary>
        //// Create InvokeMoodAnalyser having parameter mood , methodName and FieldName
        //// </summary
        public string InvokeMoodAnalyser(string mood,string methodName,string fieldName)
        {
           try
            {
                if (fieldName == null)
                    throw new MoodAnalyserException("No such field", MoodAnalyserException.ExceptionType.NO_SUCH_FIELD);
                FieldInfo fields = type.GetField(fieldName);
                string value = fields.ToString();
                if (value.Contains("String message"))
                {
                    try
                    {
                        MethodInfo info = this.type.GetMethod(methodName, new Type[] { typeof(string) });
                        object instance = Activator.CreateInstance(this.type);
                        string returnValue= (string)info.Invoke(instance, new string[] { mood });
                        return returnValue;
                    }
                    catch (NullReferenceException)
                    {
                        throw new MoodAnalyserException("No such method", MoodAnalyserException.ExceptionType.NO_SUCH_METHOD);
                    }
                }
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserException("No such field", MoodAnalyserException.ExceptionType.NO_SUCH_FIELD);
            }

            return null;
        }
    }
}
  