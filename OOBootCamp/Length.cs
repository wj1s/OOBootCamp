namespace OOBootCamp
{
    public class Length
    {
        public int Value { get; set; }

        public Length(int value, Unit unit)
        {
            Value = value;
        }

        public override bool Equals(object obj)
        {
            var length = (Length)obj;
            return Value == length.Value;
        }
    }
}