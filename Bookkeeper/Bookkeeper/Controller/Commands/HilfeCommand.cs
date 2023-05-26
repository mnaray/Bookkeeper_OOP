using Bookkeeper.View;

namespace Bookkeeper.Controller.Commands
{
    public class HilfeCommand : Command
    {
        private const string _beschreibung =
            "Dieser Befehl listet alle möglichen Befehle auf und beschreibt sie.";

        public HilfeCommand()
            : base("hilfe", _beschreibung)
        { }

        public override void Ausfuehren(string[] args)
        {
            if (args.Length > 1)
            {
                throw new Exception($"<{this.Name}> verwendet keine Argumente.");
            }

            CommandManager cm = new CommandManager();
            BefehlHilfeView view = new BefehlHilfeView(cm.Commands);
            view.GibAnsichtAus();
        }
    }
}
