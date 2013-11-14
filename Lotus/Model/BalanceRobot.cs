using System.Linq;
using Lotus.Exceptions;

namespace Lotus.Model
{
    public class BalanceRobot : Robot
    {
        public BalanceRobot(Locker[] lockers) : base(lockers)
        {
            
        }

        public new Ticket Store(Bag bag)
        {
            if (Lockers == null || Lockers.Length == 0)
                throw new ZeroLockerException();

            return Lockers.OrderByDescending(l => l.Balance).First().Store(bag);
        }
    }
}