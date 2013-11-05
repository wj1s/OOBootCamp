namespace Lotus
{
    public class Locker
    {
        private int capacity;
        private int count;
        private Bag bag;
        private Ticket ticket;

        public Locker(int capacity)
        {
            this.capacity = capacity;
        }

        public Ticket Store(Bag bag)
        {
            if (count >= capacity) throw new LockerFullException();
            
            count++;
            this.bag = bag;
            ticket = new Ticket();
            return ticket;
        }

        public Bag Pick(Ticket ticket)
        {
            return ticket.Equals(this.ticket) ? bag : null;
        }
    }
}