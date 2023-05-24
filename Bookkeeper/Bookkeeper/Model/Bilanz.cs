using System.Data.SQLite;

namespace Bookkeeper.Model
{
    public class Bilanz
    {
        private List<Konto> _konten = new List<Konto>();
        public decimal Total
        {
            get
            {
                decimal total = 0;
                foreach (Konto konto in _konten)
                {
                    konto.BerechneSaldo();
                }
                return total;
            }
        }

        public Bilanz()
        {
            DbConnection db = DbConnection.GetInstance();
            string query = "SELECT konto_id, konto_name, typ_name " +
                "FROM bilanz_konten " +
                "INNER JOIN bilanz_konto_typen " +
                "ON konto_typ = typ_id;";

            SQLiteDataReader reader = db.ExecuteSelectionQuery(query);

            while (reader.Read())
            {
                try
                {
                    int id = (int)reader["konto_id"];
                    string name = (string)reader["konto_name"];
                    string typ = (string)reader["typ_name"]; // aktiv od. passiv

                    if (typ == "aktiv") { _konten.Add(new AktivKonto(id, name)); }
                    else if (typ == "passiv") { _konten.Add(new PassivKonto(id, name)); }
                    else { throw new Exception(); }
                }
                catch (Exception)
                {
                    throw new Exception("Kontotyp konnte bei Bilanzgeneration nicht korrekt verarbeitet werden.");
                }
            }
        }

        public Dictionary<Konto, decimal> StecheBilanz()
        {
            throw new NotImplementedException();
        }
    }
}
