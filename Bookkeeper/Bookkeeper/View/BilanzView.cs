using Bookkeeper.Model;
using System.Text;

namespace Bookkeeper.View
{
    public class BilanzView : IView
    {
        private const string WAEHRUNG = "CHF";
        private int _datum; // Unix timestamp

        /// <summary>
        /// Konstruktor der BilanzView-Klasse
        /// </summary>
        /// <param name="ansichtsdatum">Das Ansichtsdatum ist ein Unix-Timestamp in Form von einem Integer</param>
        public BilanzView(int ansichtsdatum)
        {
            _datum = ansichtsdatum;
        }

        public void GibAnsichtAus()
        {
            Console.WriteLine(ErstelleAnsicht());
        }

        public string ErstelleAnsicht()
        {
            StringBuilder sbResult = new StringBuilder("");
            StringBuilder sbLine = new StringBuilder("");
            Bilanz bilanz = new Bilanz();
            Dictionary<Konto, decimal> kontoSalden = bilanz.StecheBilanz(_datum);

            sbResult.AppendLine($"Bilanz vom {UnixTimestampConverter.UnixTimestampToDateTime(_datum)}");

            for (int i = 0; i < Console.WindowWidth; i++)
            {
                sbLine.Append('-');
            }

            sbResult.AppendLine(sbLine.ToString()); // line of hyphens
            sbResult.AppendLine(Environment.NewLine);
            sbResult.AppendLine("=== Aktivkonten ===");
            sbResult.AppendLine("-------------------");

            bool beiAktivkonten = true;
            foreach (KeyValuePair<Konto, decimal> saldo in kontoSalden)
            {
                // check if at passive part yet
                if (beiAktivkonten && saldo.Key.KontoId.ToString().StartsWith('2'))
                {
                    sbResult.AppendLine(Environment.NewLine);
                    sbResult.AppendLine("=== Passivkonten ===");
                    sbResult.AppendLine("--------------------");
                    beiAktivkonten = false;
                }

                sbResult.AppendLine(saldo.Key.KontoName);
                sbResult.AppendLine($"{saldo.Value.ToString()} {WAEHRUNG}");
                sbResult.AppendLine(Environment.NewLine);
            }

            return sbResult.ToString();
        }
    }
}
