namespace Bookkeeper.Controller.Commands
{
    public abstract class Command
    {
        private string _name;
        private string _beschreibung;
        public string Name { get { return _name; } }
        public string Beschreibung { get { return _beschreibung; } }

        public Command(string name, string beschreibung)
        {
            _name = name;
            _beschreibung = beschreibung;
        }

        public abstract void Ausfuehren(string[] args);
    }
}
