//-----------------------------------------------------------------------
// <copyright file="MoodAnalyserTest.cs" company="BridgeLabz">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------
using NUnit.Framework;
using MoodAnalyser;
using System;
using System.Reflection;

namespace Tests
{
    //// <summary>
    //// Test case for MoodAnalyser
    //// </summary>
    public class MoodAnalyserTest
    {
        //// <summary>
        //// Declare global MoodAnalyserMain class name 
        //// </summary>
        private  string className = "MoodAnalyserMain";
        //// <summary>
        //// Declare global MoodAnalyserMain Wrong class name 
        //// </summary>
        private string wrongClassName = "MoodAnalyser";
        //// <summary>
        //// Declare global I am in sad mood
        //// </summary>
        private string sadMood = "I am in sad mood";
        //// <summary>
        //// Declare global MoodAnalyserMain I m in happy mood
        //// </summary>
        private string happyMood = "I am in haapy mood";
        //// <summary>
        //// Declare global MoodAnalyser method name
        //// </summary>
        private string methodName = "AnalyseMood";
        //// <summary>
        //// Declare global MoodAnalyserMain Field name 
        //// </summary>
        private string fieldName = "message";
        //// <summary>
        //// Declare global happy mood
        //// </summary>
        private string Happy = "happy";
        //// <summary>
        //// Here create instance of moodanalyserreflector class
        //// </summary>
        MoodAnalyserReflector<MoodAnalyserMain> moodAnalyserReflector = new MoodAnalyserReflector<MoodAnalyserMain>();
        //// <summary>
        //// Test case for when given sad mood should return sad
        //// </summary>
        [Test]
        public void GivenSadMesaage_WhenAnalyse_ShouldReturnSad()
        {
            MoodAnalyserMain moodAnalyser = new MoodAnalyserMain(sadMood);
            string mood = moodAnalyser.AnalyseMood();
            Assert.AreEqual("sad", mood);
        }
        //// <summary>
        //// Test case for when given happy mood should return happy
        //// </summary>
        [Test]
        public void GivenHappyMesaage_WhenAnalyse_ShouldReturnHappy()
        {
            MoodAnalyserMain moodAnalyser = new MoodAnalyserMain(happyMood);
            string mood = moodAnalyser.AnalyseMood();
            Assert.AreEqual(Happy, mood);
        }
        //// <summary>
        //// Test case for when given null mood should return Null_custom exception
        //// </summary>
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
        //// <summary>
        //// Test case for when give empty mood should return mood cant be empty exception
        //// </summary>
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
        //// <summary>
        //// Test case = 4.1 given call moodanalyserreflector and moodanalysermain both should return equal object
        //// </summary>
        [Test]
        public void GivenMoodAnalserObject_WhenAnalyse_ShouldReturnsMoodAnalyserObject()
        {
            ConstructorInfo constructorInfo = moodAnalyserReflector.GetDefaultConstructor();
            object objCompare = this.moodAnalyserReflector.GetInstance(className, constructorInfo);
            Assert.IsInstanceOf(typeof(MoodAnalyserMain), objCompare);
        }
        //// <summary>
        //// Test case = 4.2  Given wrong class name should return class not found custom exception
        //// </summary>
        [Test]
        public void GivenWrongClassName_WhenAnalyse_ShouldReturnsClassNotFoundException()
        {
            try
            {
                ConstructorInfo constructorInfo = moodAnalyserReflector.GetDefaultConstructor();
                object objCompare = this.moodAnalyserReflector.GetInstance(wrongClassName, constructorInfo);
                Assert.AreEqual(className, objCompare);
            }
            catch (MoodAnalyserException exception)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.NO_SUCH_CLASS, exception.type);
            }
        }
        //// <summary>
        //// Test case = 4.3 Given wrong method name should return method not found custom exception
        //// </summary>
        [Test]
        public void GivenWrongConstructorMethod_WhenAnalyse_ShouldReturnsMethodNotFoundException()
        {
            try
            {
                ConstructorInfo constructorInfo = moodAnalyserReflector.GetDefaultConstructor();
                ConstructorInfo wrong = null;
                object objCompare = this.moodAnalyserReflector.GetInstance(className, wrong);
                Assert.AreEqual(constructorInfo, objCompare);
            }
          catch (MoodAnalyserException exception)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.NO_SUCH_METHOD, exception.type);
            }
        }
        //// <summary>
        //// Test case = 5.1  comapare object between paramertized constructor and moodAnalyserMain
        //// </summary>
        [Test]
        public void CompareObjects_UsingParameterizedConstructor_ReturnsObject()
        {
            ConstructorInfo constructorInfo = moodAnalyserReflector.GetDefaultConstructor(1);
            object objCompare = this.moodAnalyserReflector.GetParameterizedInsatance(className, constructorInfo, sadMood);
            MoodAnalyserMain mood = new MoodAnalyserMain(sadMood);
            Assert.AreEqual(mood, objCompare);
        }
        //// <summary>
        //// Test case = 5.2   Given wrong class name should return class not found custom exception in paramterized constructor
        //// </summary>
        [Test] 
        public void GivenWrongClassName_WhenAnalyse_ShouldReturnsClassNotFoundExceptionn_ParameterConstructor()
        {
            try
            {
                ConstructorInfo constructorInfo = moodAnalyserReflector.GetDefaultConstructor(1);
                object objCompare = this.moodAnalyserReflector.GetParameterizedInsatance(wrongClassName, constructorInfo, sadMood);
                Assert.AreEqual(className, objCompare);
            }
            catch (MoodAnalyserException exception)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.NO_SUCH_CLASS, exception.type);
            }
        }
        //// <summary>
        //// Test case = 5.3   Given wrong method name should return method not found custom exception in paramterized constructor
        //// </summary>
        [Test]
        public void GivenWrongConstructorMethod_WhenAnalyse_ShouldReturnsMethodNotFoundException_ParameterConstructor()
        {
            try
            {
                ConstructorInfo constructorInfo = moodAnalyserReflector.GetDefaultConstructor(1);
                ConstructorInfo wrong = null; //Wrong Constructor 
                object objCompare = this.moodAnalyserReflector.GetParameterizedInsatance(className, wrong, sadMood);
                Assert.AreEqual(constructorInfo, objCompare);
            }
            catch (MoodAnalyserException exception)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.NO_SUCH_METHOD, exception.type);
            }
        }
        //// <summary>
        //// Test case = 6.1   GiveN MoodAnalyserMethod should return happy
       //// </summary>
        [Test]
        public void GivenMoodAnalserMethod_WhenAnalyse_ShouldReturnsHappy()
        {
            try
            {
                string actual = this.moodAnalyserReflector.InvokeMoodAnalyser(happyMood, methodName, fieldName);
                string expected = Happy;
                Assert.AreEqual(actual, expected);
            }
            catch (NullReferenceException exception)
            {
                Console.WriteLine(exception.StackTrace);
            }
        }
        //// <summary>
        //// Test case = 6.2   Given wrong method name in invoke method should return method not found custom exception 
        //// </summary>
        [Test]
        public void GivenWrongMethodName_WhenAnalyse_shouldReturnsNoSuchMethodException()
        {
            try
            {
                Object obj = this.moodAnalyserReflector.InvokeMoodAnalyser(happyMood, "wrong", fieldName);
                Assert.AreEqual(methodName, obj);
            }
            catch (MoodAnalyserException exception)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.NO_SUCH_METHOD, exception.type);
            }
        }
        //// <summary>
        //// Test case = 7.1   Given Filed value and mood to invoke method should return happy 
        //// </summary>
        [Test]
        public void GivenFieldValueHappy_WhenAnalyse_ShouldReturnsHappyMood()
        {
            string actualValue = this.moodAnalyserReflector.InvokeMoodAnalyser(happyMood, methodName, fieldName);
            Assert.AreEqual(Happy, actualValue);
        }
        //// <summary>
        //// Test case = 7.2   Given wrong Filed value and mood to invoke method should return no such filed custom exception
        //// </summary>
        [Test]
        public void GivenWrongField_WhenAnalyse_ShouldReturnNoSuchFieldException()
        {
            try
            {
                string actual = this.moodAnalyserReflector.InvokeMoodAnalyser(methodName, happyMood, "wrongfield");
                Assert.AreEqual(Happy, actual);
            }
            catch (MoodAnalyserException exception)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.NO_SUCH_FIELD, exception.type);
            }
        }
        //// <summary>
        //// Test case = 7.2   Given null Filed value and mood to invoke method should return No such filed custom exception
        //// </summary>
        [Test]
        public void GivenNullMessage_WhenAnalyse_ShouldReturnsNullException()
        {
            try
            {
                string actualValue = this.moodAnalyserReflector.InvokeMoodAnalyser(happyMood, methodName, null);
                Assert.AreEqual(Happy, actualValue);
            }
            catch (MoodAnalyserException exception)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.NO_SUCH_FIELD, exception.type);

            }
        }
    }
}
