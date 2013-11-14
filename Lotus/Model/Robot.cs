using System.Linq;
using Lotus.Exceptions;
using Lotus.LockerFinders;

namespace Lotus.Model
{
    public class Robot
    {
        protected readonly Locker[] Lockers;
        private readonly ILockerFinder fifoLockerFinder;

        private readonly ILockerFinder lockerFinder;

        private Robot(Locker[] lockers, ILockerFinder lockerFinder)
        {
            Lockers = lockers;
            this.lockerFinder = lockerFinder;
        }

        public Ticket Store(Bag bag)
        {
            if(Lockers == null || Lockers.Length ==0)
                throw new ZeroLockerException();
            if (Lockers.All(locker => !locker.GetCanStore())) throw new LockerFullException();
            return lockerFinder.FindLocker(Lockers).Store(bag);
        }

        public Bag Pick(Ticket ticket)
        {
            return Lockers.Select(locker => locker.Pick(ticket)).FirstOrDefault(bag => bag != null);
        }

        public static Robot CreateFifoRobot(Locker[] lockers)
        {
            return new Robot(lockers, new FifoLockerFinder());
        }

        public static Robot CreateBalanceRobot(Locker[] lockers)
        {
            return new Robot(lockers, new BalanceLockerFinder());
        }

        public static Robot CreateSmartRobot(Locker[] lockers)
        {
            return new Robot(lockers, new SmartLockerFinder());
        }
    }
}