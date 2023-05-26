using System.Text;

namespace Bookkeeper.View
{
    public class EingabeVerlanger : IView
    {
        public void GibAnsichtAus()
        {
            Console.WriteLine(ErstelleAnsicht());
        }

        public string ErstelleAnsicht()
        {
            StringBuilder abtrennung = new StringBuilder(Environment.NewLine);
            string forderung = "Gib einen Befehl ein: ";

            for (int i = 0; i < Console.WindowWidth; i++)
            {
                abtrennung.Append("-");
            }

            abtrennung.Append(Environment.NewLine);

            return abtrennung.ToString() + forderung;
        }
    }
}
