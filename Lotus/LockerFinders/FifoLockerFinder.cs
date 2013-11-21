using System.Linq;
using Lotus.Model;

namespace Lotus.LockerFinders
{
    public class FifoLockerFinder : ILockerFinder
    {
        public Locker FindLocker(Locker[] lockers)
        {
            return lockers.First(locker => locker.GetCanStore());
        }
    }
}