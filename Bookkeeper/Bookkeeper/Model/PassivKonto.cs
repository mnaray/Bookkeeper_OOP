namespace Bookkeeper.Model
{
    public class PassivKonto : Konto
    {
        public PassivKonto(int konotId, string kontoName) :
            base(konotId, kontoName)
        { }

        public override void TaetigeSollBuchung(decimal betrag)
        {
            _kontostand -= betrag;
        }

        public override void TaetigeHabenBuchung(decimal betrag)
        {
            _kontostand += betrag;
        }
    }
}
