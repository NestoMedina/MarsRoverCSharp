using System;
using System.Collections.Generic;
using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverTests
{
    [TestClass]
    public class RoverTests
    {
        [TestMethod]
        public void ConstructorSetsDefaultPosition()
        {
            Rover test = new Rover(200);
            Assert.AreEqual(test.Position, 200);
        }

        [TestMethod]
        public void ConstructorSetsDefaultMode()
        {
            Rover test = new Rover("NORMAL");
            Assert.AreEqual(test.Mode, "NORMAL");
        }

        [TestMethod]
        public void ConstructorSetsDefaultGeneratorWatts() //test10
        {
            Rover test = new Rover("NORMAL", 110);
            Assert.AreEqual(test.GeneratorWatts, 110);
        }

        [TestMethod]
        public void RespondsCorrectlyToModeChangeCommand()
        {
            Command[] newOrders = new Command[] { new Command("MODE_CHANGE", "NORMAL") };
            Message newMessage = new Message("Update1: From Houston", newOrders);
            Rover test = new Rover();
            test.ReceiveMessage(newMessage);
            Assert.AreEqual(test.Mode, "NORMAL");
        }

        [TestMethod]
        public void DoesNotMoveInLowPower()
        {
            Command[] newOrders = new Command[] { new Command("MODE_CHANGE", "LOW_POWER"), new Command("MOVE", 300)};
            Message newMessage = new Message("Update2: From Houston", newOrders);
            Rover test = new Rover();
            try
            {
                test.ReceiveMessage(newMessage);
            }
            catch (InvalidOperationException j)
            {
                Assert.AreEqual("WARNING ROVER IN LOW_POWER. MOVEMENT NOT POSSIBLE", j.Message);
            }
        }

        [TestMethod]
        public void PositionChangesFromMoveCommand()
        {
            Command[] newOrders = new Command[] { new Command("MOVE", 750), new Command("MOVE", 300) };
            Message newMessage = new Message("Update3: From Houston", newOrders);
            Rover test = new Rover();
            test.ReceiveMessage(newMessage);
            Assert.AreEqual(test.Position, 300);
        }

        [TestMethod] // rework this portion
        public void RoverReturnsAMessageForAnUnkownCommand()
        {
            Command[] newOrders = new Command[] { new Command("ReverseBackItUpDropDownLow", 360)};
            Message newMessage = new Message("Update4: From Houston", newOrders);
            Rover test = new Rover();
            try
            {
                test.ReceiveMessage(newMessage);
            }
            catch (InvalidOperationException j)
            {
                Assert.AreEqual("UNKOWN COMMAND", j.Message);
            }
        }




    }
}
