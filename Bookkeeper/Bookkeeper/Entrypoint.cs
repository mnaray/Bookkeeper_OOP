using System.Data.SQLite;

namespace Bookkeeper
{
    class Entrypoint
    {
        static void Main(string[] args)
        {
            // Entrypoint to application
            Console.WriteLine("Anwendung wird gestartet . . .");
            SetUpDB();
            Console.WriteLine("Anwendung ist am Laufen.");
            Console.ReadKey();
        }

        private static void SetUpDB()
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
                Console.WriteLine("Datenkbank noch nicht vorhanden." +
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
                OutputErrorMessage("Verbindung zur Datenbank kann nicht aufgebaut werden.", e);
            }

            // only run script if it's a new DB
            if (DBisNew) { ExecuteScript(connection); }

            connection.Close();
        }

        private static void ExecuteScript(SQLiteConnection connection)
        {
            // store script file contents
            FileInfo file = new FileInfo("./setup.sql");
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
                OutputErrorMessage("Datenbanksetup kann nicht durchgeführt werden.", e);
            }

            Console.WriteLine("Die neue Datenbank wurde erfolgreich erstellt!");
        }

        private static void OutputErrorMessage(string redText, Exception exception)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Environment.NewLine + redText + Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(exception.Message);
        }
    }
}