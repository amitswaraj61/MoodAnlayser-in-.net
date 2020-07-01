using NUnit.Framework;
using MoodAnalyser;
using System;
using System.Reflection;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GivenSadMesaage_WhenAnalyse_ShouldReturnSad()
        {
            MoodAnalyserMain moodAnalyser = new MoodAnalyserMain("I am in sad mood");
            String mood = moodAnalyser.AnalyseMood();
            Assert.AreEqual("sad", mood);
        }
        [Test]
        public void GivenHappyMesaage_WhenAnalyse_ShouldReturnHappy()
        {
            MoodAnalyserMain moodAnalyser = new MoodAnalyserMain("I am in haapy mood");
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
            }
            catch (MoodAnalyserException exception)
            {
                Assert.AreEqual("mood cant be null", exception.message);

            }
        }
        [Test]
        public void GivenEmptyMessage_WhenAnalyse_ShouldReturnsEmptyMoodException()
        {
            try
            {
                MoodAnalyserMain mood = new MoodAnalyserMain("");
                mood.AnalyseMood();
            }
            catch (MoodAnalyserException exception)
            {
                Assert.AreEqual("mood cant be empty", exception.message);
            }
        }
        [Test]
        public void GivenMoodAnalserObject_WhenAnalyse_ShouldReturnsMoodAnalyserObject()
        {
            MoodAnalyserFactory<MoodAnalyserMain> moodAnalyserFactory = new MoodAnalyserFactory<MoodAnalyserMain>();
            ConstructorInfo constructorInfo = moodAnalyserFactory.GetDefaultConstructor();
            object obj_compare = moodAnalyserFactory.GetInstance("MoodAnalyserMain", constructorInfo);
            Assert.IsInstanceOf(typeof(MoodAnalyserMain), obj_compare);

        }
        [Test]
        public void GivenWrongClassName_WhenAnalyse_ShouldReturnsClassNotFoundException()
        {
            try
            {
                MoodAnalyserFactory<MoodAnalyserMain> moodAnalyserFactory = new MoodAnalyserFactory<MoodAnalyserMain>();
                ConstructorInfo constructorInfo = moodAnalyserFactory.GetDefaultConstructor();
                object obj_compare = moodAnalyserFactory.GetInstance("MoodAnalyser", constructorInfo);

            }
            catch (MoodAnalyserException exception)
            {
                Assert.AreEqual("No such class", exception.Message);
            }

        }
        [Test]
        public void GivenWrongConstructorMethod_WhenAnalyse_ShouldReturnsMethodNotFoundException()
        {
            try
            {
                MoodAnalyserFactory<MoodAnalyserMain> moodAnalyserFactory = new MoodAnalyserFactory<MoodAnalyserMain>();
                //  ConstructorInfo constructorInfo = moodAnalyserFactory.GetDefaultConstructor();
                ConstructorInfo wrong = null;
                object obj_compare = moodAnalyserFactory.GetInstance("MoodAnalyserMain", wrong);
            }
            catch (MoodAnalyserException exception)
            {
                Assert.AreEqual("No such Method Found", exception.message);
            }
        }
        [Test]
        public void CompareObjects_UsingParameterizedConstructor_ReturnsObject()
        {
            MoodAnalyserFactory<MoodAnalyserMain> moodAnalyserFactory = new MoodAnalyserFactory<MoodAnalyserMain>();
            ConstructorInfo constructorInfo = moodAnalyserFactory.GetDefaultConstructor(1);
            object obj_compare = moodAnalyserFactory.GetParameterizedInsatance("MoodAnalyserMain", constructorInfo, "I am in sad mood");
            MoodAnalyserMain mood = new MoodAnalyserMain("I am in sad mood");
            Assert.AreEqual(mood, obj_compare);
        }
        [Test]
        public void GivenWrongClassName_WhenAnalyse_ShouldReturnsClassNotFoundExceptionn_ParameterConstructor()
        {
            try
            {
                MoodAnalyserFactory<MoodAnalyserMain> moodAnalyserFactory = new MoodAnalyserFactory<MoodAnalyserMain>();
                ConstructorInfo constructorInfo = moodAnalyserFactory.GetDefaultConstructor(1);
                object obj_compare = moodAnalyserFactory.GetParameterizedInsatance("MoodAnalyser", constructorInfo, "I am in sad mood");

            }
            catch (MoodAnalyserException exception)
            {
                Assert.AreEqual("No such class", exception.Message);
            }
        }
    }
}

       
   