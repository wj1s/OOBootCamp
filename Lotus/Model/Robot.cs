using System.Linq;
using Lotus.Exceptions;

namespace Lotus.Model
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
            if (Lockers.All(locker => !locker.GetCanStore())) throw new LockerFullException();
            
            return Lockers.First(locker => locker.GetCanStore()).Store(bag);
        }

        public Bag Pick(Ticket ticket)
        {
            return Lockers.Select(locker => locker.Pick(ticket)).FirstOrDefault(bag => bag != null);
        }
    }
}