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
                if (!ValidiereInput())
                {
                    throw new Exception("Format des eingegebenen Befehls ist invalid.");
                }
                _currentCommand = input.Trim().Split(' ')!;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
        }

        public void VersucheAuszuführen()
        {
            throw new NotImplementedException();
        }

        private bool ValidiereInput()
        {
            throw new NotImplementedException();
        }
    }
}
