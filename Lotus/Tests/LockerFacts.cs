using Lotus.Exceptions;
using Lotus.Model;
using Xunit;

namespace Lotus.Tests
{
    public class LockerFacts
    {
        [Fact]
        public void should_store_one_bag()
        {
            var locker = new Locker(1);
            var bag = new Bag();
            var ticket = locker.Store(bag);
            Assert.NotNull(ticket);
        }

        [Fact]
        public void should_not_store_when_locker_full()
        {
            var locker = new Locker(1);
            locker.Store(new Bag());
            Assert.Throws<LockerFullException>(() => locker.Store(new Bag()));
        }

        [Fact]
        public void should_store_multiple_bags()
        {
            var locker = new Locker(4);
            var ticket = locker.Store(new Bag());
            var ticket2 = locker.Store(new Bag());
            Assert.NotNull(ticket);
            Assert.NotNull(ticket2);
            Assert.NotEqual(ticket,ticket2);
        }

        [Fact]
        public void should_pick_when_store_bag()
        {
            var locker = new Locker(4);
            var bag = new Bag();
            var ticket = locker.Store(bag);
            Assert.Same(bag, locker.Pick(ticket));
        }
        
        [Fact]
        public void should_not_repick()
        {
            var locker = new Locker(4);
            var bag = new Bag();
            var ticket = locker.Store(bag);
            locker.Pick(ticket);
            Assert.Null(locker.Pick(ticket));
        }

        [Fact]
        public void should_not_pick_when_ticket_wrong()
        {
            var locker = new Locker(4);
            Assert.Null(locker.Pick(new Ticket()));
        }
        
        [Fact]
        public void should_not_pick_when_ticket_wrong1()
        {
            var locker = new Locker(4);
            Assert.Null(locker.Pick(null));
        }

        [Fact]
        public void should_pick_among_mulitple_bags()
        {
            var locker = new Locker(4);
            var bag = new Bag();
            var ticket = locker.Store(bag);
            locker.Store(new Bag());
            Assert.Same(bag, locker.Pick(ticket));
        }
    }
}