namespace Bookkeeper.Controller.Commands
{
    public class HilfeCommand : Command
    {
        private const string _beschreibung = "beschreibung . . .";

        public HilfeCommand()
            : base("help", _beschreibung)
        { }

        public override void Ausfuehren(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}
