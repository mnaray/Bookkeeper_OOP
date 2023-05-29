using Bookkeeper.View;

namespace Bookkeeper.Model
{
    public class Buchungssatz
    {
        private readonly int? _id;
        private string _buchungstetxt;
        private int _buchungsdatum; // Unix Timestamp
        private Konto _sollKonto;
        private Konto _habenKonto;
        private decimal _betrag;
        public int? Id { get { return _id; } }
        public string Buchungstext { get { return _buchungstetxt; } }
        public Konto SollKonto { get { return _sollKonto; } }
        public Konto HabenKonto { get { return _habenKonto; } }
        public decimal Betrag { get { return _betrag; } }

        public Buchungssatz(int id, string buchungstext, Konto sollKonto,
            Konto habenKonto, decimal betrag)
        {
            _id = id;
            _buchungstetxt = buchungstext;
            _buchungsdatum = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            _sollKonto = sollKonto;
            _habenKonto = habenKonto;
            _betrag = betrag;
        }

        public Buchungssatz(string buchungstext, Konto sollKonto,
            Konto habenKonto, decimal betrag)
        {
            _id = null;
            _buchungstetxt = buchungstext;
            _buchungsdatum = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            _sollKonto = sollKonto;
            _habenKonto = habenKonto;
            _betrag = betrag;
        }

        public Buchungssatz(int id, Konto sollKonto, Konto habenKonto, decimal betrag)
        {
            _id = id;
            _buchungstetxt = "Kein Buchungstext wurde angegeben.";
            _buchungsdatum = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            _sollKonto = sollKonto;
            _habenKonto = habenKonto;
            _betrag = betrag;
        }

        public Buchungssatz(Konto sollKonto, Konto habenKonto, decimal betrag)
        {
            _id = null;
            _buchungstetxt = "Kein Buchungstext wurde angegeben.";
            _buchungsdatum = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            _sollKonto = sollKonto;
            _habenKonto = habenKonto;
            _betrag = betrag;
        }

        public void Ausfuehren()
        {
            if (_sollKonto.KontoId == _habenKonto.KontoId)
            {
                throw new Exception("Buchung mit zwei Mal demselben Konto ist nicht erlaubt.");
            }

            DbConnection db = DbConnection.GetInstance();

            string query =
                $"INSERT INTO buchungssaetze " +
                $"(buchungstext, buchungsdatum, soll_konto_id, haben_konto_id, betrag) " +
                $"VALUES ('{_buchungstetxt}', {_buchungsdatum}, {_sollKonto.KontoId}, " +
                $"{_habenKonto.KontoId}, {Math.Round(_betrag, 2)})";

            try
            {
                db.ExecuteQuery(query);
            }
            catch (Exception e)
            {
                string nachricht = "Fehler bei Ausfuehren den Buchung.";
                new ErrorView(e, nachricht).GibAnsichtAus();
            }
        }
    }
}
