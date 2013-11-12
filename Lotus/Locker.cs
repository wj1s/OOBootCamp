using System.Collections.Generic;

namespace Lotus
{
    public class Locker
    {
        private readonly int capacity;
        private readonly IDictionary<Ticket, Bag> maps = new Dictionary<Ticket, Bag>();

        public Locker(int capacity)
        {
            this.capacity = capacity;
        }

        public bool CanStore
        {
            get { return EmptyCount > 0; }
        }

        public int EmptyCount
        {
            get { return capacity - maps.Count; }
        }

        public double Balance
        {
            get
            {
                return (double)EmptyCount/capacity;
            }
        }

        public Ticket Store(Bag bag)
        {
            if (!CanStore) throw new LockerFullException();
            var ticket = new Ticket();
            maps.Add(ticket, bag);
            return ticket;
        }

        public Bag Pick(Ticket ticket)
        {
            if (ticket == null || !maps.ContainsKey(ticket))
            {
                return null;
            }
            Bag pick = maps[ticket];
            maps.Remove(ticket);
            return pick;
        }
    }
}