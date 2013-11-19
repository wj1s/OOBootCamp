using System.Linq;
using Lotus.Model;

namespace Lotus.LockerFinders
{
    public class FIFOLockerFinder : ILockerFinder
    {
        public Locker FindLocker(Locker[] lockers)
        {
            return lockers.First(locker => locker.GetCanStore());
        }
    }
}