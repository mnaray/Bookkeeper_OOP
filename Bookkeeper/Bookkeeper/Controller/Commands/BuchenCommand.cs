using Bookkeeper.Model;

namespace Bookkeeper.Controller.Commands
{
    public class BuchenCommand : Command
    {
        private const string _beschreibung = "beschreibung . . .";

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
                throw new Exception($"<{this.Name}> hat mindestens 4 Argumente.");
            }

            if (!decimal.TryParse(args[4], out betrag))

            if (!int.TryParse(args[1], out sollKontoId) || !int.TryParse(args[2], out habenKontoId))
            {
                throw new Exception($"Eines der angegebenen Kontennummern ist keine grade Zahl");
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

            Buchungssatz buchungssatz = new Buchungssatz(sollKonto, habenKonto, betrag);
            buchungssatz.Ausfuehren();
        }
    }
}
