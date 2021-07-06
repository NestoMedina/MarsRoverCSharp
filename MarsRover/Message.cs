using System;
namespace MarsRover
{
    public class Message
    {
        public string Name { get; set; }
        public Command[] Commands { get; set; }

        public Message(string messageName, Command[] commands)
        {
            Name = messageName;
            if (String.IsNullOrEmpty(messageName))
            {
                throw new ArgumentNullException(messageName, "Message is required");
            }
            Commands = commands;
        }

    }
}
