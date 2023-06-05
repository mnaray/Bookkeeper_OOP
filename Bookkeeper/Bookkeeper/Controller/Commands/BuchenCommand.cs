using Bookkeeper.Model;
using System.Text;

namespace Bookkeeper.Controller.Commands
{
    public class BuchenCommand : Command
    {
        private const string _beschreibung =
            "Mit diesm Befehl kann man Buchungssätze bilden und diese ausführen.\n" +
            "Verwende dazu folgende Syntax:\n\n" +
            "buche <Sollkonto> <Habenkonto> <Betrag>\n\n" +
            "Man kann auch mit folgendem Befehl einen Buchungstext angeben:\n\n" +
            "buche <Sollkonto> <Habenkonto> <Betrag> --text <Buchungstext>";

        public BuchenCommand()
            : base("buche", _beschreibung)
        { }

        // Beispielbuchung:
        // buche   1020   1100   23.55    <== args array
        //         Bank / FLL    Betrag
        public override void Ausfuehren(string[] args)
        {
            int sollKontoId = -1;
            int habenKontoId = -1;
            decimal betrag = -1;

            if (args.Length < 4)
            {
                throw new Exception($"<{this.Name}> hat mindestens 3 Argumente.");
            }

            if (!decimal.TryParse(args[3], out betrag))
            {
                throw new Exception("Der eingegebene Betrag ist nicht valid.");
            }

            if (!int.TryParse(args[1], out sollKontoId) || !int.TryParse(args[2], out habenKontoId))
            {
                throw new Exception("Eines der angegebenen Kontennummern ist keine grade Zahl");
            }

            Bilanz bilanz = new Bilanz();

            Konto? sollKonto = bilanz.Konten.FirstOrDefault(k => k.KontoId == sollKontoId);
            Konto? habenKonto = bilanz.Konten.FirstOrDefault(k => k.KontoId == habenKontoId);

            if (sollKonto == null)
            {
                throw new Exception($"Konto {sollKontoId} existiert nicht.");
            }

            if (habenKonto == null)
            {
                throw new Exception($"Konto {habenKontoId} existiert nicht.");
            }

            if (args.Length == 4)
            {
                Buchungssatz buchungssatz = new Buchungssatz(sollKonto, habenKonto, betrag);
                buchungssatz.Ausfuehren();
            }
            else if (args.Length > 4 && args[4] == "--text")
            {
                string buchungsText = BuchungstextZusammensetzen(args);
                Buchungssatz buchungssatz = new Buchungssatz(buchungsText, sollKonto, habenKonto, betrag);
                buchungssatz.Ausfuehren();
            }
        }

        private string BuchungstextZusammensetzen(string[] args)
        {
            StringBuilder text = new StringBuilder("");

            // start at text beginning in args (index 5)
            for (int i = 5; i < args.Length; i++)
            {
                text.Append(args[i]);
                text.Append(' ');
            }

            return text.ToString().Trim();
        }
    }
}
