namespace OOBootCamp
{
    public class LengthUnit
    {
        public readonly static LengthUnit MM = new LengthUnit(1);
        public readonly static LengthUnit CM = new LengthUnit(10);
        public readonly static LengthUnit M = new LengthUnit(1000);
        
        public LengthUnit(double factor)
        {
            Factor = factor;
        }

        public double Factor { get; private set; }
    }
}