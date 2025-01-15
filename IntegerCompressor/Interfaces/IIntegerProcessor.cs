namespace IntegerCompressor.Interfaces {
    public interface IIntegerProcessor {
        string Encode(string csvFile);
        string Decode(string encodedString);
    }
}
