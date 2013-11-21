using System.Linq;
using Lotus.Model;

namespace Lotus.LockerFinders
{
    public class SmartLockerFinder : ILockerFinder
    {
        public Locker FindLocker(Locker[] lockers)
        {
            return lockers.OrderByDescending(l => l.GetEmptyCount()).First();
        }
    }
}