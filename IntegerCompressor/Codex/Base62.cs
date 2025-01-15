using System.Numerics;

namespace IntegerCompressor.Codex {
    public class Base62 {
        private const string Characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        private static readonly Dictionary<char, int> CharToValue = [];

        public Base62() {
            for (int i = 0; i < Characters.Length; i++) {
                CharToValue[Characters[i]] = i;
            }
        }

        public string Encode(byte[] data) {
            BigInteger value = new(data.Reverse().ToArray());
            if (value == 0) return "0";

            Stack<char> result = new();
            while (value > 0) {
                result.Push(Characters[(int)(value % CharToValue.Count)]);
                value /= CharToValue.Count;
            }
            return new string([.. result]);
        }

        public byte[] Decode(string encodedString) {
            BigInteger value = 0; int charCount = 0;
            foreach (char c in encodedString) {
                if (!CharToValue.ContainsKey(c)) throw new FormatException($"Invalid character '{c}' in Base52 string, Line Number: {charCount}.");
                value = value * CharToValue.Count + CharToValue[c];
                charCount += 1;
            }

            byte[] bytes = value.ToByteArray();
            Array.Reverse(bytes);
            return bytes;
        }
    }
}
