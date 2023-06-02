using System.Data.SQLite;

namespace Bookkeeper.Model
{
    public abstract class Konto
    {
        private int _kontoId;
        private string _kontoName;
        protected decimal _kontostand;
        public int KontoId { get { return _kontoId; } }
        public string KontoName { get { return _kontoName; } }

        public Konto(int kontoId, string kontoName)
        {
            _kontoId = kontoId;
            _kontoName = kontoName;
            _kontostand = 0;
        }

        public decimal BerechneSaldo(int datum)
        {
            DbConnection db = DbConnection.GetInstance();
            string query = // TODO: check if ' around the ID makes a difference (it shouldn't)
                $"SELECT * FROM buchungssaetze " +
                $"WHERE soll_konto_id = {_kontoId} " +
                $"OR soll_konto_id = {_kontoId};";

            SQLiteDataReader reader = db.ExecuteSelectionQuery(query);

            while (reader.Read())
            {
                int sollKontoIdDb = Convert.ToInt32(reader["soll_konto_id"]);
                int habenKontoIdDb = Convert.ToInt32(reader["haben_konto_id"]);
                decimal betrag = Convert.ToDecimal(reader["betrag"]);

                if (sollKontoIdDb == _kontoId)
                {
                    TaetigeSollBuchung(betrag);
                }
                else if (habenKontoIdDb == _kontoId)
                {
                    TaetigeHabenBuchung(betrag);
                }
                else
                {
                    throw new Exception($"Saldo von '{_kontoName}' kann nicht berechnet werden.");
                }
            }

            return _kontostand;
        }

        public abstract void TaetigeSollBuchung(decimal betrag);
        public abstract void TaetigeHabenBuchung(decimal betrag);
    }
}
