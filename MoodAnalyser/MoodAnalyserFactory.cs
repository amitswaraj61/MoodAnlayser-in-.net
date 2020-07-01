using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using MoodAnalyser;

namespace MoodAnalyser
{
    public class MoodAnalyserFactory<GenType>
    {

        public ConstructorInfo GetDefaultConstructor()
        {
            try
            {
                Type type = typeof(GenType);
                ConstructorInfo[] constructor = type.GetConstructors();

                // sending defalut constructor => parameters are 0
                foreach (var info in constructor)
                {
                    if (info.GetParameters().Length == 0)
                        return info;
                }

                return constructor[0];
            }
            catch (Exception)
            {
                throw new MoodAnalyserException("please enter valid class", MoodAnalyserException.ExceptionType.NO_SUCH_CLASS);
            }
        }

        public object GetInstance(string class_name, ConstructorInfo constructor)
        {
            try
            {
                // create type using given type
                Type type = typeof(GenType);
                // given class not equals to type name throw exception
                if (class_name != type.Name)
                    throw new MoodAnalyserException("No such class", MoodAnalyserException.ExceptionType.NO_SUCH_CLASS);
                // given constructor name is not equals to constructor of type throw exception
                if (constructor != type.GetConstructors()[0])
                    throw new MoodAnalyserException("No such Method Found", MoodAnalyserException.ExceptionType.NO_SUCH_METHOD);
                //  var Object_return = constructor.Invoke(new object[0]);
                GenType Obj_return = Activator.CreateInstance<GenType>();
                return Obj_return;
            }
            catch(MoodAnalyserException exception)
            {
                return exception.message;
            }

        }
    }
}

        











    