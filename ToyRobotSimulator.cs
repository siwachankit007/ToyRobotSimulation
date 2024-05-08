using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSimulation
{
    public class ToyRobotSimulator
    {
        private Robot robot;

        public ToyRobotSimulator()
        {
            robot = new Robot();
        }

        public void ExecuteUserCommand(string command)
        {
            string[] commandParts = command.Trim().Split(' ');
            if (commandParts.Length == 0)
            {
                Console.WriteLine("Please give a valid command.");
                return;
            }

            string action = commandParts[0].ToUpper(); // to get the action requested by the ueser
            switch (action)
            {
                case "PLACE":
                    if (commandParts.Length == 2) // to check if it is a valid action
                    {
                        string[] placeaction = commandParts[1].Split(',');
                        //checking the x and y cooridnates
                        if (placeaction.Length == 3 && int.TryParse(placeaction[0], out int x) && int.TryParse(placeaction[1], out int y))
                        {
                            Enum.TryParse(placeaction[2], out Direction direction);
                            robot.PlaceRobot(x, y, direction);
                        }
                    }
                    break;
                case "MOVE":
                    robot.Move();
                    break;
                case "LEFT":
                    robot.TurnLeft();
                    break;
                case "RIGHT":
                    robot.TurnRight();
                    break;
                case "REPORT":
                    Console.WriteLine(robot.Report());
                    break;
                default:
                    Console.WriteLine("Please give a valid command.");
                    break;
            }
        }
    }

}
