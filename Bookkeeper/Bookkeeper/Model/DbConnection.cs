using Bookkeeper.View;
using System.CodeDom;
using System.Data.SQLite;

namespace Bookkeeper.Model
{
    public class DbConnection
    {
        private static DbConnection? _instance;
        private SQLiteConnection _connection;

        private DbConnection()
        {
            _connection = SetUpDB();
        }

        public static DbConnection GetInstance()
        {
            if (_instance == null) { _instance = new DbConnection(); }
            return _instance;
        }

        public void ExecuteQuery(string query)
        {
            SQLiteCommand command = new SQLiteCommand(query, _connection);
            command.ExecuteNonQuery();
        }

        public SQLiteDataReader ExecuteSelectionQuery(string query)
        {
            SQLiteCommand command = new SQLiteCommand(query, _connection);
            return command.ExecuteReader();
        }

        private SQLiteConnection SetUpDB()
        {
            string newDBString;
            bool DBisNew = false;

            if (File.Exists("./SQLiDatabase.db")) // If DB already exists, only connect.
            {
                Console.WriteLine("Vorhandene Datenkbank wird verwendet . . .");
                newDBString = "";
            }
            else
            {
                Console.WriteLine("Datenkbank noch nicht vorhanden.\n" +
                    "Neue Datenbank wird erstellt . . .");
                newDBString = " New = True; Compress = True;";
                DBisNew = true;
            }

            SQLiteConnection connection = new("Data Source = SQLiDatabase.db; " +
                "Version = 3;" + newDBString);

            try
            {
                connection.Open();
            }
            catch (Exception e)
            {
                new ErrorView(e).ErstelleAnsicht();
            }

            // only run script if it's a new DB
            if (DBisNew) { ExecuteSetupScript(connection); }

            return connection;
        }

        private void ExecuteSetupScript(SQLiteConnection connection)
        {
            // store script file contents
            FileInfo file = new FileInfo("../../../setup.sql");
            string sqlScript = file.OpenText().ReadToEnd();

            // create sql command
            SQLiteCommand command = new SQLiteCommand(sqlScript, connection);

            // execute command on db
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                string nachricht = "Datenbanksetup kann nicht durchgeführt werden.";
                new ErrorView(e, nachricht).GibAnsichtAus();
            }

            Console.WriteLine("Die neue Datenbank wurde erfolgreich erstellt.");
        }
    }
}
