using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            // TODO: Complete Something, if anything

            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }
        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("33.671982,-85.826674,Taco Bell Annisto...", -85.826674)]
        [InlineData("32.92496,-85.961342,Taco Bell Alexander Cit...", -85.961342)]
        [InlineData("33.524131, -86.724876, Taco Bell Birmingham...", -86.724876)]
        public void ShouldParseLongitude(string line, double expected)
        {
            // TODO: Complete - "line" represents input data we will Parse to
            //       extract the Longitude.  Your .csv file will have many of these lines,
            //       each representing a TacoBell location
            //Arrange
            var test = new TacoParser();

            //Act

            var actual = test.Parse(line).Location.Longitude;

            //Assert
            Assert.Equal(actual, expected);
        }
        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        [InlineData("33.671982,-85.826674,Taco Bell Annisto...", 33.671982)]
        [InlineData("32.92496,-85.961342,Taco Bell Alexander Cit...", 32.92496)]
        [InlineData("33.524131,-86.724876,Taco Bell Birmingham...", 33.524131)]
        public void ShouldParseLatitude(string line, double expected)
        {
            //Arrange
            var test = new TacoParser();

            //Act

            var actual = test.Parse(line).Location.Latitude;

            //Assert
            Assert.Equal(actual, expected);

        }
    }
}
