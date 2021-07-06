using System;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            Rover myRover = new Rover(20);
            Console.WriteLine(myRover.ToString());

            Console.WriteLine("<---------------------------->");
            Command[] newOrders = new Command[] { new Command("MOVE", 430) };
            Message newMessage = new Message("Update4: From Houston", newOrders);
            myRover.ReceiveMessage(newMessage);
            Console.WriteLine(myRover.ToString());
            Console.WriteLine("<---------------------------->");

            Rover myRover2 = new Rover(20);
            Command[] newOrders5 = new Command[] { new Command("MOVE", 230), new Command("MODE_CHANGE", "LOW_POWER") };
            Message newMessage5 = new Message("Update 5: From Houston", newOrders5);
            myRover2.ReceiveMessage(newMessage5);
            Console.WriteLine(myRover2.ToString());


        }
    }
}
