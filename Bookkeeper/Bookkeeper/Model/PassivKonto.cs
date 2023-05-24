namespace Bookkeeper.Model
{
    public class PassivKonto : Konto
    {
        public PassivKonto(int konotId, string kontoName) : 
            base(konotId, kontoName) { }

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
