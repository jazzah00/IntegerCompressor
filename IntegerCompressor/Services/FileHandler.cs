using IntegerCompressor.Interfaces;

namespace IntegerCompressor.Services {
    public class FileHandler : IFileHandler {
        public string ReadFile(string filePath) => File.ReadAllText(filePath);
    }
}
