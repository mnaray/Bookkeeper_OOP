namespace Bookkeeper.Model
{
    public abstract class Konto
    {
        private int _kontoID;
        private string _kontoName;
        public int KontoId { get { return _kontoID; } }
        public string KontoName { get { return _kontoName; } }

        public Konto(int kontoId, string kontoName)
        {
            _kontoID = kontoId;
            _kontoName = kontoName;
        }

        public abstract void TaetigeSollBuchung(decimal betrag);
        public abstract void TaetigeHabenBuchung(decimal betrag);
        public abstract decimal BerechneSaldo();
    }
}
