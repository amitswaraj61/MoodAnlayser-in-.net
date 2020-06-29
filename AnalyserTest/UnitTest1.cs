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
        [Test]
        public void givenHappyMesaage_WhenAnalyse_ShouldReturnHappy()
        {
            MoodAnalyser moodAnalyser = new MoodAnalyser("I am in haapy mood");
            String mood = moodAnalyser.AnalyseMood();
            Assert.AreEqual("happy", mood);
        }
        [Test]
        public void givenMessage_IsNull_ReturnsHappy()
        {
            MoodAnalyser moodAnalyser = new MoodAnalyser(null);
            String mood = moodAnalyser.AnalyseMood();
            Assert.AreEqual("happy", mood);
        }
    }
}