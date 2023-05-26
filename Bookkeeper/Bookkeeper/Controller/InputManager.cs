using Bookkeeper.Controller.Commands;
using Bookkeeper.View;

namespace Bookkeeper.Controller
{
    public class InputManager
    {
        private string[] _currentCommand;
        private CommandManager _commandManager;

        public InputManager(string input)
        {
            _commandManager = new CommandManager();
            _currentCommand = Array.Empty<string>();
            try
            {
                _currentCommand = input.Trim().Split(' ')!;
                if (!ValidiereInput())
                {
                    throw new Exception("Format des eingegebenen Befehls ist invalid.");
                }
            }
            catch (Exception e)
            {
                new ErrorView(e).ErstelleAnsicht();
            }
        }

        public void VersucheAusfuehrung()
        {
            try
            {
                _commandManager.FuehreCommandAus(_currentCommand);
            }
            catch (Exception e)
            {
                string nachricht = "Es ist ein Fehler bei der Bearbeitung des Befehls aufgetreten.";
                new ErrorView(e, nachricht).GibAnsichtAus();
            }
        }

        private bool ValidiereInput()
        {
            if (_currentCommand.Length <= 0) { return false; } // check array length
            if (_currentCommand[0].Length <= 2) { return false; } // check min length of command
            if (!_commandManager.Commands.ContainsKey(_currentCommand[0])) { return false; }
            return true;
        }
    }
}
