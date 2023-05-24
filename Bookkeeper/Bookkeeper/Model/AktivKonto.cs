namespace Bookkeeper.Model
{
    public class AktivKonto : Konto
    {
        public AktivKonto(int konotId, string kontoName) :
            base(konotId, kontoName)
        { }

        public override void TaetigeSollBuchung(decimal betrag)
        {
            throw new NotImplementedException();
        }

        public override void TaetigeHabenBuchung(decimal betrag)
        {
            throw new NotImplementedException();
        }

        public override decimal BerechneSaldo()
        {
            throw new NotImplementedException();
        }
    }
}
