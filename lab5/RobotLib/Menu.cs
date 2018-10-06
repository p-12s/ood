using System;
using System.Collections.Generic;

namespace RobotLib
{
    public class Menu
    {
        public struct Item
        {
            public Item(string description, List<ICommand> command)
            {
                _description = description;
                _command = command;
            }

            public string _description;
            public List<ICommand> _command;
        };

        private Dictionary<string, Item> _items = new Dictionary<string, Item>();
        private bool _exit = false;

        private bool ExecuteCommand(string command)
        {
            _exit = false;

            if (_items.ContainsKey(command))
            {
                foreach (var item in _items[command]._command)
                {
                    item.Execute();
                }
            }
            else
            {
                Console.WriteLine("Unknown command");
            }

            return !_exit;
        }
                

        public void AddItem(string shortcut, string description, List<ICommand> command)
	    {
		    _items.Add(shortcut, new Item(description, command));
	    }

        public void Run()
        {
            ShowInstructions();

            string command;
            while (true)
            {
                Console.Write(">");
                command = Console.ReadLine();
                if (command.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                ExecuteCommand(command);
            }
        }

        public void ShowInstructions()
	    {           
            Console.WriteLine("Commands list:");
		    foreach(var item in _items)
		    {
                Console.WriteLine(item.Key + ": " + item.Value._description);
		    }
	    }

	    public void Exit()
        {
            _exit = true;
        }

    }
}
