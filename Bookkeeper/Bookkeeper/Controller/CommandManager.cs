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
            _commands.Add(command.Name, command);
        }

        public void FuehreCommandAus(string[] args)
        {
            Command command = _commands[args[0]];
            command.Ausfuehren(args);
        }
    }
}
