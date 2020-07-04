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
    public class MoodAnalyserReflector<GenType>
    {
        Type type = typeof(GenType);

        public ConstructorInfo GetDefaultConstructor(int numParameters = 0)

        {
            try
            {
                
                ConstructorInfo[] constructor = type.GetConstructors();

                // sending defalut constructor => parameters are 0
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

        public object GetInstance(string className, ConstructorInfo constructor)
        {
            // create type using given type
            Type type = typeof(GenType);
            // given class not equals to type name throw exception
            if (className != type.Name)
                throw new MoodAnalyserException("No such class", MoodAnalyserException.ExceptionType.NO_SUCH_CLASS);
            // given constructor name is not equals to constructor of type throw exception
            if (constructor != type.GetConstructors()[0])
                throw new MoodAnalyserException("No such Method Found", MoodAnalyserException.ExceptionType.NO_SUCH_METHOD);
            //  var Object_return = constructor.Invoke(new object[0]);
            GenType ObjReturn = Activator.CreateInstance<GenType>();
            return ObjReturn;
        }


        public object GetParameterizedInsatance(string className, ConstructorInfo constructor, string parameterValue)
        {
            // create type using given type
            Type type = typeof(GenType);
            // given class not equals to type name throw exception
            if (className != type.Name)
                throw new MoodAnalyserException("No_such_class", MoodAnalyserException.ExceptionType.NO_SUCH_CLASS);
            // given constructor name is not equals to constructor of type throw exception
            if (constructor != type.GetConstructors()[1])
                throw new MoodAnalyserException("No_such_Method", MoodAnalyserException.ExceptionType.NO_SUCH_METHOD);
            Object ObjReturn = Activator.CreateInstance(type, parameterValue);
            return ObjReturn;
        }

        public string InvokeMoodAnalyser(String mood, String method)
        {
            Type moodAnalyserType = typeof(GenType);
            MethodInfo methodInfo = moodAnalyserType.GetMethod(mood, new Type[] { typeof(string) });
            //  string stringArray = "I am in happy mood" ;
            object objectInstance = Activator.CreateInstance(moodAnalyserType, mood);
            string methods = (String)methodInfo.Invoke(objectInstance, null);
            return methods;
        }



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

    