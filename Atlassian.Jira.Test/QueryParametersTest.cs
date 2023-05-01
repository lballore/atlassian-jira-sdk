using System.Linq;
using Xunit;

namespace Atlassian.Jira.Test
{
    public class QueryParametersTest
    {
        [Fact]
        public void GetQueryParametersFromPath()
        {
            // Arrange
            var url = "?field1=9&field2=Test";

            // Act
            var parameters =  QueryParametersHelper.GetParametersFromPath(url);

            // Assert
            Assert.NotNull(parameters);
            Assert.Equal(2, parameters.Count());

            Assert.Equal("field1", parameters.First().Name);
            Assert.Equal("9", parameters.First().Value);

            Assert.Equal("field2", parameters.ElementAt(1).Name);
            Assert.Equal("Test", parameters.ElementAt(1).Value);
        }

        [Fact]
        public void GetQueryParametersFromPathNoEqual()
        {
            // Arrange
            var url = "?field1";

            // Act
            var parameters = QueryParametersHelper.GetParametersFromPath(url);

            // Assert
            Assert.NotNull(parameters);
            Assert.Single(parameters);

            Assert.Equal("field1", parameters.First().Name);
            Assert.Equal("", parameters.First().Value);
        }

        [Fact]
        public void GetQueryParametersFromPathMultipleEquals()
        {
            // Arrange
            var url = "?field1=value=string==";

            // Act
            var parameters = QueryParametersHelper.GetParametersFromPath(url);

            // Assert
            Assert.NotNull(parameters);
            Assert.Single(parameters);

            Assert.Equal("field1", parameters.First().Name);
            Assert.Equal("value=string==", parameters.First().Value);
        }
    }
}
