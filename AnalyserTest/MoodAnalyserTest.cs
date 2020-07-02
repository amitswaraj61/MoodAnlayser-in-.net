using NUnit.Framework;
using MoodAnalyser;
using System;
using System.Reflection;

namespace Tests
{
    public class MoodAnalyserTest
    {
        public static String className = "MoodAnalyserMain";
        public static String wrongClassName = "MoodAnalyser";
        public static String sadMood = "I am in sad mood";
        public static String happyMood = "I am in haapy mood";
        MoodAnalyserFactory<MoodAnalyserMain> moodAnalyserFactory = new MoodAnalyserFactory<MoodAnalyserMain>();

        [Test]
        public void GivenSadMesaage_WhenAnalyse_ShouldReturnSad()
        {
            MoodAnalyserMain moodAnalyser = new MoodAnalyserMain(sadMood);
            String mood = moodAnalyser.AnalyseMood();
            Assert.AreEqual("sad", mood);
        }

        [Test]
        public void GivenHappyMesaage_WhenAnalyse_ShouldReturnHappy()
        {
            MoodAnalyserMain moodAnalyser = new MoodAnalyserMain(happyMood);
            String mood = moodAnalyser.AnalyseMood();
            Assert.AreEqual("happy", mood);
        }

        [Test]
        public void GivenMessage_IsNull_ReturnsHappy()
        {
            MoodAnalyserMain moodAnalyser = new MoodAnalyserMain(null);
            String mood = null;
            try
            {
                mood = moodAnalyser.AnalyseMood();
                Assert.AreEqual(sadMood, null);
            }
            catch (MoodAnalyserException exception)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.NULL_EXCEPTION, exception.type);

            }
        }

        [Test]
        public void GivenEmptyMessage_WhenAnalyse_ShouldReturnsEmptyMoodException()
        {
            try
            {
                MoodAnalyserMain mood = new MoodAnalyserMain("");
                mood.AnalyseMood();
                Assert.AreEqual("mood not be empty", mood);
            }
            catch (MoodAnalyserException exception)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.EMPTY_EXCEPTION, exception.type);
            }
        }

        //use-case=4.1
        [Test]
        public void GivenMoodAnalserObject_WhenAnalyse_ShouldReturnsMoodAnalyserObject()
        {
            ConstructorInfo constructorInfo = moodAnalyserFactory.GetDefaultConstructor();
            object objCompare = moodAnalyserFactory.GetInstance(className, constructorInfo);
            Assert.IsInstanceOf(typeof(MoodAnalyserMain), objCompare);

        }

        //use-case=4.2
        [Test]
        public void GivenWrongClassName_WhenAnalyse_ShouldReturnsClassNotFoundException()
        {
            try
            {
                ConstructorInfo constructorInfo = moodAnalyserFactory.GetDefaultConstructor();
                object objCompare = moodAnalyserFactory.GetInstance(wrongClassName, constructorInfo);
                Assert.AreEqual(className, wrongClassName);
            }

            catch (MoodAnalyserException exception)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.NO_SUCH_CLASS, exception.type);
            }

        }

        //use-case=4.3
        [Test]
        public void GivenWrongConstructorMethod_WhenAnalyse_ShouldReturnsMethodNotFoundException()
        {
            try
            {
                ConstructorInfo constructorInfo = moodAnalyserFactory.GetDefaultConstructor();
                ConstructorInfo wrong = null;
                object objCompare = moodAnalyserFactory.GetInstance(className, wrong);
                Assert.AreEqual(constructorInfo, wrong);

            }

            catch (MoodAnalyserException exception)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.NO_SUCH_METHOD,exception.type);
            }
        }

        //use-case=5
        [Test]
        public void CompareObjects_UsingParameterizedConstructor_ReturnsObject()
        {
            ConstructorInfo constructorInfo = moodAnalyserFactory.GetDefaultConstructor(1);
            object objCompare = moodAnalyserFactory.GetParameterizedInsatance(className, constructorInfo, sadMood);
            MoodAnalyserMain mood = new MoodAnalyserMain(sadMood);
            Assert.AreEqual(mood, objCompare);
        }

        [Test] //usecase=5.2
        public void GivenWrongClassName_WhenAnalyse_ShouldReturnsClassNotFoundExceptionn_ParameterConstructor()
        {
            try
            {
                ConstructorInfo constructorInfo = moodAnalyserFactory.GetDefaultConstructor(1);
                object objCompare = moodAnalyserFactory.GetParameterizedInsatance(wrongClassName, constructorInfo, sadMood);
                Assert.AreEqual(className, wrongClassName);

            }
            catch (MoodAnalyserException exception)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.NO_SUCH_CLASS, exception.type);
            }
        }

        //use-case=5.3
        [Test]
        public void GivenWrongConstructorMethod_WhenAnalyse_ShouldReturnsMethodNotFoundExceptio_ParameterConstructor()
        {
            try
            {
                ConstructorInfo constructorInfo = moodAnalyserFactory.GetDefaultConstructor(1);
                ConstructorInfo wrong = null; //Wrong Constructor 
                object objCompare = moodAnalyserFactory.GetParameterizedInsatance(className, wrong, sadMood);
                Assert.AreEqual(constructorInfo, wrong);
            }

            catch (MoodAnalyserException exception)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.NO_SUCH_METHOD, exception.type);
            }
        }
    }
}


  

   
  