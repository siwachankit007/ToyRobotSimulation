using System;
using System.IO;
using ToyRobotSimulation;

class Program
{
    static void Main(string[] args)
    {
        ToyRobotSimulator simulator = new ToyRobotSimulator();

        Console.WriteLine("Toy Robot Simulator Begins!");
        Console.WriteLine("Please enter commands (PLACE X(position),Y(position),F(facing) | MOVE | LEFT | RIGHT | REPORT) or type 'EXIT' to quit.");


        // Read commands from file
        Console.WriteLine("Please enter the file path containing commands OR press enter to continue with manual commands");
        string filePath = Console.ReadLine();
        // Check if the file exists
        if(!string.IsNullOrEmpty(filePath) )
        {
            if (System.IO.File.Exists(filePath))
            {
                string[] commands = System.IO.File.ReadAllLines(filePath);
                foreach (string command in commands)
                {
                    simulator.ExecuteUserCommand(command);
                }
            }
            else
                Console.WriteLine("File not found" + filePath);

        }
        else
        {
            Console.WriteLine("Please continue with manual commands");
            string? command;
            do
            {
                Console.Write("--> ");
                command = Console.ReadLine()?.Trim().ToUpper();
                if (command != "EXIT")
                {
                    simulator.ExecuteUserCommand(command);
                }
            } while (command != "EXIT");
        }


        // Read commands from standard input
       
        
    }
}
