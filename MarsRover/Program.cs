using System;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Rover myRover = new Rover(20);
            Console.WriteLine(myRover.ToString());

            Command[] newOrders = new Command[] { new Command("MOVE", 430) };
            Message newMessage = new Message("Update4: From Houston", newOrders);
            myRover.ReceiveMessage(newMessage);
            Console.WriteLine(myRover.ToString());


        }
    }
}
