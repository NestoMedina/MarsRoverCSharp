using System;
using System.Linq;
namespace MarsRover
{
    public class Rover
    {
        public string Mode { get; set; }
        public int Position { get; set; }
        public int GeneratorWatts { get; set; }

        public Rover(int position)
        {
            Position = position;
            Mode = "NORMAL";
            GeneratorWatts = 110; //110 is default value
        }


       public void ReceiveMessage(Message messages)
        {
            foreach(Command item in messages.Commands)
            {
                /*if (item.CommandType != "MOVE" || item.CommandType != "MODE_CHANGE")
                {
                    Console.WriteLine("Unknown Command");
                    break;
                } */
                if (item.CommandType == "MOVE")
                {
                    if (this.Mode == "LOW_POWER")
                    {
                        const string i = "WARNING ROVER IN LOW_POWER. MOVEMENT NOT POSSIBLE";
                        throw new InvalidOperationException(i);
                    }
                    Position = item.NewPostion;
                    GeneratorWatts = 110;
                }
                else if (item.CommandType == "MODE_CHANGE")
                {
                    Mode = item.NewMode;
                    if (item.NewMode == "LOW_POWER" || this.Mode == "LOW_POWER")
                    {
                       const string i = "WARNING ROVER IN LOW_POWER. MOVEMENT NOT POSSIBLE";
                        throw new InvalidOperationException(i);
                    }
                }
            }

        } 

        public override string ToString()
        {
            return "Position: " + Position + " - Mode: " + Mode + " - GeneratorWatts: " + GeneratorWatts; 
        }




    }
}
