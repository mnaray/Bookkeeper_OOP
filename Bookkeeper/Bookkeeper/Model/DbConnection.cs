using System.Data.SQLite;

namespace Bookkeeper.Model
{
    public class DbConnection
    {
        private static DbConnection? _instance;

        private DbConnection() { }

        public static DbConnection GetInstance()
        {
            if (_instance == null) { _instance = new DbConnection(); }
            return _instance;
        }

        public void ExecuteQuery(string query)
        {
            throw new NotImplementedException();
        }

        public SQLiteDataReader ExecuteSelectionQuery(string query)
        {
            throw new NotImplementedException();
        }
    }
}
