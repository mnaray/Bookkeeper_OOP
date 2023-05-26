using Bookkeeper.Controller.Commands;

namespace Bookkeeper.Controller
{
    public class CommandManager
    {
        private Dictionary<string, Command> _commands;
        public Dictionary<string, Command> Commands { get { return _commands; } }

        public CommandManager()
        {

        }

        public void FuegeCommandHinzu(Command command)
        {
            throw new NotImplementedException();
        }

        public void FuehreCommandAus(string commandName)
        {
            throw new NotImplementedException();
        }
    }
}
