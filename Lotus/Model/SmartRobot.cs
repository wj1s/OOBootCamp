using System.Linq;
using Lotus.Exceptions;

namespace Lotus.Model
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

            return Lockers.OrderByDescending(l => l.GetEmptyCount()).First().Store(bag);
        }
    }
}