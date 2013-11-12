using System.Linq;

namespace Lotus
{
    public class Robot
    {
        protected readonly Locker[] Lockers;

        public Robot(Locker[] lockers)
        {
            Lockers = lockers;
        }

        public Ticket Store(Bag bag)
        {
            if(Lockers == null || Lockers.Length ==0)
                throw new ZeroLockerException();
            if (Lockers.All(locker => !locker.CanStore)) throw new LockerFullException();
            
            return Lockers.First(locker => locker.CanStore).Store(bag);
        }

        public Bag Pick(Ticket ticket)
        {
            return Lockers.Select(locker => locker.Pick(ticket)).FirstOrDefault(bag => bag != null);
        }
    }
}