using Xunit;
namespace DigitalParadoxCLI.Tests
{
    public class UtilityTests
    {
        
        [Fact]
        public void InShouldReturnTrueWhenArgsContainsMatchingValue()
        {
            var result_string = "foo".In("foo", "bar", "hello", "world");
            Assert.True(result_string);

            var result_int = 77.In(0, 100, 77, 1098, -85);
            Assert.True(result_int);

        }

        [Fact]
        public void InShouldReturnFalseWhenArgsNotContainsMatchingValue()
        {
            var result_string = "foo".In("bar", "hello", "world");
            Assert.False(result_string);

            var result_int = 77.In(0, 100, 1098, -85);
            Assert.False(result_int);

        }



        [Theory]
        //matches any values that contain "foo"
        [InlineData("%foo%", "foobar", true)]
        [InlineData("%hello%", "foobar", false)]
        
        //matches ends with 
        [InlineData("%bar", "foobar", true)]
        [InlineData("%bars", "foobar", false)]

        //matches starts with 
        [InlineData("foo%", "foobar", true)]
        [InlineData("hello%", "foobar", false)]

        //matches second letter 
        [InlineData("_o%", "foobar", true)]
        [InlineData("_b%", "foobar", false)]

        //matches 1st letter and is min 3 chars long 
        [InlineData("f_%_%", "foobar", true)]
        [InlineData("a_%_%", "foobar", false)]


        public void LikeExtensionCorrectlyResolves(string test, string data, bool shouldMatch)
        {
            //arrange 
               
            //act 
            var result = CompareExtensions.Like(data, test);
            //assert 

            Assert.Equal(result, shouldMatch);
        }



    }
}
