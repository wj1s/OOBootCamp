using System.Linq;

namespace Lotus.Model
{
    public class BalanceLockerFinder: ILockerFinder
    {
        public Locker FindLocker(Locker[] lockers)
        {
            return lockers.OrderByDescending(l => l.GetBalance()).First();
        }
    }
}