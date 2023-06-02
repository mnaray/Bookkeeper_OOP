namespace Bookkeeper.View
{
    public class BilanzView : IView
    {
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
            throw new NotImplementedException();
        }

        public string ErstelleAnsicht()
        {
            throw new NotImplementedException();
        }
    }
}
