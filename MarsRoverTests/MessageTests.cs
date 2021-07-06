using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRover;

namespace MarsRoverTests
{
    [TestClass]
    public class MessageTests
    {
        Command[] commands = { new Command("foo", 0), new Command("bar", 20) };

        [TestMethod]
        public void ArgumentNullExceptionThrownIfNameNotPassedToConstructor()
        {
            try
            {
                new Message("", commands);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Message is required", ex.Message);
            }
        }

        [TestMethod]
        public void ConstructorSetsName()
        {
            Message newInstance = new Message("Test Message", commands);
            Assert.AreEqual(newInstance.Name, "Test Message");
        }

        [TestMethod]
        public void ConstructorSetsCommandsField()
        {
            Message newInstance = new Message("Test Message", commands);
            Assert.AreEqual(newInstance.Commands, commands);
        }


    }
}
