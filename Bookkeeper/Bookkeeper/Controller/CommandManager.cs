using Bookkeeper.Controller.Commands;

namespace Bookkeeper.Controller
{
    public class CommandManager
    {
        private Dictionary<string, Command> _commands;
        public Dictionary<string, Command> Commands { get { return _commands; } }

        public CommandManager()
        {
            _commands = new Dictionary<string, Command>();
        }

        public void FuegeCommandHinzu(Command command)
        {
            throw new NotImplementedException();
        }

        public void FuehreCommandAus(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}
