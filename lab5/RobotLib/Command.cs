using System.Collections.Generic;
using System.Linq;

namespace RobotLib
{
    public interface ICommand
    {
        void Execute();
    }

    public class TurnOnCommand : ICommand
    {
        private Robot _robot;

        public TurnOnCommand(Robot robot)
        {
            _robot = robot;
        }

        public void Execute()
        {
            _robot.TurnOn();
        }
    };

    public class TurnOffCommand : ICommand
    {
        private Robot _robot;

        public TurnOffCommand(Robot robot)
        {
            _robot = robot;
        }

        public void Execute()
	    {
		    _robot.TurnOff();
	    }
    };

    public class WalkCommand : ICommand
    {
        private Robot _robot;
        private WalkDirection _direction;

        public WalkCommand(Robot robot, WalkDirection direction)
        {
            _robot = robot;
            _direction = direction;
        }

        public void Execute()
	    {
		    _robot.Walk(_direction);
	    }
    };

    public class StopCommand : ICommand
    {
        private Robot _robot;

        public StopCommand(Robot robot)
        {
            _robot = robot;
        }

        public void Execute()
	    {
		    _robot.Stop();
	    }
    };

    public class MacroCommand : ICommand
    {
        private List<List<ICommand>> _commands;

        public void Execute()
	    {
            foreach (var item in _commands.SelectMany(k => k))
            {
                item.Execute();
            }
        }

	    public void AddCommand(List<ICommand> cmd)
        {
            _commands.Add(cmd);
        }
    };

}

