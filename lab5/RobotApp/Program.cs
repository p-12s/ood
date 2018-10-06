using System;
using System.Collections.Generic;
using RobotLib;

namespace RobotApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Robot robot = new Robot();
            Menu menu = new Menu();

            menu.AddItem("on", "Turns the Robot on", new List<ICommand>
                {
                    new TurnOnCommand(robot)
                }
            );
            menu.AddItem("walk", "Robot go out", new List<ICommand>
                {
                    new WalkCommand(robot, WalkDirection.East),
                    new StopCommand(robot)
                }
            );
            menu.Run();

            Console.WriteLine("Hello World!");
        }
    }
}
