using System;
using System.Collections.Generic;

namespace DocumentEditorLib
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
            // до первого пробела

            if (_items.ContainsKey(command))//InsertParagraph (пока без строки и позиции)
            {
                if (command == "Help")
                {
                    ShowInstructions();
                }
                else
                {
                    foreach (var item in _items[command]._command)
                    {
                        item.Execute();
                    }
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
                command = Console.ReadLine().Trim();
                // отрезать до пробела

                if (command.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                // нужно разделять название команды и параметры
                ExecuteCommand(command);
            }
        }

        public void ShowInstructions()
        {
            Console.WriteLine("Commands list:");
            foreach (var item in _items)
            {
                Console.WriteLine(item.Key + ": " + item.Value._description);
            }
            Console.WriteLine();
        }

        public void Exit()
        {
            _exit = true;
        }

    }
}
