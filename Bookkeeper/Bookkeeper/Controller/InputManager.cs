using Bookkeeper.Controller.Commands;

namespace Bookkeeper.Controller
{
    public class InputManager
    {
        private string[] _currentCommand;
        private CommandManager _commandManager;

        public InputManager(string input)
        {
            _commandManager = new CommandManager();
            _commandManager.FuegeCommandHinzu(new HilfeCommand());
            _commandManager.FuegeCommandHinzu(new BuchenCommand());
            _commandManager.FuegeCommandHinzu(new BilanzausgabeCommand());

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
                Console.Error.WriteLine(e.Message);
            }
        }

        public void VersucheAusfuehrung()
        {
            
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
