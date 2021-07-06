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
                if (item.CommandType != "MOVE" && item.CommandType != "MODE_CHANGE")
                {
                    Console.WriteLine("WARNING UNKNOWN COMMAND");
                } 
                if (item.CommandType == "MOVE")
                {
                    if (this.Mode == "LOW_POWER")
                    {
                       Console.WriteLine("WARNING ROVER IN LOW_POWER. MOVEMENT NOT POSSIBLE");
                       break;
                    }
                    Position = item.NewPostion;
                    GeneratorWatts = 110;
                }
                else if (item.CommandType == "MODE_CHANGE")
                {
                    this.Mode = item.NewMode;
                    if (item.NewMode == "LOW_POWER")
                    {
                        Console.WriteLine("WARNING ROVER IN LOW_POWER.MOVEMENT NOT POSSIBLE");
                    }
                    else if (item.NewMode == "NORMAL")
                    {
                        this.Mode = item.NewMode;
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
