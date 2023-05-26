using Bookkeeper.Controller;
using Bookkeeper.View;
using System.Data.SQLite;
using System.Diagnostics;

namespace Bookkeeper
{
    class Entrypoint
    {
        static void Main(string[] args)
        {
            // Entrypoint to application
            StarteProgram();
            if (Debugger.IsAttached) { Console.ReadKey(); }
        }

        private static void StarteProgram()
        {
            string input = "";

            while (input != "exit")
            {
                new EingabeVerlanger().GibAnsichtAus();
                input = Console.ReadLine() ?? "";
                new InputManager(input).VersucheAusfuehrung();
            }
        }
    }
}