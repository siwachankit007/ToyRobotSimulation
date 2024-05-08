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
            string[] parts = command.Trim().Split(' ');
            if (parts.Length == 0)
            {
                Console.WriteLine("Please give a valid command.");
                return;
            }

            string action = parts[0].ToUpper();
            switch (action)
            {
                case "PLACE":
                    if (parts.Length == 2)
                    {
                        string[] args = parts[1].Split(',');
                        if (args.Length == 3 && int.TryParse(args[0], out int x) && int.TryParse(args[1], out int y))
                        {
                            Enum.TryParse(args[2], out Direction direction);
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
