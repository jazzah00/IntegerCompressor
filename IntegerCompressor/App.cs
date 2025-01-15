using IntegerCompressor.Interfaces;

namespace IntegerCompressor {
    public class App {
        private readonly IIntegerProcessor _IntegerProcessor;
        private readonly IFileHandler _FileHandler;

        public App(IIntegerProcessor integerProcessor, IFileHandler fileHandler) {
            _IntegerProcessor = integerProcessor;
            _FileHandler = fileHandler;
        }

        public void Run(string[] args) {
            if (args.Length < 2) {
                Console.WriteLine("Usage: IntegerCompressor <encode> <file-path>");
                Console.WriteLine("Usage: IntegerCompressor <decode|decodefile> <encoded-string|file-path>");
                return;
            }

            string mode = args[0].ToLower(),
                   context = args[1];

            if (mode.Equals("encode")) Console.WriteLine(_IntegerProcessor.Encode(_FileHandler.ReadFile(context)));
            else if (mode.Equals("decode")) Console.WriteLine(_IntegerProcessor.Decode(context));
            else if (mode.Equals("decodefile")) Console.WriteLine(_IntegerProcessor.Decode(_FileHandler.ReadFile(context)));
            else Console.WriteLine("Invalid mode. Please use 'encode', 'decode' or 'decodefile'.");
        }
    }
}
