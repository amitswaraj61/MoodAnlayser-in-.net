using NUnit.Framework;
using MoodAnalyser;
using System;



namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void givenSadMesaage_WhenAnalyse_ShouldReturnSad()
        {
            MoodAnalyserMain moodAnalyser = new MoodAnalyserMain("I am in sad mood");
            String mood = moodAnalyser.AnalyseMood();
            Assert.AreEqual("sad", mood);
        }
        [Test]
        public void givenHappyMesaage_WhenAnalyse_ShouldReturnHappy()
        {
            MoodAnalyserMain moodAnalyser = new MoodAnalyserMain("I am in haapy mood");
            String mood = moodAnalyser.AnalyseMood();
            Assert.AreEqual("happy", mood);
        }
        [Test]
        public void givenMessage_IsNull_ReturnsHappy()
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
        public void givenEmptyMessage_WhenAnalyse_shouldReturnsEmptyMoodException()
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
        public void givenMoodAnalyser_WhenProper_ShouldReturnObject()
        {
            MoodAnalyserMain moodAnalyzer = MoodAnalyserFactory.CreateMoodAnalyser();
            Assert.AreEqual(new MoodAnalyserMain(), moodAnalyzer);
        }
        [Test]
        public void givenWrongClassName_WhenAnalyse_shouldReturnsClassNotFoundException()
        {
            try
            {
                MoodAnalyserFactory.CreateMoodAnalyser("MoodAnalyser", "AnalyseMood");
            }
            catch (MoodAnalyserException exception)
            {
                Assert.AreEqual("Class not found", exception.message);

            }
        }
    }
}