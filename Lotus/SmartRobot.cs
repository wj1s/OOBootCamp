using System.Linq;

namespace Lotus
{
    public class SmartRobot : Robot
    {
        public SmartRobot(Locker[] lockers) : base(lockers)
        {
        }

        public new Ticket Store(Bag bag)
        {
            if (Lockers == null || Lockers.Length == 0)
                throw new ZeroLockerException();

            return Lockers.OrderByDescending(l => l.EmptyCount).First().Store(bag);
        }
    }
}