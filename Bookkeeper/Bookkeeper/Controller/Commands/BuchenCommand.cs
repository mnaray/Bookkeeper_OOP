namespace Bookkeeper.Controller.Commands
{
    public class BuchenCommand : Command
    {
        private const string _beschreibung = "beschreibung . . .";

        public BuchenCommand()
            : base("buche", _beschreibung)
        { }

        public override void Ausfuehren(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}
