using System.Linq;

namespace Lotus.Model
{
    public class SmartLockerFinder : ILockerFinder
    {
        public Locker FindLocker(Locker[] lockers)
        {
            return lockers.OrderByDescending(l => l.GetEmptyCount()).First();
        }
    }
}