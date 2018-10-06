using System;
using System.Collections.Generic;

namespace RobotLib
{
    public enum WalkDirection
    {
        None,
        North,
	    South,
	    West,
	    East,
    };

    public class Robot
    {
        private bool _turnedOn = false;
        private WalkDirection _direction = WalkDirection.None;

        public void TurnOn()
        {
            if (!_turnedOn)
            {
                _turnedOn = true;
                Console.WriteLine("It am waiting for your commands");
            }
        }

        public void TurnOff()
        {
            if (_turnedOn)
            {
                _turnedOn = false;
                _direction = WalkDirection.None;
                Console.WriteLine("It is a pleasure to serve you");
            }
        }

        public void Walk(WalkDirection direction)
        {
            if (_turnedOn)
            {
                _direction = direction;
                var directionToString = new Dictionary<WalkDirection, string>
            {
                { WalkDirection.East, "east" },
                { WalkDirection.South, "south" },
                { WalkDirection.West, "west" },
                { WalkDirection.North, "north" },
                { WalkDirection.None, "none" },
            };
                Console.WriteLine("Walking " + directionToString[direction]);
            }
            else
            {
                Console.WriteLine("The robot should be turned on first");
            }
        }

        public void Stop()
        {
            if (_turnedOn)
            {
                if (_direction != WalkDirection.None)
                {
                    _direction = WalkDirection.None;
                    Console.WriteLine("Stopped");
                }
                else
                {
                    Console.WriteLine("I am staying still");
                }
            }
            else
            {
                Console.WriteLine("The robot should be turned on first");
            }
        }
    };

}
