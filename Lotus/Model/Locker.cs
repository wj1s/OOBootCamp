using System.Collections.Generic;
using Lotus.Exceptions;

namespace Lotus.Model
{
    public class Locker
    {
        private readonly int capacity;
        private readonly IDictionary<Ticket, Bag> maps = new Dictionary<Ticket, Bag>();

        public Locker(int capacity)
        {
            this.capacity = capacity;
        }

        public bool GetCanStore()
        {
            return GetEmptyCount() > 0;
        }

        public int GetEmptyCount()
        {
            return capacity - maps.Count;
        }

        public double GetBalance()
        {
            return (double) GetEmptyCount()/capacity;
        }

        public Ticket Store(Bag bag)
        {
            if (!GetCanStore()) throw new LockerFullException();
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