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
            CanStore = true;
        }

        public bool CanStore { get; set; }

        public Ticket Store(Bag bag)
        {
            if (!CanStore) throw new LockerFullException();
            var ticket = new Ticket();
            maps.Add(ticket, bag);
            if (maps.Count == capacity) CanStore = false;
            return ticket;
        }

        public Bag Pick(Ticket ticket)
        {
            if (ticket == null || !maps.ContainsKey(ticket))
            {
                return null;
            }
            var pick = maps[ticket];
            maps.Remove(ticket);
            return pick;
        }
    }
}