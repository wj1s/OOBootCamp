using System.Linq;

namespace Lotus.Model
{
    public class FIFOLockerFinder : ILockerFinder
    {
        public Locker FindLocker(Locker[] lockers)
        {
            return lockers.First(locker => locker.GetCanStore());
        }
    }
}