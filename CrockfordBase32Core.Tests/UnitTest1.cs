using CrockfordBase32;
using System;
using Xunit;

namespace CrockfordBase32CoreTest
{
    public class UnitTest1
    {
        [Fact]
        public void CrockfordBase32Encoding_SplitInto5BitChunks_ShouldReturnASingleChunkFor0()
        {
            const int input = 0;
            var expected = new byte[] { 0 };
            var actual = CrockfordBase32Encoding.SplitInto5BitChunks(input);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CrockfordBase32Encoding_SplitInto5BitChunks_ShouldNotChunkANumberThatFitsIn5Bits()
        {
            const int input = 31;
            var expected = new byte[] { 31 };
            var actual = CrockfordBase32Encoding.SplitInto5BitChunks(input);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CrockfordBase32Encoding_SplitInto5BitChunks_ShouldChunkANumberThatFitsIn6Bits()
        {
            const int input = 32;
            var expected = new byte[] { 1, 0 };
            var actual = CrockfordBase32Encoding.SplitInto5BitChunks(input);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CrockfordBase32Encoding_SplitInto5BitChunks_ShouldChunkANumberThatFitsIn13Bits()
        {
            const int input = 4546;
            var expected = new byte[] { 4, 14, 2 };
            var actual = CrockfordBase32Encoding.SplitInto5BitChunks(input);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CrockfordBase32Encoding_Decode_ShouldThrowArgumentNullExceptionForNullInput()
        {
            try
            {
                new CrockfordBase32Encoding().Decode(null, false);
                Assert.False(true,"Expected exception was never thrown");
            }
            catch (ArgumentNullException ex)
            {
                Assert.Equal("encodedString", ex.ParamName);
            }
        }

        [Fact]
        public void CrockfordBase32Encoding_Decode_ShouldReturnNullForBadCharacter()
        {
            Assert.Null(new CrockfordBase32Encoding().Decode("/", false));
        }

        [Fact]
        public void CrockfordBase32Encoding_Decode_ShouldReturnNullForBadCharacterWithinValidOtherwiseInput()
        {
            Assert.Null(new CrockfordBase32Encoding().Decode("a/b", false));
        }

        [Fact]
        public void CrockfordBase32Encoding_Decode_ShouldReturnNullForEmptyString()
        {
            Assert.Null(new CrockfordBase32Encoding().Decode(string.Empty, false));
        }

        //[TestMethod]
        //[DeploymentItem(@"CrockfordBase32.Tests\TestData.xml")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"|DataDirectory|\TestData.xml", "test", DataAccessMethod.Sequential)]
        //public void CrockfordBase32Encoding_Encode_ShouldReturnExpectedResult()
        //{
        //    var number = ulong.Parse((string)TestContext.DataRow["number"]);
        //    var expected = (string)TestContext.DataRow["encodedString"];

        //    var actual = new CrockfordBase32Encoding().Encode(number, false);

        //    Assert.AreEqual(expected, actual);
        //}

        //[TestMethod]
        //[DeploymentItem(@"CrockfordBase32.Tests\TestData.xml")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"|DataDirectory|\TestData.xml", "test", DataAccessMethod.Sequential)]
        //public void CrockfordBase32Encoding_Encode_ShouldReturnExpectedResultWithCheckDigit()
        //{
        //    var number = ulong.Parse((string)TestContext.DataRow["number"]);
        //    var expected = (string)TestContext.DataRow["encodedString"];
        //    var checkDigit = (string)TestContext.DataRow["checkDigit"];

        //    var actual = new CrockfordBase32Encoding().Encode(number, true);

        //    Assert.AreEqual(expected + checkDigit, actual);
        //}

        //[TestMethod]
        //[DeploymentItem(@"CrockfordBase32.Tests\TestData.xml")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"|DataDirectory|\TestData.xml", "test", DataAccessMethod.Sequential)]
        //public void CrockfordBase32Encoding_Decode_ShouldReturnExpectedResult()
        //{
        //    var encodedString = (string)TestContext.DataRow["encodedString"];
        //    var expected = ulong.Parse((string)TestContext.DataRow["number"]);

        //    var actual = new CrockfordBase32Encoding().Decode(encodedString, false);

        //    Assert.AreEqual(expected, actual);
        //}

        //[TestMethod]
        //[DeploymentItem(@"CrockfordBase32.Tests\TestData.xml")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"|DataDirectory|\TestData.xml", "test", DataAccessMethod.Sequential)]
        //public void CrockfordBase32Encoding_Decode_ShouldReturnExpectedResultWithValidCheckDigit()
        //{
        //    var encodedString = (string)TestContext.DataRow["encodedString"];
        //    var checkDigit = (string)TestContext.DataRow["checkDigit"];
        //    var expected = ulong.Parse((string)TestContext.DataRow["number"]);

        //    var actual = new CrockfordBase32Encoding().Decode(encodedString + checkDigit, true);

        //    Assert.AreEqual(expected, actual);
        //}

        //[TestMethod]
        //[DeploymentItem(@"CrockfordBase32.Tests\TestData.xml")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"|DataDirectory|\TestData.xml", "test", DataAccessMethod.Sequential)]
        //public void CrockfordBase32Encoding_Decode_ShouldReturnNullForInvalidCheckDigit()
        //{
        //    var encodedString = (string)TestContext.DataRow["encodedString"];

        //    var actual = new CrockfordBase32Encoding().Decode(encodedString + '#', true);

        //    Assert.IsNull(actual);
        //}

        //[TestMethod]
        //[DeploymentItem(@"CrockfordBase32.Tests\TestData.xml")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"|DataDirectory|\TestData.xml", "test", DataAccessMethod.Sequential)]
        //public void CrockfordBase32Encoding_Decode_ShouldReturnNullForIncorrectCheckDigit()
        //{
        //    var encodedString = (string)TestContext.DataRow["encodedString"];
        //    var checkDigit = (string)TestContext.DataRow["checkDigit"];

        //    checkDigit = checkDigit.Equals("a", StringComparison.OrdinalIgnoreCase) ? "b" : "a";

        //    var actual = new CrockfordBase32Encoding().Decode(encodedString + checkDigit, true);

        //    Assert.IsNull(actual);
        //}
    }
}
