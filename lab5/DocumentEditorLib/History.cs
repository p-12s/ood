using System.Collections.Generic;

namespace DocumentEditorLib
{
    public class History
    {
        private readonly int _maxNumberOfCommandsRremembered;
        private LinkedList<ICommand> _commands;
        private LinkedList<ICommand> _canceledCommands;

        public History()
        {
            _maxNumberOfCommandsRremembered = 10;
            _commands = new LinkedList<ICommand>();
            _canceledCommands = new LinkedList<ICommand>();
        }

        public bool CanUndo()
        {
            return _commands.Count > 0;
        }

        public void Undo()
        {
            if (CanUndo())
            {
                var canceledCommand = _commands.Last.Value;
                canceledCommand.Unexecute();

                _canceledCommands.AddFirst(canceledCommand);
                _commands.RemoveLast();
            }
        }

        public bool CanRedo()
        {
            return _canceledCommands.Count > 0;
        }

        public void Redo()
        {
            if (CanRedo())
            {
                var recoverableCommand = _canceledCommands.First.Value;
                recoverableCommand.Execute(false); // восстанавливаемая команда, а не новая

                _commands.AddLast(recoverableCommand);
                _canceledCommands.RemoveFirst();
            }
        }

        public void AddCommand(ICommand command)
        {
            _commands.AddLast(command);

            if (_commands.Count > _maxNumberOfCommandsRremembered)
            {
                _commands.RemoveFirst();
            }

            if (_canceledCommands.Count > 0)
            {
                _canceledCommands.Clear();
            }
        }

    }
}
