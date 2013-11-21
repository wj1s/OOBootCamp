using Lotus.Model;

namespace Lotus.LockerFinders
{
    public interface ILockerFinder
    {
        Locker FindLocker(Locker[] lockers);
    }
}