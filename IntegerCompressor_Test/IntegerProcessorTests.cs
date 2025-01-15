using IntegerCompressor.Interfaces;
using IntegerCompressor.Services;

namespace IntegerCompressor_Test {
    public class IntegerProcessorTests {
        private readonly IIntegerProcessor _IntegerProcessor;

        public IntegerProcessorTests() {
            _IntegerProcessor = new IntegerProcessor();
        }

        [Fact]
        public void Encode_ValidInput_ProcducesEncodedString() {
            string csvInput = "1,3,6,0,2,4,7,5,8,9";
            string encodedString = _IntegerProcessor.Encode(csvInput);

            Assert.False(string.IsNullOrEmpty(encodedString));
            Assert.True(encodedString.Length < 100);
        }
    }
}
