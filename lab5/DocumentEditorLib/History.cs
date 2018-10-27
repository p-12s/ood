using System.Collections.Generic;

namespace DocumentEditorLib
{
    public class History
    {
        private readonly int _maxNumberOfCommandsRremembered;
        private LinkedList<IUndoableAction> _commands;
        private LinkedList<IUndoableAction> _canceledCommands;

        public History()
        {
            _maxNumberOfCommandsRremembered = 10;
            _commands = new LinkedList<IUndoableAction>();
            _canceledCommands = new LinkedList<IUndoableAction>();
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
                recoverableCommand.Execute();

                _commands.AddLast(recoverableCommand);
                _canceledCommands.RemoveFirst();
            }
        }

        public void AddCommand(IUndoableAction command)
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
