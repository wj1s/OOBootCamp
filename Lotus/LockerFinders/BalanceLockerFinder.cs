using System.Linq;
using Lotus.Model;

namespace Lotus.LockerFinders
{
    public class BalanceLockerFinder : ILockerFinder
    {
        public Locker FindLocker(Locker[] lockers)
        {
            return lockers.OrderByDescending(l => l.GetBalance()).First();
        }
    }
}