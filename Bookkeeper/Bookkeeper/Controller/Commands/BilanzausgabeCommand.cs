namespace Bookkeeper.Controller.Commands
{
    public class BilanzausgabeCommand : Command
    {
        private const string _beschreibung = "beschreibung . . .";

        public BilanzausgabeCommand()
            : base("bilanz", _beschreibung)
        { }

        public override void Ausfuehren(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}
