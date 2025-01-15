using IntegerCompressor.Interfaces;
using Moq;

namespace IntegerCompressor_Test {
    public class FileHandlerTests {
        [Fact]
        public void ReadFile_ValidPath_ReturnsContent() {
            var mockFileHandler = new Mock<IFileHandler>();
            mockFileHandler.Setup(f => f.ReadFile(It.IsAny<string>())).Returns("1,3,6,0,2,4,7,5,8,9");

            string content = mockFileHandler.Object.ReadFile("dummy.csv");

            Assert.Equal("1,3,6,0,2,4,7,5,8,9", content);
        }
    }
}
