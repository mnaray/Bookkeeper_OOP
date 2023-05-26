using Bookkeeper.Controller.Commands;
using System.Text;

namespace Bookkeeper.View
{
    public class BefehlHilfeView : IView
    {
        private Dictionary<string, Command> _commands;

        public BefehlHilfeView(Dictionary<string, Command> commands)
        {
            _commands = commands;
        }

        public void GibAnsichtAus()
        {
            string[] zeilen = ErstelleAnsicht().Split(Environment.NewLine);
            foreach (string zeile in zeilen)
            {
                // determine if it's a command name
                if (zeile.Trim().StartsWith('<') && zeile.Trim().EndsWith('>'))
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine(zeile);
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(zeile);
                }
            }
        }

        public string ErstelleAnsicht()
        {
            StringBuilder sb = new StringBuilder("");
            foreach (var command in _commands)
            {
                sb.AppendLine($"<{command.Key}>"); // Name
                sb.AppendLine(command.Value.Beschreibung);
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
