using NUnit.Framework;
using Mood_Analyser;
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
            MoodAnalyser moodAnalyser = new MoodAnalyser("I am in sad mood");
            String mood = moodAnalyser.AnalyseMood();
            Assert.AreEqual("sad", mood);
        }
    }
}