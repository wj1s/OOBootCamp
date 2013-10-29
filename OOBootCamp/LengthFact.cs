using Xunit;

namespace OOBootCamp
{
    public class LengthFact
    {
        [Fact]
        public void should_length_equal()
        {
            Assert.Equal(new Length(1, Unit.M), new Length(1, Unit.M));
            Assert.Equal(new Length(100, Unit.CM), new Length(100, Unit.CM));
            Assert.Equal(new Length(10, Unit.MM), new Length(10, Unit.MM));
        }
    }

    public enum Unit
    {
        CM,
        M,
        MM
    }
}