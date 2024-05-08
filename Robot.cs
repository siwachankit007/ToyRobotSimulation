using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSimulation
{
    public class Robot
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Direction F { get; private set; }

        public Robot()
        {
            // Initialize the robot's position and direction
            X = 0;
            Y = 0;
            F = Direction.NORTH;
        }

        // Method to place the robot on the table
        public void PlaceRobot(int x, int y, Direction f)
        {
            // Ensure the position is within the table bounds
            if (IsRobotValidPosition(x, y))
            {
                X = x;
                Y = y;
                F = f;
            }
        }

        // Method to move the robot one unit forward
        // Method to move the robot one unit forward
        public void Move()
        {
            // Calculate the new position based on the current direction
            int newX = X;
            int newY = Y;
            switch (F)
            {
                case Direction.NORTH:
                    newY++;
                    break;
                case Direction.SOUTH:
                    newY--;
                    break;
                case Direction.EAST:
                    newX++;
                    break;
                case Direction.WEST:
                    newX--;
                    break;
            }

            // Check if the new position is valid before moving
            if (IsRobotValidPosition(newX, newY))
            {
                X = newX;
                Y = newY;
            }
        }


        // To rotate the robot 90 degrees to the left
        public void TurnLeft()
        {
            F = (Direction)(((int)F - 1 + 4) % 4); // Ensure the result is within [0, 3]
        }

        // To rotate the robot 90 degrees to the right
        public void TurnRight()
        {
            F = (Direction)(((int)F + 1) % 4);
        }

        // To report the current position and direction of the robot
        public string Report()
        {
            return $"{X},{Y},{F}";
        }

        // To check if a position of the robot is valid or not and is within the table bounds
        private bool IsRobotValidPosition(int x, int y)
        {
            return x >= 0 && x < 5 && y >= 0 && y < 5;
        }
    }

    public enum Direction
    {
        NORTH,
        EAST,
        SOUTH,
        WEST
    }

}
