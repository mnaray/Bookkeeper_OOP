namespace Bookkeeper.View
{
    public class ErrorView : IView
    {
        private readonly Exception _exception;
        private readonly string _optionaleNachricht;

        public ErrorView(Exception exception)
        {
            _exception = exception;
            _optionaleNachricht = "Ein Fehler ist aufgetreten!";
        }

        public ErrorView(Exception exception, string optionaleNachricht)
        {
            _exception = exception;
            _optionaleNachricht = optionaleNachricht;
        }

        public void GibAnsichtAus()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ErstelleAnsicht());
            Console.ForegroundColor = ConsoleColor.White;
        }

        public string ErstelleAnsicht()
        {
            string teil1 = Environment.NewLine + "----" + _optionaleNachricht + "----" + Environment.NewLine;
            string teil2 = _exception.Message + Environment.NewLine;
            return teil1 + teil2;
        }
    }
}
