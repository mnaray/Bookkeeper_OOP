using Bookkeeper.View;

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
            if (args.Length > 3)
            {
                throw new Exception($"Der Befehl <{this.Name}> nimmt nicht mehr als 2 Argumente");
            }

            if (args.Length == 1) // no date
            {
                int jetzt = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
                BilanzView view = new BilanzView(jetzt);
                view.GibAnsichtAus();
                return;
            }

            // with date argument
            if (args[1] != "--datum")
            {
                throw new Exception("Das angegebene Argument ist nicht bekannt.");
            }

            DateTime datum = DateTime.Now;
            if (args.Length > 1 && (!DateTime.TryParse(args[2], out datum) || args[2].Length != 12))
            {
                throw new Exception("Das angegebene Datum ist nicht im richtigen Format. (TT.MM.JJJJ)");
            }

            if (datum > DateTime.Now)
            {
                throw new Exception("Das Datum muss in der Vergangenheit sein.");
            }

            int datumUnixTimestamp = (int)datum.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            BilanzView vergangenheitsView = new BilanzView(datumUnixTimestamp);
            vergangenheitsView.GibAnsichtAus();
        }
    }
}
