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

        public void Undo()// как тут выполнить инвертированную команду?
        {
            if (CanUndo())
            {
                var canceledCommand = _commands.Last.Value; // вот она отменяемая комманда
                canceledCommand.Unexecute(); // давай-ка тут же и отменим


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
                var recoverableCommand = _canceledCommands.First;
                _commands.AddLast(recoverableCommand.Value);
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

            if (_canceledCommands.Count > 0) // очистим устаревшую историю
            {
                _canceledCommands.Clear();
            }
        }

        /* пусть история только хранит команды, а не выполняет
        public void AddAndExecuteCommand(ICommand command)
        {
            command.Execute();
            _commands.AddLast(command);

            if (_commands.Count > _maxNumberOfCommandsRremembered)
            {
                _commands.RemoveFirst();
            }

            if (_canceledCommands.Count > 0) // очистим устаревшую историю
            {
                _canceledCommands.Clear();
            }
        }*/
    }
}
