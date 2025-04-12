namespace DesignPatterns.Singleton
{
    public sealed class Singleton
    {
        private static Singleton? _instance;
        private static readonly object _lock = new object();

        // Private constructor to prevent instantiation
        private Singleton() { }

        public static Singleton Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Singleton();
                    }
                    return _instance;
                }
            }
        }

        public void DisplayMessage()
        {
            Console.WriteLine("Singleton instance invoked!");
        }
    }
}
