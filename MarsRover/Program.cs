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
            Rover myRover2 = new Rover(203);
            Command[] newOrders2 = new Command[] { new Command("MODE_CHANGE", "LOW_POWER") };
            Message newMessage2 = new Message("Update4: From Houston", newOrders2);
            myRover2.ReceiveMessage(newMessage2);
            Console.WriteLine(myRover2.ToString());



            Console.WriteLine("<---------------------------->");
            Command[] newOrders3 = new Command[] { new Command("MODE_CHANGE", "NORMAL") };
            Message newMessage3 = new Message("Update4: From Houston", newOrders3);
            myRover2.ReceiveMessage(newMessage3);
            Console.WriteLine(myRover2.ToString());
        }
    }
}
