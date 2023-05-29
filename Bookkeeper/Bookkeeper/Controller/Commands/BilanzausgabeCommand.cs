namespace Bookkeeper.Controller.Commands
{
    public class BilanzausgabeCommand : Command
    {
        private const string _beschreibung =
            "Dieser Befehl gibt den aktuellen Zustand der Bilanz aus.\n" +
            "Es werden alle Bilanzkonten aufgelistet.\n" +
            "Verwende dazu folgende Syntax:\n\n" +
            "bilanz\n\n" +
            "Mit einem optionalen Zusatz kann man den Zustand der Bilanz " +
            "auch vor einem bestimmten Datum ansehen:\n\n" +
            "bilanz --datum <Datum [TT.MM.JJJJ]>";

        public BilanzausgabeCommand()
            : base("bilanz", _beschreibung)
        { }

        public override void Ausfuehren(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}
