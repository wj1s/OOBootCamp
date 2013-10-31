using Xunit;

namespace OOBootCamp
{
    public class LengthFact
    {
        [Fact]
        public void should_length_equal()
        {
            Assert.Equal(new Length(1, LengthUnit.M), new Length(1, LengthUnit.M));
            Assert.Equal(new Length(100, LengthUnit.CM), new Length(100, LengthUnit.CM));
            Assert.Equal(new Length(10, LengthUnit.MM), new Length(10, LengthUnit.MM));
            Assert.NotEqual(new Length(10, LengthUnit.MM), new Length(10, LengthUnit.M));
        }

        [Fact]
        public void should_length_equal_with_different_unit()
        {
            Assert.Equal(new Length(1, LengthUnit.M), new Length(100, LengthUnit.CM));
            Assert.Equal(new Length(1, LengthUnit.M), new Length(1000, LengthUnit.MM));
            Assert.Equal(new Length(1, LengthUnit.CM), new Length(10, LengthUnit.MM));
            Assert.Equal(new Length(10, LengthUnit.MM), new Length(1, LengthUnit.CM));
            Assert.Equal(new Length(1000, LengthUnit.MM), new Length(1, LengthUnit.M));
            Assert.Equal(new Length(100, LengthUnit.CM), new Length(1, LengthUnit.M));
        }
    }
}