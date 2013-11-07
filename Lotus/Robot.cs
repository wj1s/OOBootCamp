using System.Linq;

namespace Lotus
{
    public class Robot
    {
        private readonly Locker[] lockers;

        public Robot(Locker[] lockers)
        {
            this.lockers = lockers;
        }

        public Ticket Store(Bag bag)
        {
            if (lockers.All(locker => !locker.CanStore)) throw new LockerFullException();
            return lockers.First(locker => locker.CanStore).Store(bag);
        }

        public Bag Pick(Ticket ticket)
        {
            return lockers.Select(locker => locker.Pick(ticket)).FirstOrDefault(bag => bag != null);
        }
    }
}