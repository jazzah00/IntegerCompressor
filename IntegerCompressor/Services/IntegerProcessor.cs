using IntegerCompressor.Codex;
using IntegerCompressor.Interfaces;
using System.IO.Compression;
using System.Text;

namespace IntegerCompressor.Services {
    public class IntegerProcessor : IIntegerProcessor {
        public string Encode(string csvFile) {
            try {
                int[] integers = csvFile
                    .Split([',', '\n', '\r'], StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .Distinct()
                    .ToArray();

                byte[] byteArray = Encoding.UTF8.GetBytes(string.Join(",", integers));
                byteArray = Compress(byteArray);
                return new Base62().Encode(byteArray);
            } catch (Exception ex) {
                return $"An Error has occurred, during encoding: {ex.Message}";
            }
        }

        private static byte[] Compress(byte[] data) {
            using (MemoryStream output = new()) {
                using (BrotliStream brotli = new(output, CompressionLevel.Optimal)) {
                    brotli.Write(data, 0, data.Length);
                }
                return output.ToArray();
            }
        }

        public string Decode(string encodedString) {
            try {
                byte[] byteArray = new Base62().Decode(encodedString);
                byteArray = Decompress(byteArray);
                return Encoding.UTF8.GetString(byteArray);
            } catch (Exception ex) {
                return $"An Error has occurred, during decoding: {ex.Message}";
            }
        }

        private static byte[] Decompress(byte[] data) {
            using (MemoryStream input = new(data)) {
                using (MemoryStream output = new()) {
                    using (BrotliStream brotli = new(input, CompressionMode.Decompress)) {
                        brotli.CopyTo(output);
                    }
                    return output.ToArray();
                }
            }
        }
    }
}
