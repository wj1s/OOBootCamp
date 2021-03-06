﻿namespace OOBootCamp
{
    public class Length
    {
        public Length(int value, LengthUnit lengthUnit)
        {
            Value = value;
            Unit = lengthUnit;
        }

        private int Value { get; set; }

        private LengthUnit Unit { get; set; }

        public override bool Equals(object obj)
        {
            var target = (Length) obj;
            return Unit.ConverTo(target.Unit, Value) == target.Value;
        }
    }
}